namespace shop;

/// <summary>
/// Надає демонстраційні дані, щоб Visual Studio могла відкривати конструктори форм без параметрів.
/// </summary>
internal static class DesignTimeStore
{
    /// <summary>Створює тимчасове сховище в пам'яті для перегляду форм і підтримки конструктора.</summary>
    public static ShopStore Create()
    {
        var store = new ShopStore();
        store.Load();
        store.Login("admin", "admin");
        return store;
    }
}

