namespace shop;

/// <summary>
/// Форма інвентаризації, яка показує залишки товарів та їх загальну вартість.
/// </summary>
public sealed partial class InventoryForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює форму інвентаризації для попереднього перегляду в конструкторі Visual Studio.</summary>
    public InventoryForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, refreshButton);
    }

    /// <summary>Створює форму інвентаризації.</summary>
    public InventoryForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, refreshButton);
        RefreshGrid();
    }

    private void RefreshButton_Click(object? sender, EventArgs e) => RefreshGrid();

    private void RefreshGrid()
    {
        var rows = store.Data.Products
            .OrderBy(product => product.Name)
            .Select(product => new
            {
                product.Name,
                product.Unit,
                product.Supplier,
                product.Quantity,
                product.UnitPrice,
                Sum = product.Quantity * product.UnitPrice,
                product.LastDeliveryDate
            })
            .ToList();
        inventoryGridView.DataSource = rows;
        totalLabel.Text = $"Сумарна вартість залишків: {rows.Sum(row => row.Sum):0.00} грн";
    }
}

