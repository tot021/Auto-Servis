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
    public partial class Auto_servis : Form
    {
        public static int Radni_nalog_ID;
        string query = "Sifra Radnog Naloga", value = "",sortiraj = "Sve";
        int i = 0;
        int proveri_broj_radnog_naloga;
        public static Timer tmLoad = new Timer();
        public Auto_servis()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tmLoad.Tick += new EventHandler(tmLoad_Tick);
            tmLoad.Interval = 500;
            tmLoad.Start();
      
        }
        private void tmLoad_Tick(object sender, EventArgs e)
        {
            pocetan_selekt();
            tmLoad.Stop();
            i = 1;
            if (dataGridView1.DataSource != null)
            {
                puni_rtb();
            }
        }
        private void puni_rtb()
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
            if (proveri_broj_radnog_naloga == 0)
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                try
                {
                    kon.Open();
                    SqlDataReader myReader = null;
                    SqlCommand command = new SqlCommand("SELECT Datum_izdavanja_vozila,Opis_kvara,Napomena FROM Radni_nalog WHERE RadniNalogID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ", kon);
                    myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        if ((myReader["Opis_kvara"].ToString()) == "")
                        {
                            rtbNapomena.Enabled = false;
                            rtbOpisKvara.Enabled = false;
                            rtbOpisKvara.ReadOnly = true;
                            rtbNapomena.ReadOnly = true;
                        }
                        rtbOpisKvara.Text = (myReader["Opis_kvara"].ToString());
                        rtbNapomena.Text = (myReader["Napomena"].ToString());
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
        private void pocetan_selekt()
        {
            try
            {
                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog", kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GRESKA" + ex.ToString());
            }
        }
        private void Trazi()
        {
            if (tbSearch.Text == "")
            {
                switch (sortiraj)
                {
                    case "Sve":
                        {
                            try
                            {
                                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog", kon);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("GRESKA" + ex.ToString());
                            }
                        }
                        break;
                    case "Otvoreni":
                        {
                            try
                            {
                                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Datum_izdavanja_vozila IS NULL", kon);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("GRESKA" + ex.ToString());
                            }
                        }
                        break;
                    case "Zatvoreni":
                        {
                            try
                            {
                                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Datum_izdavanja_vozila IS NOT NULL", kon);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("GRESKA" + ex.ToString());
                            }
                        }
                        break;
                }
            }
            else
            {

                switch (sortiraj)
                {
                    case "Sve":
                        {
                            Sve();
                        }
                        break;
                    case "Otvoreni":
                        {
                            Otvoreni();
                        }
                        break;
                    case "Zatvoreni":
                        {
                            Zatvoreni();
                        }
                        break;
                }
            }
        }
        private void Sve()
        {
            switch (query)
            {
                case "Sifra Radnog Naloga":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE RadniNalogID =  '" + value + "' ", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Registarski":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Registarski LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Sifra Korisnika":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE KorID = '" + value + "' ", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Naziv":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Naziv LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Broj sasije":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Broj_sasije LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Broj motora":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Broj_motora LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Marka":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Marka LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Model":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Model LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Tip":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Tip LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Godiste":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Godiste LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Grad":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Grad LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Jmbg/pib":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Jmbg_pib LIKE '%'+ '" + value + "' + '%'", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "":
                    {
                        try
                        {

                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                        break;
                    }
            }
        }
        private void Otvoreni()
        {
            switch (query)
            {
                case "Sifra Radnog Naloga":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE RadniNalogID =  '" + value + "' AND Datum_izdavanja_vozila IS NULL ", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Registarski":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Registarski LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Sifra Korisnika":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE KorID = '" + value + "' AND Datum_izdavanja_vozila IS NULL ", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Naziv":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Naziv LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Broj sasije":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Broj_sasije LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Broj motora":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Broj_motora LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Marka":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Marka LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Model":
                    {
                        try
                        {

                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Model LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Tip":
                    {
                        try
                        {

                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Tip LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Godiste":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Godiste LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Grad":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Grad LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Jmbg/pib":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Jmbg_pib LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Datum_izdavanja_vozila IS NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                        break;
                    }
            }
        }
        private void Zatvoreni()
        {
            switch (query)
            {
                case "Sifra Radnog Naloga":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE RadniNalogID =  '" + value + "' AND Datum_izdavanja_vozila IS NOT NULL ", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Registarski":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Registarski LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Sifra Korisnika":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE KorID = '" + value + "' AND Datum_izdavanja_vozila IS NOT NULL ", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Naziv":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Naziv LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Broj sasije":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Broj_sasije LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Broj motora":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Broj_motora LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Marka":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Marka LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Model":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Model LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Tip":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Tip LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Godiste":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Godiste LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Grad":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Grad LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "Jmbg/pib":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Jmbg_pib LIKE '%'+ '" + value + "' + '%' AND Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                    }
                    break;
                case "":
                    {
                        try
                        {
                            SqlConnection kon = new SqlConnection(Konekcija.konstring);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Datum_izdavanja_vozila IS NOT NULL", kon);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("GRESKA" + ex.ToString());
                        }
                        break;
                    }
            }
        }
        private void dodajVoziloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dodaj_vozilo dv = new Dodaj_vozilo();
            dv.ShowDialog();
        }
        private void vidiSvaVozilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trazi_vozila tv = new Trazi_vozila();
            tv.ShowDialog();
        }
        private void vidiSveKorisnikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trazi_korisnika tk = new Trazi_korisnika();
            tk.ShowDialog();
        }
        private void dodajKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dodaj_korisnika dk = new Dodaj_korisnika();
            dk.ShowDialog();
        }
        private void dodajUsluguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dodaj_uslugu du = new Dodaj_uslugu();
            du.ShowDialog();
        }
        private void izmeniVozilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izmeni_vozila iv = new Izmeni_vozila();
            iv.ShowDialog();
        }
        private void izmeniKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izmeni_korisnika ik = new Izmeni_korisnika();
            ik.ShowDialog();
        }
        private void dodajRadniNalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dodaj_radni_nalog drn = new Dodaj_radni_nalog();
            drn.ShowDialog();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Radni_nalog_ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Izmeni_radni_nalog ir = new Izmeni_radni_nalog();
            ir.ShowDialog();
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbSearch.Text))
            {
                value = "";
                switch (sortiraj)
                {
                    case "Sve":
                        {
                            try
                            {
                                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog", kon);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("GRESKA" + ex.ToString());
                            }
                        }
                        break;
                    case "Otvoreni":
                        {
                            try
                            {
                                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Datum_izdavanja_vozila IS NULL", kon);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("GRESKA" + ex.ToString());
                            }
                        }
                        break;
                    case "Zatvoreni":
                        {
                            try
                            {
                                SqlConnection kon = new SqlConnection(Konekcija.konstring);
                                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Radni_nalog WHERE Datum_izdavanja_vozila IS NOT NULL", kon);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("GRESKA" + ex.ToString());
                            }
                        }
                        break;
                }
            }
            else
            {
                value = tbSearch.Text;
                value = value.Replace('*', '_');
                Trazi();
            }
        }
        private void Provera_radio_buttona(object sender, EventArgs e)
        {
           RadioButton btn = sender as RadioButton;
           if (btn != null && btn.Checked == true)
           {
               query = btn.Text;
           }  
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (i == 1)
            {
                puni_rtb();
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
             DialogResult rezultat = MessageBox.Show("Da li sigurno zelita da obrisete radni nalog?", "Provera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            command.CommandText =
                                "DELETE FROM Broj_usluga WHERE Radni_nalogID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";
                            command.ExecuteNonQuery();
                            command.CommandText =
                                "DELETE FROM Radni_nalog WHERE RadniNalogID = '"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"' ";
                            command.ExecuteNonQuery();

                            transaction.Commit();
                            // MessageBox.Show("Uspesna transakcija");
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

        private void rbSve_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn != null && btn.Checked == true)
            {
                sortiraj = btn.Text;
                Trazi();
            }
        }

        private void dodajGrupuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dodaj_grupu dg = new Dodaj_grupu();
            dg.ShowDialog();
        }

        private void promeniGrupuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izmeni_grupu ig = new Izmeni_grupu();
            ig.ShowDialog();
        }  
    }
}
