namespace shop;

partial class CorrectionsForm
{
    private ComboBox productComboBox = null!;
    private NumericUpDown newPriceNumericUpDown = null!;
    private NumericUpDown writeOffQuantityNumericUpDown = null!;
    private TextBox reasonTextBox = null!;
    private Button markdownButton = null!;
    private Button writeOffButton = null!;
    private DataGridView historyGridView = null!;
    private Panel topPanel = null!;
    private Label productLabel = null!;
    private Label priceLabel = null!;
    private Label quantityLabel = null!;
    private Label reasonLabel = null!;

    private void InitializeComponent()
    {
        productComboBox = new ComboBox();
        newPriceNumericUpDown = new NumericUpDown();
        writeOffQuantityNumericUpDown = new NumericUpDown();
        reasonTextBox = new TextBox();
        markdownButton = new Button();
        writeOffButton = new Button();
        historyGridView = new DataGridView();
        topPanel = new Panel();
        productLabel = new Label();
        priceLabel = new Label();
        quantityLabel = new Label();
        reasonLabel = new Label();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)newPriceNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)writeOffQuantityNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)historyGridView).BeginInit();
        SuspendLayout();

        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 150;
        topPanel.Controls.Add(productLabel);
        topPanel.Controls.Add(productComboBox);
        topPanel.Controls.Add(priceLabel);
        topPanel.Controls.Add(newPriceNumericUpDown);
        topPanel.Controls.Add(quantityLabel);
        topPanel.Controls.Add(writeOffQuantityNumericUpDown);
        topPanel.Controls.Add(reasonLabel);
        topPanel.Controls.Add(reasonTextBox);
        topPanel.Controls.Add(markdownButton);
        topPanel.Controls.Add(writeOffButton);

        productLabel.AutoSize = true;
        productLabel.Location = new Point(14, 18);
        productLabel.Text = "Товар";
        productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        productComboBox.Location = new Point(150, 14);
        productComboBox.Size = new Size(260, 28);

        priceLabel.AutoSize = true;
        priceLabel.Location = new Point(14, 56);
        priceLabel.Text = "Нова ціна";
        newPriceNumericUpDown.DecimalPlaces = 2;
        newPriceNumericUpDown.Maximum = 1000000;
        newPriceNumericUpDown.Location = new Point(150, 52);
        newPriceNumericUpDown.Size = new Size(140, 27);

        quantityLabel.AutoSize = true;
        quantityLabel.Location = new Point(430, 18);
        quantityLabel.Text = "Кількість списання";
        writeOffQuantityNumericUpDown.DecimalPlaces = 2;
        writeOffQuantityNumericUpDown.Maximum = 1000000;
        writeOffQuantityNumericUpDown.Value = 1;
        writeOffQuantityNumericUpDown.Location = new Point(590, 14);
        writeOffQuantityNumericUpDown.Size = new Size(140, 27);

        reasonLabel.AutoSize = true;
        reasonLabel.Location = new Point(430, 56);
        reasonLabel.Text = "Причина";
        reasonTextBox.Location = new Point(590, 52);
        reasonTextBox.Size = new Size(260, 27);

        markdownButton.Location = new Point(590, 92);
        markdownButton.Size = new Size(110, 32);
        markdownButton.Text = "Уцінити";
        markdownButton.Click += MarkdownButton_Click;

        writeOffButton.Location = new Point(706, 92);
        writeOffButton.Size = new Size(110, 32);
        writeOffButton.Text = "Списати";
        writeOffButton.Click += WriteOffButton_Click;

        historyGridView.AllowUserToAddRows = false;
        historyGridView.AllowUserToDeleteRows = false;
        historyGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        historyGridView.Dock = DockStyle.Fill;
        historyGridView.ReadOnly = true;
        historyGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 620);
        Controls.Add(historyGridView);
        Controls.Add(topPanel);
        Name = "CorrectionsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Уцінка і списання";
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)newPriceNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)writeOffQuantityNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)historyGridView).EndInit();
        ResumeLayout(false);
    }
}

