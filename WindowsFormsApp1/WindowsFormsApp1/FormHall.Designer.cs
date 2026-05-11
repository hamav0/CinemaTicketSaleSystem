namespace WindowsFormsApp1
{
    partial class FormHall
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
            this.pnlViewport = new System.Windows.Forms.Panel();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.btnBuy = new System.Windows.Forms.Button();
            this.pnlViewport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlViewport
            // 
            this.pnlViewport.BackColor = System.Drawing.Color.White;
            this.pnlViewport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViewport.Controls.Add(this.btnZoomOut);
            this.pnlViewport.Controls.Add(this.btnZoomIn);
            this.pnlViewport.Controls.Add(this.pnlCanvas);
            this.pnlViewport.Location = new System.Drawing.Point(0, 0);
            this.pnlViewport.Name = "pnlViewport";
            this.pnlViewport.Size = new System.Drawing.Size(960, 530);
            this.pnlViewport.TabIndex = 1;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.btnZoomOut.Location = new System.Drawing.Point(911, 273);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(37, 37);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "−";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.btnZoomIn.Location = new System.Drawing.Point(911, 220);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(37, 37);
            this.btnZoomIn.TabIndex = 2;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Экран;
            this.pnlCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlCanvas.Location = new System.Drawing.Point(112, 12);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(736, 48);
            this.pnlCanvas.TabIndex = 1;
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.LightGray;
            this.btnBuy.Enabled = false;
            this.btnBuy.Font = new System.Drawing.Font("Arial", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.btnBuy.ForeColor = System.Drawing.Color.DimGray;
            this.btnBuy.Location = new System.Drawing.Point(715, 536);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(234, 36);
            this.btnBuy.TabIndex = 4;
            this.btnBuy.Text = "Места не выбраны";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // FormHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 583);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.pnlViewport);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(976, 618);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(976, 618);
            this.Name = "FormHall";
            this.Text = "Haiiiiiiiiiiiiiii";
            this.Load += new System.EventHandler(this.FormHall_Load);
            this.pnlViewport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlViewport;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnBuy;
    }
}