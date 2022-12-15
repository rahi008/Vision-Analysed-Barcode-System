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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace VABS
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            datatable1();
        }
        DataTable dbdataset;
        string Sl;

        private void Report_Load(object sender, EventArgs e)
        {

        }
        
        void datatable1()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(" select * from barcode_data.barcode_results ;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView2.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(iTextSharp.text.PageSize.A4);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();
                iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Renata_ltd_logo.png");
                doc.Add(PNG);
                Paragraph paragraph = new Paragraph("Barcode Report:\n\n\n\n\n");
                doc.Add(paragraph);
                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                }
                table.HeaderRows = 1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (dataGridView1[k, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                        }
                    }
                }
                doc.Add(table);
                doc.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Product_Name LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "update barcode_data.barcode_results set Date='" + this.textBox2.Text + "',Start_time='" + this.textBox3.Text + "',End_time='" + this.textBox4.Text + "' where Sl='" + Sl + "' ;";
            
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Updated");
                datatable1();
                while (myReader.Read()) { }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox2.Text = row.Cells["Date"].Value.ToString();
                textBox3.Text = row.Cells["Start_time"].Value.ToString();
                textBox4.Text = row.Cells["End_time"].Value.ToString();
                Sl = row.Cells["Sl"].Value.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Product_Name LIKE '%{0}%'", textBox5.Text);
            dataGridView2.DataSource = DV;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(iTextSharp.text.PageSize.A4);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();
                iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Renata_ltd_logo.png");
                doc.Add(PNG);
                Paragraph paragraph = new Paragraph("Barcode Report:\n\n\n\n\n");
                doc.Add(paragraph);
                PdfPTable table = new PdfPTable(dataGridView2.Columns.Count-1);
                for (int j = 1; j < dataGridView2.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView2.Columns[j].HeaderText));
                }
                table.HeaderRows = 1;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    
                    for (int k = 1; k < dataGridView2.Columns.Count; k++)
                    {
                       if (dataGridView2[k, i].Value != null)
                            {
                                table.AddCell(new Phrase(dataGridView2[k, i].Value.ToString()));
                            }
                    }
                                             }
                doc.Add(table);
                doc.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
                string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
                string Query = "delete from barcode_data.barcode_results where Sl='" + Sl + "' ;";
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
