using System.ComponentModel;

namespace shop;

/// <summary>
/// Форма для оформлення покупок, друку чеків і коригування залишків.
/// </summary>
public sealed partial class SaleForm : Form
{
    private readonly ShopStore store;
    private readonly BindingList<SaleItem> cart = [];

    /// <summary>Створює форму продажу для попереднього перегляду в конструкторі Visual Studio.</summary>
    public SaleForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, completeButton);
    }

    /// <summary>Створює форму продажу.</summary>
    public SaleForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, completeButton);
        productComboBox.DataSource = store.Data.Products.ToList();
        productComboBox.DisplayMember = nameof(Product.Name);
        cartGridView.DataSource = cart;
        UpdateTotal();
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        try
        {
            if (productComboBox.SelectedItem is not Product product)
            {
                return;
            }

            var discount = Math.Min(100m, product.DiscountPercent + extraDiscountNumericUpDown.Value);
            cart.Add(new SaleItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Unit = product.Unit,
                Quantity = quantityNumericUpDown.Value,
                UnitPrice = product.UnitPrice,
                DiscountPercent = discount
            });
            UpdateTotal();
        }
        catch (Exception exception)
        {
            FormHelpers.ShowError(exception);
        }
    }

    private void RemoveButton_Click(object? sender, EventArgs e)
    {
        if (cartGridView.CurrentRow?.DataBoundItem is SaleItem item)
        {
            cart.Remove(item);
            UpdateTotal();
        }
    }

    private void CompleteButton_Click(object? sender, EventArgs e)
    {
        try
        {
            receiptTextBox.Text = store.CompleteSale(cart.ToList(), store.CurrentUser?.Login ?? "");
            cart.Clear();
            productComboBox.DataSource = store.Data.Products.ToList();
            UpdateTotal();
        }
        catch (Exception exception)
        {
            FormHelpers.ShowError(exception);
        }
    }

    private void UpdateTotal()
    {
        totalLabel.Text = $"Загальна сума чека: {cart.Sum(item => item.Total):0.00} грн";
    }
}

