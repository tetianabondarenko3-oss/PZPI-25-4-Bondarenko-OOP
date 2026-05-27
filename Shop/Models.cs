using System.ComponentModel;

namespace shop;

/// <summary>
/// Роль, яка визначає доступні користувачу операції програми.
/// </summary>
public enum UserRole
{
    Admin,
    Cashier
}

/// <summary>
/// Описує користувача програми, який може працювати адміністратором або касиром.
/// </summary>
public sealed class AppUser
{
    /// <summary>Унікальний ідентифікатор користувача.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Логін користувача.</summary>
    public string Login { get; set; } = "";

    /// <summary>Ім'я користувача для відображення.</summary>
    public string FullName { get; set; } = "";

    /// <summary>Пароль користувача, збережений для локального файлового варіанта курсової роботи.</summary>
    public string Password { get; set; } = "";

    /// <summary>Роль користувача.</summary>
    public UserRole Role { get; set; } = UserRole.Cashier;
}

/// <summary>
/// Представляє товар, наявний у магазині.
/// </summary>
public sealed class Product
{
    /// <summary>Унікальний ідентифікатор товару.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Найменування товару.</summary>
    public string Name { get; set; } = "";

    /// <summary>Одиниця виміру, наприклад шт., кг, пляшка.</summary>
    public string Unit { get; set; } = "шт.";

    /// <summary>Назва постачальника останнього зареєстрованого надходження.</summary>
    public string Supplier { get; set; } = "";

    /// <summary>Ціна одиниці.</summary>
    public decimal UnitPrice { get; set; }

    /// <summary>Поточна кількість на складі.</summary>
    public decimal Quantity { get; set; }

    /// <summary>Дата останнього завезення товару.</summary>
    public DateTime LastDeliveryDate { get; set; } = DateTime.Today;

    /// <summary>Дата останнього продажу. Порожнє значення означає, що товар ще не продавався.</summary>
    public DateTime? LastSaleDate { get; set; }

    /// <summary>Необов'язкова відсоткова знижка на цей товар.</summary>
    public decimal DiscountPercent { get; set; }
}

/// <summary>
/// Описує одну позицію в чеку продажу.
/// </summary>
public sealed class SaleItem
{
    /// <summary>Ідентифікатор проданого товару.</summary>
    public Guid ProductId { get; set; }

    /// <summary>Найменування товару, збережене для історії.</summary>
    public string ProductName { get; set; } = "";

    /// <summary>Одиниця виміру, збережена для історії.</summary>
    public string Unit { get; set; } = "";

    /// <summary>Продана кількість.</summary>
    public decimal Quantity { get; set; }

    /// <summary>Ціна до застосування знижок.</summary>
    public decimal UnitPrice { get; set; }

    /// <summary>Знижка, застосована до позиції продажу.</summary>
    public decimal DiscountPercent { get; set; }

    /// <summary>Підсумкова сума за позицію.</summary>
    public decimal Total => Math.Round(Quantity * UnitPrice * (1 - DiscountPercent / 100m), 2);
}

/// <summary>
/// Представляє оформлений чек продажу.
/// </summary>
public sealed class Sale
{
    /// <summary>Унікальний ідентифікатор продажу.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Номер чека, який показується покупцю.</summary>
    public int ReceiptNumber { get; set; }

    /// <summary>Дата і час продажу.</summary>
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>Логін касира, який оформив продаж.</summary>
    public string CashierLogin { get; set; } = "";

    /// <summary>Продані позиції.</summary>
    public BindingList<SaleItem> Items { get; set; } = [];

    /// <summary>Загальна сума чека.</summary>
    public decimal Total => Items.Sum(item => item.Total);
}

/// <summary>
/// Описує одну операцію надходження товару.
/// </summary>
public sealed class SupplyRecord
{
    /// <summary>Ідентифікатор надходження.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Ідентифікатор товару.</summary>
    public Guid ProductId { get; set; }

    /// <summary>Найменування товару, збережене для історії.</summary>
    public string ProductName { get; set; } = "";

    /// <summary>Постачальник, який доставив товар.</summary>
    public string Supplier { get; set; } = "";

    /// <summary>Кількість, що надійшла.</summary>
    public decimal Quantity { get; set; }

    /// <summary>Ціна одиниці після реєстрації надходження.</summary>
    public decimal UnitPrice { get; set; }

    /// <summary>Дата надходження.</summary>
    public DateTime Date { get; set; } = DateTime.Today;
}

/// <summary>
/// Тип операції коригування залишків.
/// </summary>
public enum StockCorrectionType
{
    Markdown,
    WriteOff
}

/// <summary>
/// Зберігає операцію уцінки або списання.
/// </summary>
public sealed class StockCorrection
{
    /// <summary>Ідентифікатор коригування.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Ідентифікатор товару.</summary>
    public Guid ProductId { get; set; }

    /// <summary>Найменування товару, збережене для історії.</summary>
    public string ProductName { get; set; } = "";

    /// <summary>Тип коригування.</summary>
    public StockCorrectionType Type { get; set; }

    /// <summary>Попередня ціна товару.</summary>
    public decimal OldPrice { get; set; }

    /// <summary>Нова ціна товару для операцій уцінки.</summary>
    public decimal? NewPrice { get; set; }

    /// <summary>Списана кількість.</summary>
    public decimal? Quantity { get; set; }

    /// <summary>Причина коригування.</summary>
    public string Reason { get; set; } = "";

    /// <summary>Дата операції.</summary>
    public DateTime Date { get; set; } = DateTime.Now;
}

/// <summary>
/// Описує операцію повернення товару.
/// </summary>
public sealed class ReturnRecord
{
    /// <summary>Ідентифікатор повернення.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Номер чека, за яким оформлюється повернення.</summary>
    public int ReceiptNumber { get; set; }

    /// <summary>Ідентифікатор товару.</summary>
    public Guid ProductId { get; set; }

    /// <summary>Найменування товару, збережене для історії.</summary>
    public string ProductName { get; set; } = "";

    /// <summary>Повернена кількість.</summary>
    public decimal Quantity { get; set; }

    /// <summary>Сума коштів за повернення.</summary>
    public decimal Amount { get; set; }

    /// <summary>Причина повернення.</summary>
    public string Reason { get; set; } = "";

    /// <summary>Дата повернення.</summary>
    public DateTime Date { get; set; } = DateTime.Now;
}

/// <summary>
/// Кореневий об'єкт, який серіалізується у JSON.
/// </summary>
public sealed class ShopData
{
    /// <summary>Колекція товарів.</summary>
    public BindingList<Product> Products { get; set; } = [];

    /// <summary>Колекція продажів.</summary>
    public BindingList<Sale> Sales { get; set; } = [];

    /// <summary>Історія надходжень.</summary>
    public BindingList<SupplyRecord> Supplies { get; set; } = [];

    /// <summary>Історія уцінок і списань.</summary>
    public BindingList<StockCorrection> Corrections { get; set; } = [];

    /// <summary>Історія повернень.</summary>
    public BindingList<ReturnRecord> Returns { get; set; } = [];

    /// <summary>Користувачі, які можуть увійти до програми.</summary>
    public BindingList<AppUser> Users { get; set; } = [];

    /// <summary>Наступний номер чека.</summary>
    public int NextReceiptNumber { get; set; } = 1;
}

