namespace frmLogin
{
    partial class frmSignin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignin));
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            lblGuest = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnSignUp = new Guna.UI2.WinForms.Guna2Button();
            btnSignIn = new Guna.UI2.WinForms.Guna2Button();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            label5 = new Label();
            lblPassword = new Label();
            lblUserName = new Label();
            lblWelcome = new Label();
            lblTitle = new Label();
            lblExit = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = LastProjectOOP.Properties.Resources.cf1;
            pictureBox1.Location = new Point(148, 103);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 299);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(lblGuest);
            groupBox1.Controls.Add(btnSignUp);
            groupBox1.Controls.Add(btnSignIn);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblPassword);
            groupBox1.Controls.Add(lblUserName);
            groupBox1.Controls.Add(lblWelcome);
            groupBox1.Location = new Point(381, 103);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(328, 299);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // lblGuest
            // 
            lblGuest.BackColor = Color.White;
            lblGuest.Font = new Font("Times New Roman", 12F, FontStyle.Underline, GraphicsUnit.Point);
            lblGuest.ForeColor = Color.SeaGreen;
            lblGuest.Location = new Point(143, 262);
            lblGuest.Margin = new Padding(2);
            lblGuest.Name = "lblGuest";
            lblGuest.Size = new Size(38, 21);
            lblGuest.TabIndex = 10;
            lblGuest.Text = "Guest";
            lblGuest.Click += lblGuest_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.BorderRadius = 15;
            btnSignUp.CustomizableEdges = customizableEdges1;
            btnSignUp.DisabledState.BorderColor = Color.DarkGray;
            btnSignUp.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSignUp.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSignUp.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSignUp.FillColor = Color.SeaGreen;
            btnSignUp.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignUp.ForeColor = Color.Azure;
            btnSignUp.Location = new Point(192, 223);
            btnSignUp.Margin = new Padding(2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSignUp.Size = new Size(102, 32);
            btnSignUp.TabIndex = 9;
            btnSignUp.Text = "Sign up";
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnSignIn
            // 
            btnSignIn.BorderRadius = 15;
            btnSignIn.CustomizableEdges = customizableEdges3;
            btnSignIn.DisabledState.BorderColor = Color.DarkGray;
            btnSignIn.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSignIn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSignIn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSignIn.FillColor = Color.SeaGreen;
            btnSignIn.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignIn.ForeColor = Color.Azure;
            btnSignIn.Location = new Point(30, 223);
            btnSignIn.Margin = new Padding(2);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSignIn.Size = new Size(102, 32);
            btnSignIn.TabIndex = 4;
            btnSignIn.Text = "Sign in";
            btnSignIn.Click += btnSignIn_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.MediumSpringGreen;
            txtPassword.BorderRadius = 15;
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(27, 175);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter your passsword";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(273, 32);
            txtPassword.TabIndex = 8;
            // 
            // txtUserName
            // 
            txtUserName.BorderColor = Color.MediumSpringGreen;
            txtUserName.BorderRadius = 15;
            txtUserName.CustomizableEdges = customizableEdges7;
            txtUserName.DefaultText = "";
            txtUserName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUserName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUserName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUserName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUserName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUserName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUserName.Location = new Point(27, 106);
            txtUserName.Margin = new Padding(2);
            txtUserName.Name = "txtUserName";
            txtUserName.PasswordChar = '\0';
            txtUserName.PlaceholderText = "Enter your user name";
            txtUserName.SelectedText = "";
            txtUserName.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtUserName.Size = new Size(273, 32);
            txtUserName.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(84, 57);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(151, 15);
            label5.TabIndex = 6;
            label5.Text = "enter your account to continue";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(27, 154);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 16);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserName.Location = new Point(27, 84);
            lblUserName.Margin = new Padding(2, 0, 2, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(69, 16);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "UserName:";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.Location = new Point(84, 23);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(158, 27);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Back";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Times New Roman", 26.25F, FontStyle.Italic, GraphicsUnit.Point);
            lblTitle.Location = new Point(280, 35);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 41);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Rainy Day Coffee";
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.BackColor = Color.MediumSeaGreen;
            lblExit.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblExit.ForeColor = Color.FromArgb(255, 192, 128);
            lblExit.Location = new Point(2, 4);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(36, 26);
            lblExit.TabIndex = 21;
            lblExit.Text = "←";
            lblExit.Click += lblExit_Click;
            // 
            // frmSignin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = LastProjectOOP.Properties.Resources.cf3;
            ClientSize = new Size(824, 431);
            Controls.Add(lblExit);
            Controls.Add(lblTitle);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "frmSignin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CoffeeSystem";
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label lblTitle;
        private Label lblPassword;
        private Label lblUserName;
        private Label lblWelcome;
        private Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2Button btnSignUp;
        private Guna.UI2.WinForms.Guna2Button btnSignIn;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGuest;
        private Label lblExit;
    }
}