namespace shop;

/// <summary>
/// Головне вікно програми з меню переходу до окремих функціональних форм.
/// </summary>
public sealed partial class MainForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює головну форму для попереднього перегляду в конструкторі Visual Studio.</summary>
    public MainForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this);
    }

    /// <summary>Створює вікно головного меню для авторизованого користувача.</summary>
    public MainForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this);
        userStatusLabel.Text = $"Користувач: {store.CurrentUser?.FullName} ({store.CurrentUser?.Role})";
        fileStatusLabel.Text = $"Файл даних: {store.DataFilePath}";
        RefreshSummary();
    }

    private void ProductsMenuItem_Click(object? sender, EventArgs e) => Open(new ProductsForm(store));

    private void SupplyMenuItem_Click(object? sender, EventArgs e) => Open(new SupplyForm(store));

    private void SaleMenuItem_Click(object? sender, EventArgs e) => Open(new SaleForm(store));

    private void CorrectionsMenuItem_Click(object? sender, EventArgs e) => OpenAdmin(new CorrectionsForm(store));

    private void InventoryMenuItem_Click(object? sender, EventArgs e) => Open(new InventoryForm(store));

    private void ReportsMenuItem_Click(object? sender, EventArgs e) => Open(new ReportsForm(store));

    private void ReturnsMenuItem_Click(object? sender, EventArgs e) => Open(new ReturnsForm(store));

    private void UsersMenuItem_Click(object? sender, EventArgs e) => OpenAdmin(new UsersForm(store));

    private void SaveMenuItem_Click(object? sender, EventArgs e)
    {
        store.Save();
        MessageBox.Show("Дані збережено.", "Дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BackupMenuItem_Click(object? sender, EventArgs e)
    {
        var path = store.CreateBackup();
        MessageBox.Show($"Резервну копію створено:\n{path}", "Дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e) => Close();

    private void Open(Form form)
    {
        using (form)
        {
            form.ShowDialog(this);
        }

        RefreshSummary();
    }

    private void OpenAdmin(Form form)
    {
        if (store.CurrentUser?.Role != UserRole.Admin)
        {
            MessageBox.Show("Ця дія доступна лише адміністратору.", "Доступ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            form.Dispose();
            return;
        }

        Open(form);
    }

    private void RefreshSummary()
    {
        var stockValue = store.Data.Products.Sum(item => item.Quantity * item.UnitPrice);
        var income = store.Data.Sales.Sum(sale => sale.Total) - store.Data.Returns.Sum(item => item.Amount);
        summaryLabel.Text =
            "Головне меню\n\n" +
            $"Товарів у базі: {store.Data.Products.Count}\n" +
            $"Продажів: {store.Data.Sales.Count}\n" +
            $"Повернень: {store.Data.Returns.Count}\n" +
            $"Вартість залишків: {stockValue:0.00} грн\n" +
            $"Загальний дохід: {income:0.00} грн";
    }

    private void mainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }
}

