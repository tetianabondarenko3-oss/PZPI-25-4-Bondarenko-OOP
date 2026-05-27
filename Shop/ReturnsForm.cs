namespace shop;

/// <summary>
/// Форма для повернення товарів та перегляду історії повернень.
/// </summary>
public sealed partial class ReturnsForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює форму повернень для попереднього перегляду в конструкторі Visual Studio.</summary>
    public ReturnsForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, returnButton);
    }

    /// <summary>Створює форму повернень.</summary>
    public ReturnsForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, returnButton);
        RefreshHistory();
        LoadReceiptItems();
    }

    private void ReceiptNumericUpDown_ValueChanged(object? sender, EventArgs e) => LoadReceiptItems();

    private void FindReceiptButton_Click(object? sender, EventArgs e) => LoadReceiptItems();

    private void ReturnButton_Click(object? sender, EventArgs e)
    {
        try
        {
            if (itemComboBox.SelectedItem is not SaleItem item)
            {
                throw new InvalidOperationException("Оберіть товар з чека.");
            }

            store.RegisterReturn((int)receiptNumericUpDown.Value, item.ProductId, quantityNumericUpDown.Value, reasonTextBox.Text);
            MessageBox.Show("Повернення оформлено, залишок скориговано.", "Повернення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshHistory();
        }
        catch (Exception exception)
        {
            FormHelpers.ShowError(exception);
        }
    }

    private void LoadReceiptItems()
    {
        var sale = store.Data.Sales.FirstOrDefault(item => item.ReceiptNumber == (int)receiptNumericUpDown.Value);
        itemComboBox.DataSource = sale?.Items.ToList() ?? [];
        itemComboBox.DisplayMember = nameof(SaleItem.ProductName);
    }

    private void RefreshHistory()
    {
        returnsGridView.DataSource = store.Data.Returns
            .OrderByDescending(item => item.Date)
            .Select(item => new
            {
                item.Date,
                item.ReceiptNumber,
                item.ProductName,
                item.Quantity,
                item.Amount,
                item.Reason
            })
            .ToList();
    }
}

