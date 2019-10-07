namespace Auto_servis
{
    partial class Izmeni_radni_nalog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Izmeni_radni_nalog));
            this.btnZakljucaj = new System.Windows.Forms.Button();
            this.rtbNapomena = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbZavrseno = new System.Windows.Forms.TextBox();
            this.tbRadniNalogID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDatum = new System.Windows.Forms.TextBox();
            this.rtbOpisKvara = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbKorisnik = new System.Windows.Forms.TextBox();
            this.tbRegistarski = new System.Windows.Forms.TextBox();
            this.tbPozvati = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbKilometraza = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbKorID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.TransakcijaKorErr = new System.Windows.Forms.ErrorProvider(this.components);
            this.TransakcijaAutErr = new System.Windows.Forms.ErrorProvider(this.components);
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.btn_Podaci_korisnika = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaKorErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaAutErr)).BeginInit();
            this.SuspendLayout();
            // 
            // btnZakljucaj
            // 
            this.btnZakljucaj.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakljucaj.Location = new System.Drawing.Point(550, 248);
            this.btnZakljucaj.Name = "btnZakljucaj";
            this.btnZakljucaj.Size = new System.Drawing.Size(94, 34);
            this.btnZakljucaj.TabIndex = 118;
            this.btnZakljucaj.Text = "Zakljucaj";
            this.btnZakljucaj.UseVisualStyleBackColor = true;
            this.btnZakljucaj.Click += new System.EventHandler(this.btnZakljucaj_Click);
            // 
            // rtbNapomena
            // 
            this.rtbNapomena.Location = new System.Drawing.Point(311, 140);
            this.rtbNapomena.MaxLength = 150;
            this.rtbNapomena.Name = "rtbNapomena";
            this.rtbNapomena.Size = new System.Drawing.Size(333, 96);
            this.rtbNapomena.TabIndex = 117;
            this.rtbNapomena.Text = "";
            this.rtbNapomena.TextChanged += new System.EventHandler(this.rtbNapomena_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(308, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 116;
            this.label8.Text = "Napomena:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbZavrseno);
            this.panel2.Controls.Add(this.tbRadniNalogID);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbDatum);
            this.panel2.Location = new System.Drawing.Point(408, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 106);
            this.panel2.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Broj radnog naloga:";
            // 
            // tbZavrseno
            // 
            this.tbZavrseno.Enabled = false;
            this.tbZavrseno.Location = new System.Drawing.Point(119, 67);
            this.tbZavrseno.Name = "tbZavrseno";
            this.tbZavrseno.ReadOnly = true;
            this.tbZavrseno.Size = new System.Drawing.Size(100, 20);
            this.tbZavrseno.TabIndex = 107;
            // 
            // tbRadniNalogID
            // 
            this.tbRadniNalogID.Enabled = false;
            this.tbRadniNalogID.Location = new System.Drawing.Point(119, 13);
            this.tbRadniNalogID.Name = "tbRadniNalogID";
            this.tbRadniNalogID.ReadOnly = true;
            this.tbRadniNalogID.Size = new System.Drawing.Size(100, 20);
            this.tbRadniNalogID.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 106;
            this.label5.Text = "Zavrseno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 104;
            this.label4.Text = "Datum:";
            // 
            // tbDatum
            // 
            this.tbDatum.Enabled = false;
            this.tbDatum.Location = new System.Drawing.Point(119, 39);
            this.tbDatum.MaxLength = 10;
            this.tbDatum.Name = "tbDatum";
            this.tbDatum.ReadOnly = true;
            this.tbDatum.Size = new System.Drawing.Size(100, 20);
            this.tbDatum.TabIndex = 105;
            // 
            // rtbOpisKvara
            // 
            this.rtbOpisKvara.Location = new System.Drawing.Point(12, 186);
            this.rtbOpisKvara.MaxLength = 150;
            this.rtbOpisKvara.Name = "rtbOpisKvara";
            this.rtbOpisKvara.Size = new System.Drawing.Size(236, 96);
            this.rtbOpisKvara.TabIndex = 114;
            this.rtbOpisKvara.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 113;
            this.label1.Text = "Opis kvara:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tbKorisnik);
            this.panel1.Controls.Add(this.tbRegistarski);
            this.panel1.Controls.Add(this.tbPozvati);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbKilometraza);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbKorID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 152);
            this.panel1.TabIndex = 111;
            // 
            // tbKorisnik
            // 
            this.tbKorisnik.Enabled = false;
            this.tbKorisnik.Location = new System.Drawing.Point(134, 41);
            this.tbKorisnik.Name = "tbKorisnik";
            this.tbKorisnik.ReadOnly = true;
            this.tbKorisnik.Size = new System.Drawing.Size(100, 20);
            this.tbKorisnik.TabIndex = 112;
            // 
            // tbRegistarski
            // 
            this.tbRegistarski.Enabled = false;
            this.tbRegistarski.Location = new System.Drawing.Point(134, 67);
            this.tbRegistarski.Name = "tbRegistarski";
            this.tbRegistarski.ReadOnly = true;
            this.tbRegistarski.Size = new System.Drawing.Size(100, 20);
            this.tbRegistarski.TabIndex = 111;
            // 
            // tbPozvati
            // 
            this.tbPozvati.Enabled = false;
            this.tbPozvati.Location = new System.Drawing.Point(134, 122);
            this.tbPozvati.Name = "tbPozvati";
            this.tbPozvati.ReadOnly = true;
            this.tbPozvati.Size = new System.Drawing.Size(100, 20);
            this.tbPozvati.TabIndex = 109;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 110;
            this.label7.Text = "Pozvati:";
            // 
            // tbKilometraza
            // 
            this.tbKilometraza.Enabled = false;
            this.tbKilometraza.Location = new System.Drawing.Point(134, 96);
            this.tbKilometraza.Name = "tbKilometraza";
            this.tbKilometraza.ReadOnly = true;
            this.tbKilometraza.Size = new System.Drawing.Size(100, 20);
            this.tbKilometraza.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 16);
            this.label6.TabIndex = 107;
            this.label6.Text = "Trenutna kilometraza:";
            // 
            // tbKorID
            // 
            this.tbKorID.Enabled = false;
            this.tbKorID.Location = new System.Drawing.Point(134, 10);
            this.tbKorID.Name = "tbKorID";
            this.tbKorID.ReadOnly = true;
            this.tbKorID.Size = new System.Drawing.Size(100, 20);
            this.tbKorID.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 105;
            this.label3.Text = "Sifra korisnika:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(64, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 101;
            this.label15.Text = "Registarski:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(80, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 44;
            this.label13.Text = "Korisnik:";
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.Location = new System.Drawing.Point(311, 248);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(94, 34);
            this.btnIzmeni.TabIndex = 112;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // TransakcijaKorErr
            // 
            this.TransakcijaKorErr.ContainerControl = this;
            this.TransakcijaKorErr.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaKorErr.Icon")));
            // 
            // TransakcijaAutErr
            // 
            this.TransakcijaAutErr.ContainerControl = this;
            this.TransakcijaAutErr.Icon = ((System.Drawing.Icon)(resources.GetObject("TransakcijaAutErr.Icon")));
            // 
            // tm
            // 
            this.tm.Interval = 2000;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // btn_Podaci_korisnika
            // 
            this.btn_Podaci_korisnika.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Podaci_korisnika.Location = new System.Drawing.Point(428, 248);
            this.btn_Podaci_korisnika.Name = "btn_Podaci_korisnika";
            this.btn_Podaci_korisnika.Size = new System.Drawing.Size(94, 34);
            this.btn_Podaci_korisnika.TabIndex = 119;
            this.btn_Podaci_korisnika.Text = "Vidi podatke";
            this.btn_Podaci_korisnika.UseVisualStyleBackColor = true;
            this.btn_Podaci_korisnika.Click += new System.EventHandler(this.btn_Podaci_korisnika_Click);
            // 
            // Izmeni_radni_nalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 330);
            this.Controls.Add(this.btn_Podaci_korisnika);
            this.Controls.Add(this.btnZakljucaj);
            this.Controls.Add(this.rtbNapomena);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rtbOpisKvara);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnIzmeni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Izmeni_radni_nalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izmeni radni nalog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Izmeni_radni_nalog_FormClosing);
            this.Load += new System.EventHandler(this.Izmeni_radni_nalog_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaKorErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransakcijaAutErr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnZakljucaj;
        private System.Windows.Forms.RichTextBox rtbNapomena;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbZavrseno;
        private System.Windows.Forms.TextBox tbRadniNalogID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDatum;
        private System.Windows.Forms.RichTextBox rtbOpisKvara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPozvati;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbKilometraza;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbKorID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.TextBox tbKorisnik;
        private System.Windows.Forms.TextBox tbRegistarski;
        private System.Windows.Forms.ErrorProvider TransakcijaKorErr;
        private System.Windows.Forms.ErrorProvider TransakcijaAutErr;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.Button btn_Podaci_korisnika;
    }
}