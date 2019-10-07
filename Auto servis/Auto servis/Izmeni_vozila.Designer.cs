namespace Auto_servis
{
    partial class Izmeni_vozila
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Izmeni_vozila));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMarka = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.tbMarka = new System.Windows.Forms.TextBox();
            this.btnMarka = new System.Windows.Forms.Button();
            this.btnModel = new System.Windows.Forms.Button();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tmLoad = new System.Windows.Forms.Timer(this.components);
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.IzmeniMarkuErr = new System.Windows.Forms.ErrorProvider(this.components);
            this.IzmeniModelErr = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IzmeniMarkuErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IzmeniModelErr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Izmeni vozila";
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
            this.panel1.Location = new System.Drawing.Point(13, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 144);
            this.panel1.TabIndex = 35;
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
            // tbMarka
            // 
            this.tbMarka.Location = new System.Drawing.Point(13, 65);
            this.tbMarka.Name = "tbMarka";
            this.tbMarka.Size = new System.Drawing.Size(100, 20);
            this.tbMarka.TabIndex = 2;
            this.tbMarka.TextChanged += new System.EventHandler(this.tbMarka_TextChanged);
            // 
            // btnMarka
            // 
            this.btnMarka.Enabled = false;
            this.btnMarka.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarka.Location = new System.Drawing.Point(13, 101);
            this.btnMarka.Name = "btnMarka";
            this.btnMarka.Size = new System.Drawing.Size(87, 26);
            this.btnMarka.TabIndex = 3;
            this.btnMarka.Text = "Izmeni marku";
            this.btnMarka.UseVisualStyleBackColor = true;
            this.btnMarka.Click += new System.EventHandler(this.btnMarka_Click);
            // 
            // btnModel
            // 
            this.btnModel.Enabled = false;
            this.btnModel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModel.Location = new System.Drawing.Point(134, 100);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(87, 26);
            this.btnModel.TabIndex = 6;
            this.btnModel.Text = "Izmeni model";
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
            // tmLoad
            // 
            this.tmLoad.Interval = 500;
            this.tmLoad.Tick += new System.EventHandler(this.tmLoad_Tick);
            // 
            // tm
            // 
            this.tm.Interval = 2000;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // IzmeniMarkuErr
            // 
            this.IzmeniMarkuErr.ContainerControl = this;
            this.IzmeniMarkuErr.Icon = ((System.Drawing.Icon)(resources.GetObject("IzmeniMarkuErr.Icon")));
            // 
            // IzmeniModelErr
            // 
            this.IzmeniModelErr.ContainerControl = this;
            this.IzmeniModelErr.Icon = ((System.Drawing.Icon)(resources.GetObject("IzmeniModelErr.Icon")));
            // 
            // Izmeni_vozila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 220);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Izmeni_vozila";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izmeni vozila";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Izmeni_vozila_FormClosing);
            this.Load += new System.EventHandler(this.Izmeni_vozila_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IzmeniMarkuErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IzmeniModelErr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMarka;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.TextBox tbMarka;
        private System.Windows.Forms.Button btnMarka;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.Timer tmLoad;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.ErrorProvider IzmeniMarkuErr;
        private System.Windows.Forms.ErrorProvider IzmeniModelErr;
    }
}