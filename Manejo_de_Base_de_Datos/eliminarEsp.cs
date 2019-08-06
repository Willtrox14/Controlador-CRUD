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
    public partial class eliminarEsp : Form
    {
        public eliminarEsp()
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
            string cedula = textBox1.Text;
            if (cedula.Length < 9 && cedula != "")
            {
                string query = "DELETE FROM ESTUDIANTE WHERE CEDULA = " + cedula;
                string querySecurity = "SELECT * FROM ESTUDIANTE WHERE CEDULA = " + cedula;
                string mysqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=unitec;";
                MySqlConnection databaseConnection = new MySqlConnection(mysqlConnectionString);

                delete(cedula, query, databaseConnection, querySecurity);

            }
            else
            {
                MessageBox.Show("Verifique que la cedula no exceda de los 8 digitos y que el campo no este vacio...");
                textBox1.Clear();
                textBox1.Focus();
            }
            
        }

        private void delete(string cedula, string query, MySqlConnection databaseConnection, string querySecurity)
        {
           
            MySqlCommand securityCommand = new MySqlCommand(querySecurity, databaseConnection);
            securityCommand.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader mySecurityReader = securityCommand.ExecuteReader();

                if (mySecurityReader.HasRows)
                {
                    mySecurityReader.Close();
                    MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
                    databaseCommand.CommandTimeout = 60;
                    MySqlDataReader myReader = databaseCommand.ExecuteReader();
                    try
                    {
                        MessageBox.Show("El estudiante con cedula: " + cedula + " ha sido eliminado satisfactoriamente...");
                        
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    catch (Exception e) { 
                    MessageBox.Show("Error: " + e.Message);
                    }
                    
                    
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13){
            string cedula = textBox1.Text;
            if (cedula.Length < 9 && cedula != "")
            {
                string query = "DELETE FROM ESTUDIANTE WHERE CEDULA = " + cedula;
                string querySecurity = "SELECT * FROM ESTUDIANTE WHERE CEDULA = " + cedula;
                string mysqlConnectionString = "datasource=127.0.0.1;port=3306;user=root;password=root;database=unitec;";
                MySqlConnection databaseConnection = new MySqlConnection(mysqlConnectionString);

                delete(cedula, query, databaseConnection, querySecurity);

            }
            else
            {
                MessageBox.Show("Verifique que la cedula no exceda de los 8 digitos y que el campo no este vacio...");
                textBox1.Clear();
                textBox1.Focus();
            }
            }
        }

    }
}
