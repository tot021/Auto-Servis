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
    public partial class Vidi_podatke : Form
    {
        string Radni_nalog_ID;
        public Vidi_podatke()
        {
            InitializeComponent();
        }

        private void Vidi_podatke_Load(object sender, EventArgs e)
        {
            if (Dodaj_radni_nalog.promenljiva_za_podatke_dodaj == 1)
            {
                Dodaj_radni_nalog.promenljiva_za_podatke_dodaj = 0;
                Radni_nalog_ID = Dodaj_radni_nalog.RadniNalogID.ToString();
                puni_tb_po_autu();
                puni_tb_korisnika();
            }
            else
            {
                Izmeni_radni_nalog.promenljiva_za_podatke_izmeni = 0;
                Radni_nalog_ID = Izmeni_radni_nalog.RadniNalogID.ToString();
                puni_tb_po_autu();
                puni_tb_korisnika();
            }

        }
        private void puni_tb_korisnika()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {

                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT Naziv,Adresa,Grad,Pozivni_broj,Jmbg_pib,Mobilni,Mobilni2,Telefon,E_mail,Websajt,Rok_placanja,Grupa FROM Radni_nalog WHERE RadniNalogID = '" + Radni_nalog_ID + "' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    tbKorisnik.Text = (myReader["Naziv"].ToString());
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
                    tbGrupa.Text = (myReader["Grupa"].ToString());

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
        private void puni_tb_po_autu()
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {


                kon.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT Registarski,Marka,Model,Tip,Godiste,Broj_sasije,Broj_motora,Zapremina,Snaga_kw,Gorivo,Stara_tablica,Stara_tablica1,Pozvati,Radio_kod,Kljuc_kod FROM Radni_nalog WHERE RadniNalogID = '" + Radni_nalog_ID + "' ", kon);
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    tbRegistarski.Text = (myReader["Registarski"].ToString());
                    tbMarka.Text = (myReader["Marka"].ToString());
                    tbModel.Text = (myReader["Model"].ToString());
                    tbTip.Text = (myReader["Tip"].ToString());
                    tbGodiste.Text = (myReader["Godiste"].ToString());
                    tbBrojSasije.Text = (myReader["Broj_sasije"].ToString());
                    tbBrojMotora.Text = (myReader["Broj_motora"].ToString());
                    tbZapremina.Text = (myReader["Zapremina"].ToString());
                    tbSnaga.Text = (myReader["Snaga_kw"].ToString());
                    tbGorivo.Text = (myReader["Gorivo"].ToString());
                    tbStaraTablica.Text = (myReader["Stara_tablica"].ToString());
                    tbStaraTablica1.Text = (myReader["Stara_tablica1"].ToString());
                    tbPozvati.Text = (myReader["Pozvati"].ToString());
                    tbRadioKod.Text = (myReader["Radio_kod"].ToString());
                    tbKljucKod.Text = (myReader["Kljuc_kod"].ToString());
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
    }
}
