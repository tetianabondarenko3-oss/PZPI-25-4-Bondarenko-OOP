namespace shop;

partial class ReportsForm
{
    private ComboBox periodComboBox = null!;
    private Button buildButton = null!;
    private Label incomeLabel = null!;
    private TabControl reportsTabControl = null!;
    private DataGridView salesGridView = null!;
    private DataGridView popularGridView = null!;
    private DataGridView unsoldGridView = null!;
    private Panel topPanel = null!;
    private Label periodLabel = null!;
    private TabPage salesPage = null!;
    private TabPage popularPage = null!;
    private TabPage unsoldPage = null!;

    private void InitializeComponent()
    {
        periodComboBox = new ComboBox();
        buildButton = new Button();
        incomeLabel = new Label();
        reportsTabControl = new TabControl();
        salesGridView = new DataGridView();
        popularGridView = new DataGridView();
        unsoldGridView = new DataGridView();
        topPanel = new Panel();
        periodLabel = new Label();
        salesPage = new TabPage();
        popularPage = new TabPage();
        unsoldPage = new TabPage();
        topPanel.SuspendLayout();
        reportsTabControl.SuspendLayout();
        salesPage.SuspendLayout();
        popularPage.SuspendLayout();
        unsoldPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)salesGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)popularGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)unsoldGridView).BeginInit();
        SuspendLayout();

        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 48;
        topPanel.Controls.Add(periodLabel);
        topPanel.Controls.Add(periodComboBox);
        topPanel.Controls.Add(buildButton);

        periodLabel.AutoSize = true;
        periodLabel.Location = new Point(12, 16);
        periodLabel.Text = "Період";
        periodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        periodComboBox.Items.Add("День");
        periodComboBox.Items.Add("Тиждень");
        periodComboBox.Items.Add("Місяць");
        periodComboBox.Items.Add("Весь час");
        periodComboBox.Location = new Point(76, 12);
        periodComboBox.Size = new Size(160, 28);
        periodComboBox.SelectedIndexChanged += PeriodComboBox_SelectedIndexChanged;

        buildButton.Location = new Point(250, 10);
        buildButton.Size = new Size(115, 31);
        buildButton.Text = "Сформувати";
        buildButton.Click += BuildButton_Click;

        incomeLabel.Dock = DockStyle.Top;
        incomeLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        incomeLabel.Height = 38;
        incomeLabel.TextAlign = ContentAlignment.MiddleLeft;

        salesGridView.AllowUserToAddRows = false;
        salesGridView.AllowUserToDeleteRows = false;
        salesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        salesGridView.Dock = DockStyle.Fill;
        salesGridView.ReadOnly = true;
        salesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        popularGridView.AllowUserToAddRows = false;
        popularGridView.AllowUserToDeleteRows = false;
        popularGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        popularGridView.Dock = DockStyle.Fill;
        popularGridView.ReadOnly = true;
        popularGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        unsoldGridView.AllowUserToAddRows = false;
        unsoldGridView.AllowUserToDeleteRows = false;
        unsoldGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        unsoldGridView.Dock = DockStyle.Fill;
        unsoldGridView.ReadOnly = true;
        unsoldGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        salesPage.Text = "Продажі";
        salesPage.Controls.Add(salesGridView);
        popularPage.Text = "Популярні товари";
        popularPage.Controls.Add(popularGridView);
        unsoldPage.Text = "Не продаються";
        unsoldPage.Controls.Add(unsoldGridView);

        reportsTabControl.Dock = DockStyle.Fill;
        reportsTabControl.TabPages.Add(salesPage);
        reportsTabControl.TabPages.Add(popularPage);
        reportsTabControl.TabPages.Add(unsoldPage);

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1050, 650);
        Controls.Add(reportsTabControl);
        Controls.Add(incomeLabel);
        Controls.Add(topPanel);
        Name = "ReportsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Аналітика та звіти";
        topPanel.ResumeLayout(false);
        topPanel.PerformLayout();
        reportsTabControl.ResumeLayout(false);
        salesPage.ResumeLayout(false);
        popularPage.ResumeLayout(false);
        unsoldPage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)salesGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)popularGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)unsoldGridView).EndInit();
        ResumeLayout(false);
    }
}

