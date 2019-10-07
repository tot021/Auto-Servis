using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Auto_servis
{
    public partial class Dodaj_korisnika : Form
    {
        int KorisnikID,AutoID,i = 0,errorRegistarski,errorBrojSasije;
        int errorNaziv,errorMobilni;
        public static int promenljiva_za_formu = 0;
        public static Timer tmLoad = new Timer();
        public Dodaj_korisnika()
        {
            InitializeComponent();
        }
        private void Dodaj_korisnika_Load(object sender, EventArgs e)
        { 
            tmLoad.Tick += new EventHandler(tmLoad_Tick);
            tmLoad.Interval = 500;
            tmLoad.Start();
        }
        private void btnUnesiKorisnika_Click(object sender, EventArgs e)
        {
            broj_korisnika();
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
                        "Insert Into Korisnik(KorID,Naziv,Adresa,Grad,Pozivni_broj,Jmbg_pib,Mobilni,Mobilni2,Telefon,E_mail,Websajt,Rok_placanja,Grupa) VALUES('" + KorisnikID.ToString() + "','" + tbNaziv.Text + "','" + tbAdresa.Text + "','" + tbGrad.Text + "','" + tbPozivniBroj.Text + "','" + tbJmbgPib.Text + "','" + tbMobilni.Text + "','" + tbMobilni2.Text + "','" + tbTelefon.Text + "','" + tbEmail.Text + "','" + tbWebsajt.Text + "','" + tbRokPlacanja.Text + "','" + cbGrupa.Text + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Uspesna transakcija");
                    Brisanje_polja_posle_transakcije_korisnika();
                    TransakcijaKorErr.SetError(btnUnesiKorisnika,"Uspesna transakcija");
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
                        puniKorisnika();
                        
                    }
                }
            }
        
        }
        // --------------------------------------------------
        // Funkcija za prebrojavanje korisnika i Auta
        private void broj_korisnika()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            kon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = kon;
            command.CommandText = "SELECT COUNT(KorID) from Korisnik";
            KorisnikID = int.Parse((command.ExecuteScalar()).ToString());
            KorisnikID++;
            kon.Close();
        }
        private void broj_auta()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            kon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = kon;
            command.CommandText = "SELECT COUNT(AutoID) from Auto";
            AutoID = int.Parse((command.ExecuteScalar()).ToString());
            AutoID++;
            kon.Close();
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
        
        // Pregled praznog polja ----------------------------------------------------------------
        private void Pregled_praznog_polja_Korisnika()
        {
            if ((errorNaziv == 0) && (errorMobilni==0) && (cbGrupa.SelectedIndex >=0))
            {
                btnUnesiKorisnika.Enabled = true;
            }
            else
            {
                btnUnesiKorisnika.Enabled = false;
            }
        }
        private void Pregled_praznog_polja_Auta()
        {
            if  ((errorRegistarski == 0) && (errorBrojSasije == 0) && (!String.IsNullOrWhiteSpace(tbBrojSasije.Text)) && (!String.IsNullOrWhiteSpace(tbRegistarski.Text)) && (cbGodiste.SelectedIndex >= 0) && (cbTip.SelectedIndex >= 0) && (cbModel.SelectedIndex >= 0) && (cbMarka.SelectedIndex >= 0) && (cbKorisnik.SelectedIndex >= 0))
            {
                btnUnesiAuto.Enabled = true;
            }
            else
            {
                btnUnesiAuto.Enabled = false;
            }
            
        }
       
        private void Brisanje_polja_posle_transakcije_korisnika()
        {
            tbNaziv.Clear();
            tbAdresa.Clear();
            tbGrad.Clear();
            tbPozivniBroj.Clear();
            tbJmbgPib.Clear();
            tbMobilni.Clear();
            tbMobilni2.Clear();
            tbTelefon.Clear();
            tbEmail.Clear();
            tbWebsajt.Clear();
            tbRokPlacanja.Clear();
            puniGrupu();
        }
        private void Brisanje_polja_posle_transakcije_auta()
        {
            tbRegistarski.Clear();
            tbBrojSasije.Clear();
            tbBrojMotora.Clear();
            tbZapremina.Clear();
            tbSnaga.Clear();
            tbStaraTablica.Clear();
            tbStaraTablica1.Clear();
            tbPozvati.Clear();
            tbRadioKod.Clear();
            tbKljucKod.Clear();
            puniKorisnika();
            puni_marku();
            puni_model();
            puniTip();
            puniGodiste();
            puniGorivo();
        }
        //Timer za pocetak
        private void tmLoad_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                puni_marku();
                puniTip();
                puniGodiste();
                puni_model();
                puniKorisnika();
                puniGorivo();
                puniGrupu();
                
                
                
                
                if (String.IsNullOrWhiteSpace(tbRegistarski.Text))
                {
                    errorRegistarski = 1;
                    RegistarskiError.SetError(tbRegistarski, "Prazno polje");
                }
                if (String.IsNullOrWhiteSpace(tbBrojSasije.Text))
                {
                    errorBrojSasije = 1;
                    BrojSasijeError.SetError(tbBrojSasije, "Prazno polje");
                }
                if (String.IsNullOrWhiteSpace(tbNaziv.Text))
                {
                    errorNaziv = 1;
                    NazivError.SetError(tbNaziv, "Prazno polje");
                }
                if (String.IsNullOrWhiteSpace(tbMobilni.Text))
                {
                    errorMobilni = 1;
                    MobilniError.SetError(tbMobilni, "Prazno polje");
                } 
                i = 1;
                tmLoad.Stop();
            }
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT KorID,Naziv FROM Korisnik ORDER BY Naziv ASC", kon);
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
        private void tbBrojSasije_TextChanged(object sender, EventArgs e)
        {
           
                if (String.IsNullOrWhiteSpace(tbBrojSasije.Text))
                {
                    BrojSasijeError.SetError(tbBrojSasije, "Prazno polje");
                    errorBrojSasije = 1;
                }
                else
                {
                    BrojSasijeError.SetError(tbBrojSasije, "");
                    errorBrojSasije = 0;
                }
                
                
            Pregled_praznog_polja_Auta();
        }
        private void tbRegistarski_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbRegistarski.Text))
            {
                RegistarskiError.SetError(tbRegistarski, "Prazno polje");
                errorRegistarski = 1;
               
            }
            else 
            {
              
                RegistarskiError.SetError(tbRegistarski , "");
                errorRegistarski = 0;
                
                
                
            }
            Pregled_praznog_polja_Auta();
        }
        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                puni_model();
            }
            Pregled_praznog_polja_Auta();
        }
        private void cbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja_Auta();
           
        }
        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja_Auta();
        }
        private void cbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja_Auta();
          
        }
        private void cbGodiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pregled_praznog_polja_Auta();
            
        }
        private void tbNaziv_TextChanged(object sender, EventArgs e)
        {
            
                if (String.IsNullOrWhiteSpace(tbNaziv.Text))
                {
                    NazivError.SetError(tbNaziv, "Prazno polje");
                    errorNaziv = 1;
                }
                else
                {
                    NazivError.SetError(tbNaziv, "");
                    errorNaziv = 0;
                }
                Pregled_praznog_polja_Korisnika();
        }
        private void tbMobilni_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbMobilni.Text))
            {
                MobilniError.SetError(tbMobilni, "Prazno polje");
                errorMobilni = 1;
            }
            else
            {
                MobilniError.SetError(tbMobilni, "");
                errorMobilni = 0;
            }
            Pregled_praznog_polja_Korisnika();
        }
        private void tbGrupa_TextChanged(object sender, EventArgs e)
        {
            
            Pregled_praznog_polja_Korisnika();
        }
        private void btnUnesiAuto_Click(object sender, EventArgs e)
        {
            //Prvo proveriti da li ima postojeceg broja sasije jer on mora biti jedinstven, posle moze transakcija za unos podataka!!
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) FROM Auto WHERE Broj_sasije = '"+tbBrojSasije.Text+"'", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Broj sasije postoji");
                }
                else
                {
                    broj_auta();
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
                                "Insert Into Auto(AutoID,KorID,Registarski,Marka,Model,Tip,Godiste,Broj_sasije,Broj_motora,Zapremina,Snaga_kw,Gorivo,Stara_tablica,Stara_tablica1,Pozvati,Radio_kod,Kljuc_kod) VALUES('" + AutoID.ToString() + "','" + cbKorisnik.SelectedValue.ToString() + "','" + tbRegistarski.Text + "','" + cbMarka.Text + "','" + cbModel.Text + "','" + cbTip.Text + "','" + cbGodiste.Text + "','" + tbBrojSasije.Text + "','" + tbBrojMotora.Text + "','" + tbZapremina.Text + "','" + tbSnaga.Text + "','"+cbGorivo.Text+"','" + tbStaraTablica.Text + "','" + tbStaraTablica1.Text + "','" + tbPozvati.Text + "','" + tbRadioKod.Text + "','" + tbKljucKod.Text + "')";
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            //MessageBox.Show("Uspesna transakcija");
                            TransakcijaAutErr.SetError(btnUnesiAuto, "Uspesna transakcija");
                            Brisanje_polja_posle_transakcije_auta();
                            tm.Start();
                           
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Transakcija" + ex.ToString());
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
            catch
            {
                MessageBox.Show("Greska pri proveravanju broja sasije");
            }
        }
        private void tm_Tick(object sender, EventArgs e)
        {
            TransakcijaAutErr.Clear();
            TransakcijaKorErr.Clear();
            tm.Stop();
        }
        private void btnUnesiSve_Click(object sender, EventArgs e)
        {
            i = 0;
            promenljiva_za_formu = 1;
            Dodaj_vozilo dv = new Dodaj_vozilo();
            dv.ShowDialog();
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            i = 0;
            promenljiva_za_formu = 1;
            Izmeni_vozila iv = new Izmeni_vozila();
            iv.ShowDialog();
        }
        private void btnUnesiGrupu_Click(object sender, EventArgs e)
        {
            i = 0;
            promenljiva_za_formu = 1;
            Dodaj_grupu dg = new Dodaj_grupu();
            dg.ShowDialog();
        }
        private void btnImeniGrupu_Click(object sender, EventArgs e)
        {
            i = 0;
            promenljiva_za_formu = 1;
            Izmeni_grupu ig = new Izmeni_grupu();
            ig.ShowDialog();
        }     
    }
}
