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
    public partial class Izmeni_grupu : Form
    {
        public Izmeni_grupu()
        {
            InitializeComponent();
        }

        private void cbGrupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbGrupa.Text = cbGrupa.Text;
            label1.Text = cbGrupa.Text;
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

        private void Izmeni_grupu_Load(object sender, EventArgs e)
        {
            puniGrupu();
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
                        "UPDATE Grupa SET Grupa ='" + tbGrupa.Text + "' WHERE GrupaID = '" + cbGrupa.SelectedValue.ToString() + "'";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    TransakcijaGrupa.SetError(btnGrupa, "Izmena uspesna");


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

        private void tm_Tick(object sender, EventArgs e)
        {
            tm.Stop();
            TransakcijaGrupa.Clear();
        }

        private void Izmeni_grupu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Dodaj_korisnika.promenljiva_za_formu == 1)
            {
                Dodaj_korisnika.promenljiva_za_formu = 0;
                Dodaj_korisnika.tmLoad.Start();
            }
        }
    }
}
