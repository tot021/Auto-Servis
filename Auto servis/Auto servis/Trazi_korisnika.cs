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
    public partial class Trazi_korisnika : Form
    {
        int a;
        string trazi;
        public static int AutoID = 0;
        public static Timer tmLoad = new Timer();
        public Trazi_korisnika()
        {
            InitializeComponent();
        }

        private void Trazi_korisnika_Load(object sender, EventArgs e)
        {
            
            tmLoad.Tick += new EventHandler(tmLoad_Tick);
            tmLoad.Interval = 500;
            if (Izmeni_korisnika.promenljiva_za_trazi_korisnika == 1)
            {
                Izmeni_korisnika.promenljiva_za_trazi_korisnika = 0;
                dataGridView1.DataSource = null;
                if (rbTraziKor.Checked == true)
                {

                    try
                    {

                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja , Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod FROM Korisnik,Auto WHERE Auto.KorId = Korisnik.KorID AND Auto.Broj_sasije = '" + Izmeni_korisnika.broj_sasije + "'", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("GRESKA" + ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod , Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja FROM Auto,Korisnik WHERE Korisnik.KorID = Auto.KorId AND Auto.Broj_sasije = '"+Izmeni_korisnika.broj_sasije+"' ", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("GRESKA" + ex.ToString());
                    }
                }
            }
            else if (Izmeni_korisnika_dvoklik.promenljiva_za_trazi_korisnika == 1)
            {
                Izmeni_korisnika_dvoklik.promenljiva_za_trazi_korisnika = 0;
                dataGridView1.DataSource = null;
                if (rbTraziKor.Checked == true)
                {

                    try
                    {

                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja , Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod FROM Korisnik,Auto WHERE Auto.KorId = Korisnik.KorID AND Auto.Broj_sasije = '" + Izmeni_korisnika_dvoklik.broj_sasije + "'", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("GRESKA" + ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod , Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja FROM Auto,Korisnik WHERE Korisnik.KorID = Auto.KorId AND Auto.Broj_sasije = '" + Izmeni_korisnika_dvoklik.broj_sasije + "' ", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("GRESKA" + ex.ToString());
                    }
                }
            }
            else
            {
                pocetan_selekt();
            } 
        }
        private void tmLoad_Tick(object sender, EventArgs e)
        {
            tmLoad.Stop();
            pocetan_selekt();
        }
        private void pocetan_selekt()
        {
            dataGridView1.DataSource = null;
            if (rbTraziKor.Checked == true)
            {
                
                try
                {
                    
                    SqlConnection kon = new SqlConnection(Konekcija.konstring);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja , Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod FROM Korisnik,Auto WHERE Auto.KorId = Korisnik.KorID", kon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GRESKA" + ex.ToString());
                }
            }
            else
            {
                try
                {
                    SqlConnection kon = new SqlConnection(Konekcija.konstring);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod , Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja FROM Auto,Korisnik WHERE Korisnik.KorID = Auto.KorId ", kon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GRESKA" + ex.ToString());
                }
            }
        }

        private void Trazi()
        {
            try
            {
                if (rbTraziKor.Checked == true)
                {
                    dataGridView1.DataSource = null;
                    try
                    {
                        a = int.Parse(trazi);
                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja , Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod FROM Korisnik,Auto WHERE Auto.KorId = Korisnik.KorID AND Korisnik.KorID LIKE '%'+ '" + trazi + "' + '%' ", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch
                    {
                       
                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja , Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod FROM Korisnik,Auto WHERE Auto.KorId = Korisnik.KorID AND Korisnik.Naziv LIKE '%'+ '" + trazi + "' + '%' ", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                else if (rbTraziAuto.Checked == true)
                {
                    dataGridView1.DataSource = null;
                    try
                    {
                        a = int.Parse(trazi);
                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod , Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja FROM Auto,Korisnik WHERE Korisnik.KorID = Auto.KorId AND Auto.AutoID LIKE '%'+ '" + trazi + "' + '%' ", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch
                    {
                        SqlConnection kon = new SqlConnection(Konekcija.konstring);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod , Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja  FROM Auto,Korisnik WHERE Korisnik.KorID = Auto.KorId AND Auto.Registarski LIKE '%'+ '" + trazi + "' + '%' ", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                else
                {
                    dataGridView1.DataSource = null;
                    SqlConnection kon = new SqlConnection(Konekcija.konstring);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Korisnik.KorID , Korisnik.Naziv , Korisnik.Adresa , Korisnik.Grad , Korisnik.Mobilni , Korisnik.Telefon , Korisnik.Rok_placanja , Auto.AutoID , Auto.Registarski , Auto.Marka , Auto.Model, Auto.Tip , Auto.Tip, Auto.Godiste, Auto.Broj_sasije , Auto.Broj_motora , Auto.Zapremina , Auto.Snaga_kw , Auto.Gorivo , Auto.Stara_tablica , Auto.Stara_tablica1 , Auto.Pozvati , Auto.Radio_kod , Auto.Kljuc_kod FROM Korisnik,Auto WHERE Auto.KorId = Korisnik.KorID", kon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("GRESKA" + ex.ToString());
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            trazi = tbSearch.Text;
            trazi = trazi.Replace('*', '_');
            Trazi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Izmeni_korisnika_dvoklik dvoklik = new Izmeni_korisnika_dvoklik();
            if (rbTraziAuto.Checked == true)
            {
                AutoID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            else
            {
                AutoID = int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
            }
            dvoklik.ShowDialog();
        }

        private void rbTraziKor_CheckedChanged(object sender, EventArgs e)
        {
            Trazi();
        }

        private void rbTraziAuto_CheckedChanged(object sender, EventArgs e)
        {
            Trazi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
