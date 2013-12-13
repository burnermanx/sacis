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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Caixa de Entrada");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Enviados");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mcNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogo = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoGeralItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoPessoalItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sair = new System.Windows.Forms.ToolStripMenuItem();
            this.mc_split = new System.Windows.Forms.SplitContainer();
            this.mcTreeview = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mensagensGridView = new System.Windows.Forms.DataGridView();
            this.remetente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lixeira = new System.Windows.Forms.DataGridViewImageColumn();
            this.menuStrip1.SuspendLayout();
            this.mc_split.Panel1.SuspendLayout();
            this.mc_split.Panel2.SuspendLayout();
            this.mc_split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mensagensGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcNovo,
            this.catalogo,
            this.sair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(561, 24);
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
            // catalogo
            // 
            this.catalogo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogoGeralItem,
            this.catalogoPessoalItem});
            this.catalogo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.catalogo.Image = ((System.Drawing.Image)(resources.GetObject("catalogo.Image")));
            this.catalogo.Name = "catalogo";
            this.catalogo.Size = new System.Drawing.Size(83, 20);
            this.catalogo.Text = "&Catálogo";
            // 
            // catalogoGeralItem
            // 
            this.catalogoGeralItem.Name = "catalogoGeralItem";
            this.catalogoGeralItem.Size = new System.Drawing.Size(114, 22);
            this.catalogoGeralItem.Text = "Geral";
            this.catalogoGeralItem.Click += new System.EventHandler(this.catalogoGeralItem_Click);
            // 
            // catalogoPessoalItem
            // 
            this.catalogoPessoalItem.Name = "catalogoPessoalItem";
            this.catalogoPessoalItem.Size = new System.Drawing.Size(114, 22);
            this.catalogoPessoalItem.Text = "Pessoal";
            this.catalogoPessoalItem.Click += new System.EventHandler(this.catalogoPessoalItem_Click);
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
            this.mc_split.Panel2.Controls.Add(this.mensagensGridView);
            this.mc_split.Size = new System.Drawing.Size(561, 256);
            this.mc_split.SplitterDistance = 148;
            this.mc_split.TabIndex = 2;
            // 
            // mcTreeview
            // 
            this.mcTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcTreeview.ImageKey = "pasta.jpg";
            this.mcTreeview.ImageList = this.imageList1;
            this.mcTreeview.Location = new System.Drawing.Point(0, 0);
            this.mcTreeview.Name = "mcTreeview";
            treeNode1.Name = "entrada";
            treeNode1.Text = "Caixa de Entrada";
            treeNode2.Name = "enviados";
            treeNode2.Text = "Enviados";
            this.mcTreeview.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.mcTreeview.RightToLeftLayout = true;
            this.mcTreeview.SelectedImageIndex = 0;
            this.mcTreeview.Size = new System.Drawing.Size(144, 252);
            this.mcTreeview.TabIndex = 0;
            this.mcTreeview.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mcTreeviewNodeClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pasta.jpg");
            // 
            // mensagensGridView
            // 
            this.mensagensGridView.AllowUserToAddRows = false;
            this.mensagensGridView.AllowUserToDeleteRows = false;
            this.mensagensGridView.AllowUserToOrderColumns = true;
            this.mensagensGridView.AllowUserToResizeColumns = false;
            this.mensagensGridView.AllowUserToResizeRows = false;
            this.mensagensGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mensagensGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.mensagensGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mensagensGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mensagensGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remetente,
            this.assunto,
            this.data,
            this.tamanho,
            this.id,
            this.Lixeira});
            this.mensagensGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mensagensGridView.GridColor = System.Drawing.SystemColors.Window;
            this.mensagensGridView.Location = new System.Drawing.Point(0, 0);
            this.mensagensGridView.Name = "mensagensGridView";
            this.mensagensGridView.ReadOnly = true;
            this.mensagensGridView.RowHeadersVisible = false;
            this.mensagensGridView.Size = new System.Drawing.Size(405, 252);
            this.mensagensGridView.TabIndex = 0;
            this.mensagensGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mensagensGridView_MouseClick);
            this.mensagensGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mensagensGridView_CellContentDoubleClick);
            // 
            // remetente
            // 
            this.remetente.FillWeight = 86.60805F;
            this.remetente.HeaderText = "Remetente";
            this.remetente.Name = "remetente";
            this.remetente.ReadOnly = true;
            // 
            // assunto
            // 
            this.assunto.FillWeight = 86.60805F;
            this.assunto.HeaderText = "Assunto";
            this.assunto.Name = "assunto";
            this.assunto.ReadOnly = true;
            // 
            // data
            // 
            this.data.FillWeight = 86.60805F;
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            // 
            // tamanho
            // 
            this.tamanho.FillWeight = 86.60805F;
            this.tamanho.HeaderText = "Tamanho";
            this.tamanho.Name = "tamanho";
            this.tamanho.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Lixeira
            // 
            this.Lixeira.FillWeight = 62.23333F;
            this.Lixeira.HeaderText = "";
            this.Lixeira.Image = ((System.Drawing.Image)(resources.GetObject("Lixeira.Image")));
            this.Lixeira.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Lixeira.Name = "Lixeira";
            this.Lixeira.ReadOnly = true;
            this.Lixeira.ToolTipText = "Excluir Mensagem";
            // 
            // gerenciaMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 280);
            this.Controls.Add(this.mc_split);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "gerenciaMensagem";
            this.Text = "Projeto S.A.C.I.S. - Gerenciamento de Mensagens";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mc_split.Panel1.ResumeLayout(false);
            this.mc_split.Panel2.ResumeLayout(false);
            this.mc_split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mensagensGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mcNovo;
        private System.Windows.Forms.ToolStripMenuItem catalogo;
        private System.Windows.Forms.ToolStripMenuItem sair;
        private System.Windows.Forms.SplitContainer mc_split;
        private System.Windows.Forms.TreeView mcTreeview;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem catalogoGeralItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoPessoalItem;
        private System.Windows.Forms.DataGridView mensagensGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn remetente;
        private System.Windows.Forms.DataGridViewTextBoxColumn assunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewImageColumn Lixeira;
    
    }
}