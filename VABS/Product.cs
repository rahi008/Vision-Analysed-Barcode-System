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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            datatable();
        }
        string Sl;

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "insert into barcode_data.product_infos (Product_Name,Barcode_number) values ('" + this.prdctnm_text.Text + "','" + this.brcdnmbr_text.Text + "') ;";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Product_Name"].Value.ToString();
                textBox2.Text = row.Cells["Barcode_number"].Value.ToString();
                Sl = row.Cells["Sl"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "update barcode_data.product_infos set Product_Name='" + this.textBox1.Text + "',Barcode_number='" + this.textBox2.Text + "' where Sl='" + Sl + "' ;";
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
        void datatable()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(" select * from barcode_data.product_infos ;", conDataBase);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "delete from barcode_data.product_infos where Sl='" + Sl + "' ;";
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
