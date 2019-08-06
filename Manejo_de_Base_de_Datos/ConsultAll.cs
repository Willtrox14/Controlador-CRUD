using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Manejo_de_Base_de_Datos
{
    public partial class ConsultAll : Form
    {
        public ConsultAll()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
             button2.Enabled = false;
                string query = "SELECT * FROM ESTUDIANTE";
                Queries(query);

        }

        private void Queries(string query)
        {

            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=UNITEC;";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string read = ("Nombre: " + myReader.GetString(0) + " - Cedula: " + myReader.GetString(1) + " - Edad: " + myReader.GetString(2) + Environment.NewLine);
                        textBox1.Text += (read);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error y es el siguiente: " + e.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Close();
        }

        private void ConsultAll_Load(object sender, EventArgs e)
        {

        }
    }
}
