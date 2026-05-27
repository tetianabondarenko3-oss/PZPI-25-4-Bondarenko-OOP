namespace shop;

/// <summary>
/// Форма для уцінки та списання товарів.
/// </summary>
public sealed partial class CorrectionsForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює форму коригувань для попереднього перегляду в конструкторі Visual Studio.</summary>
    public CorrectionsForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, markdownButton);
    }

    /// <summary>Створює форму коригувань.</summary>
    public CorrectionsForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, markdownButton);
        productComboBox.DataSource = store.Data.Products.ToList();
        productComboBox.DisplayMember = nameof(Product.Name);
        RefreshHistory();
    }

    private Product? SelectedProduct => productComboBox.SelectedItem as Product;

    private void MarkdownButton_Click(object? sender, EventArgs e)
    {
        try
        {
            if (SelectedProduct is null)
            {
                return;
            }

            store.ApplyMarkdown(SelectedProduct, newPriceNumericUpDown.Value, reasonTextBox.Text);
            RefreshHistory();
        }
        catch (Exception exception)
        {
            FormHelpers.ShowError(exception);
        }
    }

    private void WriteOffButton_Click(object? sender, EventArgs e)
    {
        try
        {
            if (SelectedProduct is null || !FormHelpers.Confirm("Списання зменшить залишок товару. Продовжити?"))
            {
                return;
            }

            store.WriteOff(SelectedProduct, writeOffQuantityNumericUpDown.Value, reasonTextBox.Text);
            RefreshHistory();
        }
        catch (Exception exception)
        {
            FormHelpers.ShowError(exception);
        }
    }

    private void RefreshHistory()
    {
        historyGridView.DataSource = store.Data.Corrections
            .OrderByDescending(item => item.Date)
            .Select(item => new
            {
                item.Date,
                Operation = item.Type == StockCorrectionType.Markdown ? "Уцінка" : "Списання",
                item.ProductName,
                item.OldPrice,
                item.NewPrice,
                item.Quantity,
                item.Reason
            })
            .ToList();
    }
}

