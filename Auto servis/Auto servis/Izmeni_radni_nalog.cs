using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
namespace Auto_servis
{
    public partial class Izmeni_radni_nalog : Form
    {
        string datum_prijema_vozila,Datum_izdavanja_vozila;
        string pamcenje_opisa, pamcenje_napomene;
        int brojac;
        int cuvaj_broj;
        public static int promenljiva_za_podatke_izmeni = 0, RadniNalogID;
        public Izmeni_radni_nalog()
        {
            InitializeComponent();
        }

        private void Izmeni_radni_nalog_Load(object sender, EventArgs e)
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT KorID, Naziv,Datum_prijema_vozila ,Datum_izdavanja_vozila, Registarski, Predjena_kilometraza, Pozvati, RadniNalogID , Napomena , Opis_kvara FROM Radni_nalog WHERE RadniNalogID = '" + Auto_servis.Radni_nalog_ID.ToString() + "' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    tbKorID.Text= (myReader["KorID"].ToString());
                    tbKorisnik.Text = (myReader["Naziv"].ToString());
                    tbRegistarski.Text = (myReader["Registarski"].ToString());
                    tbKilometraza.Text = (myReader["Predjena_kilometraza"].ToString());
                    tbPozvati.Text = (myReader["Pozvati"].ToString());
                    tbRadniNalogID.Text = (myReader["RadniNalogID"].ToString());
                    rtbNapomena.Text = (myReader["Napomena"].ToString());
                    rtbOpisKvara.Text = (myReader["Opis_kvara"].ToString());
                    datum_prijema_vozila = (myReader["Datum_prijema_vozila"].ToString());
                    Datum_izdavanja_vozila = (myReader["Datum_izdavanja_vozila"].ToString());
                  
                   
                  
                }
                if (Datum_izdavanja_vozila != "")
                {
                    zakljucan_radni_nalog();

                }
                Brojanje_karaktera();
                pamcenje_napomene = rtbNapomena.Text;
                pamcenje_opisa = rtbOpisKvara.Text;
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni txt " + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();

                }
            }
        }
        private void Brojanje_karaktera()
        {
            foreach (char c in datum_prijema_vozila)
            {
                brojac++;
                if (char.IsWhiteSpace(c))
                {
                    
                    break;
                }
            }
            foreach (char c in Datum_izdavanja_vozila)
            {
                cuvaj_broj++;
                if (char.IsWhiteSpace(c))
                {

                    break;
                }
            }


            tbDatum.Text = datum_prijema_vozila.Substring(0, brojac);
            tbZavrseno.Text = Datum_izdavanja_vozila.Substring(0, cuvaj_broj);
        }
   
        private void Izmeni_radni_nalog_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
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
                        "UPDATE Radni_nalog SET Opis_kvara = '"+rtbOpisKvara.Text+"', Napomena = '"+rtbNapomena.Text+"' WHERE Radni_nalog.RadniNalogID = '"+tbRadniNalogID.Text+"' ";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    // MessageBox.Show("Uspesna transakcija");
                    TransakcijaKorErr.SetError(btnIzmeni, "Uspesna transakcija");
                    btnZakljucaj.Enabled = true;
                    Auto_servis.tmLoad.Start();
                    pamcenje_napomene = rtbNapomena.Text;
                    pamcenje_opisa = rtbOpisKvara.Text;
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
        private void zakljucan_radni_nalog()
        {
            rtbNapomena.Enabled = false;
            rtbNapomena.ReadOnly = true;
            rtbOpisKvara.Enabled = false;
            rtbOpisKvara.ReadOnly = true;
            btnIzmeni.Enabled = false;
            btnZakljucaj.Enabled = false;
            tbZavrseno.Enabled = false;
            tbZavrseno.ReadOnly = true;
        }
        private void btnZakljucaj_Click(object sender, EventArgs e)
        {
            if((rtbOpisKvara.Text != pamcenje_opisa) || (rtbNapomena.Text != pamcenje_napomene))
            {
               
                 DialogResult Sacuvaj = MessageBox.Show("Da li zelite da sacuvate promene?", "Sacuvaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (Sacuvaj == DialogResult.Yes)
                 {
                     SqlConnection kon = new SqlConnection(Konekcija.konstring);
                     pamcenje_napomene = rtbNapomena.Text;
                     pamcenje_opisa = rtbOpisKvara.Text;
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
                                 "UPDATE Radni_nalog SET Opis_kvara = '" + rtbOpisKvara.Text + "', Napomena = '" + rtbNapomena.Text + "' WHERE Radni_nalog.RadniNalogID = '" + tbRadniNalogID.Text + "' ";
                             command.ExecuteNonQuery();
                             transaction.Commit();
                             MessageBox.Show("Promene uspesno sacuvane!");
                             //TransakcijaKorErr.SetError(btnIzmeni, "Uspesna transakcija");
                             // btnZakljucaj.Enabled = true;
                             Auto_servis.tmLoad.Start();
                             // tm.Start();
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
                 else
                 {
                     DialogResult rezultat = MessageBox.Show("Da li sigurno zelita da zakljucate radni nalog?", "Provera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (rezultat == DialogResult.Yes)
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
                                 Datum_izdavanja_vozila = DateTime.Today.ToShortDateString();
                                 tbZavrseno.Text = Datum_izdavanja_vozila;
                                 command.CommandText =
                                     "UPDATE Radni_nalog SET Datum_izdavanja_vozila = '" + Datum_izdavanja_vozila + "' WHERE RadniNalogID = '" + tbRadniNalogID.Text + "' ";
                                 command.ExecuteNonQuery();
                                 transaction.Commit();
                                 // MessageBox.Show("Uspesna transakcija");
                                 TransakcijaKorErr.SetError(btnZakljucaj, "Uspesna transakcija");
                                 zakljucan_radni_nalog();
                                 
                                 tm.Start();
                                 Auto_servis.tmLoad.Start();
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
                 }

            }
            else
            {
                DialogResult rezultat = MessageBox.Show("Da li sigurno zelita da zakljucate radni nalog?", "Provera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rezultat == DialogResult.Yes)
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
                            Datum_izdavanja_vozila = DateTime.Today.ToShortDateString();
                            tbZavrseno.Text = Datum_izdavanja_vozila;
                            command.CommandText =
                                "UPDATE Radni_nalog SET Datum_izdavanja_vozila = '" + Datum_izdavanja_vozila + "' WHERE RadniNalogID = '" + tbRadniNalogID.Text + "' ";
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            // MessageBox.Show("Uspesna transakcija");
                            TransakcijaKorErr.SetError(btnZakljucaj, "Uspesna transakcija");
                            zakljucan_radni_nalog();
                            Auto_servis.tmLoad.Start();
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
            }
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            TransakcijaAutErr.Clear();
            TransakcijaKorErr.Clear();
            tm.Stop();
        }

        private void rtbNapomena_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Podaci_korisnika_Click(object sender, EventArgs e)
        {
            promenljiva_za_podatke_izmeni = 1;
            RadniNalogID = int.Parse(tbRadniNalogID.Text);
            Vidi_podatke vk = new Vidi_podatke();
            vk.ShowDialog();
        }
    }
}
