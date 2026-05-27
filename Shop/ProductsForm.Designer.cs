namespace shop;

partial class ProductsForm
{
    private TextBox searchTextBox = null!;
    private Button refreshButton = null!;
    private Button editButton = null!;
    private Button deleteButton = null!;
    private DataGridView productsGridView = null!;
    private Panel topPanel = null!;
    private Label searchLabel = null!;

    private void InitializeComponent()
    {
        searchTextBox = new TextBox();
        refreshButton = new Button();
        editButton = new Button();
        deleteButton = new Button();
        productsGridView = new DataGridView();
        topPanel = new Panel();
        searchLabel = new Label();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)productsGridView).BeginInit();
        SuspendLayout();

        topPanel.Controls.Add(deleteButton);
        topPanel.Controls.Add(editButton);
        topPanel.Controls.Add(refreshButton);
        topPanel.Controls.Add(searchTextBox);
        topPanel.Controls.Add(searchLabel);
        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 52;

        searchLabel.AutoSize = true;
        searchLabel.Location = new Point(12, 16);
        searchLabel.Text = "Пошук";

        searchTextBox.Location = new Point(70, 12);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.Size = new Size(260, 27);
        searchTextBox.TextChanged += SearchTextBox_TextChanged;

        refreshButton.Location = new Point(348, 10);
        refreshButton.Size = new Size(100, 31);
        refreshButton.Text = "Оновити";
        refreshButton.UseVisualStyleBackColor = true;
        refreshButton.Click += RefreshButton_Click;

        editButton.Location = new Point(454, 10);
        editButton.Size = new Size(110, 31);
        editButton.Text = "Редагувати";
        editButton.UseVisualStyleBackColor = true;
        editButton.Click += EditButton_Click;

        deleteButton.Location = new Point(570, 10);
        deleteButton.Size = new Size(100, 31);
        deleteButton.Text = "Видалити";
        deleteButton.UseVisualStyleBackColor = true;
        deleteButton.Click += DeleteButton_Click;

        productsGridView.AllowUserToAddRows = false;
        productsGridView.AllowUserToDeleteRows = false;
        productsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        productsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        productsGridView.Dock = DockStyle.Fill;
        productsGridView.MultiSelect = false;
        productsGridView.ReadOnly = true;
        productsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1050, 620);
        Controls.Add(productsGridView);
        Controls.Add(topPanel);
        Name = "ProductsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Товари";
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)productsGridView).EndInit();
        ResumeLayout(false);
    }
}

