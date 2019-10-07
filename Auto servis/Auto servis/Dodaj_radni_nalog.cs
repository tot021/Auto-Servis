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
    public partial class Dodaj_radni_nalog : Form
    {
        public static Timer tmLoad = new Timer();
        int i = 0;
        int proveri_broj_radnog_naloga;
        int radni_nalogID;
        public static int RadniNalogID;
        public static int promenljiva_za_podatke_dodaj = 0;
        string Stara_tablica,Stara_tablica1,Radio_kod,Kljuc_kod, Gorivo, Marka, Model, Tip, Broj_sasije, Broj_motora, Godiste, Snaga_kw, Zapremina, Naziv, Adresa, Grad, Pozivni_broj, Jmbg_pib, Mobilni, Mobilni2, Telefon, E_mail, Websajt, Rok_placanja, Grupa, Datum_prijema_vozila, Pozvati, Predjena_kilometraza, OpisKvara,Napomena, Datum_izdavanja_vozila;
        bool error;
        string pamcenje_opisa, pamcenje_napomene;
        public Dodaj_radni_nalog()
        {
            InitializeComponent();
        }
        private void Dodaj_radni_nalog_Load(object sender, EventArgs e)
        {
            tmLoad.Tick += new EventHandler(tmLoad_Tick);
            tmLoad.Interval = 500;
            Datum_prijema();
            tmLoad.Start();
        }
        private void tmLoad_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                KilometrazaError.SetError(tbKilometraza, "Popunite polje");
                puniKorisnika();
                broj_radnog_naloga();
                i = 1;
                puniRegistarski();
                Biraj_pozvati();
                tmLoad.Stop();
            }
        }
        private void Datum_prijema()
        {
            tbDatum.Text = DateTime.Today.ToShortDateString();
            Datum_prijema_vozila = tbDatum.Text;
        }
        private void Datum_izdavanja()
        {
            Datum_izdavanja_vozila = DateTime.Today.ToShortDateString();
        }
        private void puniKorisnika()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT KorID,Naziv FROM Korisnik ORDER BY Naziv ASC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbKorisnik.DataSource = dt;
                cbKorisnik.DisplayMember = "Naziv";
                cbKorisnik.ValueMember = "KorID";
                tbKorID.Text = cbKorisnik.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni Korisnika" + ex.ToString());
            }
        }
        private void puniRegistarski()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT Registarski, AutoID FROM Auto WHERE Auto.KorId = '" + cbKorisnik.SelectedValue.ToString() + "'", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbRegistarski.DataSource = dt;
                cbRegistarski.DisplayMember = "Registarski";
                cbRegistarski.ValueMember = "AutoID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni Registarski" + ex.ToString());
            }
        }
        private void broj_radnog_naloga()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            //proveriti da li ima nesto u tabeli
            try
            {
                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT COUNT(RadniNalogID) from Radni_nalog";
                proveri_broj_radnog_naloga = int.Parse((command.ExecuteScalar()).ToString());
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("prova broja radnog naloga" + ex.ToString());
            }
            if (proveri_broj_radnog_naloga != 0)
            {
                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT MAX(RadniNalogID) from Radni_nalog";
                radni_nalogID = int.Parse((command.ExecuteScalar()).ToString());
                radni_nalogID++;
                tbRadniNalogID.Text = radni_nalogID.ToString();
                kon.Close();
            }
            else 
            {
                radni_nalogID = 1;
                tbRadniNalogID.Text = radni_nalogID.ToString();
            }
            
            
        }
        private void cbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                puniRegistarski();
                Biraj_pozvati();
                tbKorID.Text = cbKorisnik.SelectedValue.ToString();
                Pregled_praznog_polja();
            }
        }
        private void Biraj_pozvati()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {
                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT Auto.Pozvati , Korisnik.Mobilni FROM Auto, Korisnik WHERE Registarski = '" + cbRegistarski.Text + "' AND Korisnik.KorID  = '"+tbKorID.Text+"' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    if ((myReader["Pozvati"].ToString()) != "")
                    {
                        tbPozvati.Text = (myReader["Pozvati"].ToString());
                    }
                    else
                    {
                        tbPozvati.Text = (myReader["Mobilni"].ToString());
                    }
                  
                }
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
        private void Pregled_praznog_polja()
        {
            if ((error == false) && (!String.IsNullOrWhiteSpace(tbPozvati.Text)) && (!String.IsNullOrWhiteSpace(tbDatum.Text)) && (!String.IsNullOrWhiteSpace(tbKorID.Text)) && (!String.IsNullOrWhiteSpace(tbRadniNalogID.Text)) && (!String.IsNullOrWhiteSpace(cbKorisnik.Text)) && (!String.IsNullOrWhiteSpace(cbRegistarski.Text)) && (!String.IsNullOrWhiteSpace(tbKilometraza.Text)))
            {
                btnRadniNalog.Enabled = true;
            }
            else
            {
                btnRadniNalog.Enabled = false;
            }
        }
        private void tbKorID_TextChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja();
        }
        private void cbRegistarski_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja();
        }
        private void tbKilometraza_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbKilometraza.Text))
            {
                foreach (char c in tbKilometraza.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        KilometrazaError.SetError(tbKilometraza, "Dozvoljeni su samo brojevi");
                        error = true;
                    }
                    else
                    {
                        error = false;
                        KilometrazaError.Clear();
                    }
                }
                
                
            }
            Predjena_kilometraza = tbKilometraza.Text;
            Pregled_praznog_polja();
        }
        private void tbPozvati_TextChanged(object sender, EventArgs e)
        {
            Pozvati = tbPozvati.Text;
            Pregled_praznog_polja();
            
        }
        private void tbRadniNalogID_TextChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja();
        }
        private void tbDatum_TextChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja();
        }
        private void tbRok_TextChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja();
        }
        private void rtbOpisKvara_TextChanged(object sender, EventArgs e)
        {
            OpisKvara = rtbOpisKvara.Text;
            Pregled_praznog_polja();
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
        private void citaj_korisnika()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {
                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM Korisnik WHERE KorID = '" + tbKorID.Text + "' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    Naziv = (myReader["Naziv"].ToString());
                    Adresa = (myReader["Adresa"].ToString());
                    Grad = (myReader["Grad"].ToString());
                    Pozivni_broj = (myReader["Pozivni_broj"].ToString());
                    Jmbg_pib = (myReader["Jmbg_pib"].ToString());
                    Mobilni = (myReader["Mobilni"].ToString());
                    Mobilni2 = (myReader["Mobilni2"].ToString());
                    Telefon = (myReader["Telefon"].ToString());
                    E_mail = (myReader["E_mail"].ToString());
                    Websajt = (myReader["Websajt"].ToString());
                    Rok_placanja = (myReader["Rok_placanja"].ToString());
                    Grupa = (myReader["Grupa"].ToString());
                }
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
        private void citaj_auto()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {
                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT Stara_tablica,Stara_tablica1,Radio_kod,Kljuc_kod,Gorivo,Marka,Model,Tip,Godiste,Broj_sasije,Broj_motora,Zapremina,Snaga_kw FROM Auto WHERE Registarski = '" + cbRegistarski.Text + "' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    Stara_tablica = (myReader["Stara_tablica"].ToString());
                    Stara_tablica1 = (myReader["Stara_tablica1"].ToString());
                    Radio_kod = (myReader["Radio_kod"].ToString());
                    Kljuc_kod = (myReader["Kljuc_kod"].ToString());
                    Gorivo = (myReader["Gorivo"].ToString());
                    Marka = (myReader["Marka"].ToString());
                    Model = (myReader["Model"].ToString());
                    Tip = (myReader["Tip"].ToString());
                    Godiste = (myReader["Godiste"].ToString());
                    Broj_sasije = (myReader["Broj_sasije"].ToString());
                    Broj_motora = (myReader["Broj_motora"].ToString());
                    Zapremina = (myReader["Zapremina"].ToString());
                    Snaga_kw = (myReader["Snaga_kw"].ToString());
                }
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
        private void btnRadniNalog_Click(object sender, EventArgs e)
        {
            citaj_korisnika();
            citaj_auto();
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
                        "INSERT INTO Radni_nalog(RadniNalogID , KorID , Datum_prijema_vozila , Registarski , Marka , Model , Tip , Broj_sasije , Broj_motora , Godiste , Snaga_kw , Gorivo , Stara_tablica , Stara_tablica1 , Radio_kod , Kljuc_kod , Zapremina , Pozvati , Predjena_kilometraza , Naziv , Adresa , Grad , Pozivni_broj , Jmbg_pib , Mobilni , Mobilni2 , Telefon , E_mail , Websajt , Rok_placanja , Grupa , Opis_kvara , Napomena) VALUES('" + tbRadniNalogID.Text + "' , '" + tbKorID.Text + "' , '" + Datum_prijema_vozila + "' , '" + cbRegistarski.Text + "' , '" + Marka + "' , '" + Model + "' , '" + Tip + "' , '" + Broj_sasije + "' , '" + Broj_motora + "' , '" + Godiste + "' , '" + Snaga_kw + "' , '" + Gorivo + "' , '" + Stara_tablica + "' , '" + Stara_tablica1 + "' , '" + Radio_kod + "' , '" + Kljuc_kod + "' , '" + Zapremina + "' , '" + Pozvati + "' , '" + Predjena_kilometraza + "' , '" + Naziv + "' , '" + Adresa + "' , '" + Grad + "' , '" + Pozivni_broj + "' , '" + Jmbg_pib + "' , '" + Mobilni + "' , '" + Mobilni2 + "' , '" + Telefon + "' , '" + E_mail + "' , '" + Websajt + "' , '" + Rok_placanja + "' , '" + Grupa + "' , '" + OpisKvara + "' , '" + Napomena + "' )";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Uspesna transakcija");
                    TransakcijaKorErr.SetError(btnRadniNalog,"Uspesna transakcija");
                    btnZakljucaj.Enabled = true;
                    btn_Podaci_korisnika.Enabled = true;
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
                    btnIzmeni.Enabled = true;
                    btnRadniNalog.Visible = false;
                    btnIzmeni.Visible = true;
                    btnRadniNalog.Enabled = false;
                    cbKorisnik.Enabled = false;
                    cbRegistarski.Enabled = false;
                    tbKilometraza.Enabled = false;
                    tbKilometraza.ReadOnly = true;
                    tbPozvati.Enabled = false;
                    tbPozvati.ReadOnly = true;
                    tbDatum.ReadOnly = true;
                    tbDatum.Enabled = false;
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
            Napomena = rtbNapomena.Text;
        }
        private void Dodaj_radni_nalog_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void btn_Podaci_korisnika_Click(object sender, EventArgs e)
        {
            promenljiva_za_podatke_dodaj = 1;
            RadniNalogID = int.Parse(tbRadniNalogID.Text);
            Vidi_podatke vk = new Vidi_podatke();
            vk.ShowDialog();
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
                        "UPDATE Radni_nalog SET Opis_kvara = '" + rtbOpisKvara.Text + "', Napomena = '" + rtbNapomena.Text + "' WHERE Radni_nalog.RadniNalogID = '" + tbRadniNalogID.Text + "' ";
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
    }
}
