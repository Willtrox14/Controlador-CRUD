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
    public partial class ConsultaEsp : Form
    {
        public ConsultaEsp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 main = new Form1();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Campo vacio, es obligatorio...");
            }
            else
            {
                if (textBox1.Text.Length > 8)
                {
                    MessageBox.Show("Debe tener maximo 8 caracteres...");
                }
                else
                {
                    string cedula = textBox1.Text;
                    textBox1.Clear();
                    textBox1.Focus();
                    string query = "SELECT * FROM ESTUDIANTE WHERE CEDULA = " + cedula;
                    Queries(query);
                }
            }
        }

        private void Queries(string query)
        {

            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=UNITEC;";
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
                        textBox2.Text += (read);
                        if (read == "")
                        {
                            MessageBox.Show("Esa cedula no esta registrada...");
                        }
                    }
                }
                else {
                        MessageBox.Show("Esa cedula no esta registrada...");                }
                     }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error y es el siguiente: " + e);
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13){
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Campo vacio, es obligatorio...");
                }
                else
                {
                    if (textBox1.Text.Length > 8)
                    {
                        MessageBox.Show("Debe tener maximo 8 caracteres...");
                    }
                    else
                    {
                        string cedula = textBox1.Text;
                        textBox1.Clear();
                        textBox1.Focus();
                        string query = "SELECT * FROM ESTUDIANTE WHERE CEDULA = " + cedula;
                        Queries(query);
                    }
                }
            }
        }

    }
}
