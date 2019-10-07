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
    public partial class Dodaj_uslugu : Form
    {
        int i = 0;
        int UslugaID = 0;
        public Dodaj_uslugu()
        {
            InitializeComponent();
        }

        private void Dodaj_uslugu_Load(object sender, EventArgs e)
        {
            tmLoad.Start();
        }
        private void puniUslugu()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usluge ORDER BY Usluga ASC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbUsluga.DataSource = dt;
                cbUsluga.DisplayMember = "Usluga";
                cbUsluga.ValueMember = "UslugaID";
                cbUsluga.SelectedIndex = 0;
                tbIzmeniUslugu.Text = cbUsluga.Text;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni Uslugu" + ex.ToString());
            }
        }



        private void cbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                
                PuniTb();
                tbIzmeniUslugu.Text = cbUsluga.Text;
            }
        }
        private void PuniTb()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {
                
                DataTable dt = new DataTable();
                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT Cena FROM Usluge WHERE UslugaID = '"+cbUsluga.SelectedValue.ToString()+"'",kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    lblCena.Text = (myReader["Cena"].ToString());
                    tbIzmeniCenu.Text = (myReader["Cena"].ToString());
                }
               
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cena " + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();


                }
            }
        }

        private void tmLoad_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                puniUslugu();
                i = 1;
                PuniTb();
            }
        }

        private void tbUsluga_TextChanged(object sender, EventArgs e)
        {
            if ((!String.IsNullOrWhiteSpace(tbUsluga.Text)) && (!String.IsNullOrWhiteSpace(tbCena.Text)))
            {
                btnUsluga.Enabled = true;
            }
            else
            {
                btnUsluga.Enabled = false;
            }
        }

        private void tbCena_TextChanged(object sender, EventArgs e)
        {
            if ((!String.IsNullOrWhiteSpace(tbUsluga.Text)) && (!String.IsNullOrWhiteSpace(tbCena.Text)))
            {
                btnUsluga.Enabled = true;
            }
            else
            {
                btnUsluga.Enabled = false;
            }
        }

        private void broj_usluga()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            kon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = kon;
            command.CommandText = "SELECT COUNT(UslugaID) from Usluge";
            UslugaID = int.Parse((command.ExecuteScalar()).ToString());
            UslugaID++;
            kon.Close();


        }
        private void btnUsluga_Click(object sender, EventArgs e)
        {
            broj_usluga();
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
                        "INSERT INTO Usluge(UslugaID,Usluga,Cena) VALUES ('" + UslugaID.ToString() + "','" + tbUsluga.Text + "','" + tbCena.Text + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Uspesna transakcija");
                    TransakcijaUsluErr.SetError(btnUsluga, "Uspesna transakcija");
                    tbCena.Clear();
                    tbUsluga.Clear();
                    puniUslugu();
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
                       

                    }
                }
            }
        }

        private void tbIzmeniUslugu_TextChanged(object sender, EventArgs e)
        {
            if ((!String.IsNullOrWhiteSpace(tbIzmeniUslugu.Text)) && (!String.IsNullOrWhiteSpace(tbIzmeniCenu.Text)))
            {
                btnUpdateUsluga.Enabled = true;
            }
            else
            {
                btnUpdateUsluga.Enabled = false;
            }
        }

        private void tbIzmeniCenu_TextChanged(object sender, EventArgs e)
        {
            if ((!String.IsNullOrWhiteSpace(tbIzmeniUslugu.Text)) && (!String.IsNullOrWhiteSpace(tbIzmeniCenu.Text)))
            {
                btnUpdateUsluga.Enabled = true;
            }
            else
            {
                btnUpdateUsluga.Enabled = false;
            }
        }

        private void btnUpdateUsluga_Click(object sender, EventArgs e)
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
                        "UPDATE Usluge SET Usluga = '"+tbIzmeniUslugu.Text +"', Cena = '"+tbIzmeniCenu.Text +"' WHERE UslugaID = '"+ cbUsluga.SelectedValue.ToString()+"' ";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                  //  MessageBox.Show("Uspesna transakcija");
                    IzmeniUslErr.SetError(btnUpdateUsluga, "Uspesna transakcija");
                    tbIzmeniCenu.Clear();
                    tbIzmeniUslugu.Clear();
                    puniUslugu();
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


                    }
                }
            }
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            IzmeniUslErr.Clear();
            TransakcijaUsluErr.Clear();
            tm.Stop();
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
