namespace shop;

partial class LoginForm
{
    private TextBox loginTextBox = null!;
    private TextBox passwordTextBox = null!;
    private Button loginButton = null!;
    private Button cancelLoginButton = null!;
    private Label loginLabel = null!;
    private Label passwordLabel = null!;
    private Label hintLabel = null!;

    private void InitializeComponent()
    {
        loginTextBox = new TextBox();
        passwordTextBox = new TextBox();
        loginButton = new Button();
        cancelLoginButton = new Button();
        loginLabel = new Label();
        passwordLabel = new Label();
        hintLabel = new Label();
        SuspendLayout();
        // 
        // loginTextBox
        // 
        loginTextBox.Location = new Point(120, 23);
        loginTextBox.Name = "loginTextBox";
        loginTextBox.Size = new Size(220, 26);
        loginTextBox.TabIndex = 5;
        loginTextBox.Text = "admin";
        // 
        // passwordTextBox
        // 
        passwordTextBox.Location = new Point(120, 65);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PasswordChar = '*';
        passwordTextBox.Size = new Size(220, 26);
        passwordTextBox.TabIndex = 3;
        passwordTextBox.Text = "admin";
        // 
        // loginButton
        // 
        loginButton.Location = new Point(134, 138);
        loginButton.Name = "loginButton";
        loginButton.Size = new Size(100, 30);
        loginButton.TabIndex = 2;
        loginButton.Text = "Увійти";
        loginButton.UseVisualStyleBackColor = true;
        loginButton.Click += LoginButton_Click;
        // 
        // cancelLoginButton
        // 
        cancelLoginButton.Location = new Point(240, 138);
        cancelLoginButton.Name = "cancelLoginButton";
        cancelLoginButton.Size = new Size(100, 30);
        cancelLoginButton.TabIndex = 1;
        cancelLoginButton.Text = "Вийти";
        cancelLoginButton.UseVisualStyleBackColor = true;
        cancelLoginButton.Click += CancelLoginButton_Click;
        // 
        // loginLabel
        // 
        loginLabel.AutoSize = true;
        loginLabel.Location = new Point(24, 27);
        loginLabel.Name = "loginLabel";
        loginLabel.Size = new Size(42, 19);
        loginLabel.TabIndex = 6;
        loginLabel.Text = "Логін";
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Location = new Point(24, 65);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(56, 19);
        passwordLabel.TabIndex = 4;
        passwordLabel.Text = "Пароль";
        // 
        // hintLabel
        // 
        hintLabel.AutoSize = true;
        hintLabel.Location = new Point(24, 103);
        hintLabel.Name = "hintLabel";
        hintLabel.Size = new Size(359, 19);
        hintLabel.TabIndex = 0;
        hintLabel.Text = "Початкові облікові записи: admin/admin, cashier/cashier";
        // 
        // LoginForm
        // 
        AcceptButton = loginButton;
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelLoginButton;
        ClientSize = new Size(380, 188);
        Controls.Add(hintLabel);
        Controls.Add(cancelLoginButton);
        Controls.Add(loginButton);
        Controls.Add(passwordTextBox);
        Controls.Add(passwordLabel);
        Controls.Add(loginTextBox);
        Controls.Add(loginLabel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Вхід до програми";
        ResumeLayout(false);
        PerformLayout();
    }
}

