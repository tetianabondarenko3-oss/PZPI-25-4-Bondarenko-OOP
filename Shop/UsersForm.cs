namespace shop;

/// <summary>
/// Форма адміністратора для керування користувачами програми.
/// </summary>
public sealed partial class UsersForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює форму користувачів для попереднього перегляду в конструкторі Visual Studio.</summary>
    public UsersForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, addButton);
    }

    /// <summary>Створює форму адміністрування користувачів.</summary>
    public UsersForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, addButton);
        RefreshGrid();
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new UserEditForm();
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            store.Data.Users.Add(dialog.User);
            store.Save();
            RefreshGrid();
        }
    }

    private void EditButton_Click(object? sender, EventArgs e)
    {
        if (usersGridView.CurrentRow?.DataBoundItem is not AppUser user)
        {
            return;
        }

        using var dialog = new UserEditForm(user);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            store.Save();
            RefreshGrid();
        }
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        if (usersGridView.CurrentRow?.DataBoundItem is not AppUser user)
        {
            return;
        }

        if (store.Data.Users.Count <= 1)
        {
            MessageBox.Show("У програмі має залишитися хоча б один користувач.", "Користувачі", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (FormHelpers.Confirm($"Видалити користувача \"{user.Login}\"?"))
        {
            store.Data.Users.Remove(user);
            store.Save();
            RefreshGrid();
        }
    }

    private void RefreshGrid()
    {
        usersGridView.DataSource = store.Data.Users.ToList();
    }
}

