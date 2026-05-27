using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace shop;

/// <summary>
/// Забезпечує завантаження, збереження, резервне копіювання та бізнес-операції магазину.
/// </summary>
public sealed class ShopStore
{
    private readonly JsonSerializerOptions jsonOptions = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>Шлях до файлу даних програми.</summary>
    public string DataFilePath { get; }

    /// <summary>Поточні дані магазину.</summary>
    public ShopData Data { get; private set; } = new();

    /// <summary>Поточний авторизований користувач.</summary>
    public AppUser? CurrentUser { get; private set; }

    /// <summary>Створює сховище та налаштовує розташування JSON-файлу.</summary>
    public ShopStore()
    {
        var folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CourseShop");
        Directory.CreateDirectory(folder);
        DataFilePath = Path.Combine(folder, "shop-data.json");
    }

    /// <summary>Завантажує дані з JSON або створює початкові дані для першого запуску.</summary>
    public void Load()
    {
        if (File.Exists(DataFilePath))
        {
            var json = File.ReadAllText(DataFilePath, Encoding.UTF8);
            Data = JsonSerializer.Deserialize<ShopData>(json, jsonOptions) ?? new ShopData();
        }

        EnsureInitialData();
    }

    /// <summary>Зберігає всі дані програми у JSON-файл.</summary>
    public void Save()
    {
        var json = JsonSerializer.Serialize(Data, jsonOptions);
        File.WriteAllText(DataFilePath, json, Encoding.UTF8);
    }

    /// <summary>Створює резервну копію JSON-бази даних із позначкою часу.</summary>
    public string CreateBackup()
    {
        Save();
        var backupFolder = Path.Combine(Path.GetDirectoryName(DataFilePath)!, "Backups");
        Directory.CreateDirectory(backupFolder);
        var backupPath = Path.Combine(backupFolder, $"shop-data-{DateTime.Now:yyyyMMdd-HHmmss}.json");
        File.Copy(DataFilePath, backupPath, overwrite: false);
        return backupPath;
    }

    /// <summary>Авторизує користувача за логіном і паролем.</summary>
    public bool Login(string login, string password)
    {
        CurrentUser = Data.Users.FirstOrDefault(user =>
            string.Equals(user.Login, login.Trim(), StringComparison.OrdinalIgnoreCase)
            && user.Password == password);
        return CurrentUser is not null;
    }

