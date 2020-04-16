namespace Pcelarstvo
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.UnosPodataka = new System.Windows.Forms.Button();
            this.ProvjeraStanja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UnosPodataka
            // 
            this.UnosPodataka.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnosPodataka.Location = new System.Drawing.Point(245, 353);
            this.UnosPodataka.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.UnosPodataka.Name = "UnosPodataka";
            this.UnosPodataka.Size = new System.Drawing.Size(319, 61);
            this.UnosPodataka.TabIndex = 0;
            this.UnosPodataka.Text = "Unos Podataka";
            this.UnosPodataka.UseVisualStyleBackColor = true;
            this.UnosPodataka.Click += new System.EventHandler(this.UnosPodataka_Click);
            // 
            // ProvjeraStanja
            // 
            this.ProvjeraStanja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProvjeraStanja.Location = new System.Drawing.Point(583, 353);
            this.ProvjeraStanja.Name = "ProvjeraStanja";
            this.ProvjeraStanja.Size = new System.Drawing.Size(319, 61);
            this.ProvjeraStanja.TabIndex = 1;
            this.ProvjeraStanja.Text = "Provjera stanja";
            this.ProvjeraStanja.UseVisualStyleBackColor = true;
            this.ProvjeraStanja.Click += new System.EventHandler(this.ProvjeraStanja_Click_1);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pcelarstvo.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1145, 494);
            this.Controls.Add(this.ProvjeraStanja);
            this.Controls.Add(this.UnosPodataka);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScreen";
            this.Text = "Evidencija Pcelarstva: Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UnosPodataka;
        private System.Windows.Forms.Button ProvjeraStanja;
    }
}