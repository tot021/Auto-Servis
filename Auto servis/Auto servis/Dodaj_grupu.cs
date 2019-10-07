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
    public partial class Dodaj_grupu : Form
    {
        public Dodaj_grupu()
        {
            InitializeComponent();
        }

        private void btnGrupa_Click(object sender, EventArgs e)
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
                        "Insert Into Grupa(Grupa) VALUES('" + tbGrupa.Text + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Uspesna transakcija");
                    TransakcijaGrupa.SetError(btnGrupa, "Uspesna transakcija");



                    tbGrupa.Clear();
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
                        puniGrupu();

                    }
                }
            }
        }
        private void puniGrupu()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Grupa ORDER BY Grupa.Grupa ASC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbGrupa.DataSource = dt;
                cbGrupa.DisplayMember = "Grupa";
                cbGrupa.ValueMember = "GrupaID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("PuniGrupa" + ex.ToString());
            }

        }

        private void tm_Tick(object sender, EventArgs e)
        {
            TransakcijaGrupa.Clear();
            tm.Stop();
        }

        private void tbGrupa_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbGrupa.Text))
            {
                btnGrupa.Enabled = false;
            }
            else 
            {
                btnGrupa.Enabled = true;
            }
        }

        private void Dodaj_grupu_Load(object sender, EventArgs e)
        {
            puniGrupu();
        }

        private void Dodaj_grupu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Dodaj_korisnika.promenljiva_za_formu == 1)
            {
                Dodaj_korisnika.promenljiva_za_formu = 0;
                Dodaj_korisnika.tmLoad.Start();
            }
        }


    }
}
