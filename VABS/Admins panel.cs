using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VABS
{
    public partial class Admins_den : Form
    {
        string i;
        public Admins_den(string user)
        {
            InitializeComponent();
            i = user;
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Barcode_inspection f6 = new Barcode_inspection(i);
                f6.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Login f2 = new Login();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report f7 = new Report();
            f7.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User f8 = new User();
            f8.ShowDialog();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Product f5 = new Product();
            f5.ShowDialog();
        }

        private void Admins_den_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
