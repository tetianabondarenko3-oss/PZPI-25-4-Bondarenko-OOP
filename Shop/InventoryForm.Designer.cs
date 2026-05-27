namespace shop;

partial class InventoryForm
{
    private Button refreshButton = null!;
    private DataGridView inventoryGridView = null!;
    private Label totalLabel = null!;
    private Panel topPanel = null!;

    private void InitializeComponent()
    {
        refreshButton = new Button();
        inventoryGridView = new DataGridView();
        totalLabel = new Label();
        topPanel = new Panel();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)inventoryGridView).BeginInit();
        SuspendLayout();

        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 48;
        topPanel.Controls.Add(refreshButton);

        refreshButton.Location = new Point(12, 9);
        refreshButton.Size = new Size(100, 31);
        refreshButton.Text = "Оновити";
        refreshButton.Click += RefreshButton_Click;

        totalLabel.Dock = DockStyle.Bottom;
        totalLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        totalLabel.Height = 42;
        totalLabel.TextAlign = ContentAlignment.MiddleRight;

        inventoryGridView.AllowUserToAddRows = false;
        inventoryGridView.AllowUserToDeleteRows = false;
        inventoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        inventoryGridView.Dock = DockStyle.Fill;
        inventoryGridView.ReadOnly = true;
        inventoryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 600);
        Controls.Add(inventoryGridView);
        Controls.Add(totalLabel);
        Controls.Add(topPanel);
        Name = "InventoryForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Інвентаризація залишків";
        topPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)inventoryGridView).EndInit();
        ResumeLayout(false);
    }
}

