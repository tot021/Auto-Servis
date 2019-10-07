namespace Auto_servis
{
    partial class Dodaj_uslugu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dodaj_uslugu));
            this.label1 = new System.Windows.Forms.Label();
            this.btnUsluga = new System.Windows.Forms.Button();
            this.tbUsluga = new System.Windows.Forms.TextBox();
            this.cbUsluga = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCena = new System.Windows.Forms.Label();
            this.tbCena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.tmLoad = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIzmeniCenu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdateUsluga = new System.Windows.Forms.Button();
            this.tbIzmeniUslugu = new System.Windows.Forms.TextBox();
            this.IzmeniUslErr = new System.Windows.Forms.ErrorProvider(this.components);
            this.TransakcijaUsluErr = new System.Windows.Forms.ErrorProvider(this.components);
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IzmeniUslErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaUsluErr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Unos usluga";
            // 
            // btnUsluga
            // 
            this.btnUsluga.Enabled = false;
            this.btnUsluga.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsluga.Location = new System.Drawing.Point(89, 106);
            this.btnUsluga.Name = "btnUsluga";
            this.btnUsluga.Size = new System.Drawing.Size(87, 26);
            this.btnUsluga.TabIndex = 3;
            this.btnUsluga.Text = "Unesi uslugu";
            this.btnUsluga.UseVisualStyleBackColor = true;
            this.btnUsluga.Click += new System.EventHandler(this.btnUsluga_Click);
            // 
            // tbUsluga
            // 
            this.tbUsluga.Location = new System.Drawing.Point(17, 69);
            this.tbUsluga.Name = "tbUsluga";
            this.tbUsluga.Size = new System.Drawing.Size(100, 20);
            this.tbUsluga.TabIndex = 2;
            this.tbUsluga.TextChanged += new System.EventHandler(this.tbUsluga_TextChanged);
            // 
            // cbUsluga
            // 
            this.cbUsluga.DropDownHeight = 80;
            this.cbUsluga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsluga.FormattingEnabled = true;
            this.cbUsluga.IntegralHeight = false;
            this.cbUsluga.Location = new System.Drawing.Point(17, 33);
            this.cbUsluga.MaxDropDownItems = 100;
            this.cbUsluga.Name = "cbUsluga";
            this.cbUsluga.Size = new System.Drawing.Size(100, 21);
            this.cbUsluga.TabIndex = 1;
            this.cbUsluga.SelectedIndexChanged += new System.EventHandler(this.cbUsluga_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Usluga:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblCena);
            this.panel2.Controls.Add(this.tbCena);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnUsluga);
            this.panel2.Controls.Add(this.tbUsluga);
            this.panel2.Controls.Add(this.cbUsluga);
            this.panel2.Location = new System.Drawing.Point(12, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 155);
            this.panel2.TabIndex = 33;
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCena.Location = new System.Drawing.Point(144, 35);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(0, 16);
            this.lblCena.TabIndex = 28;
            // 
            // tbCena
            // 
            this.tbCena.Location = new System.Drawing.Point(147, 69);
            this.tbCena.Name = "tbCena";
            this.tbCena.Size = new System.Drawing.Size(100, 20);
            this.tbCena.TabIndex = 27;
            this.tbCena.TextChanged += new System.EventHandler(this.tbCena_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Cena:";
            // 
            // btnZatvori
            // 
            this.btnZatvori.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZatvori.Location = new System.Drawing.Point(250, 203);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(87, 26);
            this.btnZatvori.TabIndex = 36;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // tmLoad
            // 
            this.tmLoad.Interval = 500;
            this.tmLoad.Tick += new System.EventHandler(this.tmLoad_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbIzmeniCenu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnUpdateUsluga);
            this.panel1.Controls.Add(this.tbIzmeniUslugu);
            this.panel1.Location = new System.Drawing.Point(301, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 113);
            this.panel1.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(144, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 28;
            // 
            // tbIzmeniCenu
            // 
            this.tbIzmeniCenu.Location = new System.Drawing.Point(133, 34);
            this.tbIzmeniCenu.Name = "tbIzmeniCenu";
            this.tbIzmeniCenu.Size = new System.Drawing.Size(100, 20);
            this.tbIzmeniCenu.TabIndex = 27;
            this.tbIzmeniCenu.TextChanged += new System.EventHandler(this.tbIzmeniCenu_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(130, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Cena:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Usluga:";
            // 
            // btnUpdateUsluga
            // 
            this.btnUpdateUsluga.Enabled = false;
            this.btnUpdateUsluga.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUsluga.Location = new System.Drawing.Point(85, 69);
            this.btnUpdateUsluga.Name = "btnUpdateUsluga";
            this.btnUpdateUsluga.Size = new System.Drawing.Size(87, 26);
            this.btnUpdateUsluga.TabIndex = 3;
            this.btnUpdateUsluga.Text = "Izmeni uslugu";
            this.btnUpdateUsluga.UseVisualStyleBackColor = true;
            this.btnUpdateUsluga.Click += new System.EventHandler(this.btnUpdateUsluga_Click);
            // 
            // tbIzmeniUslugu
            // 
            this.tbIzmeniUslugu.Location = new System.Drawing.Point(17, 35);
            this.tbIzmeniUslugu.Name = "tbIzmeniUslugu";
            this.tbIzmeniUslugu.Size = new System.Drawing.Size(100, 20);
            this.tbIzmeniUslugu.TabIndex = 2;
            this.tbIzmeniUslugu.TextChanged += new System.EventHandler(this.tbIzmeniUslugu_TextChanged);
            // 
            // IzmeniUslErr
            // 
            this.IzmeniUslErr.ContainerControl = this;
            this.IzmeniUslErr.Icon = ((System.Drawing.Icon)(resources.GetObject("IzmeniUslErr.Icon")));
            // 
            // TransakcijaUsluErr
            // 
            this.TransakcijaUsluErr.ContainerControl = this;
            this.TransakcijaUsluErr.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaUsluErr.Icon")));
            // 
            // tm
            // 
            this.tm.Interval = 2000;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // Dodaj_uslugu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dodaj_uslugu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj uslugu";
            this.Load += new System.EventHandler(this.Dodaj_uslugu_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IzmeniUslErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaUsluErr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUsluga;
        private System.Windows.Forms.TextBox tbUsluga;
        private System.Windows.Forms.ComboBox cbUsluga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCena;
        private System.Windows.Forms.Timer tmLoad;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIzmeniCenu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdateUsluga;
        private System.Windows.Forms.TextBox tbIzmeniUslugu;
        private System.Windows.Forms.ErrorProvider IzmeniUslErr;
        private System.Windows.Forms.ErrorProvider TransakcijaUsluErr;
        private System.Windows.Forms.Timer tm;
    }
}