    /// <summary>Реєструє надходження товару і створює товар, якщо найменування нове.</summary>
    public Product RegisterSupply(string name, string unit, string supplier, decimal price, decimal quantity, DateTime date)
    {
        ValidateText(name, "Найменування");
        ValidateText(unit, "Одиниця виміру");
        ValidateText(supplier, "Постачальник");
        ValidatePositive(price, "Ціна");
        ValidatePositive(quantity, "Кількість");

        var product = Data.Products.FirstOrDefault(item =>
            string.Equals(item.Name.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));

        if (product is null)
        {
            product = new Product { Name = name.Trim(), Unit = unit.Trim() };
            Data.Products.Add(product);
        }

        product.Unit = unit.Trim();
        product.Supplier = supplier.Trim();
        product.UnitPrice = price;
        product.Quantity += quantity;
        product.LastDeliveryDate = date.Date;

        Data.Supplies.Add(new SupplyRecord
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Supplier = supplier.Trim(),
            Quantity = quantity,
            UnitPrice = price,
            Date = date.Date
        });
        Save();
        return product;
    }

    /// <summary>Оновлює основну інформацію про товар.</summary>
    public void UpdateProduct(Product product, string name, string unit, string supplier, decimal price, decimal quantity, DateTime lastDelivery, decimal discount)
    {
        ValidateText(name, "Найменування");
        ValidateText(unit, "Одиниця виміру");
        ValidateText(supplier, "Постачальник");
        ValidateNonNegative(price, "Ціна");
        ValidateNonNegative(quantity, "Кількість");
        ValidatePercent(discount, "Знижка");

        var duplicate = Data.Products.Any(item =>
            item.Id != product.Id
            && string.Equals(item.Name.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));
        if (duplicate)
        {
            throw new InvalidOperationException("Товар з таким найменуванням вже існує.");
        }

        product.Name = name.Trim();
        product.Unit = unit.Trim();
        product.Supplier = supplier.Trim();
        product.UnitPrice = price;
        product.Quantity = quantity;
        product.LastDeliveryDate = lastDelivery.Date;
        product.DiscountPercent = discount;
        Save();
    }

    /// <summary>Видаляє товар із поточного списку залишків.</summary>
    public void DeleteProduct(Product product)
    {
        Data.Products.Remove(product);
        Save();
    }

    /// <summary>Оформлює продаж, зменшує залишки та повертає текст чека.</summary>
    public string CompleteSale(IEnumerable<SaleItem> items, string cashierLogin)
    {
        var saleItems = items.ToList();
        if (saleItems.Count == 0)
        {
            throw new InvalidOperationException("Додайте хоча б один товар до чека.");
        }

        foreach (var item in saleItems)
        {
            var product = GetProduct(item.ProductId);
            ValidatePositive(item.Quantity, $"Кількість для {product.Name}");
            if (item.Quantity > product.Quantity)
            {
                throw new InvalidOperationException($"Недостатньо товару \"{product.Name}\" на складі.");
            }
        }

        foreach (var item in saleItems)
        {
            var product = GetProduct(item.ProductId);
            product.Quantity -= item.Quantity;
            product.LastSaleDate = DateTime.Now;
        }

        var sale = new Sale
        {
            ReceiptNumber = Data.NextReceiptNumber++,
            Date = DateTime.Now,
            CashierLogin = cashierLogin,
            Items = new BindingList<SaleItem>(saleItems)
        };
        Data.Sales.Add(sale);
        Save();
        return BuildReceipt(sale);
    }

    /// <summary>Застосовує уцінку до ціни товару.</summary>
    public void ApplyMarkdown(Product product, decimal newPrice, string reason)
    {
        ValidateNonNegative(newPrice, "Нова ціна");
        ValidateText(reason, "Причина");
        if (newPrice >= product.UnitPrice)
        {
            throw new InvalidOperationException("Нова ціна для уцінки має бути меншою за поточну.");
        }

        var oldPrice = product.UnitPrice;
        product.UnitPrice = newPrice;
        Data.Corrections.Add(new StockCorrection
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Type = StockCorrectionType.Markdown,
            OldPrice = oldPrice,
            NewPrice = newPrice,
            Reason = reason.Trim()
        });
        Save();
    }

    /// <summary>Списує пошкоджену або прострочену кількість товару.</summary>
    public void WriteOff(Product product, decimal quantity, string reason)
    {
        ValidatePositive(quantity, "Кількість");
        ValidateText(reason, "Причина");
        if (quantity > product.Quantity)
        {
            throw new InvalidOperationException("Не можна списати більше, ніж є у залишку.");
        }

        product.Quantity -= quantity;
        Data.Corrections.Add(new StockCorrection
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Type = StockCorrectionType.WriteOff,
            OldPrice = product.UnitPrice,
            Quantity = quantity,
            Reason = reason.Trim()
        });
        Save();
    }

    /// <summary>Реєструє повернення товару та відновлює залишок.</summary>
    public void RegisterReturn(int receiptNumber, Guid productId, decimal quantity, string reason)
    {
        ValidatePositive(quantity, "Кількість повернення");
        ValidateText(reason, "Причина");

        var sale = Data.Sales.FirstOrDefault(item => item.ReceiptNumber == receiptNumber)
            ?? throw new InvalidOperationException("Чек з таким номером не знайдено.");
        var saleItem = sale.Items.FirstOrDefault(item => item.ProductId == productId)
            ?? throw new InvalidOperationException("У цьому чеку немає обраного товару.");
        var alreadyReturned = Data.Returns
            .Where(item => item.ReceiptNumber == receiptNumber && item.ProductId == productId)
            .Sum(item => item.Quantity);
        if (alreadyReturned + quantity > saleItem.Quantity)
        {
            throw new InvalidOperationException("Кількість повернення перевищує продану кількість.");
        }

        var product = GetProduct(productId);
        product.Quantity += quantity;
        Data.Returns.Add(new ReturnRecord
        {
            ReceiptNumber = receiptNumber,
            ProductId = productId,
            ProductName = product.Name,
            Quantity = quantity,
            Amount = Math.Round(quantity * saleItem.UnitPrice * (1 - saleItem.DiscountPercent / 100m), 2),
            Reason = reason.Trim()
        });
        Save();
    }

    /// <summary>Повертає товар за ідентифікатором.</summary>
    public Product GetProduct(Guid productId)
    {
        return Data.Products.FirstOrDefault(product => product.Id == productId)
            ?? throw new InvalidOperationException("Товар не знайдено.");
    }

    /// <summary>Формує текст чека для друку за вибраним продажем.</summary>
    public static string BuildReceipt(Sale sale)
    {
        var builder = new StringBuilder();
        builder.AppendLine("МАГАЗИН");
        builder.AppendLine($"Чек N {sale.ReceiptNumber}");
        builder.AppendLine($"Дата: {sale.Date:dd.MM.yyyy HH:mm}");
        builder.AppendLine($"Касир: {sale.CashierLogin}");
        builder.AppendLine(new string('-', 42));
        foreach (var item in sale.Items)
        {
            builder.AppendLine($"{item.ProductName}");
            builder.AppendLine($"  {item.Quantity:0.###} {item.Unit} x {item.UnitPrice:0.00} грн, знижка {item.DiscountPercent:0.##}% = {item.Total:0.00} грн");
        }

        builder.AppendLine(new string('-', 42));
        builder.AppendLine($"Разом: {sale.Total:0.00} грн");
        return builder.ToString();
    }

    /// <summary>Повертає продажі, здійснені у вибраному періоді.</summary>
    public IEnumerable<Sale> GetSales(DateTime from, DateTime to)
    {
        return Data.Sales.Where(sale => sale.Date >= from && sale.Date <= to);
    }

    private void EnsureInitialData()
    {
        if (Data.Users.Count == 0)
        {
            Data.Users.Add(new AppUser { Login = "admin", Password = "admin", FullName = "Адміністратор", Role = UserRole.Admin });
            Data.Users.Add(new AppUser { Login = "cashier", Password = "cashier", FullName = "Касир", Role = UserRole.Cashier });
        }

        if (Data.Products.Count == 0)
        {
            Data.Products.Add(new Product { Name = "Клавіатура", Unit = "шт.", Supplier = "TechTrade", UnitPrice = 550m, Quantity = 12, LastDeliveryDate = DateTime.Today.AddDays(-7) });
            Data.Products.Add(new Product { Name = "Миша", Unit = "шт.", Supplier = "CompLine", UnitPrice = 320m, Quantity = 20, LastDeliveryDate = DateTime.Today.AddDays(-4), DiscountPercent = 5m });
            Data.Products.Add(new Product { Name = "USB-кабель", Unit = "шт.", Supplier = "CablePro", UnitPrice = 120m, Quantity = 35, LastDeliveryDate = DateTime.Today.AddDays(-10) });
        }

        Save();
    }

    private static void ValidateText(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Поле \"{fieldName}\" не може бути порожнім.");
        }
    }

    private static void ValidatePositive(decimal value, string fieldName)
    {
        if (value <= 0)
        {
            throw new InvalidOperationException($"Поле \"{fieldName}\" має бути більше нуля.");
        }
    }

    private static void ValidateNonNegative(decimal value, string fieldName)
    {
        if (value < 0)
        {
            throw new InvalidOperationException($"Поле \"{fieldName}\" не може бути від'ємним.");
        }
    }

    private static void ValidatePercent(decimal value, string fieldName)
    {
        if (value < 0 || value > 100)
        {
            throw new InvalidOperationException($"Поле \"{fieldName}\" має бути від 0 до 100.");
        }
    }
}

