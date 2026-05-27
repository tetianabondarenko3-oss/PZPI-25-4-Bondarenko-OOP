namespace shop;

partial class MainForm
{
    private MenuStrip mainMenuStrip = null!;
    private Label summaryLabel = null!;
    private StatusStrip statusStrip = null!;
    private ToolStripStatusLabel userStatusLabel = null!;
    private ToolStripStatusLabel fileStatusLabel = null!;
    private ToolStripMenuItem productsMenuItem = null!;
    private ToolStripMenuItem supplyMenuItem = null!;
    private ToolStripMenuItem saleMenuItem = null!;
    private ToolStripMenuItem correctionsMenuItem = null!;
    private ToolStripMenuItem inventoryMenuItem = null!;
    private ToolStripMenuItem reportsMenuItem = null!;
    private ToolStripMenuItem returnsMenuItem = null!;
    private ToolStripMenuItem usersMenuItem = null!;
    private ToolStripMenuItem dataMenuItem = null!;
    private ToolStripMenuItem saveMenuItem = null!;
    private ToolStripMenuItem backupMenuItem = null!;
    private ToolStripMenuItem exitMenuItem = null!;

    private void InitializeComponent()
    {
        mainMenuStrip = new MenuStrip();
        productsMenuItem = new ToolStripMenuItem();
        supplyMenuItem = new ToolStripMenuItem();
        saleMenuItem = new ToolStripMenuItem();
        correctionsMenuItem = new ToolStripMenuItem();
        inventoryMenuItem = new ToolStripMenuItem();
        reportsMenuItem = new ToolStripMenuItem();
        returnsMenuItem = new ToolStripMenuItem();
        usersMenuItem = new ToolStripMenuItem();
        dataMenuItem = new ToolStripMenuItem();
        saveMenuItem = new ToolStripMenuItem();
        backupMenuItem = new ToolStripMenuItem();
        exitMenuItem = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripMenuItem();
        summaryLabel = new Label();
        statusStrip = new StatusStrip();
        userStatusLabel = new ToolStripStatusLabel();
        fileStatusLabel = new ToolStripStatusLabel();
        mainMenuStrip.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // mainMenuStrip
        // 
        mainMenuStrip.Items.AddRange(new ToolStripItem[] { productsMenuItem, supplyMenuItem, saleMenuItem, correctionsMenuItem, inventoryMenuItem, reportsMenuItem, returnsMenuItem, usersMenuItem, dataMenuItem, exitMenuItem, toolStripMenuItem1 });
        mainMenuStrip.Location = new Point(0, 0);
        mainMenuStrip.Name = "mainMenuStrip";
        mainMenuStrip.Size = new Size(1180, 27);
        mainMenuStrip.TabIndex = 2;
        mainMenuStrip.ItemClicked += mainMenuStrip_ItemClicked;
        // 
        // productsMenuItem
        // 
        productsMenuItem.Name = "productsMenuItem";
        productsMenuItem.Size = new Size(66, 23);
        productsMenuItem.Text = "Товари";
        productsMenuItem.Click += ProductsMenuItem_Click;
        // 
        // supplyMenuItem
        // 
        supplyMenuItem.Name = "supplyMenuItem";
        supplyMenuItem.Size = new Size(108, 23);
        supplyMenuItem.Text = "Надходження";
        supplyMenuItem.Click += SupplyMenuItem_Click;
        // 
        // saleMenuItem
        // 
        saleMenuItem.Name = "saleMenuItem";
        saleMenuItem.Size = new Size(72, 23);
        saleMenuItem.Text = "Продаж";
        saleMenuItem.Click += SaleMenuItem_Click;
        // 
        // correctionsMenuItem
        // 
        correctionsMenuItem.Name = "correctionsMenuItem";
        correctionsMenuItem.Size = new Size(131, 23);
        correctionsMenuItem.Text = "Уцінка і списання";
        correctionsMenuItem.Click += CorrectionsMenuItem_Click;
        // 
        // inventoryMenuItem
        // 
        inventoryMenuItem.Name = "inventoryMenuItem";
        inventoryMenuItem.Size = new Size(115, 23);
        inventoryMenuItem.Text = "Інвентаризація";
        inventoryMenuItem.Click += InventoryMenuItem_Click;
        // 
        // reportsMenuItem
        // 
        reportsMenuItem.Name = "reportsMenuItem";
        reportsMenuItem.Size = new Size(53, 23);
        reportsMenuItem.Text = "Звіти";
        reportsMenuItem.Click += ReportsMenuItem_Click;
        // 
        // returnsMenuItem
        // 
        returnsMenuItem.Name = "returnsMenuItem";
        returnsMenuItem.Size = new Size(99, 23);
        returnsMenuItem.Text = "Повернення";
        returnsMenuItem.Click += ReturnsMenuItem_Click;
        // 
        // usersMenuItem
        // 
        usersMenuItem.Name = "usersMenuItem";
        usersMenuItem.Size = new Size(97, 23);
        usersMenuItem.Text = "Користувачі";
        usersMenuItem.Click += UsersMenuItem_Click;
        // 
        // dataMenuItem
        // 
        dataMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveMenuItem, backupMenuItem });
        dataMenuItem.Name = "dataMenuItem";
        dataMenuItem.Size = new Size(49, 23);
        dataMenuItem.Text = "Дані";
        // 
        // saveMenuItem
        // 
        saveMenuItem.Name = "saveMenuItem";
        saveMenuItem.Size = new Size(173, 24);
        saveMenuItem.Text = "Зберегти";
        saveMenuItem.Click += SaveMenuItem_Click;
        // 
        // backupMenuItem
        // 
        backupMenuItem.Name = "backupMenuItem";
        backupMenuItem.Size = new Size(173, 24);
        backupMenuItem.Text = "Резервна копія";
        backupMenuItem.Click += BackupMenuItem_Click;
        // 
        // exitMenuItem
        // 
        exitMenuItem.Name = "exitMenuItem";
        exitMenuItem.Size = new Size(54, 23);
        exitMenuItem.Text = "Вихід";
        exitMenuItem.Click += ExitMenuItem_Click;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(12, 23);
        // 
        // summaryLabel
        // 
        summaryLabel.Dock = DockStyle.Fill;
        summaryLabel.Font = new Font("Segoe UI", 13F);
        summaryLabel.Location = new Point(0, 27);
        summaryLabel.Name = "summaryLabel";
        summaryLabel.Size = new Size(1180, 594);
        summaryLabel.TabIndex = 0;
        summaryLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { userStatusLabel, fileStatusLabel });
        statusStrip.Location = new Point(0, 621);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1180, 22);
        statusStrip.TabIndex = 1;
        // 
        // userStatusLabel
        // 
        userStatusLabel.Name = "userStatusLabel";
        userStatusLabel.Size = new Size(0, 17);
        // 
        // fileStatusLabel
        // 
        fileStatusLabel.Name = "fileStatusLabel";
        fileStatusLabel.Size = new Size(0, 17);
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1180, 643);
        Controls.Add(summaryLabel);
        Controls.Add(statusStrip);
        Controls.Add(mainMenuStrip);
        MainMenuStrip = mainMenuStrip;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Магазин. Комп'ютер замість касового апарату";
        mainMenuStrip.ResumeLayout(false);
        mainMenuStrip.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private ToolStripMenuItem toolStripMenuItem1;
}

