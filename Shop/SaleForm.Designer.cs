namespace shop;

partial class SaleForm
{
    private ComboBox productComboBox = null!;
    private NumericUpDown quantityNumericUpDown = null!;
    private NumericUpDown extraDiscountNumericUpDown = null!;
    private Button addButton = null!;
    private Button removeButton = null!;
    private Button completeButton = null!;
    private DataGridView cartGridView = null!;
    private TextBox receiptTextBox = null!;
    private Label totalLabel = null!;
    private Panel topPanel = null!;
    private Label productLabel = null!;
    private Label quantityLabel = null!;
    private Label discountLabel = null!;

    private void InitializeComponent()
    {
        productComboBox = new ComboBox();
        quantityNumericUpDown = new NumericUpDown();
        extraDiscountNumericUpDown = new NumericUpDown();
        addButton = new Button();
        removeButton = new Button();
        completeButton = new Button();
        cartGridView = new DataGridView();
        receiptTextBox = new TextBox();
        totalLabel = new Label();
        topPanel = new Panel();
        productLabel = new Label();
        quantityLabel = new Label();
        discountLabel = new Label();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)extraDiscountNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)cartGridView).BeginInit();
        SuspendLayout();

        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 54;
        topPanel.Controls.Add(productLabel);
        topPanel.Controls.Add(productComboBox);
        topPanel.Controls.Add(quantityLabel);
        topPanel.Controls.Add(quantityNumericUpDown);
        topPanel.Controls.Add(discountLabel);
        topPanel.Controls.Add(extraDiscountNumericUpDown);
        topPanel.Controls.Add(addButton);
        topPanel.Controls.Add(removeButton);
        topPanel.Controls.Add(completeButton);

        productLabel.AutoSize = true;
        productLabel.Location = new Point(12, 17);
        productLabel.Text = "Товар";
        productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        productComboBox.Location = new Point(62, 13);
        productComboBox.Size = new Size(240, 28);

        quantityLabel.AutoSize = true;
        quantityLabel.Location = new Point(318, 17);
        quantityLabel.Text = "Кількість";
        quantityNumericUpDown.DecimalPlaces = 2;
        quantityNumericUpDown.Maximum = 1000000;
        quantityNumericUpDown.Value = 1;
        quantityNumericUpDown.Location = new Point(392, 13);
        quantityNumericUpDown.Size = new Size(100, 27);

        discountLabel.AutoSize = true;
        discountLabel.Location = new Point(504, 17);
        discountLabel.Text = "Дод. знижка, %";
        extraDiscountNumericUpDown.DecimalPlaces = 2;
        extraDiscountNumericUpDown.Maximum = 100;
        extraDiscountNumericUpDown.Location = new Point(625, 13);
        extraDiscountNumericUpDown.Size = new Size(90, 27);

        addButton.Location = new Point(730, 11);
        addButton.Size = new Size(85, 31);
        addButton.Text = "Додати";
        addButton.Click += AddButton_Click;

        removeButton.Location = new Point(821, 11);
        removeButton.Size = new Size(90, 31);
        removeButton.Text = "Прибрати";
        removeButton.Click += RemoveButton_Click;

        completeButton.Location = new Point(917, 11);
        completeButton.Size = new Size(120, 31);
        completeButton.Text = "Оформити";
        completeButton.Click += CompleteButton_Click;

        receiptTextBox.Dock = DockStyle.Right;
        receiptTextBox.Font = new Font("Consolas", 10F);
        receiptTextBox.Multiline = true;
        receiptTextBox.ReadOnly = true;
        receiptTextBox.ScrollBars = ScrollBars.Vertical;
        receiptTextBox.Size = new Size(420, 596);

        cartGridView.AllowUserToAddRows = false;
        cartGridView.AllowUserToDeleteRows = false;
        cartGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        cartGridView.Dock = DockStyle.Fill;
        cartGridView.ReadOnly = true;
        cartGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        totalLabel.Dock = DockStyle.Bottom;
        totalLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        totalLabel.Height = 42;
        totalLabel.Text = "Загальна сума чека: 0.00 грн";
        totalLabel.TextAlign = ContentAlignment.MiddleRight;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1150, 650);
        Controls.Add(cartGridView);
        Controls.Add(totalLabel);
        Controls.Add(receiptTextBox);
        Controls.Add(topPanel);
        Name = "SaleForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Оформлення покупки";
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)extraDiscountNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)cartGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

