namespace shop;

partial class ReturnsForm
{
    private NumericUpDown receiptNumericUpDown = null!;
    private ComboBox itemComboBox = null!;
    private NumericUpDown quantityNumericUpDown = null!;
    private TextBox reasonTextBox = null!;
    private Button findReceiptButton = null!;
    private Button returnButton = null!;
    private DataGridView returnsGridView = null!;
    private Panel topPanel = null!;
    private Label receiptLabel = null!;
    private Label itemLabel = null!;
    private Label quantityLabel = null!;
    private Label reasonLabel = null!;

    private void InitializeComponent()
    {
        receiptNumericUpDown = new NumericUpDown();
        itemComboBox = new ComboBox();
        quantityNumericUpDown = new NumericUpDown();
        reasonTextBox = new TextBox();
        findReceiptButton = new Button();
        returnButton = new Button();
        returnsGridView = new DataGridView();
        topPanel = new Panel();
        receiptLabel = new Label();
        itemLabel = new Label();
        quantityLabel = new Label();
        reasonLabel = new Label();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)receiptNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)returnsGridView).BeginInit();
        SuspendLayout();

        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 150;
        topPanel.Controls.Add(receiptLabel);
        topPanel.Controls.Add(receiptNumericUpDown);
        topPanel.Controls.Add(itemLabel);
        topPanel.Controls.Add(itemComboBox);
        topPanel.Controls.Add(quantityLabel);
        topPanel.Controls.Add(quantityNumericUpDown);
        topPanel.Controls.Add(reasonLabel);
        topPanel.Controls.Add(reasonTextBox);
        topPanel.Controls.Add(findReceiptButton);
        topPanel.Controls.Add(returnButton);

        receiptLabel.AutoSize = true;
        receiptLabel.Location = new Point(14, 18);
        receiptLabel.Text = "Номер чека";
        receiptNumericUpDown.Maximum = 1000000;
        receiptNumericUpDown.Minimum = 1;
        receiptNumericUpDown.Value = 1;
        receiptNumericUpDown.Location = new Point(140, 14);
        receiptNumericUpDown.Size = new Size(120, 27);
        receiptNumericUpDown.ValueChanged += ReceiptNumericUpDown_ValueChanged;

        itemLabel.AutoSize = true;
        itemLabel.Location = new Point(14, 56);
        itemLabel.Text = "Товар з чека";
        itemComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        itemComboBox.Location = new Point(140, 52);
        itemComboBox.Size = new Size(260, 28);

        quantityLabel.AutoSize = true;
        quantityLabel.Location = new Point(430, 18);
        quantityLabel.Text = "Кількість";
        quantityNumericUpDown.DecimalPlaces = 2;
        quantityNumericUpDown.Maximum = 1000000;
        quantityNumericUpDown.Value = 1;
        quantityNumericUpDown.Location = new Point(560, 14);
        quantityNumericUpDown.Size = new Size(140, 27);

        reasonLabel.AutoSize = true;
        reasonLabel.Location = new Point(430, 56);
        reasonLabel.Text = "Причина";
        reasonTextBox.Location = new Point(560, 52);
        reasonTextBox.Size = new Size(260, 27);

        findReceiptButton.Location = new Point(720, 13);
        findReceiptButton.Size = new Size(120, 31);
        findReceiptButton.Text = "Знайти чек";
        findReceiptButton.Click += FindReceiptButton_Click;

        returnButton.Location = new Point(560, 92);
        returnButton.Size = new Size(180, 32);
        returnButton.Text = "Оформити повернення";
        returnButton.Click += ReturnButton_Click;

        returnsGridView.AllowUserToAddRows = false;
        returnsGridView.AllowUserToDeleteRows = false;
        returnsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        returnsGridView.Dock = DockStyle.Fill;
        returnsGridView.ReadOnly = true;
        returnsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 620);
        Controls.Add(returnsGridView);
        Controls.Add(topPanel);
        Name = "ReturnsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Повернення товару";
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)receiptNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)returnsGridView).EndInit();
        ResumeLayout(false);
    }
}

