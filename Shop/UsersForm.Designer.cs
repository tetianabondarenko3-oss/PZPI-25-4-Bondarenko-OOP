namespace shop;

partial class UsersForm
{
    private Button addButton = null!;
    private Button editButton = null!;
    private Button deleteButton = null!;
    private DataGridView usersGridView = null!;
    private Panel topPanel = null!;

    private void InitializeComponent()
    {
        addButton = new Button();
        editButton = new Button();
        deleteButton = new Button();
        usersGridView = new DataGridView();
        topPanel = new Panel();
        topPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)usersGridView).BeginInit();
        SuspendLayout();

        topPanel.Dock = DockStyle.Top;
        topPanel.Height = 48;
        topPanel.Controls.Add(addButton);
        topPanel.Controls.Add(editButton);
        topPanel.Controls.Add(deleteButton);

        addButton.Location = new Point(12, 9);
        addButton.Size = new Size(90, 31);
        addButton.Text = "Додати";
        addButton.Click += AddButton_Click;

        editButton.Location = new Point(108, 9);
        editButton.Size = new Size(110, 31);
        editButton.Text = "Редагувати";
        editButton.Click += EditButton_Click;

        deleteButton.Location = new Point(224, 9);
        deleteButton.Size = new Size(90, 31);
        deleteButton.Text = "Видалити";
        deleteButton.Click += DeleteButton_Click;

        usersGridView.AllowUserToAddRows = false;
        usersGridView.AllowUserToDeleteRows = false;
        usersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        usersGridView.Dock = DockStyle.Fill;
        usersGridView.ReadOnly = true;
        usersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(850, 520);
        Controls.Add(usersGridView);
        Controls.Add(topPanel);
        Name = "UsersForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Користувачі";
        topPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)usersGridView).EndInit();
        ResumeLayout(false);
    }
}

