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
    public partial class Izmeni_vozila : Form
    {
        int i = 0;
        public Izmeni_vozila()
        {
            InitializeComponent();
        }

        private void Izmeni_vozila_Load(object sender, EventArgs e)
        {
            tmLoad.Start(); 
        }

        private void tmLoad_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                puni_marku();
                puni_model();
                i = 1;
            }
        }


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
                cbMarka.SelectedIndex = 0;

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

        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                puni_model();
            }
            tbMarka.Text = cbMarka.Text;
        }
        private void btnZatvori_Click(object sender, EventArgs e)
        {
            if (Trazi_vozila.promenljiva_za_izmenu == 1)
            {
                Trazi_vozila.tmPublic.Start();
                Trazi_vozila.promenljiva_za_izmenu = 0;
                this.Hide();
            }

            else if (Dodaj_korisnika.promenljiva_za_formu == 1)
            {

                Dodaj_korisnika.tmLoad.Start();
                Dodaj_korisnika.promenljiva_za_formu = 0;
                this.Hide();
            }
            else
            {
                this.Hide();
            }
           
            
           
        }

        private void tbMarka_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbMarka.Text))
            {
                btnMarka.Enabled = true;
            }
            else 
            {
                btnMarka.Enabled = false;
            }
        }

        private void tbModel_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbModel.Text))
            {
                btnModel.Enabled = true;
            }
            else
            {
                btnModel.Enabled = false;
            }
        }

        private void btnMarka_Click(object sender, EventArgs e)
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
                        "UPDATE Vozila SET Marka = '"+tbMarka.Text +"' WHERE VoziloID = '"+cbMarka.SelectedValue.ToString()+"'";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    //MessageBox.Show("Uspesna transakcija");
                    IzmeniMarkuErr.SetError(btnMarka, "Uspesna izmena");


                    tbMarka.Clear();
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
                        puni_marku();

                    }
                }
            }
        }

        private void btnModel_Click(object sender, EventArgs e)
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
                        "UPDATE Model SET Model = '" + tbModel.Text + "' WHERE ModelID = '" + cbModel.SelectedValue.ToString() + "'";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    IzmeniModelErr.SetError(btnModel, "Izmena uspesna");


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

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbModel.Text = cbModel.Text;
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            IzmeniMarkuErr.Clear();
            IzmeniModelErr.Clear();
            tm.Stop();
        }

        private void Izmeni_vozila_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Trazi_vozila.promenljiva_za_izmenu == 1)
            {
                Trazi_vozila.tmPublic.Start();
                Trazi_vozila.promenljiva_za_izmenu = 0;
            }
            else if (Dodaj_korisnika.promenljiva_za_formu == 1)
            {
                Dodaj_korisnika.promenljiva_za_formu = 0;
                Dodaj_korisnika.tmLoad.Start();
            }
        }
       

    }
}
