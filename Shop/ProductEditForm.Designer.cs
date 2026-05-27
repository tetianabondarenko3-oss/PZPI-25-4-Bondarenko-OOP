namespace shop;

partial class ProductEditForm
{
    private TextBox nameTextBox = null!;
    private TextBox unitTextBox = null!;
    private TextBox supplierTextBox = null!;
    private NumericUpDown priceNumericUpDown = null!;
    private NumericUpDown quantityNumericUpDown = null!;
    private DateTimePicker deliveryDatePicker = null!;
    private NumericUpDown discountNumericUpDown = null!;
    private Button saveButton = null!;
    private Button cancelEditButton = null!;
    private Label nameLabel = null!;
    private Label unitLabel = null!;
    private Label supplierLabel = null!;
    private Label priceLabel = null!;
    private Label quantityLabel = null!;
    private Label dateLabel = null!;
    private Label discountLabel = null!;

    private void InitializeComponent()
    {
        nameTextBox = new TextBox();
        unitTextBox = new TextBox();
        supplierTextBox = new TextBox();
        priceNumericUpDown = new NumericUpDown();
        quantityNumericUpDown = new NumericUpDown();
        deliveryDatePicker = new DateTimePicker();
        discountNumericUpDown = new NumericUpDown();
        saveButton = new Button();
        cancelEditButton = new Button();
        nameLabel = new Label();
        unitLabel = new Label();
        supplierLabel = new Label();
        priceLabel = new Label();
        quantityLabel = new Label();
        dateLabel = new Label();
        discountLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)discountNumericUpDown).BeginInit();
        SuspendLayout();

        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(20, 24);
        nameLabel.Text = "Найменування";
        nameTextBox.Location = new Point(170, 20);
        nameTextBox.Size = new Size(220, 27);

        unitLabel.AutoSize = true;
        unitLabel.Location = new Point(20, 62);
        unitLabel.Text = "Одиниця виміру";
        unitTextBox.Location = new Point(170, 58);
        unitTextBox.Size = new Size(220, 27);

        supplierLabel.AutoSize = true;
        supplierLabel.Location = new Point(20, 100);
        supplierLabel.Text = "Постачальник";
        supplierTextBox.Location = new Point(170, 96);
        supplierTextBox.Size = new Size(220, 27);

        priceLabel.AutoSize = true;
        priceLabel.Location = new Point(20, 138);
        priceLabel.Text = "Ціна одиниці";
        priceNumericUpDown.DecimalPlaces = 2;
        priceNumericUpDown.Maximum = 1000000;
        priceNumericUpDown.Location = new Point(170, 134);
        priceNumericUpDown.Size = new Size(140, 27);
        priceNumericUpDown.ThousandsSeparator = true;

        quantityLabel.AutoSize = true;
        quantityLabel.Location = new Point(20, 176);
        quantityLabel.Text = "Кількість";
        quantityNumericUpDown.DecimalPlaces = 2;
        quantityNumericUpDown.Maximum = 1000000;
        quantityNumericUpDown.Location = new Point(170, 172);
        quantityNumericUpDown.Size = new Size(140, 27);
        quantityNumericUpDown.ThousandsSeparator = true;

        dateLabel.AutoSize = true;
        dateLabel.Location = new Point(20, 214);
        dateLabel.Text = "Дата завезення";
        deliveryDatePicker.Location = new Point(170, 210);
        deliveryDatePicker.Size = new Size(180, 27);

        discountLabel.AutoSize = true;
        discountLabel.Location = new Point(20, 252);
        discountLabel.Text = "Знижка, %";
        discountNumericUpDown.DecimalPlaces = 2;
        discountNumericUpDown.Maximum = 100;
        discountNumericUpDown.Location = new Point(170, 248);
        discountNumericUpDown.Size = new Size(140, 27);

        saveButton.Location = new Point(184, 296);
        saveButton.Size = new Size(100, 32);
        saveButton.Text = "Зберегти";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButton_Click;

        cancelEditButton.Location = new Point(290, 296);
        cancelEditButton.Size = new Size(100, 32);
        cancelEditButton.Text = "Скасувати";
        cancelEditButton.UseVisualStyleBackColor = true;
        cancelEditButton.Click += CancelEditButton_Click;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 350);
        Controls.Add(cancelEditButton);
        Controls.Add(saveButton);
        Controls.Add(discountNumericUpDown);
        Controls.Add(discountLabel);
        Controls.Add(deliveryDatePicker);
        Controls.Add(dateLabel);
        Controls.Add(quantityNumericUpDown);
        Controls.Add(quantityLabel);
        Controls.Add(priceNumericUpDown);
        Controls.Add(priceLabel);
        Controls.Add(supplierTextBox);
        Controls.Add(supplierLabel);
        Controls.Add(unitTextBox);
        Controls.Add(unitLabel);
        Controls.Add(nameTextBox);
        Controls.Add(nameLabel);
        Name = "ProductEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Редагування товару";
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)discountNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

