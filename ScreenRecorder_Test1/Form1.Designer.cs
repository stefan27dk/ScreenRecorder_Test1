namespace ScreenRecorder_Test1
{
    partial class Form1
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
            this.fps_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Player_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Player_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fps_label
            // 
            this.fps_label.AutoSize = true;
            this.fps_label.Location = new System.Drawing.Point(523, 70);
            this.fps_label.Name = "fps_label";
            this.fps_label.Size = new System.Drawing.Size(35, 13);
            this.fps_label.TabIndex = 0;
            this.fps_label.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(523, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Player_pictureBox
            // 
            this.Player_pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Player_pictureBox.Location = new System.Drawing.Point(65, 57);
            this.Player_pictureBox.Name = "Player_pictureBox";
            this.Player_pictureBox.Size = new System.Drawing.Size(397, 289);
            this.Player_pictureBox.TabIndex = 2;
            this.Player_pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Player_pictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fps_label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Player_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fps_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Player_pictureBox;
    }
}

