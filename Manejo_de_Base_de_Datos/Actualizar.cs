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
    public partial class Actualizar : Form
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string cedula = textBox1.Text;
            if (cedula.Length < 9 && cedula != "")
            {
                string query = "SELECT * FROM ESTUDIANTE WHERE CEDULA = " + cedula;

                string mysqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=unitec;";
                MySqlConnection databaseConnection = new MySqlConnection(mysqlConnectionString);

                consultarCedula(cedula, query, databaseConnection);
            }
            else {
                MessageBox.Show("Verifique que la cedula no exceda de los 8 digitos y que el campo no este vacio...");
            }
            

        }

        private void consultarCedula(string cedula, string query, MySqlConnection databaseConnection) {
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    button2.Enabled = false;
                    button3.Enabled = true;
                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox3.Text = cedula;
                    textBox4.Enabled = true;

                    myReader.Read();

                    textBox2.Text = myReader.GetString(0);
                    textBox4.Text = myReader.GetString(2);

                }
                else
                {
                    MessageBox.Show("Esta cedula no esta registrada...");
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 main = new Form1();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Alguno de los Campos esta Vacio, todos son obligatorios...");
            }
            else
            {
                if (textBox2.Text.Length > 20 || textBox3.Text.Length > 8 || textBox4.Text.Length > 2)
                {
                    MessageBox.Show("El nombre no debe tener mas de 20 caracteres, la cedula 8 y la edad 2");
                }
                else
                {
                    string cedulaVieja = textBox1.Text;
                    string nombre = textBox2.Text;
                    string cedulaNueva = textBox3.Text;
                    string edad = textBox4.Text;
                    string queryUpdate = "UPDATE estudiante SET Nombre = '" + nombre + "', Cedula = '" + cedulaNueva + "', Edad = '" + edad + "' WHERE Cedula = '" + cedulaVieja + "'";
                    string mysqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=unitec;";
                    MySqlConnection databaseConnection = new MySqlConnection(mysqlConnectionString);
                    query(queryUpdate, databaseConnection);
                    button2.Enabled = true;
                    button3.Enabled = false;
                    textBox1.Text = "Nombre";
                    textBox2.Text = "Cedula";
                    textBox3.Text = "Edad";
                    textBox1.Enabled = true;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;

                }
            }
        }

        private void query(string queryUpdate, MySqlConnection databaseConnection) {
            MySqlCommand databaseCommand = new MySqlCommand(queryUpdate, databaseConnection);
            databaseCommand.CommandTimeout = 60;
            try {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                MessageBox.Show("Estudiante Exitosamente Actualizado");
            }catch(Exception e){
                MessageBox.Show("Error: " + e.Message);
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13){
                string cedula = textBox1.Text;
                if (cedula.Length < 9 && cedula != "")
                {
                    string query = "SELECT * FROM ESTUDIANTE WHERE CEDULA = " + cedula;

                    string mysqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=unitec;";
                    MySqlConnection databaseConnection = new MySqlConnection(mysqlConnectionString);
                    
                        textBox2.Focus();
                    
                    consultarCedula(cedula, query, databaseConnection);
                }
                else
                {
                    MessageBox.Show("Verifique que la cedula no exceda de los 8 digitos y que el campo no este vacio...");
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13){
            textBox3.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Alguno de los Campos esta Vacio, todos son obligatorios...");
                }
                else
                {
                    if (textBox2.Text.Length > 20 || textBox3.Text.Length > 8 || textBox4.Text.Length > 2)
                    {
                        MessageBox.Show("El nombre no debe tener mas de 20 caracteres, la cedula 8 y la edad 2");
                    }
                    else
                    {
                        string cedulaVieja = textBox1.Text;
                        string nombre = textBox2.Text;
                        string cedulaNueva = textBox3.Text;
                        string edad = textBox4.Text;
                        string queryUpdate = "UPDATE estudiante SET Nombre = '" + nombre + "', Cedula = '" + cedulaNueva + "', Edad = '" + edad + "' WHERE Cedula = '" + cedulaVieja + "'";
                        string mysqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=unitec;";
                        MySqlConnection databaseConnection = new MySqlConnection(mysqlConnectionString);
                        query(queryUpdate, databaseConnection);
                        button2.Enabled = true;
                        button3.Enabled = false;
                        textBox1.Text = "Cedula";
                        textBox2.Text = "Nombre";
                        textBox3.Text = "Cedula";
                        textBox4.Text = "Edad";
                        textBox1.Enabled = true;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;

                    }
                }
            }
        }

    }
}
