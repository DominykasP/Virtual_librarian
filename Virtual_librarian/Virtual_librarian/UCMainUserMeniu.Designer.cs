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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.mtbPasiimti = new MetroFramework.Controls.MetroTabPage();
            this.ucScanBook1 = new Virtual_librarian.UCScanBook();
            this.mtbTerminai = new MetroFramework.Controls.MetroTabPage();
            this.grdTerminai = new MetroFramework.Controls.MetroGrid();
            this.mtbKnyguKatalogas = new MetroFramework.Controls.MetroTabPage();
            this.grdAllBooks = new MetroFramework.Controls.MetroGrid();
            this.mtbManoUžklausos = new MetroFramework.Controls.MetroTabPage();
            this.btnSiustiManoUzklausas = new MetroFramework.Controls.MetroTile();
            this.grdManoUzklausos = new MetroFramework.Controls.MetroGrid();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblNaudotojoVardas = new MetroFramework.Controls.MetroLabel();
            this.btnAtsijungti = new MetroFramework.Controls.MetroTile();
            this.metroTabControl1.SuspendLayout();
            this.mtbPasiimti.SuspendLayout();
            this.mtbTerminai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTerminai)).BeginInit();
            this.mtbKnyguKatalogas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllBooks)).BeginInit();
            this.mtbManoUžklausos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdManoUzklausos)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.mtbPasiimti);
            this.metroTabControl1.Controls.Add(this.mtbTerminai);
            this.metroTabControl1.Controls.Add(this.mtbKnyguKatalogas);
            this.metroTabControl1.Controls.Add(this.mtbManoUžklausos);
            this.metroTabControl1.Location = new System.Drawing.Point(3, 36);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(677, 309);
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
            this.mtbPasiimti.Size = new System.Drawing.Size(669, 267);
            this.mtbPasiimti.TabIndex = 0;
            this.mtbPasiimti.Text = "Pasiimti/Grąžinti knygą";
            this.mtbPasiimti.VerticalScrollbarBarColor = true;
            this.mtbPasiimti.VerticalScrollbarHighlightOnWheel = false;
            this.mtbPasiimti.VerticalScrollbarSize = 10;
            // 
            // ucScanBook1
            // 
            this.ucScanBook1.Location = new System.Drawing.Point(3, 11);
            this.ucScanBook1.Margin = new System.Windows.Forms.Padding(7);
            this.ucScanBook1.Name = "ucScanBook1";
            this.ucScanBook1.Size = new System.Drawing.Size(650, 250);
            this.ucScanBook1.TabIndex = 2;
            this.ucScanBook1.UseSelectable = true;
            this.ucScanBook1.Load += new System.EventHandler(this.ucScanBook1_Load_1);
            // 
            // mtbTerminai
            // 
            this.mtbTerminai.Controls.Add(this.grdTerminai);
            this.mtbTerminai.HorizontalScrollbarBarColor = true;
            this.mtbTerminai.HorizontalScrollbarHighlightOnWheel = false;
            this.mtbTerminai.HorizontalScrollbarSize = 10;
            this.mtbTerminai.Location = new System.Drawing.Point(4, 38);
            this.mtbTerminai.Name = "mtbTerminai";
            this.mtbTerminai.Size = new System.Drawing.Size(669, 267);
            this.mtbTerminai.TabIndex = 3;
            this.mtbTerminai.Text = "Patikrinti terminus";
            this.mtbTerminai.VerticalScrollbarBarColor = true;
            this.mtbTerminai.VerticalScrollbarHighlightOnWheel = false;
            this.mtbTerminai.VerticalScrollbarSize = 10;
            // 
            // grdTerminai
            // 
            this.grdTerminai.AllowUserToAddRows = false;
            this.grdTerminai.AllowUserToDeleteRows = false;
            this.grdTerminai.AllowUserToResizeRows = false;
            this.grdTerminai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTerminai.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTerminai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdTerminai.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdTerminai.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTerminai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTerminai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTerminai.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdTerminai.EnableHeadersVisualStyles = false;
            this.grdTerminai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdTerminai.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTerminai.Location = new System.Drawing.Point(3, 3);
            this.grdTerminai.Name = "grdTerminai";
            this.grdTerminai.ReadOnly = true;
            this.grdTerminai.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTerminai.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdTerminai.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdTerminai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTerminai.Size = new System.Drawing.Size(663, 258);
            this.grdTerminai.TabIndex = 2;
            this.grdTerminai.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTerminai_CellDoubleClick);
            this.grdTerminai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdTerminai_KeyPress);
            // 
            // mtbKnyguKatalogas
            // 
            this.mtbKnyguKatalogas.Controls.Add(this.grdAllBooks);
            this.mtbKnyguKatalogas.HorizontalScrollbarBarColor = true;
            this.mtbKnyguKatalogas.HorizontalScrollbarHighlightOnWheel = false;
            this.mtbKnyguKatalogas.HorizontalScrollbarSize = 10;
            this.mtbKnyguKatalogas.Location = new System.Drawing.Point(4, 38);
            this.mtbKnyguKatalogas.Name = "mtbKnyguKatalogas";
            this.mtbKnyguKatalogas.Size = new System.Drawing.Size(669, 267);
            this.mtbKnyguKatalogas.TabIndex = 1;
            this.mtbKnyguKatalogas.Text = "Knygų katalogas";
            this.mtbKnyguKatalogas.VerticalScrollbarBarColor = true;
            this.mtbKnyguKatalogas.VerticalScrollbarHighlightOnWheel = false;
            this.mtbKnyguKatalogas.VerticalScrollbarSize = 10;
            // 
            // grdAllBooks
            // 
            this.grdAllBooks.AllowUserToAddRows = false;
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
            this.grdAllBooks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllBooks_CellDoubleClick);
            this.grdAllBooks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdAllBooks_KeyPress);
            // 
            // mtbManoUžklausos
            // 
            this.mtbManoUžklausos.Controls.Add(this.btnSiustiManoUzklausas);
            this.mtbManoUžklausos.Controls.Add(this.grdManoUzklausos);
            this.mtbManoUžklausos.HorizontalScrollbarBarColor = true;
            this.mtbManoUžklausos.HorizontalScrollbarHighlightOnWheel = false;
            this.mtbManoUžklausos.HorizontalScrollbarSize = 10;
            this.mtbManoUžklausos.Location = new System.Drawing.Point(4, 38);
            this.mtbManoUžklausos.Name = "mtbManoUžklausos";
            this.mtbManoUžklausos.Size = new System.Drawing.Size(669, 267);
            this.mtbManoUžklausos.TabIndex = 2;
            this.mtbManoUžklausos.Text = "Mano užklausos";
            this.mtbManoUžklausos.VerticalScrollbarBarColor = true;
            this.mtbManoUžklausos.VerticalScrollbarHighlightOnWheel = false;
            this.mtbManoUžklausos.VerticalScrollbarSize = 10;
            // 
            // btnSiustiManoUzklausas
            // 
            this.btnSiustiManoUzklausas.ActiveControl = null;
            this.btnSiustiManoUzklausas.Location = new System.Drawing.Point(3, 230);
            this.btnSiustiManoUzklausas.Name = "btnSiustiManoUzklausas";
            this.btnSiustiManoUzklausas.Size = new System.Drawing.Size(240, 38);
            this.btnSiustiManoUzklausas.TabIndex = 4;
            this.btnSiustiManoUzklausas.Text = "Siųsti mano užklausas bibliotekininkei";
            this.btnSiustiManoUzklausas.UseSelectable = true;
            this.btnSiustiManoUzklausas.Click += new System.EventHandler(this.btnSiustiManoUzklausas_Click);
            // 
            // grdManoUzklausos
            // 
            this.grdManoUzklausos.AllowUserToAddRows = false;
            this.grdManoUzklausos.AllowUserToDeleteRows = false;
            this.grdManoUzklausos.AllowUserToResizeRows = false;
            this.grdManoUzklausos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdManoUzklausos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdManoUzklausos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdManoUzklausos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdManoUzklausos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdManoUzklausos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdManoUzklausos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdManoUzklausos.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdManoUzklausos.EnableHeadersVisualStyles = false;
            this.grdManoUzklausos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdManoUzklausos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdManoUzklausos.Location = new System.Drawing.Point(3, 3);
            this.grdManoUzklausos.Name = "grdManoUzklausos";
            this.grdManoUzklausos.ReadOnly = true;
            this.grdManoUzklausos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdManoUzklausos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdManoUzklausos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdManoUzklausos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdManoUzklausos.Size = new System.Drawing.Size(663, 220);
            this.grdManoUzklausos.TabIndex = 2;
            this.grdManoUzklausos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdManoUzklausos_CellDoubleClick);
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
            this.mtbPasiimti.ResumeLayout(false);
            this.mtbTerminai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTerminai)).EndInit();
            this.mtbKnyguKatalogas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllBooks)).EndInit();
            this.mtbManoUžklausos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdManoUzklausos)).EndInit();
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
        private MetroFramework.Controls.MetroTabPage mtbManoUžklausos;
        private MetroFramework.Controls.MetroGrid grdManoUzklausos;
        private MetroFramework.Controls.MetroTile btnSiustiManoUzklausas;
        private MetroFramework.Controls.MetroTabPage mtbTerminai;
        private MetroFramework.Controls.MetroGrid grdTerminai;
    }
}
