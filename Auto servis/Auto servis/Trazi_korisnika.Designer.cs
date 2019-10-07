namespace Auto_servis
{
    partial class Trazi_korisnika
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trazi_korisnika));
            this.rbTraziKor = new System.Windows.Forms.RadioButton();
            this.rbTraziAuto = new System.Windows.Forms.RadioButton();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbTraziKor
            // 
            this.rbTraziKor.AutoSize = true;
            this.rbTraziKor.Checked = true;
            this.rbTraziKor.Location = new System.Drawing.Point(18, 23);
            this.rbTraziKor.Name = "rbTraziKor";
            this.rbTraziKor.Size = new System.Drawing.Size(109, 17);
            this.rbTraziKor.TabIndex = 1;
            this.rbTraziKor.TabStop = true;
            this.rbTraziKor.Text = "Trazi po Korisniku";
            this.rbTraziKor.UseVisualStyleBackColor = true;
            this.rbTraziKor.CheckedChanged += new System.EventHandler(this.rbTraziKor_CheckedChanged);
            // 
            // rbTraziAuto
            // 
            this.rbTraziAuto.AutoSize = true;
            this.rbTraziAuto.Location = new System.Drawing.Point(133, 23);
            this.rbTraziAuto.Name = "rbTraziAuto";
            this.rbTraziAuto.Size = new System.Drawing.Size(88, 17);
            this.rbTraziAuto.TabIndex = 2;
            this.rbTraziAuto.TabStop = true;
            this.rbTraziAuto.Text = "Trazi po Autu";
            this.rbTraziAuto.UseVisualStyleBackColor = true;
            this.rbTraziAuto.CheckedChanged += new System.EventHandler(this.rbTraziAuto_CheckedChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(227, 20);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 20);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(885, 208);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Trazi_korisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(867, 464);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.rbTraziAuto);
            this.Controls.Add(this.rbTraziKor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Trazi_korisnika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trazi korisnika";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Trazi_korisnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.RadioButton rbTraziKor;
        public System.Windows.Forms.RadioButton rbTraziAuto;
    }
}