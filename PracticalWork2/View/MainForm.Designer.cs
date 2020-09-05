namespace PracticalWork
{
    partial class MainForm
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
            this.btnPixel = new System.Windows.Forms.Button();
            this.btnMillimeter = new System.Windows.Forms.Button();
            this.btnInch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPixel
            // 
            this.btnPixel.Location = new System.Drawing.Point(12, 25);
            this.btnPixel.Name = "btnPixel";
            this.btnPixel.Size = new System.Drawing.Size(143, 37);
            this.btnPixel.TabIndex = 0;
            this.btnPixel.Text = "Pixel";
            this.btnPixel.UseVisualStyleBackColor = true;
            // 
            // btnMillimeter
            // 
            this.btnMillimeter.Location = new System.Drawing.Point(205, 25);
            this.btnMillimeter.Name = "btnMillimeter";
            this.btnMillimeter.Size = new System.Drawing.Size(143, 37);
            this.btnMillimeter.TabIndex = 1;
            this.btnMillimeter.Text = "Millimeter";
            this.btnMillimeter.UseVisualStyleBackColor = true;
            // 
            // btnInch
            // 
            this.btnInch.Location = new System.Drawing.Point(393, 25);
            this.btnInch.Name = "btnInch";
            this.btnInch.Size = new System.Drawing.Size(143, 37);
            this.btnInch.TabIndex = 2;
            this.btnInch.Text = "Inch";
            this.btnInch.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(758, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(143, 37);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 450);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPixel);
            this.panel1.Controls.Add(this.btnMillimeter);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnInch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 85);
            this.panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 553);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPixel;
        private System.Windows.Forms.Button btnMillimeter;
        private System.Windows.Forms.Button btnInch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

