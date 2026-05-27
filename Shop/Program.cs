namespace shop;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var store = new ShopStore();
        store.Load();

        using var loginForm = new LoginForm(store);
        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new MainForm(store));
        }
    }
}

