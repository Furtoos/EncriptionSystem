namespace _1_лаба
{
    partial class KeysInspector
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
            this.Key = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Methods_rich = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Review = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // Key
            // 
            this.Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key.Location = new System.Drawing.Point(12, 12);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(214, 30);
            this.Key.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Methods_rich
            // 
            this.Methods_rich.Location = new System.Drawing.Point(232, 12);
            this.Methods_rich.Name = "Methods_rich";
            this.Methods_rich.Size = new System.Drawing.Size(188, 96);
            this.Methods_rich.TabIndex = 2;
            this.Methods_rich.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Check";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Check_Click);
            // 
            // Review
            // 
            this.Review.Location = new System.Drawing.Point(37, 48);
            this.Review.Name = "Review";
            this.Review.Size = new System.Drawing.Size(127, 37);
            this.Review.TabIndex = 4;
            this.Review.Text = "Review";
            this.Review.UseVisualStyleBackColor = true;
            this.Review.Click += new System.EventHandler(this.Review_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // KeysInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 159);
            this.Controls.Add(this.Review);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Methods_rich);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Key);
            this.Name = "KeysInspector";
            this.Text = "KeysInspector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox Methods_rich;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Review;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}