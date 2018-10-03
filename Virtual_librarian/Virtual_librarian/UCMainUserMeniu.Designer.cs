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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.mtbPasiimti = new MetroFramework.Controls.MetroTabPage();
            this.mtbKnyguKatalogas = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblNaudotojoVardas = new MetroFramework.Controls.MetroLabel();
            this.btnAtsijungti = new MetroFramework.Controls.MetroTile();
            this.grdAllBooks = new MetroFramework.Controls.MetroGrid();
            this.ucScanBook1 = new Virtual_librarian.UCScanBook();
            this.metroTabControl1.SuspendLayout();
            this.mtbPasiimti.SuspendLayout();
            this.mtbKnyguKatalogas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllBooks)).BeginInit();
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
            this.mtbPasiimti.Controls.Add(this.ucScanBook1);
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
            this.mtbKnyguKatalogas.Controls.Add(this.grdAllBooks);
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
            // grdAllBooks
            // 
            this.grdAllBooks.AllowUserToDeleteRows = false;
            this.grdAllBooks.AllowUserToResizeRows = false;
            this.grdAllBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAllBooks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdAllBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdAllBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdAllBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAllBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdAllBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAllBooks.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdAllBooks.EnableHeadersVisualStyles = false;
            this.grdAllBooks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdAllBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdAllBooks.Location = new System.Drawing.Point(3, 3);
            this.grdAllBooks.Name = "grdAllBooks";
            this.grdAllBooks.ReadOnly = true;
            this.grdAllBooks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAllBooks.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdAllBooks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAllBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAllBooks.Size = new System.Drawing.Size(663, 258);
            this.grdAllBooks.TabIndex = 2;
            // 
            // ucScanBook1
            // 
            this.ucScanBook1.Location = new System.Drawing.Point(3, 11);
            this.ucScanBook1.Name = "ucScanBook1";
            this.ucScanBook1.Size = new System.Drawing.Size(650, 250);
            this.ucScanBook1.TabIndex = 2;
            this.ucScanBook1.UseSelectable = true;
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
            this.mtbPasiimti.ResumeLayout(false);
            this.mtbKnyguKatalogas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllBooks)).EndInit();
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
        private MetroFramework.Controls.MetroGrid grdAllBooks;
        private UCScanBook ucScanBook1;
    }
}
