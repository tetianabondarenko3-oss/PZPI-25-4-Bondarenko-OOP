namespace shop;

/// <summary>
/// Вікно входу, яке виконує авторизацію адміністратора або касира.
/// </summary>
public sealed partial class LoginForm : Form
{
    private readonly ShopStore store;

    /// <summary>Створює форму входу для попереднього перегляду в конструкторі Visual Studio.</summary>
    public LoginForm()
    {
        store = new ShopStore();
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, loginButton, cancelLoginButton);
    }

    /// <summary>Створює форму входу для вибраного сховища даних.</summary>
    public LoginForm(ShopStore store)
    {
        this.store = store;
        InitializeComponent();
        FormHelpers.ConfigureHotkeys(this, loginButton, cancelLoginButton);
    }

    private void LoginButton_Click(object? sender, EventArgs e)
    {
        if (store.Login(loginTextBox.Text, passwordTextBox.Text))
        {
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        MessageBox.Show("Неправильний логін або пароль.", "Вхід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void CancelLoginButton_Click(object? sender, EventArgs e)
    {
        Close();
    }
}

