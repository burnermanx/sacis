namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class gerenciaMensagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gerenciaMensagem));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mcNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoGeral = new System.Windows.Forms.ToolStripMenuItem();
            this.sair = new System.Windows.Forms.ToolStripMenuItem();
            this.mc_split = new System.Windows.Forms.SplitContainer();
            this.mcTreeview = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mcList = new System.Windows.Forms.ListView();
            this.De = new System.Windows.Forms.ColumnHeader();
            this.Assunto = new System.Windows.Forms.ColumnHeader();
            this.Recebido = new System.Windows.Forms.ColumnHeader();
            this.Tamanho = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.mc_split.Panel1.SuspendLayout();
            this.mc_split.Panel2.SuspendLayout();
            this.mc_split.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcNovo,
            this.catalogoGeral,
            this.sair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(570, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mcNovo
            // 
            this.mcNovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mcNovo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mcNovo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mcNovo.Image = ((System.Drawing.Image)(resources.GetObject("mcNovo.Image")));
            this.mcNovo.Name = "mcNovo";
            this.mcNovo.Size = new System.Drawing.Size(65, 20);
            this.mcNovo.Text = "&Novo";
            this.mcNovo.Click += new System.EventHandler(this.novoClick);
            // 
            // catalogoGeral
            // 
            this.catalogoGeral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.catalogoGeral.Image = ((System.Drawing.Image)(resources.GetObject("catalogoGeral.Image")));
            this.catalogoGeral.Name = "catalogoGeral";
            this.catalogoGeral.Size = new System.Drawing.Size(83, 20);
            this.catalogoGeral.Text = "&Catálogo";
            this.catalogoGeral.Click += new System.EventHandler(this.catalogoGeralClick);
            // 
            // sair
            // 
            this.sair.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.sair.Image = ((System.Drawing.Image)(resources.GetObject("sair.Image")));
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(72, 20);
            this.sair.Text = "&Fechar";
            this.sair.Click += new System.EventHandler(this.sairClick);
            // 
            // mc_split
            // 
            this.mc_split.BackColor = System.Drawing.SystemColors.Window;
            this.mc_split.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mc_split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mc_split.Location = new System.Drawing.Point(0, 24);
            this.mc_split.Name = "mc_split";
            // 
            // mc_split.Panel1
            // 
            this.mc_split.Panel1.Controls.Add(this.mcTreeview);
            // 
            // mc_split.Panel2
            // 
            this.mc_split.Panel2.Controls.Add(this.mcList);
            this.mc_split.Size = new System.Drawing.Size(570, 256);
            this.mc_split.SplitterDistance = 181;
            this.mc_split.TabIndex = 2;
            // 
            // mcTreeview
            // 
            this.mcTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcTreeview.ImageKey = "pasta.jpg";
            this.mcTreeview.ImageList = this.imageList1;
            this.mcTreeview.Location = new System.Drawing.Point(0, 0);
            this.mcTreeview.Name = "mcTreeview";
            this.mcTreeview.SelectedImageIndex = 0;
            this.mcTreeview.Size = new System.Drawing.Size(177, 252);
            this.mcTreeview.TabIndex = 0;
            this.mcTreeview.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mcTreeviewNodeClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pasta.jpg");
            // 
            // mcList
            // 
            this.mcList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.De,
            this.Assunto,
            this.Recebido,
            this.Tamanho});
            this.mcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcList.Location = new System.Drawing.Point(0, 0);
            this.mcList.Name = "mcList";
            this.mcList.Size = new System.Drawing.Size(381, 252);
            this.mcList.SmallImageList = this.imageList1;
            this.mcList.TabIndex = 0;
            this.mcList.UseCompatibleStateImageBehavior = false;
            this.mcList.View = System.Windows.Forms.View.Details;
            this.mcList.DoubleClick += new System.EventHandler(this.duploClick);
            this.mcList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.colunaClick);
            // 
            // De
            // 
            this.De.Text = "De";
            this.De.Width = 124;
            // 
            // Assunto
            // 
            this.Assunto.Text = "Assunto";
            this.Assunto.Width = 82;
            // 
            // Recebido
            // 
            this.Recebido.Text = "Recebido em";
            this.Recebido.Width = 93;
            // 
            // Tamanho
            // 
            this.Tamanho.Text = "Tamanho";
            this.Tamanho.Width = 77;
            // 
            // gerenciaMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 280);
            this.Controls.Add(this.mc_split);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "gerenciaMensagem";
            this.Text = "Projeto S.A.C.I.S. - Gerenciamento de Mensagens";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.apagar);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mc_split.Panel1.ResumeLayout(false);
            this.mc_split.Panel2.ResumeLayout(false);
            this.mc_split.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mcNovo;
        private System.Windows.Forms.ToolStripMenuItem catalogoGeral;
        private System.Windows.Forms.ToolStripMenuItem sair;
        private System.Windows.Forms.SplitContainer mc_split;
        private System.Windows.Forms.TreeView mcTreeview;
        private System.Windows.Forms.ListView mcList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader De;
        private System.Windows.Forms.ColumnHeader Assunto;
        private System.Windows.Forms.ColumnHeader Recebido;
        private System.Windows.Forms.ColumnHeader Tamanho;
    
    }
}