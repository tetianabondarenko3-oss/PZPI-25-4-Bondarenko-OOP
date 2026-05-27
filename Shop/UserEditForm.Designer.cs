namespace shop;

partial class UserEditForm
{
    private TextBox loginTextBox = null!;
    private TextBox nameTextBox = null!;
    private TextBox passwordTextBox = null!;
    private ComboBox roleComboBox = null!;
    private Button createButton = null!;
    private Button cancelUserButton = null!;
    private Label loginLabel = null!;
    private Label nameLabel = null!;
    private Label passwordLabel = null!;
    private Label roleLabel = null!;

    private void InitializeComponent()
    {
        loginTextBox = new TextBox();
        nameTextBox = new TextBox();
        passwordTextBox = new TextBox();
        roleComboBox = new ComboBox();
        createButton = new Button();
        cancelUserButton = new Button();
        loginLabel = new Label();
        nameLabel = new Label();
        passwordLabel = new Label();
        roleLabel = new Label();
        SuspendLayout();

        loginLabel.AutoSize = true;
        loginLabel.Location = new Point(20, 24);
        loginLabel.Text = "Логін";
        loginTextBox.Location = new Point(120, 20);
        loginTextBox.Size = new Size(220, 27);

        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(20, 62);
        nameLabel.Text = "Ім'я";
        nameTextBox.Location = new Point(120, 58);
        nameTextBox.Size = new Size(220, 27);

        passwordLabel.AutoSize = true;
        passwordLabel.Location = new Point(20, 100);
        passwordLabel.Text = "Пароль";
        passwordTextBox.Location = new Point(120, 96);
        passwordTextBox.PasswordChar = '*';
        passwordTextBox.Size = new Size(220, 27);

        roleLabel.AutoSize = true;
        roleLabel.Location = new Point(20, 138);
        roleLabel.Text = "Роль";
        roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        roleComboBox.Location = new Point(120, 134);
        roleComboBox.Size = new Size(160, 28);

        createButton.Location = new Point(134, 184);
        createButton.Size = new Size(100, 32);
        createButton.Text = "Створити";
        createButton.Click += CreateButton_Click;

        cancelUserButton.Location = new Point(240, 184);
        cancelUserButton.Size = new Size(100, 32);
        cancelUserButton.Text = "Скасувати";
        cancelUserButton.Click += CancelUserButton_Click;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(380, 240);
        Controls.Add(cancelUserButton);
        Controls.Add(createButton);
        Controls.Add(roleComboBox);
        Controls.Add(roleLabel);
        Controls.Add(passwordTextBox);
        Controls.Add(passwordLabel);
        Controls.Add(nameTextBox);
        Controls.Add(nameLabel);
        Controls.Add(loginTextBox);
        Controls.Add(loginLabel);
        Name = "UserEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Новий користувач";
        ResumeLayout(false);
        PerformLayout();
    }
}

