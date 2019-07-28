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
    public partial class Ingresar : Form
    {
        public Ingresar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 main = new Form1();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Alguno de los Campos esta Vacio, todos son obligatorios...");
            }
            else
            {
                if (textBox1.Text.Length > 20 || textBox2.Text.Length > 8 || textBox3.Text.Length > 2)
                {
                    MessageBox.Show("El nombre no debe tener mas de 20 caracteres, la cedula 8 y la edad 2");
                }
                else
                {
                    string nombre = textBox1.Text;
                    string cedula = textBox2.Text;
                    string edad = textBox3.Text;
                    string query = "INSERT INTO ESTUDIANTE(Nombre,Cedula,Edad) VALUES ('" + nombre + "','" + cedula + "','" + edad + "')";
                    Queries(query,cedula);
                    textBox1.Focus();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
        }

        private void Queries(string query, string cedula)
        {
            string securityString = "SELECT * FROM ESTUDIANTE WHERE Cedula = '" + cedula + "'";
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=;database=UNITEC;";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            MySqlCommand commandSecurity = new MySqlCommand(securityString, databaseConnection);
            try {
                databaseConnection.Open();
                MySqlDataReader mySecurityReader = commandSecurity.ExecuteReader();
                if (mySecurityReader.HasRows)
                {
                    MessageBox.Show("Ya existe un estudiante con esta cedula...");
                }
                else
                {
                    mySecurityReader.Close();
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    MessageBox.Show("Estudiante Ingresado");
                }
            }catch(Exception e){
                MessageBox.Show("El error es: " + e.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13){
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Alguno de los Campos esta Vacio, todos son obligatorios...");
                }
                else
                {
                    if (textBox1.Text.Length > 20 || textBox2.Text.Length > 8 || textBox3.Text.Length > 2)
                    {
                        MessageBox.Show("El nombre no debe tener mas de 20 caracteres, la cedula 8 y la edad 2");
                    }
                    else
                    {
                        string nombre = textBox1.Text;
                        string cedula = textBox2.Text;
                        string edad = textBox3.Text;
                        
                        string query = "INSERT INTO ESTUDIANTE(Nombre,Cedula,Edad) VALUES ('" + nombre + "','" + cedula + "','" + edad + "')";
                        Queries(query, cedula);
                        textBox1.Focus();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                }
            }
        }

    }
}
