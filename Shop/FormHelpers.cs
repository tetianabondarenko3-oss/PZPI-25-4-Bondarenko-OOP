namespace shop;

/// <summary>
/// Містить допоміжні методи для створення узгоджених елементів Windows Forms.
/// </summary>
public static class FormHelpers
{
    /// <summary>Налаштовує стандартні клавіші керування для форми курсової роботи.</summary>
    public static void ConfigureHotkeys(Form form, Button? acceptButton = null, Button? cancelButton = null, string? helpText = null)
    {
        form.KeyPreview = true;

        if (acceptButton is not null)
        {
            form.AcceptButton = acceptButton;
        }

        if (cancelButton is not null)
        {
            form.CancelButton = cancelButton;
        }

        form.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show(
                    helpText ?? "F1 - допомога\nEnter - згода\nEsc - закрити вікно\nTab - наступне поле\nShift+Tab - попереднє поле",
                    "Допомога",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                form.Close();
                e.Handled = true;
            }
        };
    }

    /// <summary>Показує повідомлення про помилку перевірки або обробки даних.</summary>
    public static void ShowError(Exception exception)
    {
        MessageBox.Show(exception.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    /// <summary>Запитує підтвердження важливої дії у користувача.</summary>
    public static bool Confirm(string message)
    {
        return MessageBox.Show(message, "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    /// <summary>Створює стандартне текстове поле.</summary>
    public static TextBox TextBox(string text = "")
    {
        return new TextBox { Text = text, Width = 220 };
    }

    /// <summary>Створює стандартне числове поле.</summary>
    public static NumericUpDown Number(decimal value = 0, decimal maximum = 1_000_000, int decimals = 2)
    {
        var number = new NumericUpDown
        {
            Maximum = maximum,
            DecimalPlaces = decimals,
            Increment = decimals == 0 ? 1 : 0.1m,
            Width = 140,
            ThousandsSeparator = true
        };
        number.Value = Math.Min(Math.Max(value, number.Minimum), number.Maximum);
        return number;
    }

    /// <summary>Додає підписаний елемент керування до табличного розміщення.</summary>
    public static void AddRow(TableLayoutPanel table, string label, Control control)
    {
        var row = table.RowCount;
        table.RowCount = row + 1;
        table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        table.Controls.Add(new Label { Text = label, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 8, 3, 3) }, 0, row);
        table.Controls.Add(control, 1, row);
    }

    /// <summary>Додає елемент керування в новий рядок на всю ширину таблиці.</summary>
    public static void AddFullRow(TableLayoutPanel table, Control control)
    {
        var row = table.RowCount;
        table.RowCount = row + 1;
        table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        table.Controls.Add(control, 0, row);
        table.SetColumnSpan(control, Math.Max(1, table.ColumnCount));
    }

    /// <summary>Створює таблицю даних для списків лише для перегляду.</summary>
    public static DataGridView Grid()
    {
        return new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoGenerateColumns = true,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
    }
}

