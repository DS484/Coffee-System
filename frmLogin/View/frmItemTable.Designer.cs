namespace LastProjectOOP
{
    partial class frmItemTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemTable));
            pictureBox2 = new PictureBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dgvItem = new Guna.UI2.WinForms.Guna2DataGridView();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblQuantity = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            btnRemove = new Guna.UI2.WinForms.Guna2Button();
            cbList = new ComboBox();
            lblReset = new Label();
            label2 = new Label();
            lblExit = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItem).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logocf;
            pictureBox2.Location = new Point(-1, 0);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(379, 654);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.Sienna;
            guna2HtmlLabel1.Location = new Point(737, 23);
            guna2HtmlLabel1.Margin = new Padding(4, 3, 4, 3);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(192, 57);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "List Item";
            // 
            // dgvItem
            // 
            dgvItem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 216, 189);
            dgvItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(230, 126, 34);
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvItem.ColumnHeadersHeight = 35;
            dgvItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(249, 229, 211);
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Sienna;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(238, 169, 107);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvItem.DefaultCellStyle = dataGridViewCellStyle3;
            dgvItem.GridColor = Color.FromArgb(192, 64, 0);
            dgvItem.Location = new Point(670, 107);
            dgvItem.Margin = new Padding(4, 3, 4, 3);
            dgvItem.Name = "dgvItem";
            dgvItem.RowHeadersVisible = false;
            dgvItem.RowHeadersWidth = 62;
            dgvItem.RowTemplate.Height = 33;
            dgvItem.Size = new Size(527, 440);
            dgvItem.TabIndex = 2;
            dgvItem.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Carrot;
            dgvItem.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 216, 189);
            dgvItem.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvItem.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvItem.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvItem.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvItem.ThemeStyle.BackColor = Color.White;
            dgvItem.ThemeStyle.GridColor = Color.FromArgb(192, 64, 0);
            dgvItem.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(230, 126, 34);
            dgvItem.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvItem.ThemeStyle.HeaderStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            dgvItem.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvItem.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvItem.ThemeStyle.HeaderStyle.Height = 35;
            dgvItem.ThemeStyle.ReadOnly = false;
            dgvItem.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(249, 229, 211);
            dgvItem.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItem.ThemeStyle.RowsStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            dgvItem.ThemeStyle.RowsStyle.ForeColor = Color.Sienna;
            dgvItem.ThemeStyle.RowsStyle.Height = 33;
            dgvItem.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(238, 169, 107);
            dgvItem.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dgvItem.CellClick += Item_CellClick;
            dgvItem.CellContentClick += guna2DataGridView1_CellContentClick;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.ForeColor = Color.Sienna;
            lblName.Location = new Point(386, 194);
            lblName.Margin = new Padding(4, 3, 4, 3);
            lblName.Name = "lblName";
            lblName.Size = new Size(62, 28);
            lblName.TabIndex = 4;
            lblName.Text = "Name";
            // 
            // lblPrice
            // 
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrice.ForeColor = Color.Sienna;
            lblPrice.Location = new Point(386, 281);
            lblPrice.Margin = new Padding(4, 3, 4, 3);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 28);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // lblQuantity
            // 
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblQuantity.ForeColor = Color.Sienna;
            lblQuantity.Location = new Point(386, 366);
            lblQuantity.Margin = new Padding(4, 3, 4, 3);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(95, 28);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity";
            // 
            // txtName
            // 
            txtName.BorderColor = Color.Maroon;
            txtName.BorderRadius = 15;
            txtName.CustomizableEdges = customizableEdges1;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(488, 178);
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PlaceholderText = "";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtName.Size = new Size(175, 44);
            txtName.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.BorderColor = Color.Maroon;
            txtPrice.BorderRadius = 15;
            txtPrice.CustomizableEdges = customizableEdges3;
            txtPrice.DefaultText = "";
            txtPrice.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPrice.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPrice.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrice.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Location = new Point(488, 265);
            txtPrice.Name = "txtPrice";
            txtPrice.PasswordChar = '\0';
            txtPrice.PlaceholderText = "";
            txtPrice.SelectedText = "";
            txtPrice.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPrice.Size = new Size(175, 44);
            txtPrice.TabIndex = 7;
            // 
            // txtQuantity
            // 
            txtQuantity.BorderColor = Color.Maroon;
            txtQuantity.BorderRadius = 15;
            txtQuantity.CustomizableEdges = customizableEdges5;
            txtQuantity.DefaultText = "";
            txtQuantity.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtQuantity.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtQuantity.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtQuantity.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtQuantity.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtQuantity.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtQuantity.Location = new Point(488, 350);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PasswordChar = '\0';
            txtQuantity.PlaceholderText = "";
            txtQuantity.SelectedText = "";
            txtQuantity.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtQuantity.Size = new Size(175, 44);
            txtQuantity.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 15;
            btnAdd.CustomizableEdges = customizableEdges7;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.SeaGreen;
            btnAdd.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(466, 574);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAdd.Size = new Size(149, 59);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BorderRadius = 15;
            btnUpdate.CustomizableEdges = customizableEdges9;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdate.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(737, 574);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnUpdate.Size = new Size(148, 59);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnRemove
            // 
            btnRemove.BorderRadius = 15;
            btnRemove.CustomizableEdges = customizableEdges11;
            btnRemove.DisabledState.BorderColor = Color.DarkGray;
            btnRemove.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRemove.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRemove.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRemove.FillColor = Color.IndianRed;
            btnRemove.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(992, 574);
            btnRemove.Name = "btnRemove";
            btnRemove.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRemove.Size = new Size(150, 59);
            btnRemove.TabIndex = 8;
            btnRemove.Text = "Remove";
            btnRemove.Click += btnRemove_Click;
            // 
            // cbList
            // 
            cbList.ForeColor = Color.Sienna;
            cbList.FormattingEnabled = true;
            cbList.Items.AddRange(new object[] { "Tea", "Coffee", "Soda", "Smoothie", "Juice", "Cacao" });
            cbList.Location = new Point(386, 107);
            cbList.Name = "cbList";
            cbList.Size = new Size(255, 33);
            cbList.TabIndex = 9;
            cbList.Text = "Category of shop";
            cbList.SelectedIndexChanged += cbList_SelectedIndexChanged;
            // 
            // lblReset
            // 
            lblReset.AutoSize = true;
            lblReset.BackColor = Color.Sienna;
            lblReset.Font = new Font("Times New Roman", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblReset.ForeColor = Color.FromArgb(255, 192, 128);
            lblReset.Location = new Point(1140, 47);
            lblReset.Name = "lblReset";
            lblReset.Size = new Size(54, 51);
            lblReset.TabIndex = 10;
            lblReset.Text = "⟳";
            lblReset.Click += lblReset_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(1036, 59);
            label2.Name = "label2";
            label2.Size = new Size(98, 32);
            label2.TabIndex = 11;
            label2.Text = "Reload";
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.BackColor = Color.Sienna;
            lblExit.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblExit.ForeColor = Color.FromArgb(255, 192, 128);
            lblExit.Location = new Point(380, 3);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(54, 41);
            lblExit.TabIndex = 18;
            lblExit.Text = "←";
            lblExit.Click += lblExit_Click;
            // 
            // frmItemTable
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1210, 652);
            Controls.Add(lblExit);
            Controls.Add(label2);
            Controls.Add(lblReset);
            Controls.Add(cbList);
            Controls.Add(btnRemove);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(lblQuantity);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(dgvItem);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(pictureBox2);
            Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.Sienna;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmItemTable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmItemTable";
            Load += frmItemTable_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvItem;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuantity;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private ComboBox cbList;
        private Label lblReset;
        private Label label2;
        private Label lblExit;
    }
}