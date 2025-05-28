namespace Xadrez
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Rainha = new System.Windows.Forms.PictureBox();
            this.Cavalo = new System.Windows.Forms.PictureBox();
            this.Bispo = new System.Windows.Forms.PictureBox();
            this.Torre = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Rainha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cavalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bispo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre)).BeginInit();
            this.SuspendLayout();
            // 
            // Rainha
            // 
            this.Rainha.BackgroundImage = global::Xadrez.Properties.Resources.rainha_branca;
            this.Rainha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rainha.Location = new System.Drawing.Point(19, 21);
            this.Rainha.Name = "Rainha";
            this.Rainha.Size = new System.Drawing.Size(100, 100);
            this.Rainha.TabIndex = 0;
            this.Rainha.TabStop = false;
            this.Rainha.Click += new System.EventHandler(this.CClick);
            // 
            // Cavalo
            // 
            this.Cavalo.BackgroundImage = global::Xadrez.Properties.Resources.cavalo_branco;
            this.Cavalo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cavalo.Location = new System.Drawing.Point(149, 21);
            this.Cavalo.Name = "Cavalo";
            this.Cavalo.Size = new System.Drawing.Size(100, 100);
            this.Cavalo.TabIndex = 1;
            this.Cavalo.TabStop = false;
            this.Cavalo.Click += new System.EventHandler(this.CClick);
            // 
            // Bispo
            // 
            this.Bispo.BackgroundImage = global::Xadrez.Properties.Resources.bispo_branco;
            this.Bispo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bispo.Location = new System.Drawing.Point(279, 21);
            this.Bispo.Name = "Bispo";
            this.Bispo.Size = new System.Drawing.Size(100, 100);
            this.Bispo.TabIndex = 2;
            this.Bispo.TabStop = false;
            this.Bispo.Click += new System.EventHandler(this.CClick);
            // 
            // Torre
            // 
            this.Torre.BackgroundImage = global::Xadrez.Properties.Resources.torre_branca;
            this.Torre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Torre.Location = new System.Drawing.Point(409, 21);
            this.Torre.Name = "Torre";
            this.Torre.Size = new System.Drawing.Size(100, 100);
            this.Torre.TabIndex = 3;
            this.Torre.TabStop = false;
            this.Torre.Click += new System.EventHandler(this.CClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(529, 139);
            this.Controls.Add(this.Torre);
            this.Controls.Add(this.Bispo);
            this.Controls.Add(this.Cavalo);
            this.Controls.Add(this.Rainha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promova seu Peão";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Rainha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cavalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bispo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Torre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Rainha;
        private System.Windows.Forms.PictureBox Cavalo;
        private System.Windows.Forms.PictureBox Bispo;
        private System.Windows.Forms.PictureBox Torre;
    }
}