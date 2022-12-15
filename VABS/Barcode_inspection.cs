using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ozeki.Camera;
using Ozeki.Media;
using Time = System.DateTime;
using Ozeki.Vision;
using MySql.Data.MySqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace VABS
{
    public partial class Barcode_inspection : Form
    {
        CameraURLBuilderWF _myCameraUrlBuilder;
        private IBarcodeReader _barcodeReader;
        private OzekiCamera _camera;
        private DrawingImageProvider _imageProvider;
        private MediaConnector _connector;
        private ImageProcesserHandler _imageProcesserHandler;
        private FrameCapture _frameCapture;
        private List<DetectedBarcode> _barcodesList;
        private int _counter;
        private int _counter1;
        private int _index = 0;

        string b;
        string p;
        string k;

        public Barcode_inspection(string us)
        {
            InitializeComponent();
            datatable1();
            k = us;
            combofill();
        }
        DataTable dbdataset;
        void combofill()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = " select * from barcode_data.product_infos ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string cmbnw = myReader.GetString("Product_Name");
                    comboBox1.Items.Add(cmbnw);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = " select * from barcode_data.product_infos where Product_name='" + comboBox1.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    p = myReader.GetString("Product_Name");
                    b = myReader.GetString("Barcode_number");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void _camera_CameraStateChanged(object sender, CameraStateEventArgs e)
        {
            InvokeGuiThread(() =>
            {
                if (e.State == CameraState.Connecting)
                    buttonConnect.Enabled = false;
                if (e.State == CameraState.Streaming)
                    buttonDisconnect.Enabled = true;
                if (e.State == CameraState.Disconnected)
                {
                    buttonDisconnect.Enabled = false;
                    buttonConnect.Enabled = true;
                }
            });
        }
        void InvokeGuiThread(Action action)
        {
            BeginInvoke(action);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (_camera != null)
            {
                _camera.CameraStateChanged -= _camera_CameraStateChanged;
                _camera.Disconnect();
                _connector.Disconnect(_camera.VideoChannel, _imageProvider);
                _camera.Dispose();
                _camera = null;
            }

            _camera = new OzekiCamera(_myCameraUrlBuilder.CameraURL);

            _camera.CameraStateChanged += _camera_CameraStateChanged;

            _connector.Connect(_camera.VideoChannel, _imageProvider);
            videoViewer.SetImageProvider(_imageProvider);

            videoViewer.Start();

            _camera.Start();

            textBoxState.Text = @"Camera started.";
            buttonStartDetect.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = _myCameraUrlBuilder.ShowDialog();

            if (result != DialogResult.OK) return;

            tb_cameraUrl.Text = _myCameraUrlBuilder.CameraURL;

            buttonConnect.Enabled = true;
        }

        void StopDetect()
        {
            _frameCapture.Stop();
            _connector.Disconnect(_frameCapture, _imageProcesserHandler);
            _barcodeReader.DetectionOccurred -= _barcodeReaderUSBcam_DetectionOccurred;

            buttonStartDetect.Enabled = true;
            buttonStopDetect.Enabled = false;
            textBoxDetectorState.Text = @"Stopped";
            _imageProcesserHandler.Stop();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (_camera == null) return;

            if (buttonStopDetect.Enabled)
                StopDetect();

            _connector.Disconnect(_camera.VideoChannel, _imageProvider);
            videoViewer.Stop();
            _camera.Stop();

            textBoxState.Text = @"Camera stopped.";
            buttonStartDetect.Enabled = false;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "insert into barcode_data.barcode_results (Product_Name,Batch_number) values ('" + this.comboBox1.Text + "','" + this.batchnmbr.Text + "') ;";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read()) { }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        void _barcodeReaderUSBcam_DetectionOccurred(object sender, BarcodeDetectedEventArgs e)
        {
            InvokeGuiThread(() =>
            {
                if (e == null)
                    return;

                else if (e.DetectedBarcode.Content.Equals(b))
                { _counter++; }
                else
                {
                    _counter++;
                    _counter1++;
                    System.Media.SystemSounds.Beep.Play();
                }




                _barcodesList.Add(e.DetectedBarcode);
                DateTime Date1 = DateTime.Now;
                DateTime dateonly = Date1.Date;


                textBoxBarcodes.Text += String.Format("{0}, Date: {1}, Barcode format: {2}, Content: {3}",
                    _counter, DateTime.Now, e.DetectedBarcode.BarcodeFormat, e.DetectedBarcode.Content) + Environment.NewLine;
            });
            System.Threading.Thread.Sleep(500);
        }


        private void buttonStartDetect_Click(object sender, EventArgs e)
        {
            StopDetect();
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "update barcode_data.barcode_results set Batch_number='" + this.batchnmbr.Text + "' ,Date='" + DateTime.Now.ToString("d") + "', Start_time='" + DateTime.Now.ToString("t") + "',User='" + k + "' where Batch_number='" + this.batchnmbr.Text + "' ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read()) { }
                _barcodeReader.DetectionOccurred += _barcodeReaderUSBcam_DetectionOccurred;

                _imageProcesserHandler.AddProcesser(_barcodeReader);

                _frameCapture.SetInterval(Int32.Parse(textBoxFrame.Text));

                _connector.Connect(_camera.VideoChannel, _frameCapture);
                _connector.Connect(_frameCapture, _imageProcesserHandler);

                _frameCapture.Start();
                _imageProcesserHandler.Start();

                buttonStartDetect.Enabled = false;
                buttonStopDetect.Enabled = true;
                textBoxDetectorState.Text = @"Running...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error occured: " + ex.Message);
            }
        }
        void textBoxFrame_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _frameCapture.SetInterval(Int32.Parse(textBoxFrame.Text));
                _frameCapture.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonStopDetect_Click(object sender, EventArgs e)
        {
            StopDetect();
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            string Query = "update barcode_data.barcode_results set Batch_number='" + this.batchnmbr.Text + "' ,End_time='" + DateTime.Now.ToString("t") + "',Total_inspected='" + _counter + "',Total_rejected='" + _counter1 + "'where Batch_number='" + this.batchnmbr.Text + "' ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                datatable1();

                while (myReader.Read()) { }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Barcode_inspection_Load(object sender, EventArgs e)
        {
            _imageProvider = new DrawingImageProvider();
            _connector = new MediaConnector();
            _imageProcesserHandler = new ImageProcesserHandler();
            _frameCapture = new FrameCapture();
            _barcodeReader = ImageProcesserFactory.CreateBarcodeReader();
            _barcodesList = new List<DetectedBarcode>();
            videoViewer.SetImageProvider(_imageProvider);
            _myCameraUrlBuilder = new CameraURLBuilderWF();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();

            Login f2 = new Login();
            f2.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Product_Name LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }
        void datatable1()
        {
            string constring = "datasource=127.0.0.1;port=3306;username=root;password=raSa2139";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(" select Product_Name,Batch_number,Date,Start_time,End_time,Total_inspected,Total_rejected,User from barcode_data.barcode_results ;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
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

        private void button3_Click_1(object sender, EventArgs e)
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
    }
}
