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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            datatable();
        }
        string Admin;
        string admin;
        string Sl;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Admin = "Y";
        }

        private void Nozzzzzzzzzzz_CheckedChanged(object sender, EventArgs e)
        {
            Admin = "N";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "insert into barcode_data.eid (Name,ID,Admin,Password) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + Admin+"','" + this.textBox3.Text + "') ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                datatable();
                while (myReader.Read()) { }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        void datatable()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(" select * from barcode_data.eid ;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch
            {

            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "update barcode_data.eid set Name='" + this.textBox4.Text + "',ID='" + this.textBox5.Text + "',Password='" + this.textBox6.Text + "',Admin='" + admin + "' where Sl='" + Sl + "' ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Updated");
                datatable();
                while (myReader.Read()) { }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells["Name"].Value.ToString();
                textBox5.Text = row.Cells["ID"].Value.ToString();
                admin = row.Cells["Admin"].Value.ToString();
                textBox6.Text = row.Cells["Password"].Value.ToString();
                Sl = row.Cells["Sl"].Value.ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            admin = "Y";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            admin = "N";
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "delete from barcode_data.eid where Sl='" + Sl + "' ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read()) { }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        
    }
}
