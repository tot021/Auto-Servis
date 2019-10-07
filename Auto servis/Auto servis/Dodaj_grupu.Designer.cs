namespace Auto_servis
{
    partial class Dodaj_grupu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dodaj_grupu));
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbGrupa = new System.Windows.Forms.ComboBox();
            this.btnGrupa = new System.Windows.Forms.Button();
            this.tbGrupa = new System.Windows.Forms.TextBox();
            this.TransakcijaGrupa = new System.Windows.Forms.ErrorProvider(this.components);
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaGrupa)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Unos Grupe";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbGrupa);
            this.panel2.Controls.Add(this.btnGrupa);
            this.panel2.Controls.Add(this.tbGrupa);
            this.panel2.Location = new System.Drawing.Point(33, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 155);
            this.panel2.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Grupa:";
            // 
            // cbGrupa
            // 
            this.cbGrupa.DropDownHeight = 80;
            this.cbGrupa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupa.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGrupa.FormattingEnabled = true;
            this.cbGrupa.IntegralHeight = false;
            this.cbGrupa.Location = new System.Drawing.Point(10, 27);
            this.cbGrupa.Name = "cbGrupa";
            this.cbGrupa.Size = new System.Drawing.Size(100, 24);
            this.cbGrupa.TabIndex = 7;
            // 
            // btnGrupa
            // 
            this.btnGrupa.Enabled = false;
            this.btnGrupa.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupa.Location = new System.Drawing.Point(10, 101);
            this.btnGrupa.Name = "btnGrupa";
            this.btnGrupa.Size = new System.Drawing.Size(87, 36);
            this.btnGrupa.TabIndex = 9;
            this.btnGrupa.Text = "Unesi Grupu";
            this.btnGrupa.UseVisualStyleBackColor = true;
            this.btnGrupa.Click += new System.EventHandler(this.btnGrupa_Click);
            // 
            // tbGrupa
            // 
            this.tbGrupa.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrupa.Location = new System.Drawing.Point(10, 65);
            this.tbGrupa.Name = "tbGrupa";
            this.tbGrupa.Size = new System.Drawing.Size(100, 21);
            this.tbGrupa.TabIndex = 8;
            this.tbGrupa.TextChanged += new System.EventHandler(this.tbGrupa_TextChanged);
            // 
            // TransakcijaGrupa
            // 
            this.TransakcijaGrupa.ContainerControl = this;
            this.TransakcijaGrupa.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaGrupa.Icon")));
            // 
            // tm
            // 
            this.tm.Interval = 2000;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // Dodaj_grupu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 212);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dodaj_grupu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj grupu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dodaj_grupu_FormClosing);
            this.Load += new System.EventHandler(this.Dodaj_grupu_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaGrupa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbGrupa;
        private System.Windows.Forms.Button btnGrupa;
        private System.Windows.Forms.TextBox tbGrupa;
        private System.Windows.Forms.ErrorProvider TransakcijaGrupa;
        private System.Windows.Forms.Timer tm;
    }
}