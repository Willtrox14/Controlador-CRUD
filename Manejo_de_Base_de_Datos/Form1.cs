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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingresar main = new Ingresar();
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsultAll todo = new ConsultAll();
            todo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultaEsp especifico = new ConsultaEsp();
            especifico.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actualizar update = new Actualizar();
            update.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            eliminarEsp eliminarEsp = new eliminarEsp();
            eliminarEsp.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            deleteAll();
        }

        private void deleteAll()
        {
            string mysqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=unitec;";
            MySqlConnection databaseConnection = new MySqlConnection(mysqlConnectionString);
            string query = "DELETE FROM ESTUDIANTE";
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;
            
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                MessageBox.Show("Todos los registros han sido Eliminados");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
        
    }
}
