using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn = null;                                                                                                                           //IP:llä toimii
            connectionString = "Server = 10.212.26.22,5555\\appdev; Database = SavoniaMeasurementsV2; Trusted_Connection = True; MultipleActiveResultSets = true"; //IP: 10.212.26.22  sql-savonia.ky.local
            cnn = new SqlConnection(connectionString);
            string Query = "select top 10 * from Data";
            DataTable table = new DataTable();
            
            
            try 
            { 
                cnn.Open();
                MessageBox.Show("connection open!");
                SqlCommand cmd = new SqlCommand(Query, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(Query, cnn);
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;
                if(table == null)
                {
                    MessageBox.Show("taulu tyhjä");
                }
                else
                {
                    MessageBox.Show("taulussa on dataa");
                }
               

            }
            catch(Exception ex) 
            {

                MessageBox.Show(ex.Message, "ei toimi");
            }
            finally
            {
                cnn.Close();
                MessageBox.Show("connection closed");
            }
            
        }

       

        
    }
}
