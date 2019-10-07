using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Auto_servis
{
    public partial class Dodaj_vozilo : Form
    {
        int VoziloID, ModelID,i = 0;
        public Dodaj_vozilo()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// TRANSAKCIJA MARKE ----------------------------------------------------------------------
        /// </summary>
        private void btnMarka_Click(object sender, EventArgs e)
        {
            broj_vozila();
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            using (kon)
            {
                kon.Open();
                SqlCommand command = kon.CreateCommand();
                SqlTransaction transaction;
                transaction = kon.BeginTransaction("sample transaction");
                command.Connection = kon;
                command.Transaction = transaction;
                try
                {
                    command.CommandText =
                        "Insert Into Vozila(VoziloID,Marka) VALUES('" + VoziloID.ToString() + "', '" + tbMarka.Text + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Uspesna transakcija");
                    TransakcijaMarka.SetError(btnMarka, "Uspesna transakcija");
                    tbMarka.Clear();
                    tm.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transakcija" + ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Rollback" + ex2.Message);
                    }
                }
                finally
                {
                    if (kon.State == ConnectionState.Open)
                    {
                        kon.Close();
                        puni_marku();
                    }
                }
            }
        }
        /// <summary>
        /// TRANSAKCIJA MODELA-----------------------------------------------------------------------
        /// </summary>
        private void btnModel_Click(object sender, EventArgs e)
        {
            broj_modela();
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            using (kon)
            {
                kon.Open();
                SqlCommand command = kon.CreateCommand();
                SqlTransaction transaction;
                transaction = kon.BeginTransaction("sample transaction");
                command.Connection = kon;
                command.Transaction = transaction;
                try
                {
                    command.CommandText =
                        "Insert Into Model(ModelID,VoziloId,Model) VALUES('" + ModelID.ToString() + "', '" + cbMarka.SelectedValue.ToString() + "', '" + tbModel.Text + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Uspesna transakcija");
                    TransakcijaModel.SetError(btnModel, "Uspesna transakcija");
                    tbModel.Clear();
                    tm.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transakcija" + ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Rollback" + ex2.Message);
                    }
                }
                finally
                {
                    if (kon.State == ConnectionState.Open)
                    {
                        kon.Close();
                        puni_model();
                    }
                }
            }
        }
        /// <summary>
        /// FUNKCIJE ZA POVECAVANJE ID-OVA VOZILA---------------------------------------------------------
        /// </summary>
        private void broj_vozila()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            kon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = kon;
            command.CommandText = "SELECT COUNT(VoziloID) from Vozila";
            VoziloID = int.Parse((command.ExecuteScalar()).ToString());
            VoziloID++;
            kon.Close();
        }
        private void broj_modela()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            kon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = kon;
            command.CommandText = "SELECT COUNT(ModelID) from Model";
            ModelID = int.Parse((command.ExecuteScalar()).ToString());
            ModelID++;
            kon.Close();
        }
        /// <summary>
        /// FUNKCIJE PUNI KOMBOBOXOVE ---------------------------------------------------------------------------
        /// </summary>
        private void puni_marku()
        {
            
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vozila ORDER BY Marka ASC;", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbMarka.DataSource = dt;
                cbMarka.DisplayMember = "Marka";
                cbMarka.ValueMember = "VoziloID";
                //cbMarka.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni marku" + ex.ToString());
            }
            
        }
        private void puni_model()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                cbModel.Text = "";
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Model WHERE Model.VoziloId = '" + cbMarka.SelectedValue.ToString() + "' ORDER BY Model.Model ASC;", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbModel.DataSource = dt;
                cbModel.DisplayMember = "Model";
                cbModel.ValueMember = "ModelID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni model" + ex.ToString());
                cbModel.Text = "";
            }
            
        }
        private void puniTip()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tip ORDER BY Tip.Tip ASC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbTip.DataSource = dt;
                cbTip.DisplayMember = "Tip";
                cbTip.ValueMember = "TipID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("PuniTip" + ex.ToString());
            }
        }
        private void puniGodiste()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Godina ORDER BY Godina DESC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbGodiste.DataSource = dt;
                cbGodiste.DisplayMember = "Godina";
                cbGodiste.ValueMember = "GodID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni Godiste" + ex.ToString());
            }
        }
        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                puni_model();
            }
        }
        /// <summary>
        /// POCETAK TIMERA -----------------------------------------------------
        /// </summary>
        private void tmLoad_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                puni_marku();
                puniTip();
                puniGodiste();
                puni_model();
                
                i = 1;
                tmLoad.Stop();
            }
        }
        private void Dodaj_vozilo_Load(object sender, EventArgs e)
        {
            tmLoad.Start(); 
        }
        /// <summary>
        /// PROVERA PRAZNOG POLJA ZA UPOTREBU DUGMETA -----------------------------------------------------------
        /// </summary>
        private void tbMarka_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbMarka.Text))
            {
                btnMarka.Enabled = false;
            }
            else
            {
                btnMarka.Enabled = true;
            }
        }
        private void tbModel_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbModel.Text))
            {
                btnModel.Enabled = false;
            }
            else
            {
                btnModel.Enabled = true;
            }
        }
        private void tbTip_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbTip.Text))
            {
                btnTip.Enabled = false;
            }
            else
            {
                btnTip.Enabled = true;
            }
        }
        private void tbGodiste_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbGodiste.Text))
            {
                btnGod.Enabled = false;
            }
            else
            {
                btnGod.Enabled = true;
            }
        }
        /// <summary>
        /// TRANSAKCIJA TIP------------------------------------------------------------------------
        /// </summary>
        private void btnTip_Click(object sender, EventArgs e)
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            using (kon)
            {
                kon.Open();
                SqlCommand command = kon.CreateCommand();
                SqlTransaction transaction;
                transaction = kon.BeginTransaction("sample transaction");
                command.Connection = kon;
                command.Transaction = transaction;
                try
                {
                    command.CommandText =
                        "Insert Into Tip(Tip) VALUES('" + tbTip.Text + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Uspesna transakcija");
                    TransakcijaTip.SetError(btnTip, "Uspesna transakcija");
                    tbTip.Clear();
                    tm.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transakcija" + ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Rollback" + ex2.Message);
                    }
                }
                finally
                {
                    if (kon.State == ConnectionState.Open)
                    {
                        kon.Close();
                        puniTip();
                    }
                }
            }
        }
        private void btnGod_Click(object sender, EventArgs e)
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            using (kon)
            {
                kon.Open();
                SqlCommand command = kon.CreateCommand();
                SqlTransaction transaction;
                transaction = kon.BeginTransaction("sample transaction");
                command.Connection = kon;
                command.Transaction = transaction;
                try
                {
                    command.CommandText =
                        "Insert Into Godina(Godina) VALUES('" + tbGodiste.Text + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    //MessageBox.Show("Uspesna transakcija");
                    TransakcijaGodina.SetError(btnGod, "Uspesna transakcija");
                    tbGodiste.Clear();
                    tm.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transakcija" + ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Rollback" + ex2.Message);
                    }
                }
                finally
                {
                    if (kon.State == ConnectionState.Open)
                    {
                        kon.Close();
                        puniGodiste();
                    }
                }
            }
        }
       
        private void tm_Tick(object sender, EventArgs e)
        {
            TransakcijaGodina.Clear();
            TransakcijaMarka.Clear();
            TransakcijaModel.Clear();
            TransakcijaTip.Clear();
            tm.Stop();
        }
        private void Dodaj_vozilo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Dodaj_korisnika.promenljiva_za_formu == 1)
            {
                Dodaj_korisnika.promenljiva_za_formu = 0;
                Dodaj_korisnika.tmLoad.Start();
            }
        }
        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
