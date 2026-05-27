namespace shop;

using System.Text;

/// <summary>
/// Форма аналітики зі звітами продажів і популярністю товарів.
/// </summary>
public sealed partial class ReportsForm : Form
{
    private readonly ShopStore store;
    private List<Sale> currentSales = [];
    private decimal currentReturnedAmount;
    private decimal currentIncome;

    /// <summary>Створює форму звітів для попереднього перегляду в конструкторі Visual Studio.</summary>
    public ReportsForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, buildButton);
    }

    /// <summary>Створює форму звітів.</summary>
    public ReportsForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, buildButton);
        periodComboBox.SelectedIndex = 0;
        BuildReport();
    }

    private void PeriodComboBox_SelectedIndexChanged(object? sender, EventArgs e) => BuildReport();

    private void BuildButton_Click(object? sender, EventArgs e)
    {
        BuildReport();
        SaveReportToFile();
    }

    private void BuildReport()
    {
        var (from, to) = GetPeriod();
        currentSales = store.GetSales(from, to).ToList();
        currentReturnedAmount = store.Data.Returns.Where(item => item.Date >= from && item.Date <= to).Sum(item => item.Amount);
        currentIncome = currentSales.Sum(sale => sale.Total) - currentReturnedAmount;
        incomeLabel.Text = $"Продажів: {currentSales.Count}; дохід з урахуванням повернень: {currentIncome:0.00} грн";

        salesGridView.DataSource = currentSales.Select(sale => new
        {
            sale.ReceiptNumber,
            sale.Date,
            sale.CashierLogin,
            sale.Total
        }).ToList();

        popularGridView.DataSource = currentSales.SelectMany(sale => sale.Items)
            .GroupBy(item => item.ProductName)
            .Select(group => new
            {
                Product = group.Key,
                Quantity = group.Sum(item => item.Quantity),
                Income = group.Sum(item => item.Total)
            })
            .OrderByDescending(item => item.Quantity)
            .ToList();

        var soldIds = currentSales.SelectMany(sale => sale.Items).Select(item => item.ProductId).Distinct().ToHashSet();
        unsoldGridView.DataSource = store.Data.Products
            .Where(product => !soldIds.Contains(product.Id))
            .Select(product => new
            {
                product.Name,
                product.Supplier,
                product.Quantity,
                product.UnitPrice,
                product.LastSaleDate
            })
            .ToList();
    }

    private (DateTime From, DateTime To) GetPeriod()
    {
        var now = DateTime.Now;
        var from = periodComboBox.SelectedIndex switch
        {
            0 => now.Date,
            1 => now.Date.AddDays(-6),
            2 => now.Date.AddMonths(-1),
            _ => DateTime.MinValue
        };
        return (from, now);
    }

    private void SaveReportToFile()
    {
        using var dialog = new SaveFileDialog
        {
            Filter = "Текстовий файл (*.txt)|*.txt",
            FileName = $"sales-report-{DateTime.Now:yyyy-MM-dd}.txt",
            Title = "Зберегти звіт"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        File.WriteAllText(dialog.FileName, BuildReportText(), Encoding.UTF8);
        MessageBox.Show("Звіт збережено.", "Звіти", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private string BuildReportText()
    {
        var builder = new StringBuilder();
        builder.AppendLine("ЗВІТ ПО ПРОДАЖАХ");
        builder.AppendLine($"Період: {periodComboBox.Text}");
        builder.AppendLine($"Дата формування: {DateTime.Now:dd.MM.yyyy HH:mm}");
        builder.AppendLine();
        builder.AppendLine($"Кількість чеків: {currentSales.Count}");
        builder.AppendLine($"Сума продажів: {currentSales.Sum(sale => sale.Total):0.00} грн");
        builder.AppendLine($"Сума повернень: {currentReturnedAmount:0.00} грн");
        builder.AppendLine($"Загальний дохід: {currentIncome:0.00} грн");
        builder.AppendLine();
        builder.AppendLine("Продажі:");

        foreach (var sale in currentSales.OrderBy(sale => sale.Date))
        {
            builder.AppendLine($"Чек N {sale.ReceiptNumber}, {sale.Date:dd.MM.yyyy HH:mm}, касир {sale.CashierLogin}, сума {sale.Total:0.00} грн");
            foreach (var item in sale.Items)
            {
                builder.AppendLine($"  {item.ProductName}: {item.Quantity:0.###} {item.Unit} x {item.UnitPrice:0.00}, знижка {item.DiscountPercent:0.##}%, разом {item.Total:0.00} грн");
            }
        }

        builder.AppendLine();
        builder.AppendLine("Найпопулярніші товари:");
        foreach (var item in currentSales.SelectMany(sale => sale.Items)
                     .GroupBy(item => item.ProductName)
                     .Select(group => new { Product = group.Key, Quantity = group.Sum(item => item.Quantity), Income = group.Sum(item => item.Total) })
                     .OrderByDescending(item => item.Quantity))
        {
            builder.AppendLine($"{item.Product}: {item.Quantity:0.###}, дохід {item.Income:0.00} грн");
        }

        builder.AppendLine();
        builder.AppendLine("Товари, що не продаються у вибраному періоді:");
        var soldIds = currentSales.SelectMany(sale => sale.Items).Select(item => item.ProductId).Distinct().ToHashSet();
        foreach (var product in store.Data.Products.Where(product => !soldIds.Contains(product.Id)).OrderBy(product => product.Name))
        {
            builder.AppendLine($"{product.Name}, постачальник {product.Supplier}: залишок {product.Quantity:0.###} {product.Unit}, ціна {product.UnitPrice:0.00} грн");
        }

        return builder.ToString();
    }
}

