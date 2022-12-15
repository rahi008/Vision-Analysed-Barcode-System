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

namespace VABS
{
    public partial class Login : Form
    {
        
        string p;
        public Login()
        {
            InitializeComponent();
            password_text.PasswordChar = '*';
            password_text.MaxLength = 25;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
                MySqlConnection myConn = new MySqlConnection(myconnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from barcode_data.eid where ID='" + this.username_text.Text + "' and Password='" + this.password_text.Text + "';", myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                    p = myReader.GetString("Admin");
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct");
                    this.Hide();
                    
                    if (p == "Y")
                    {
                        Admins_den f3 = new Admins_den(username_text.Text);
                        f3.ShowDialog();
                    }
                    else if (p == "N")
                    {
                        Barcode_inspection f4 = new Barcode_inspection(username_text.Text);
                        f4.ShowDialog();
                    }


                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password...access denied");
                }
                else
                {
                    MessageBox.Show("Username and password is not correct...please try again");
                }
                //myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
