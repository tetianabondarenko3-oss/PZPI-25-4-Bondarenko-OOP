namespace shop;

/// <summary>
/// Форма каталогу товарів з пошуком, редагуванням і видаленням.
/// </summary>
public sealed partial class ProductsForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює форму каталогу товарів для попереднього перегляду в конструкторі Visual Studio.</summary>
    public ProductsForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, refreshButton);
    }

    /// <summary>Створює форму каталогу товарів.</summary>
    public ProductsForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, refreshButton);
        RefreshGrid();
    }

    private void SearchTextBox_TextChanged(object? sender, EventArgs e) => RefreshGrid();

    private void RefreshButton_Click(object? sender, EventArgs e) => RefreshGrid();

    private void EditButton_Click(object? sender, EventArgs e)
    {
        if (productsGridView.CurrentRow?.DataBoundItem is not ProductView view)
        {
            return;
        }

        using var dialog = new ProductEditForm(store, store.GetProduct(view.Id));
        dialog.ShowDialog(this);
        RefreshGrid();
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        if (productsGridView.CurrentRow?.DataBoundItem is not ProductView view
            || !FormHelpers.Confirm($"Видалити товар \"{view.Name}\"?"))
        {
            return;
        }

        store.DeleteProduct(store.GetProduct(view.Id));
        RefreshGrid();
    }

    private void RefreshGrid()
    {
        var term = searchTextBox.Text.Trim();
        productsGridView.DataSource = store.Data.Products
            .Where(product => string.IsNullOrWhiteSpace(term)
                || product.Name.Contains(term, StringComparison.OrdinalIgnoreCase)
                || product.Unit.Contains(term, StringComparison.OrdinalIgnoreCase))
            .Select(product => new ProductView(product))
            .ToList();
    }

    private sealed class ProductView
    {
        public ProductView(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Unit = product.Unit;
            Supplier = product.Supplier;
            UnitPrice = product.UnitPrice;
            Quantity = product.Quantity;
            LastDeliveryDate = product.LastDeliveryDate;
            LastSaleDate = product.LastSaleDate;
            DiscountPercent = product.DiscountPercent;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Unit { get; }
        public string Supplier { get; }
        public decimal UnitPrice { get; }
        public decimal Quantity { get; }
        public DateTime LastDeliveryDate { get; }
        public DateTime? LastSaleDate { get; }
        public decimal DiscountPercent { get; }
    }
}

