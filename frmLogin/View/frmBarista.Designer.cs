namespace LastProjectOOP
{
    partial class frmBarista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarista));
            dgvOrder = new Guna.UI2.WinForms.Guna2DataGridView();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbname = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbLogout = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblExit = new Label();
            btnInfo = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrder).BeginInit();
            SuspendLayout();
            // 
            // dgvOrder
            // 
            dgvOrder.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(201, 231, 203);
            dgvOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrder.BackgroundColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(76, 175, 80);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOrder.ColumnHeadersHeight = 35;
            dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(219, 239, 220);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(135, 201, 138);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOrder.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOrder.GridColor = Color.Green;
            dgvOrder.Location = new Point(71, 152);
            dgvOrder.Name = "dgvOrder";
            dgvOrder.RowHeadersVisible = false;
            dgvOrder.RowHeadersWidth = 62;
            dgvOrder.RowTemplate.Height = 33;
            dgvOrder.Size = new Size(1006, 377);
            dgvOrder.TabIndex = 0;
            dgvOrder.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Green;
            dgvOrder.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(201, 231, 203);
            dgvOrder.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvOrder.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvOrder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvOrder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvOrder.ThemeStyle.BackColor = Color.FromArgb(192, 255, 192);
            dgvOrder.ThemeStyle.GridColor = Color.Green;
            dgvOrder.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(76, 175, 80);
            dgvOrder.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvOrder.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvOrder.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvOrder.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvOrder.ThemeStyle.HeaderStyle.Height = 35;
            dgvOrder.ThemeStyle.ReadOnly = false;
            dgvOrder.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(219, 239, 220);
            dgvOrder.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrder.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvOrder.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvOrder.ThemeStyle.RowsStyle.Height = 33;
            dgvOrder.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(135, 201, 138);
            dgvOrder.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // btnSave
            // 
            btnSave.CustomizableEdges = customizableEdges1;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.SeaGreen;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(531, 547);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSave.Size = new Size(130, 57);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.SeaGreen;
            guna2HtmlLabel1.Location = new Point(370, 40);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(430, 38);
            guna2HtmlLabel1.TabIndex = 3;
            guna2HtmlLabel1.Text = "Infomation Barista and Orders";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel2.ForeColor = Color.SeaGreen;
            guna2HtmlLabel2.Location = new Point(71, 92);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(65, 27);
            guna2HtmlLabel2.TabIndex = 4;
            guna2HtmlLabel2.Text = "Name:";
            // 
            // lbname
            // 
            lbname.BackColor = Color.Transparent;
            lbname.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbname.ForeColor = Color.SeaGreen;
            lbname.Location = new Point(146, 92);
            lbname.Name = "lbname";
            lbname.Size = new Size(54, 27);
            lbname.TabIndex = 9;
            lbname.Text = "name";
            // 
            // lbLogout
            // 
            lbLogout.BackColor = Color.Transparent;
            lbLogout.Font = new Font("Times New Roman", 11F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lbLogout.ForeColor = Color.SeaGreen;
            lbLogout.Location = new Point(71, 588);
            lbLogout.Name = "lbLogout";
            lbLogout.Size = new Size(70, 27);
            lbLogout.TabIndex = 10;
            lbLogout.Text = "Logout";
            lbLogout.Click += lbLogout_Click;
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.BackColor = Color.MediumSeaGreen;
            lblExit.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblExit.ForeColor = Color.FromArgb(255, 192, 128);
            lblExit.Location = new Point(4, 5);
            lblExit.Margin = new Padding(4, 0, 4, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(54, 41);
            lblExit.TabIndex = 20;
            lblExit.Text = "←";
            lblExit.Click += lblExit_Click;
            // 
            // btnInfo
            // 
            btnInfo.BackColor = Color.Transparent;
            btnInfo.BorderRadius = 15;
            btnInfo.CustomizableEdges = customizableEdges3;
            btnInfo.DisabledState.BorderColor = Color.DarkGray;
            btnInfo.DisabledState.CustomBorderColor = Color.DarkGray;
            btnInfo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnInfo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnInfo.FillColor = Color.SeaGreen;
            btnInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnInfo.ForeColor = Color.White;
            btnInfo.Location = new Point(991, 103);
            btnInfo.Name = "btnInfo";
            btnInfo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnInfo.Size = new Size(86, 43);
            btnInfo.TabIndex = 21;
            btnInfo.Text = "Info";
            btnInfo.Click += btnInfo_Click;
            // 
            // frmBarista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.cf3;
            ClientSize = new Size(1134, 642);
            Controls.Add(btnInfo);
            Controls.Add(lblExit);
            Controls.Add(lbLogout);
            Controls.Add(lbname);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(btnSave);
            Controls.Add(dgvOrder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmBarista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmBarista";
            Load += frmBarista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvOrder;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbname;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbLogout;
        private Label lblExit;
        private Guna.UI2.WinForms.Guna2Button btnInfo;
    }
}