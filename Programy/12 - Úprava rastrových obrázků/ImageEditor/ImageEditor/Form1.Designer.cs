namespace WindowsFormsApplication1
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
            this.hlavniMenu = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otevřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kresleníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tloušťkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.kopírovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.celéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.celéPoBodechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barevnéFiltryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cMYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odstínyŠediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aritmetickýPrůměrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.váženýPrůměrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.černobílýObrázekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obyčejnýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distribuceChybyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateLeft90toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.souměrnostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svisláToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vodorovnáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zOOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.xCeléToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smažVpravoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.od = new System.Windows.Forms.OpenFileDialog();
            this.cd = new System.Windows.Forms.ColorDialog();
            this.hlavniMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // hlavniMenu
            // 
            this.hlavniMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.kresleníToolStripMenuItem,
            this.kopírovatToolStripMenuItem,
            this.barevnéFiltryToolStripMenuItem,
            this.rotaceToolStripMenuItem,
            this.souměrnostiToolStripMenuItem,
            this.zOOMToolStripMenuItem,
            this.smažVpravoToolStripMenuItem});
            this.hlavniMenu.Location = new System.Drawing.Point(0, 0);
            this.hlavniMenu.Name = "hlavniMenu";
            this.hlavniMenu.Size = new System.Drawing.Size(883, 24);
            this.hlavniMenu.TabIndex = 0;
            this.hlavniMenu.Text = "Hlavní menu";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otevřítToolStripMenuItem,
            this.konecToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // otevřítToolStripMenuItem
            // 
            this.otevřítToolStripMenuItem.Name = "otevřítToolStripMenuItem";
            this.otevřítToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.otevřítToolStripMenuItem.Text = "Otevřít";
            this.otevřítToolStripMenuItem.Click += new System.EventHandler(this.otevřítToolStripMenuItem_Click);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // kresleníToolStripMenuItem
            // 
            this.kresleníToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barvaToolStripMenuItem,
            this.tloušťkaToolStripMenuItem});
            this.kresleníToolStripMenuItem.Enabled = false;
            this.kresleníToolStripMenuItem.Name = "kresleníToolStripMenuItem";
            this.kresleníToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.kresleníToolStripMenuItem.Text = "Kreslení";
            // 
            // barvaToolStripMenuItem
            // 
            this.barvaToolStripMenuItem.Name = "barvaToolStripMenuItem";
            this.barvaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.barvaToolStripMenuItem.Text = "Barva";
            this.barvaToolStripMenuItem.Click += new System.EventHandler(this.barvaToolStripMenuItem_Click);
            // 
            // tloušťkaToolStripMenuItem
            // 
            this.tloušťkaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.tloušťkaToolStripMenuItem.Name = "tloušťkaToolStripMenuItem";
            this.tloušťkaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tloušťkaToolStripMenuItem.Text = "Tloušťka čáry";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "1 px";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "2 px";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "3 px";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // kopírovatToolStripMenuItem
            // 
            this.kopírovatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.celéToolStripMenuItem,
            this.celéPoBodechToolStripMenuItem});
            this.kopírovatToolStripMenuItem.Enabled = false;
            this.kopírovatToolStripMenuItem.Name = "kopírovatToolStripMenuItem";
            this.kopírovatToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.kopírovatToolStripMenuItem.Text = "Kopírovat";
            // 
            // celéToolStripMenuItem
            // 
            this.celéToolStripMenuItem.Name = "celéToolStripMenuItem";
            this.celéToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.celéToolStripMenuItem.Text = "Rychlé";
            this.celéToolStripMenuItem.Click += new System.EventHandler(this.celéToolStripMenuItem_Click);
            // 
            // celéPoBodechToolStripMenuItem
            // 
            this.celéPoBodechToolStripMenuItem.Name = "celéPoBodechToolStripMenuItem";
            this.celéPoBodechToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.celéPoBodechToolStripMenuItem.Text = "Po bodech";
            this.celéPoBodechToolStripMenuItem.Click += new System.EventHandler(this.celéPoBodechToolStripMenuItem_Click);
            // 
            // barevnéFiltryToolStripMenuItem
            // 
            this.barevnéFiltryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBToolStripMenuItem,
            this.cMYToolStripMenuItem,
            this.odstínyŠediToolStripMenuItem,
            this.černobílýObrázekToolStripMenuItem,
            this.negativToolStripMenuItem});
            this.barevnéFiltryToolStripMenuItem.Enabled = false;
            this.barevnéFiltryToolStripMenuItem.Name = "barevnéFiltryToolStripMenuItem";
            this.barevnéFiltryToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.barevnéFiltryToolStripMenuItem.Text = "Barevné filtry";
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rToolStripMenuItem,
            this.bToolStripMenuItem,
            this.bToolStripMenuItem1});
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.rGBToolStripMenuItem.Text = "RGB";
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.rToolStripMenuItem.Text = "R";
            this.rToolStripMenuItem.Click += new System.EventHandler(this.rToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.bToolStripMenuItem.Text = "G";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem1
            // 
            this.bToolStripMenuItem1.Name = "bToolStripMenuItem1";
            this.bToolStripMenuItem1.Size = new System.Drawing.Size(82, 22);
            this.bToolStripMenuItem1.Text = "B";
            this.bToolStripMenuItem1.Click += new System.EventHandler(this.bToolStripMenuItem1_Click);
            // 
            // cMYToolStripMenuItem
            // 
            this.cMYToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem,
            this.mToolStripMenuItem,
            this.yToolStripMenuItem});
            this.cMYToolStripMenuItem.Name = "cMYToolStripMenuItem";
            this.cMYToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cMYToolStripMenuItem.Text = "CMY";
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.cToolStripMenuItem.Text = "C";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // mToolStripMenuItem
            // 
            this.mToolStripMenuItem.Name = "mToolStripMenuItem";
            this.mToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.mToolStripMenuItem.Text = "M";
            this.mToolStripMenuItem.Click += new System.EventHandler(this.mToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // odstínyŠediToolStripMenuItem
            // 
            this.odstínyŠediToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aritmetickýPrůměrToolStripMenuItem,
            this.váženýPrůměrToolStripMenuItem});
            this.odstínyŠediToolStripMenuItem.Name = "odstínyŠediToolStripMenuItem";
            this.odstínyŠediToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.odstínyŠediToolStripMenuItem.Text = "Odstíny šedi";
            // 
            // aritmetickýPrůměrToolStripMenuItem
            // 
            this.aritmetickýPrůměrToolStripMenuItem.Name = "aritmetickýPrůměrToolStripMenuItem";
            this.aritmetickýPrůměrToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.aritmetickýPrůměrToolStripMenuItem.Text = "Aritmetický průměr";
            this.aritmetickýPrůměrToolStripMenuItem.Click += new System.EventHandler(this.aritmetickýPrůměrToolStripMenuItem_Click);
            // 
            // váženýPrůměrToolStripMenuItem
            // 
            this.váženýPrůměrToolStripMenuItem.Name = "váženýPrůměrToolStripMenuItem";
            this.váženýPrůměrToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.váženýPrůměrToolStripMenuItem.Text = "Vážený průměr (správně)";
            this.váženýPrůměrToolStripMenuItem.Click += new System.EventHandler(this.váženýPrůměrToolStripMenuItem_Click);
            // 
            // černobílýObrázekToolStripMenuItem
            // 
            this.černobílýObrázekToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obyčejnýToolStripMenuItem,
            this.distribuceChybyToolStripMenuItem});
            this.černobílýObrázekToolStripMenuItem.Name = "černobílýObrázekToolStripMenuItem";
            this.černobílýObrázekToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.černobílýObrázekToolStripMenuItem.Text = "Černobílý obrázek";
            // 
            // obyčejnýToolStripMenuItem
            // 
            this.obyčejnýToolStripMenuItem.Name = "obyčejnýToolStripMenuItem";
            this.obyčejnýToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.obyčejnýToolStripMenuItem.Text = "Obyčejný";
            this.obyčejnýToolStripMenuItem.Click += new System.EventHandler(this.obyčejnýToolStripMenuItem_Click);
            // 
            // distribuceChybyToolStripMenuItem
            // 
            this.distribuceChybyToolStripMenuItem.Name = "distribuceChybyToolStripMenuItem";
            this.distribuceChybyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.distribuceChybyToolStripMenuItem.Text = "Distribuce chyby";
            this.distribuceChybyToolStripMenuItem.Click += new System.EventHandler(this.distribuceChybyToolStripMenuItem_Click);
            // 
            // negativToolStripMenuItem
            // 
            this.negativToolStripMenuItem.Name = "negativToolStripMenuItem";
            this.negativToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.negativToolStripMenuItem.Text = "Negativ";
            this.negativToolStripMenuItem.Click += new System.EventHandler(this.negativToolStripMenuItem_Click);
            // 
            // rotaceToolStripMenuItem
            // 
            this.rotaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateLeft90toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.rotaceToolStripMenuItem.Enabled = false;
            this.rotaceToolStripMenuItem.Name = "rotaceToolStripMenuItem";
            this.rotaceToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.rotaceToolStripMenuItem.Text = "Rotace";
            // 
            // rotateLeft90toolStripMenuItem5
            // 
            this.rotateLeft90toolStripMenuItem5.Name = "rotateLeft90toolStripMenuItem5";
            this.rotateLeft90toolStripMenuItem5.Size = new System.Drawing.Size(109, 22);
            this.rotateLeft90toolStripMenuItem5.Text = "+ 90 °";
            this.rotateLeft90toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem6.Text = "–  90 °";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem7.Text = "   180 °";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // souměrnostiToolStripMenuItem
            // 
            this.souměrnostiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.svisláToolStripMenuItem,
            this.vodorovnáToolStripMenuItem});
            this.souměrnostiToolStripMenuItem.Enabled = false;
            this.souměrnostiToolStripMenuItem.Name = "souměrnostiToolStripMenuItem";
            this.souměrnostiToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.souměrnostiToolStripMenuItem.Text = "Souměrnosti";
            // 
            // svisláToolStripMenuItem
            // 
            this.svisláToolStripMenuItem.Name = "svisláToolStripMenuItem";
            this.svisláToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.svisláToolStripMenuItem.Text = "Svislá";
            this.svisláToolStripMenuItem.Click += new System.EventHandler(this.svosláToolStripMenuItem_Click);
            // 
            // vodorovnáToolStripMenuItem
            // 
            this.vodorovnáToolStripMenuItem.Name = "vodorovnáToolStripMenuItem";
            this.vodorovnáToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.vodorovnáToolStripMenuItem.Text = "Vodorovná";
            this.vodorovnáToolStripMenuItem.Click += new System.EventHandler(this.vodorovnáToolStripMenuItem_Click);
            // 
            // zOOMToolStripMenuItem
            // 
            this.zOOMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.xCeléToolStripMenuItem,
            this.xToolStripMenuItem});
            this.zOOMToolStripMenuItem.Enabled = false;
            this.zOOMToolStripMenuItem.Name = "zOOMToolStripMenuItem";
            this.zOOMToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.zOOMToolStripMenuItem.Text = "Zoom";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem8.Text = "1/2";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // xCeléToolStripMenuItem
            // 
            this.xCeléToolStripMenuItem.Name = "xCeléToolStripMenuItem";
            this.xCeléToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.xCeléToolStripMenuItem.Text = "2x celé";
            this.xCeléToolStripMenuItem.Click += new System.EventHandler(this.xCeléToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lHToolStripMenuItem,
            this.pHToolStripMenuItem,
            this.lDToolStripMenuItem,
            this.pDToolStripMenuItem});
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.xToolStripMenuItem.Text = "2x čtvrtinu";
            // 
            // lHToolStripMenuItem
            // 
            this.lHToolStripMenuItem.Name = "lHToolStripMenuItem";
            this.lHToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.lHToolStripMenuItem.Text = "LH";
            this.lHToolStripMenuItem.Click += new System.EventHandler(this.lHToolStripMenuItem_Click);
            // 
            // pHToolStripMenuItem
            // 
            this.pHToolStripMenuItem.Name = "pHToolStripMenuItem";
            this.pHToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.pHToolStripMenuItem.Text = "PH";
            this.pHToolStripMenuItem.Click += new System.EventHandler(this.pHToolStripMenuItem_Click);
            // 
            // lDToolStripMenuItem
            // 
            this.lDToolStripMenuItem.Name = "lDToolStripMenuItem";
            this.lDToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.lDToolStripMenuItem.Text = "LD";
            this.lDToolStripMenuItem.Click += new System.EventHandler(this.lDToolStripMenuItem_Click);
            // 
            // pDToolStripMenuItem
            // 
            this.pDToolStripMenuItem.Name = "pDToolStripMenuItem";
            this.pDToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.pDToolStripMenuItem.Text = "PD";
            this.pDToolStripMenuItem.Click += new System.EventHandler(this.pDToolStripMenuItem_Click);
            // 
            // smažVpravoToolStripMenuItem
            // 
            this.smažVpravoToolStripMenuItem.Name = "smažVpravoToolStripMenuItem";
            this.smažVpravoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.smažVpravoToolStripMenuItem.Text = "Smaž vpravo";
            this.smažVpravoToolStripMenuItem.Click += new System.EventHandler(this.smažVpravoToolStripMenuItem_Click);
            // 
            // od
            // 
            this.od.DefaultExt = "*.jpg";
            this.od.Filter = "Obrázky|*.jpg;*.bmp;*.png;*.jpeg;*.gif;*.tiff";
            this.od.Title = "Otevřít obrázek";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 476);
            this.Controls.Add(this.hlavniMenu);
            this.MainMenuStrip = this.hlavniMenu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Editor obrázků";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.hlavniMenu.ResumeLayout(false);
            this.hlavniMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip hlavniMenu;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otevřítToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog od;
        private System.Windows.Forms.ToolStripMenuItem kopírovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem celéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem celéPoBodechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smažVpravoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barevnéFiltryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kresleníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tloušťkaToolStripMenuItem;
        private System.Windows.Forms.ColorDialog cd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cMYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odstínyŠediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aritmetickýPrůměrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem váženýPrůměrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem černobílýObrázekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obyčejnýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distribuceChybyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateLeft90toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem souměrnostiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem svisláToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vodorovnáToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zOOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xCeléToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativToolStripMenuItem;
    }
}

