﻿
namespace WindowsFormsShip
{
    partial class FormShip
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShip));
            this.pictureBoxBoat = new System.Windows.Forms.PictureBox();
            //this.buttonCreateShip = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            //this.buttonCreateSuperShip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoat)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBoat
            // 
            this.pictureBoxBoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBoat.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBoat.Name = "pictureBoxBoat";
            this.pictureBoxBoat.Size = new System.Drawing.Size(1374, 829);
            this.pictureBoxBoat.TabIndex = 0;
            this.pictureBoxBoat.TabStop = false;
            // 
            // buttonCreateShip
            // 
            /*this.buttonCreateShip.Location = new System.Drawing.Point(13, 13);
            this.buttonCreateShip.Name = "buttonCreateShip";
            this.buttonCreateShip.Size = new System.Drawing.Size(235, 39);
            this.buttonCreateShip.TabIndex = 1;
            this.buttonCreateShip.Text = "Создать теплоход";
            this.buttonCreateShip.UseVisualStyleBackColor = true;
            this.buttonCreateShip.Click += new System.EventHandler(this.buttonCreateShip_Click);*/
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImage = global::WindowsFormsShip.Properties.Resources.left;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(1131, 746);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(73, 71);
            this.buttonLeft.TabIndex = 2;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUp.BackgroundImage")));
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUp.Location = new System.Drawing.Point(1210, 669);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(73, 71);
            this.buttonUp.TabIndex = 3;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImage = global::WindowsFormsShip.Properties.Resources.right;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.Location = new System.Drawing.Point(1289, 746);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(73, 71);
            this.buttonRight.TabIndex = 4;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = global::WindowsFormsShip.Properties.Resources.down;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDown.Location = new System.Drawing.Point(1210, 746);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(73, 71);
            this.buttonDown.TabIndex = 5;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonCreateSuperShip
            // 
            /*this.buttonCreateSuperShip.Location = new System.Drawing.Point(13, 58);
            this.buttonCreateSuperShip.Name = "buttonCreateSuperShip";
            this.buttonCreateSuperShip.Size = new System.Drawing.Size(313, 39);
            this.buttonCreateSuperShip.TabIndex = 6;
            this.buttonCreateSuperShip.Text = "Создать теплоход про";
            this.buttonCreateSuperShip.UseVisualStyleBackColor = true;
            this.buttonCreateSuperShip.Click += new System.EventHandler(this.buttonCreateSuperShip_Click);*/
            // 
            // FormShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 829);
            //this.Controls.Add(this.buttonCreateSuperShip);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonLeft);
            //this.Controls.Add(this.buttonCreateShip);
            this.Controls.Add(this.pictureBoxBoat);
            this.Name = "FormShip";
            this.Text = "FormShip";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBoat;
        //private System.Windows.Forms.Button buttonCreateShip;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        //private System.Windows.Forms.Button buttonCreateSuperShip;
    }
}

