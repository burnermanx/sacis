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
            this.mc_novo = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sair = new System.Windows.Forms.ToolStripMenuItem();
            this.mc_split = new System.Windows.Forms.SplitContainer();
            this.mc_treeview = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mc_list = new System.Windows.Forms.ListView();
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
            this.mc_novo,
            this.opçõesToolStripMenuItem,
            this.sair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(570, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mc_novo
            // 
            this.mc_novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mc_novo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mc_novo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mc_novo.Image = ((System.Drawing.Image)(resources.GetObject("mc_novo.Image")));
            this.mc_novo.Name = "mc_novo";
            this.mc_novo.Size = new System.Drawing.Size(65, 20);
            this.mc_novo.Text = "&Novo";
            this.mc_novo.Click += new System.EventHandler(this.novo_Click);
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.opçõesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("opçõesToolStripMenuItem.Image")));
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.opçõesToolStripMenuItem.Text = "&Catálogo";
            // 
            // sair
            // 
            this.sair.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.sair.Image = ((System.Drawing.Image)(resources.GetObject("sair.Image")));
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(72, 20);
            this.sair.Text = "&Fechar";
            this.sair.Click += new System.EventHandler(this.sair_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sair_Click);
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
            this.mc_split.Panel1.Controls.Add(this.mc_treeview);
            // 
            // mc_split.Panel2
            // 
            this.mc_split.Panel2.Controls.Add(this.mc_list);
            this.mc_split.Size = new System.Drawing.Size(570, 256);
            this.mc_split.SplitterDistance = 181;
            this.mc_split.TabIndex = 2;
            // 
            // mc_treeview
            // 
            this.mc_treeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mc_treeview.ImageKey = "pasta.jpg";
            this.mc_treeview.ImageList = this.imageList1;
            this.mc_treeview.Location = new System.Drawing.Point(0, 0);
            this.mc_treeview.Name = "mc_treeview";
            this.mc_treeview.SelectedImageIndex = 0;
            this.mc_treeview.Size = new System.Drawing.Size(177, 252);
            this.mc_treeview.TabIndex = 0;
            this.mc_treeview.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mc_treeview_node_click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pasta.jpg");
            // 
            // mc_list
            // 
            this.mc_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.De,
            this.Assunto,
            this.Recebido,
            this.Tamanho});
            this.mc_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mc_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mc_list.Location = new System.Drawing.Point(0, 0);
            this.mc_list.Name = "mc_list";
            this.mc_list.Size = new System.Drawing.Size(381, 252);
            this.mc_list.SmallImageList = this.imageList1;
            this.mc_list.TabIndex = 0;
            this.mc_list.UseCompatibleStateImageBehavior = false;
            this.mc_list.View = System.Windows.Forms.View.Details;
            this.mc_list.DoubleClick += new System.EventHandler(this.duplo_click);
            this.mc_list.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.coluna_click);
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
        private System.Windows.Forms.ToolStripMenuItem mc_novo;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sair;
        private System.Windows.Forms.SplitContainer mc_split;
        private System.Windows.Forms.TreeView mc_treeview;
        private System.Windows.Forms.ListView mc_list;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader De;
        private System.Windows.Forms.ColumnHeader Assunto;
        private System.Windows.Forms.ColumnHeader Recebido;
        private System.Windows.Forms.ColumnHeader Tamanho;
    
    }
}