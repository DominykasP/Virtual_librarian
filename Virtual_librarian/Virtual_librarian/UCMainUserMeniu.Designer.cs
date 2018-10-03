namespace Virtual_librarian
{
    partial class UCMainUserMeniu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.mtbPasiimti = new MetroFramework.Controls.MetroTabPage();
            this.mtbKnyguKatalogas = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblNaudotojoVardas = new MetroFramework.Controls.MetroLabel();
            this.btnAtsijungti = new MetroFramework.Controls.MetroTile();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.mtbPasiimti);
            this.metroTabControl1.Controls.Add(this.mtbKnyguKatalogas);
            this.metroTabControl1.Location = new System.Drawing.Point(3, 36);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(677, 306);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // mtbPasiimti
            // 
            this.mtbPasiimti.HorizontalScrollbarBarColor = true;
            this.mtbPasiimti.HorizontalScrollbarHighlightOnWheel = false;
            this.mtbPasiimti.HorizontalScrollbarSize = 10;
            this.mtbPasiimti.Location = new System.Drawing.Point(4, 38);
            this.mtbPasiimti.Name = "mtbPasiimti";
            this.mtbPasiimti.Size = new System.Drawing.Size(669, 264);
            this.mtbPasiimti.TabIndex = 0;
            this.mtbPasiimti.Text = "Pasiimti/Grąžinti knygą";
            this.mtbPasiimti.VerticalScrollbarBarColor = true;
            this.mtbPasiimti.VerticalScrollbarHighlightOnWheel = false;
            this.mtbPasiimti.VerticalScrollbarSize = 10;
            // 
            // mtbKnyguKatalogas
            // 
            this.mtbKnyguKatalogas.HorizontalScrollbarBarColor = true;
            this.mtbKnyguKatalogas.HorizontalScrollbarHighlightOnWheel = false;
            this.mtbKnyguKatalogas.HorizontalScrollbarSize = 10;
            this.mtbKnyguKatalogas.Location = new System.Drawing.Point(4, 38);
            this.mtbKnyguKatalogas.Name = "mtbKnyguKatalogas";
            this.mtbKnyguKatalogas.Size = new System.Drawing.Size(669, 264);
            this.mtbKnyguKatalogas.TabIndex = 1;
            this.mtbKnyguKatalogas.Text = "Knygų katalogas";
            this.mtbKnyguKatalogas.VerticalScrollbarBarColor = true;
            this.mtbKnyguKatalogas.VerticalScrollbarHighlightOnWheel = false;
            this.mtbKnyguKatalogas.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(7, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(141, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Prisijungęs naudotojas:";
            // 
            // lblNaudotojoVardas
            // 
            this.lblNaudotojoVardas.AutoSize = true;
            this.lblNaudotojoVardas.Location = new System.Drawing.Point(155, 3);
            this.lblNaudotojoVardas.Name = "lblNaudotojoVardas";
            this.lblNaudotojoVardas.Size = new System.Drawing.Size(55, 19);
            this.lblNaudotojoVardas.TabIndex = 2;
            this.lblNaudotojoVardas.Text = "[vardas]";
            // 
            // btnAtsijungti
            // 
            this.btnAtsijungti.ActiveControl = null;
            this.btnAtsijungti.Location = new System.Drawing.Point(537, 3);
            this.btnAtsijungti.Name = "btnAtsijungti";
            this.btnAtsijungti.Size = new System.Drawing.Size(146, 38);
            this.btnAtsijungti.TabIndex = 3;
            this.btnAtsijungti.Text = "Atsijungti";
            this.btnAtsijungti.UseSelectable = true;
            this.btnAtsijungti.Click += new System.EventHandler(this.btnAtsijungti_Click);
            // 
            // UCMainUserMeniu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAtsijungti);
            this.Controls.Add(this.lblNaudotojoVardas);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "UCMainUserMeniu";
            this.Size = new System.Drawing.Size(683, 345);
            this.Load += new System.EventHandler(this.UCMainUserMeniu_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage mtbPasiimti;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel lblNaudotojoVardas;
        private MetroFramework.Controls.MetroTile btnAtsijungti;
        private MetroFramework.Controls.MetroTabPage mtbKnyguKatalogas;
    }
}
