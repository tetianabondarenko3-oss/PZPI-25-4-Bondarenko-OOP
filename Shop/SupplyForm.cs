namespace shop;

/// <summary>
/// Форма для реєстрації надходження товарів, як наявних, так і нових найменувань.
/// </summary>
public sealed partial class SupplyForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює форму надходжень для попереднього перегляду в конструкторі Visual Studio.</summary>
    public SupplyForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, registerButton);
    }

    /// <summary>Створює форму реєстрації надходження.</summary>
    public SupplyForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, registerButton);
        productComboBox.DataSource = store.Data.Products.Select(product => product.Name).ToList();
        RefreshHistory();
    }

    private void ProductComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var product = store.Data.Products.FirstOrDefault(item => item.Name == productComboBox.Text);
        if (product is null)
        {
            return;
        }

        unitTextBox.Text = product.Unit;
        supplierTextBox.Text = product.Supplier;
        priceNumericUpDown.Value = Math.Min(priceNumericUpDown.Maximum, product.UnitPrice);
    }

    private void RegisterButton_Click(object? sender, EventArgs e)
    {
        try
        {
            store.RegisterSupply(productComboBox.Text, unitTextBox.Text, supplierTextBox.Text, priceNumericUpDown.Value, quantityNumericUpDown.Value, deliveryDatePicker.Value);
            MessageBox.Show("Надходження зареєстровано.", "Надходження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            productComboBox.DataSource = store.Data.Products.Select(product => product.Name).ToList();
            RefreshHistory();
        }
        catch (Exception exception)
        {
            FormHelpers.ShowError(exception);
        }
    }

    private void RefreshHistory()
    {
        historyGridView.DataSource = store.Data.Supplies
            .OrderByDescending(item => item.Date)
            .Select(item => new
            {
                item.Date,
                item.ProductName,
                item.Supplier,
                item.Quantity,
                item.UnitPrice
            })
            .ToList();
    }
}

