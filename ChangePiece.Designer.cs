
namespace neko_chess
{
    partial class ChangePiece
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
            this.picQueen = new System.Windows.Forms.PictureBox();
            this.picKnight = new System.Windows.Forms.PictureBox();
            this.picRook = new System.Windows.Forms.PictureBox();
            this.picBishop = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBishop)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picQueen
            // 
            this.picQueen.BackColor = System.Drawing.Color.Transparent;
            this.picQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQueen.InitialImage = null;
            this.picQueen.Location = new System.Drawing.Point(180, 0);
            this.picQueen.Margin = new System.Windows.Forms.Padding(0);
            this.picQueen.Name = "picQueen";
            this.picQueen.Size = new System.Drawing.Size(60, 60);
            this.picQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQueen.TabIndex = 24;
            this.picQueen.TabStop = false;
            this.picQueen.Tag = "2,7";
            this.picQueen.Click += new System.EventHandler(this.Pic_Click);
            // 
            // picKnight
            // 
            this.picKnight.BackColor = System.Drawing.Color.Transparent;
            this.picKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picKnight.InitialImage = null;
            this.picKnight.Location = new System.Drawing.Point(0, 0);
            this.picKnight.Margin = new System.Windows.Forms.Padding(0);
            this.picKnight.Name = "picKnight";
            this.picKnight.Size = new System.Drawing.Size(60, 60);
            this.picKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKnight.TabIndex = 25;
            this.picKnight.TabStop = false;
            this.picKnight.Tag = "2,7";
            this.picKnight.Click += new System.EventHandler(this.Pic_Click);
            // 
            // picRook
            // 
            this.picRook.BackColor = System.Drawing.Color.Transparent;
            this.picRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRook.InitialImage = null;
            this.picRook.Location = new System.Drawing.Point(60, 0);
            this.picRook.Margin = new System.Windows.Forms.Padding(0);
            this.picRook.Name = "picRook";
            this.picRook.Size = new System.Drawing.Size(60, 60);
            this.picRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRook.TabIndex = 26;
            this.picRook.TabStop = false;
            this.picRook.Tag = "2,7";
            this.picRook.Click += new System.EventHandler(this.Pic_Click);
            // 
            // picBishop
            // 
            this.picBishop.BackColor = System.Drawing.Color.Transparent;
            this.picBishop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBishop.InitialImage = null;
            this.picBishop.Location = new System.Drawing.Point(120, 0);
            this.picBishop.Margin = new System.Windows.Forms.Padding(0);
            this.picBishop.Name = "picBishop";
            this.picBishop.Size = new System.Drawing.Size(60, 60);
            this.picBishop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBishop.TabIndex = 27;
            this.picBishop.TabStop = false;
            this.picBishop.Tag = "2,7";
            this.picBishop.Click += new System.EventHandler(this.Pic_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picKnight);
            this.panel1.Controls.Add(this.picQueen);
            this.panel1.Controls.Add(this.picBishop);
            this.panel1.Controls.Add(this.picRook);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 60);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "成る駒を選択して下さい";
            // 
            // ChangePiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(270, 119);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePiece";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "駒選択";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePiece_FormClosing);
            this.Load += new System.EventHandler(this.ChangePiece_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBishop)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picQueen;
        private System.Windows.Forms.PictureBox picKnight;
        private System.Windows.Forms.PictureBox picRook;
        private System.Windows.Forms.PictureBox picBishop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}