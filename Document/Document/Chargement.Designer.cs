namespace Document
{
    partial class Chargement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chargement));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MyprogressBar = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(183, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "DeveloppedByGroupe6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(101, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "DOCUMENT MANGEMENT SYSTEM";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MyprogressBar
            // 
            this.MyprogressBar.Animated = true;
            this.MyprogressBar.AnimationSpeed = 0.6F;
            this.MyprogressBar.Backwards = true;
            this.MyprogressBar.BaseColor = System.Drawing.Color.White;
            this.MyprogressBar.IdleColor = System.Drawing.Color.Gainsboro;
            this.MyprogressBar.IdleOffset = 20;
            this.MyprogressBar.IdleThickness = 10;
            this.MyprogressBar.Image = ((System.Drawing.Image)(resources.GetObject("MyprogressBar.Image")));
            this.MyprogressBar.ImageSize = new System.Drawing.Size(52, 52);
            this.MyprogressBar.Location = new System.Drawing.Point(164, 57);
            this.MyprogressBar.Name = "MyprogressBar";
            this.MyprogressBar.ProgressMaxColor = System.Drawing.Color.DarkMagenta;
            this.MyprogressBar.ProgressMinColor = System.Drawing.Color.Red;
            this.MyprogressBar.ProgressOffset = 0;
            this.MyprogressBar.ProgressThickness = 15;
            this.MyprogressBar.Size = new System.Drawing.Size(205, 191);
            this.MyprogressBar.TabIndex = 7;
            // 
            // Chargement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(532, 305);
            this.Controls.Add(this.MyprogressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Chargement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chargement";
            this.Load += new System.EventHandler(this.Chargement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI.WinForms.GunaCircleProgressBar MyprogressBar;
    }
}