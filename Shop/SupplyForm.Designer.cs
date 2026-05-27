namespace shop;

partial class SupplyForm
{
    private ComboBox productComboBox = null!;
    private TextBox unitTextBox = null!;
    private TextBox supplierTextBox = null!;
    private NumericUpDown priceNumericUpDown = null!;
    private NumericUpDown quantityNumericUpDown = null!;
    private DateTimePicker deliveryDatePicker = null!;
    private Button registerButton = null!;
    private DataGridView historyGridView = null!;
    private Panel topPanel = null!;
    private Label productLabel = null!;
    private Label unitLabel = null!;
    private Label supplierLabel = null!;
    private Label priceLabel = null!;
    private Label quantityLabel = null!;
    private Label dateLabel = null!;

    private void InitializeComponent()
    {
        productComboBox = new ComboBox();
        unitTextBox = new TextBox();
        supplierTextBox = new TextBox();
        priceNumericUpDown = new NumericUpDown();
        quantityNumericUpDown = new NumericUpDown();
        deliveryDatePicker = new DateTimePicker();
        registerButton = new Button();
        historyGridView = new DataGridView();
        topPanel = new Panel();
        productLabel = new Label();
        unitLabel = new Label();
        supplierLabel = new Label();
        priceLabel = new Label();
        quantityLabel = new Label();
        dateLabel = new Label();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)historyGridView).BeginInit();
        SuspendLayout();

        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 150;
        topPanel.Controls.Add(productLabel);
        topPanel.Controls.Add(productComboBox);
        topPanel.Controls.Add(unitLabel);
        topPanel.Controls.Add(unitTextBox);
        topPanel.Controls.Add(supplierLabel);
        topPanel.Controls.Add(supplierTextBox);
        topPanel.Controls.Add(priceLabel);
        topPanel.Controls.Add(priceNumericUpDown);
        topPanel.Controls.Add(quantityLabel);
        topPanel.Controls.Add(quantityNumericUpDown);
        topPanel.Controls.Add(dateLabel);
        topPanel.Controls.Add(deliveryDatePicker);
        topPanel.Controls.Add(registerButton);

        productLabel.AutoSize = true;
        productLabel.Location = new Point(14, 18);
        productLabel.Text = "Найменування";
        productComboBox.Location = new Point(140, 14);
        productComboBox.Size = new Size(260, 28);
        productComboBox.DropDownStyle = ComboBoxStyle.DropDown;
        productComboBox.SelectedIndexChanged += ProductComboBox_SelectedIndexChanged;

        unitLabel.AutoSize = true;
        unitLabel.Location = new Point(14, 56);
        unitLabel.Text = "Одиниця виміру";
        unitTextBox.Location = new Point(140, 52);
        unitTextBox.Size = new Size(140, 27);
        unitTextBox.Text = "шт.";

        supplierLabel.AutoSize = true;
        supplierLabel.Location = new Point(14, 94);
        supplierLabel.Text = "Постачальник";
        supplierTextBox.Location = new Point(140, 90);
        supplierTextBox.Size = new Size(260, 27);
        supplierTextBox.Text = "Постачальник";

        priceLabel.AutoSize = true;
        priceLabel.Location = new Point(14, 122);
        priceLabel.Text = "Ціна одиниці";
        priceNumericUpDown.DecimalPlaces = 2;
        priceNumericUpDown.Maximum = 1000000;
        priceNumericUpDown.Minimum = 0;
        priceNumericUpDown.Value = 1;
        priceNumericUpDown.Location = new Point(140, 118);
        priceNumericUpDown.Size = new Size(140, 27);

        quantityLabel.AutoSize = true;
        quantityLabel.Location = new Point(430, 18);
        quantityLabel.Text = "Кількість";
        quantityNumericUpDown.DecimalPlaces = 2;
        quantityNumericUpDown.Maximum = 1000000;
        quantityNumericUpDown.Value = 1;
        quantityNumericUpDown.Location = new Point(560, 14);
        quantityNumericUpDown.Size = new Size(140, 27);

        dateLabel.AutoSize = true;
        dateLabel.Location = new Point(430, 56);
        dateLabel.Text = "Дата завезення";
        deliveryDatePicker.Location = new Point(560, 52);
        deliveryDatePicker.Size = new Size(180, 27);

        registerButton.Location = new Point(560, 89);
        registerButton.Size = new Size(150, 32);
        registerButton.Text = "Зареєструвати";
        registerButton.UseVisualStyleBackColor = true;
        registerButton.Click += RegisterButton_Click;

        historyGridView.AllowUserToAddRows = false;
        historyGridView.AllowUserToDeleteRows = false;
        historyGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        historyGridView.Dock = DockStyle.Fill;
        historyGridView.ReadOnly = true;
        historyGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(950, 600);
        Controls.Add(historyGridView);
        Controls.Add(topPanel);
        Name = "SupplyForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Реєстрація надходження товару";
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)historyGridView).EndInit();
        ResumeLayout(false);
    }
}

