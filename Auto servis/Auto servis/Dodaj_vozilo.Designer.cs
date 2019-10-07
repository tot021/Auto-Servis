namespace Auto_servis
{
    partial class Dodaj_vozilo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dodaj_vozilo));
            this.btnMarka = new System.Windows.Forms.Button();
            this.cbMarka = new System.Windows.Forms.ComboBox();
            this.tbMarka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModel = new System.Windows.Forms.Button();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tmLoad = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTip = new System.Windows.Forms.ComboBox();
            this.btnTip = new System.Windows.Forms.Button();
            this.tbTip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGod = new System.Windows.Forms.Button();
            this.cbGodiste = new System.Windows.Forms.ComboBox();
            this.tbGodiste = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.TransakcijaMarka = new System.Windows.Forms.ErrorProvider(this.components);
            this.TransakcijaModel = new System.Windows.Forms.ErrorProvider(this.components);
            this.TransakcijaTip = new System.Windows.Forms.ErrorProvider(this.components);
            this.TransakcijaGodina = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaMarka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaGodina)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMarka
            // 
            this.btnMarka.Enabled = false;
            this.btnMarka.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarka.Location = new System.Drawing.Point(13, 101);
            this.btnMarka.Name = "btnMarka";
            this.btnMarka.Size = new System.Drawing.Size(87, 26);
            this.btnMarka.TabIndex = 3;
            this.btnMarka.Text = "Unesi marku";
            this.btnMarka.UseVisualStyleBackColor = true;
            this.btnMarka.Click += new System.EventHandler(this.btnMarka_Click);
            // 
            // cbMarka
            // 
            this.cbMarka.DropDownHeight = 80;
            this.cbMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarka.FormattingEnabled = true;
            this.cbMarka.IntegralHeight = false;
            this.cbMarka.Location = new System.Drawing.Point(13, 27);
            this.cbMarka.MaxDropDownItems = 100;
            this.cbMarka.Name = "cbMarka";
            this.cbMarka.Size = new System.Drawing.Size(100, 21);
            this.cbMarka.TabIndex = 1;
            this.cbMarka.SelectedIndexChanged += new System.EventHandler(this.cbMarka_SelectedIndexChanged);
            // 
            // tbMarka
            // 
            this.tbMarka.Location = new System.Drawing.Point(13, 65);
            this.tbMarka.Name = "tbMarka";
            this.tbMarka.Size = new System.Drawing.Size(100, 20);
            this.tbMarka.TabIndex = 2;
            this.tbMarka.TextChanged += new System.EventHandler(this.tbMarka_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Marka:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(131, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Model:";
            // 
            // btnModel
            // 
            this.btnModel.Enabled = false;
            this.btnModel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModel.Location = new System.Drawing.Point(134, 100);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(87, 26);
            this.btnModel.TabIndex = 6;
            this.btnModel.Text = "Unesi model";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.btnModel_Click);
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(134, 65);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(100, 20);
            this.tbModel.TabIndex = 5;
            this.tbModel.TextChanged += new System.EventHandler(this.tbModel_TextChanged);
            // 
            // cbModel
            // 
            this.cbModel.DropDownHeight = 80;
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.IntegralHeight = false;
            this.cbModel.Location = new System.Drawing.Point(134, 27);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(100, 21);
            this.cbModel.TabIndex = 4;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbMarka);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbModel);
            this.panel1.Controls.Add(this.tbMarka);
            this.panel1.Controls.Add(this.btnMarka);
            this.panel1.Controls.Add(this.btnModel);
            this.panel1.Controls.Add(this.tbModel);
            this.panel1.Location = new System.Drawing.Point(12, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 144);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Unos vozila";
            // 
            // tmLoad
            // 
            this.tmLoad.Interval = 500;
            this.tmLoad.Tick += new System.EventHandler(this.tmLoad_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbTip);
            this.panel2.Controls.Add(this.btnTip);
            this.panel2.Controls.Add(this.tbTip);
            this.panel2.Location = new System.Drawing.Point(260, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(117, 144);
            this.panel2.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Tip:";
            // 
            // cbTip
            // 
            this.cbTip.DropDownHeight = 80;
            this.cbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTip.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTip.FormattingEnabled = true;
            this.cbTip.IntegralHeight = false;
            this.cbTip.Location = new System.Drawing.Point(10, 27);
            this.cbTip.Name = "cbTip";
            this.cbTip.Size = new System.Drawing.Size(100, 24);
            this.cbTip.TabIndex = 7;
            // 
            // btnTip
            // 
            this.btnTip.Enabled = false;
            this.btnTip.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTip.Location = new System.Drawing.Point(10, 100);
            this.btnTip.Name = "btnTip";
            this.btnTip.Size = new System.Drawing.Size(87, 26);
            this.btnTip.TabIndex = 9;
            this.btnTip.Text = "Unesi Tip";
            this.btnTip.UseVisualStyleBackColor = true;
            this.btnTip.Click += new System.EventHandler(this.btnTip_Click);
            // 
            // tbTip
            // 
            this.tbTip.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTip.Location = new System.Drawing.Point(10, 65);
            this.tbTip.Name = "tbTip";
            this.tbTip.Size = new System.Drawing.Size(100, 21);
            this.tbTip.TabIndex = 8;
            this.tbTip.TextChanged += new System.EventHandler(this.tbTip_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Unos Tip-a";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnGod);
            this.panel3.Controls.Add(this.cbGodiste);
            this.panel3.Controls.Add(this.tbGodiste);
            this.panel3.Location = new System.Drawing.Point(383, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(117, 144);
            this.panel3.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Godina:";
            // 
            // btnGod
            // 
            this.btnGod.Enabled = false;
            this.btnGod.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGod.Location = new System.Drawing.Point(10, 101);
            this.btnGod.Name = "btnGod";
            this.btnGod.Size = new System.Drawing.Size(87, 26);
            this.btnGod.TabIndex = 12;
            this.btnGod.Text = "Unesi godiste";
            this.btnGod.UseVisualStyleBackColor = true;
            this.btnGod.Click += new System.EventHandler(this.btnGod_Click);
            // 
            // cbGodiste
            // 
            this.cbGodiste.DropDownHeight = 80;
            this.cbGodiste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGodiste.FormattingEnabled = true;
            this.cbGodiste.IntegralHeight = false;
            this.cbGodiste.Location = new System.Drawing.Point(10, 28);
            this.cbGodiste.Name = "cbGodiste";
            this.cbGodiste.Size = new System.Drawing.Size(100, 21);
            this.cbGodiste.TabIndex = 10;
            // 
            // tbGodiste
            // 
            this.tbGodiste.Location = new System.Drawing.Point(9, 66);
            this.tbGodiste.Name = "tbGodiste";
            this.tbGodiste.Size = new System.Drawing.Size(100, 20);
            this.tbGodiste.TabIndex = 11;
            this.tbGodiste.TextChanged += new System.EventHandler(this.tbGodiste_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(380, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Unos godine";
            // 
            // tm
            // 
            this.tm.Interval = 2000;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // TransakcijaMarka
            // 
            this.TransakcijaMarka.ContainerControl = this;
            this.TransakcijaMarka.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaMarka.Icon")));
            // 
            // TransakcijaModel
            // 
            this.TransakcijaModel.ContainerControl = this;
            this.TransakcijaModel.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaModel.Icon")));
            // 
            // TransakcijaTip
            // 
            this.TransakcijaTip.ContainerControl = this;
            this.TransakcijaTip.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaTip.Icon")));
            // 
            // TransakcijaGodina
            // 
            this.TransakcijaGodina.ContainerControl = this;
            this.TransakcijaGodina.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaGodina.Icon")));
            // 
            // Dodaj_vozilo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 227);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dodaj_vozilo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj vozilo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dodaj_vozilo_FormClosing);
            this.Load += new System.EventHandler(this.Dodaj_vozilo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaMarka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaGodina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMarka;
        private System.Windows.Forms.ComboBox cbMarka;
        private System.Windows.Forms.TextBox tbMarka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmLoad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbTip;
        private System.Windows.Forms.Button btnTip;
        private System.Windows.Forms.TextBox tbTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGod;
        private System.Windows.Forms.ComboBox cbGodiste;
        private System.Windows.Forms.TextBox tbGodiste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.ErrorProvider TransakcijaMarka;
        private System.Windows.Forms.ErrorProvider TransakcijaModel;
        private System.Windows.Forms.ErrorProvider TransakcijaTip;
        private System.Windows.Forms.ErrorProvider TransakcijaGodina;
    }
}