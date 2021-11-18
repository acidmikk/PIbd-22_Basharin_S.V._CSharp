
namespace WindowsFormsShip
{
    partial class FormDock
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
            this.pictureBoxParking = new System.Windows.Forms.PictureBox();
            this.buttonSetShip = new System.Windows.Forms.Button();
            this.buttonSetSuperShip = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTakeShip = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewLevelName = new System.Windows.Forms.TextBox();
            this.buttonAddDock = new System.Windows.Forms.Button();
            this.listBoxDocks = new System.Windows.Forms.ListBox();
            this.buttonDelDock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxParking
            // 
            this.pictureBoxParking.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxParking.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxParking.Name = "pictureBoxParking";
            this.pictureBoxParking.Size = new System.Drawing.Size(1127, 748);
            this.pictureBoxParking.TabIndex = 0;
            this.pictureBoxParking.TabStop = false;
            // 
            // buttonSetShip
            // 
            this.buttonSetShip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetShip.Location = new System.Drawing.Point(1133, 467);
            this.buttonSetShip.Name = "buttonSetShip";
            this.buttonSetShip.Size = new System.Drawing.Size(217, 65);
            this.buttonSetShip.TabIndex = 1;
            this.buttonSetShip.Text = "Припарковать обычный корабль";
            this.buttonSetShip.UseVisualStyleBackColor = true;
            this.buttonSetShip.Click += new System.EventHandler(this.buttonSetShip_Click);
            // 
            // buttonSetSuperShip
            // 
            this.buttonSetSuperShip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetSuperShip.Location = new System.Drawing.Point(1133, 538);
            this.buttonSetSuperShip.Name = "buttonSetSuperShip";
            this.buttonSetSuperShip.Size = new System.Drawing.Size(217, 65);
            this.buttonSetSuperShip.TabIndex = 2;
            this.buttonSetSuperShip.Text = "Припарковать супер корабль";
            this.buttonSetSuperShip.UseVisualStyleBackColor = true;
            this.buttonSetSuperShip.Click += new System.EventHandler(this.buttonSetSuperShip_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonTakeShip);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1133, 609);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 127);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Угнать корабль";
            // 
            // buttonTakeShip
            // 
            this.buttonTakeShip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTakeShip.Location = new System.Drawing.Point(6, 74);
            this.buttonTakeShip.Name = "buttonTakeShip";
            this.buttonTakeShip.Size = new System.Drawing.Size(205, 47);
            this.buttonTakeShip.TabIndex = 2;
            this.buttonTakeShip.Text = "Угнать";
            this.buttonTakeShip.UseVisualStyleBackColor = true;
            this.buttonTakeShip.Click += new System.EventHandler(this.buttonTakeShip_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox1.Location = new System.Drawing.Point(111, 40);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 26);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1133, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Парковка:";
            // 
            // textBoxNewLevelName
            // 
            this.textBoxNewLevelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewLevelName.Location = new System.Drawing.Point(1133, 32);
            this.textBoxNewLevelName.Name = "textBoxNewLevelName";
            this.textBoxNewLevelName.Size = new System.Drawing.Size(217, 26);
            this.textBoxNewLevelName.TabIndex = 5;
            // 
            // buttonAddDock
            // 
            this.buttonAddDock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddDock.Location = new System.Drawing.Point(1133, 64);
            this.buttonAddDock.Name = "buttonAddDock";
            this.buttonAddDock.Size = new System.Drawing.Size(217, 35);
            this.buttonAddDock.TabIndex = 6;
            this.buttonAddDock.Text = "Добавить парковку";
            this.buttonAddDock.UseVisualStyleBackColor = true;
            this.buttonAddDock.Click += new System.EventHandler(this.buttonAddDock_Click);
            // 
            // listBoxDocks
            // 
            this.listBoxDocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDocks.FormattingEnabled = true;
            this.listBoxDocks.ItemHeight = 20;
            this.listBoxDocks.Location = new System.Drawing.Point(1133, 105);
            this.listBoxDocks.Name = "listBoxDocks";
            this.listBoxDocks.Size = new System.Drawing.Size(217, 204);
            this.listBoxDocks.TabIndex = 7;
            this.listBoxDocks.SelectedIndexChanged += new System.EventHandler(this.listBoxDocks_SelectedIndexChanged);
            // 
            // buttonDelDock
            // 
            this.buttonDelDock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelDock.Location = new System.Drawing.Point(1133, 315);
            this.buttonDelDock.Name = "buttonDelDock";
            this.buttonDelDock.Size = new System.Drawing.Size(217, 35);
            this.buttonDelDock.TabIndex = 9;
            this.buttonDelDock.Text = "Удалить парковку";
            this.buttonDelDock.UseVisualStyleBackColor = true;
            this.buttonDelDock.Click += new System.EventHandler(this.buttonDelDock_Click);
            // 
            // FormDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 748);
            this.Controls.Add(this.buttonDelDock);
            this.Controls.Add(this.listBoxDocks);
            this.Controls.Add(this.buttonAddDock);
            this.Controls.Add(this.textBoxNewLevelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSetSuperShip);
            this.Controls.Add(this.buttonSetShip);
            this.Controls.Add(this.pictureBoxParking);
            this.Name = "FormDock";
            this.Text = "FormDock";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParking;
        private System.Windows.Forms.Button buttonSetShip;
        private System.Windows.Forms.Button buttonSetSuperShip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTakeShip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewLevelName;
        private System.Windows.Forms.Button buttonAddDock;
        private System.Windows.Forms.ListBox listBoxDocks;
        private System.Windows.Forms.Button buttonDelDock;
    }
}