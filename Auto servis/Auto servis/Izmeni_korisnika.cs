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
    public partial class Izmeni_korisnika : Form
    {
        public static Timer tmLoad = new Timer();
        int i = 0;
        int gorivoID,MarkaID,ModelID,TipID,GodisteID,GrupaID;
        string gorivo,marka,model,tip,godiste,grupa;
        public static string broj_sasije;
        public static int promenljiva_za_trazi_korisnika = 0;
        public Izmeni_korisnika()
        {
            InitializeComponent();
        }

        private void btnIzmeniKorisnika_Click(object sender, EventArgs e)
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
                        "UPDATE Korisnik SET Naziv = '" + tbNaziv.Text + "' , Adresa = '" + tbAdresa.Text + "' , Grad = '" + tbGrad.Text + "' , Pozivni_broj = '" + tbPozivniBroj.Text + "' , Jmbg_pib = '" + tbJmbgPib.Text + "', Mobilni = '" + tbMobilni.Text + "', Mobilni2 = '" + tbMobilni2.Text + "', Telefon = '" + tbTelefon.Text + "', E_mail = '" + tbEmail.Text + "' , Websajt = '" + tbWebsajt.Text + "' , Rok_placanja = '" + tbRokPlacanja.Text + "' , Grupa = '" + cbGrupa.Text + "' WHERE KorID = '" + cbNaziv.SelectedValue.ToString() +"'";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    //MessageBox.Show("Uspesna transakcija");
                    TransakcijaKorErr.SetError(btnIzmeniKorisnika,  "Uspesna transakcija");
                    i = 0;
                    tmLoad.Start();
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

        private void btnIzmeniAuto_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) FROM Auto WHERE Broj_sasije = '" + tbBrojSasije.Text + "'", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (broj_sasije == tbBrojSasije.Text)
                {
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
                                "UPDATE Auto SET Registarski = '" + tbRegistarski.Text + "' , Marka = '" + cbMarka.Text + "' , Model = '" + cbModel.Text + "' , Tip =  '" + cbTip.Text + "' , Godiste = '" + cbGodiste.Text + "' , Broj_sasije =  '" + tbBrojSasije.Text + "' , Broj_motora = '" + tbBrojMotora.Text + "' , Zapremina = '" + tbZapremina.Text + "' , Snaga_kw =  '" + tbSnaga.Text + "' , Gorivo = '" + cbGorivo.Text + "' , Stara_tablica = '" + tbStaraTablica.Text + "' , Stara_tablica1 = '" + tbStaraTablica1.Text + "' , Pozvati = '" + tbPozvati.Text + "' ,Radio_kod = '" + tbRadioKod.Text + "' , Kljuc_kod = '" + tbKljucKod.Text + "' WHERE AutoID = '" + cbRegistarski.SelectedValue.ToString() + "'";
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            //MessageBox.Show("Uspesna transakcija");
                            TransakcijaAutErr.SetError(btnIzmeniAuto, "Uspesna transakcija");
                            i = 0;
                            tmLoad.Start();
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
                else if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Broj sasije postoji");
                    promenljiva_za_trazi_korisnika = 1;
                    broj_sasije = tbBrojSasije.Text;
                    Trazi_korisnika tk = new Trazi_korisnika();
                    tk.ShowDialog();
                }
                else
                {

                    
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
                                "UPDATE Auto SET Registarski = '" + tbRegistarski.Text + "' , Marka = '" + cbMarka.Text + "' , Model = '" + cbModel.Text + "' , Tip =  '" + cbTip.Text + "' , Godiste = '" + cbGodiste.Text + "' , Broj_sasije =  '" + tbBrojSasije.Text + "' , Broj_motora = '" + tbBrojMotora.Text + "' , Zapremina = '" + tbZapremina.Text + "' , Snaga_kw =  '" + tbSnaga.Text + "' , Gorivo = '" + cbGorivo.Text + "' , Stara_tablica = '" + tbStaraTablica.Text + "' , Stara_tablica1 = '" + tbStaraTablica1.Text + "' , Pozvati = '" + tbPozvati.Text + "' ,Radio_kod = '" + tbRadioKod.Text + "' , Kljuc_kod = '" + tbKljucKod.Text + "' WHERE AutoID = '" + cbRegistarski.SelectedValue.ToString() + "'";
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            //MessageBox.Show("Uspesna transakcija");
                            TransakcijaAutErr.SetError(btnIzmeniAuto, "Uspesna transakcija");
                            i = 0;
                            tmLoad.Start();
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
            catch(Exception ex)
            {
                MessageBox.Show("Greska pri proveravanju broja sasije" + ex.ToString());
            }
        }

        private void cbNaziv_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {
                
                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM Korisnik WHERE Naziv = '"+cbNaziv.Text+"' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    tbNaziv.Text = (myReader["Naziv"].ToString());
                    tbAdresa.Text = (myReader["Adresa"].ToString());
                    tbGrad.Text = (myReader["Grad"].ToString());
                    tbPozivniBroj.Text = (myReader["Pozivni_broj"].ToString());
                    tbJmbgPib.Text = (myReader["Jmbg_pib"].ToString());
                    tbMobilni.Text = (myReader["Mobilni"].ToString());
                    tbMobilni2.Text = (myReader["Mobilni2"].ToString());
                    tbTelefon.Text = (myReader["Telefon"].ToString());
                    tbEmail.Text = (myReader["E_mail"].ToString());
                    tbWebsajt.Text = (myReader["Websajt"].ToString());
                    tbRokPlacanja.Text = (myReader["Rok_placanja"].ToString());
                    grupa = (myReader["Grupa"].ToString());
                    TraziGrupaID();

                }
                kon.Close();
                cbGrupa.SelectedValue = GrupaID;
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
        private void puniKorisnika()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT KorID, Naziv FROM Korisnik  ORDER BY Naziv ASC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbKorisnik.DataSource = dt;
                cbKorisnik.DisplayMember = "Naziv";
                cbKorisnik.ValueMember = "KorID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni Korisnika" + ex.ToString());
            }
        }
        private void puniGorivo()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Gorivo ORDER BY Gorivo ASC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbGorivo.DataSource = dt;
                cbGorivo.DisplayMember = "Gorivo";
                cbGorivo.ValueMember = "GorivoID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Puni Gorivo" + ex.ToString());
            }
        }
        private void puniNaziv()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT KorID,Naziv FROM Korisnik ORDER BY Naziv ASC", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbNaziv.DataSource = dt;
                cbNaziv.DisplayMember = "Naziv";
                cbNaziv.ValueMember = "KorID";
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT Registarski, AutoID FROM Auto WHERE Auto.KorId = '"+cbKorisnik.SelectedValue.ToString()+"'", kon);
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

        private void Izmeni_korisnika_Load(object sender, EventArgs e)
        {
            tmLoad.Tick += new EventHandler(tmLoad_Tick);
            tmLoad.Interval = 500;
            tmLoad.Start();
        }
        private void tmLoad_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                tmLoad.Stop();
                puniGrupu();
                puni_marku();
                puniTip();
                puniGodiste(); 
                puniKorisnika();
                puniGorivo();
                puni_model();
                puniNaziv();
                puniRegistarski();
                i = 1;
                Registarski();
                
                
                
            }
        }

        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                puni_model();
            }
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            TransakcijaAutErr.Clear();
            TransakcijaKorErr.Clear();
            tm.Stop();
        }

        private void cbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                puniRegistarski();
            }
            
        }

        private void cbRegistarski_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                Registarski();
            }
        }
        private void TraziGorivoID()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT GorivoID from Gorivo WHERE Gorivo = '" + gorivo + "'";
                gorivoID = int.Parse((command.ExecuteScalar()).ToString());
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" GorivoID++" + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();

                }
            }
        }
        private void TraziGrupaID()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT GrupaID from Grupa WHERE Grupa = '" + grupa + "'";
                GrupaID = int.Parse((command.ExecuteScalar()).ToString());
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" GorivoID++" + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();

                }
            }
        }

        private void TraziMarkaID()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT VoziloID from Vozila WHERE Marka = '" + marka + "'";
                MarkaID = int.Parse((command.ExecuteScalar()).ToString());
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" MarkaID++" + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();

                }
            }
        }

        private void TraziModelID()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT ModelID from Model WHERE Model = '" + model + "'";
                ModelID = int.Parse((command.ExecuteScalar()).ToString());
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" ModelID++" + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();

                }
            }
        }
        private void TraziTipID()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT TipID from Tip WHERE Tip = '" + tip + "'";
                TipID = int.Parse((command.ExecuteScalar()).ToString());
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" TipID++" + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();

                }
            }
        }
        private void TraziGodisteID()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = kon;
                command.CommandText = "SELECT GodID from Godina WHERE Godina = '" + godiste + "'";
                GodisteID = int.Parse((command.ExecuteScalar()).ToString());
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" GodisteID++" + ex.ToString());
            }
            finally
            {
                if (kon.State == ConnectionState.Open)
                {
                    kon.Close();

                }
            }
        }
       
        private void Registarski()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM Auto WHERE Registarski = '" + cbRegistarski.Text + "' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    tbRegistarski.Text = (myReader["Registarski"].ToString());
                    marka = (myReader["Marka"].ToString());
                    model = (myReader["Model"].ToString());
                    tip = (myReader["Tip"].ToString());
                    godiste = (myReader["Godiste"].ToString());
                    tbBrojSasije.Text = (myReader["Broj_sasije"].ToString());
                    broj_sasije = (myReader["Broj_sasije"].ToString());
                    tbBrojMotora.Text = (myReader["Broj_motora"].ToString());
                    tbZapremina.Text = (myReader["Zapremina"].ToString());
                    tbSnaga.Text = (myReader["Snaga_kw"].ToString());
                    gorivo = (myReader["Gorivo"].ToString());
                    tbStaraTablica.Text = (myReader["Stara_tablica"].ToString());
                    tbStaraTablica1.Text = (myReader["Stara_tablica1"].ToString());
                    tbPozvati.Text = (myReader["Pozvati"].ToString());
                    tbRadioKod.Text = (myReader["Radio_kod"].ToString());
                    tbKljucKod.Text = (myReader["Kljuc_kod"].ToString());
                    TraziGorivoID();
                    TraziMarkaID();
                    TraziModelID();
                    TraziTipID();
                    TraziGodisteID();
                }
                kon.Close();
                cbGorivo.SelectedValue = gorivoID;
                cbMarka.SelectedValue = MarkaID;
                cbModel.SelectedValue = ModelID;
                cbTip.SelectedValue = TipID;
                cbGodiste.SelectedValue = GodisteID;
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

        private void Izmeni_korisnika_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Dodaj_korisnika.promenljiva_za_formu == 1)
            {
                Dodaj_korisnika.promenljiva_za_formu = 0;
                Dodaj_korisnika.tmLoad.Start();
            }
        }
    }
}
