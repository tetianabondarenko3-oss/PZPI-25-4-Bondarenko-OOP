namespace shop;

/// <summary>
/// Діалогове вікно для редагування полів товару.
/// </summary>
public sealed partial class ProductEditForm : Form
{
    private readonly ShopStore store;
    private readonly Product product;

    /// <summary>Створює діалог редагування товару для попереднього перегляду в конструкторі Visual Studio.</summary>
    public ProductEditForm()
    {
        store = new ShopStore();
        product = new Product();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, saveButton, cancelEditButton);
    }

    /// <summary>Створює діалог редагування товару.</summary>
    public ProductEditForm(ShopStore store, Product product)
    {
        this.store = store;
        this.product = product;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, saveButton, cancelEditButton);
        nameTextBox.Text = product.Name;
        unitTextBox.Text = product.Unit;
        supplierTextBox.Text = product.Supplier;
        priceNumericUpDown.Value = Math.Min(priceNumericUpDown.Maximum, product.UnitPrice);
        quantityNumericUpDown.Value = Math.Min(quantityNumericUpDown.Maximum, product.Quantity);
        deliveryDatePicker.Value = product.LastDeliveryDate;
        discountNumericUpDown.Value = Math.Min(discountNumericUpDown.Maximum, product.DiscountPercent);
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        try
        {
            store.UpdateProduct(
                product,
                nameTextBox.Text,
                unitTextBox.Text,
                supplierTextBox.Text,
                priceNumericUpDown.Value,
                quantityNumericUpDown.Value,
                deliveryDatePicker.Value,
                discountNumericUpDown.Value);
            Close();
        }
        catch (Exception exception)
        {
            FormHelpers.ShowError(exception);
        }
    }

    private void CancelEditButton_Click(object? sender, EventArgs e) => Close();
}

