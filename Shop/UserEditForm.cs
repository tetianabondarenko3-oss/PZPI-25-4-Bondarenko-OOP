namespace shop;

/// <summary>
/// Діалогове вікно для створення користувача програми.
/// </summary>
public sealed partial class UserEditForm : Form
{
    private readonly AppUser? editableUser;

    /// <summary>Користувач, створений у діалоговому вікні.</summary>
    public AppUser User { get; private set; } = new();

    /// <summary>Створює діалог користувача.</summary>
    public UserEditForm()
    {
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, createButton, cancelUserButton);
        roleComboBox.DataSource = Enum.GetValues<UserRole>();
    }

    /// <summary>Створює діалог для редагування наявного користувача.</summary>
    public UserEditForm(AppUser user)
    {
        editableUser = user;
        User = user;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, createButton, cancelUserButton);
        roleComboBox.DataSource = Enum.GetValues<UserRole>();
        loginTextBox.Text = user.Login;
        nameTextBox.Text = user.FullName;
        passwordTextBox.Text = user.Password;
        roleComboBox.SelectedItem = user.Role;
        createButton.Text = "Зберегти";
        Text = "Редагування користувача";
    }

    private void CreateButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(loginTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
        {
            MessageBox.Show("Логін і пароль обов'язкові.", "Користувачі", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (editableUser is not null)
        {
            editableUser.Login = loginTextBox.Text.Trim();
            editableUser.FullName = string.IsNullOrWhiteSpace(nameTextBox.Text) ? loginTextBox.Text.Trim() : nameTextBox.Text.Trim();
            editableUser.Password = passwordTextBox.Text;
            editableUser.Role = roleComboBox.SelectedItem is UserRole editedRole ? editedRole : UserRole.Cashier;
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        User = new AppUser
        {
            Login = loginTextBox.Text.Trim(),
            FullName = string.IsNullOrWhiteSpace(nameTextBox.Text) ? loginTextBox.Text.Trim() : nameTextBox.Text.Trim(),
            Password = passwordTextBox.Text,
            Role = roleComboBox.SelectedItem is UserRole role ? role : UserRole.Cashier
        };
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelUserButton_Click(object? sender, EventArgs e) => Close();
}

