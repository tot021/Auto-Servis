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
    public partial class Trazi_vozila : Form
    {
        public static Timer tmPublic = new Timer();
        public static int promenljiva_za_izmenu = 0;
        int a = 0;
        public Trazi_vozila()
        {
            InitializeComponent();
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection kon = new SqlConnection(Konekcija.konstring);
            try
            {
                if (tbSearch.Text != "")
                {
                    try
                    {
                        a = int.Parse(tbSearch.Text);
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Vozila.VoziloID, Vozila.Marka, Model.Model FROM Vozila,Model WHERE Vozila.VoziloID = Model.VoziloId AND  Vozila.VoziloID LIKE '%'+'" + tbSearch.Text + "'+'%'", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch
                    {
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Vozila.VoziloID, Vozila.Marka, Model.Model FROM Vozila,Model WHERE Vozila.VoziloID = Model.VoziloId AND Vozila.Marka LIKE '%'+'" + tbSearch.Text + "'+'%'", kon);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Vozila.VoziloID, Vozila.Marka, Model.Model FROM Vozila,Model WHERE Vozila.VoziloID = Model.VoziloId", kon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            
        }
        
        private void Trazi_vozila_Load(object sender, EventArgs e)
        {
            tmPublic.Interval = 500;
            tmPublic.Tick +=new EventHandler(tmPublic_Tick);
            PuniDataGrid();
            
        }
       
        private void PuniDataGrid()
            {
                try
                {
                    SqlConnection kon = new SqlConnection(Konekcija.konstring);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Vozila.VoziloID, Vozila.Marka, Model.Model, Model.ModelID FROM Vozila,Model WHERE Vozila.VoziloID = Model.VoziloId", kon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            promenljiva_za_izmenu = 1;
            Izmeni_vozila iv = new Izmeni_vozila();
            iv.ShowDialog();
        }
        private void tmPublic_Tick(object sender, EventArgs e)
        {
            tmPublic.Stop();
            PuniDataGrid();
        }
        
    }
}
