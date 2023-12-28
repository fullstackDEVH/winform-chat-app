using System.Net;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace CHAT
{
    public partial class frmClient : Form
    {
        private Socket client;
        private List<Socket> clientSockets;
        private IPEndPoint iPEndPoint;
        private int port = 9001;
        private IPAddress iPAddress;
        private string pathImage;
        private Image icon;
        private int pos = 0;
        public string ipLocal = "127.0.0.1";
        public byte[] clientData;
        private float size = 14;
        private string font = "Times New Roman";
        public static string receivedPath = @"C:\SendFile\";
        private string pathFile = "";
        private String filename = "";
        bool isSending = false;

        public frmClient()
        {
            InitializeComponent();
            MyConnect();

        }

        private void receiverMessage()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    int bytesRead = client.Receive(data);

                    string header = Encoding.UTF8.GetString(data.Take(5).ToArray());
                    Debug.WriteLine("header : " + header);

                    if (header == "IMAGE")
                    {
                        // Process image data
                        if (bytesRead > 5)
                        {
                            byte[] imageData = new byte[bytesRead - 5];
                            Array.Copy(data, 5, imageData, 0, bytesRead - 5);

                            // Handle image data here (e.g., display in PictureBox)
                            DisplayImageInRichTextBox(imageData);
                        }
                    }
                    else if ((header == "TEXTT"))
                    {
                        // Display text messages in the RichTextBox
                        string message = Encoding.UTF8.GetString(data, 0, bytesRead);
                        addMessageRich(message, "receiver");
                    }
                }
            }
            catch
            {
                client.Close();
            }
        }

        private void DisplayImageInRichTextBox(byte[] imageData)
        {
            try
            {
                if (imageData != null && imageData.Length > 0)
                {
                    Debug.WriteLine("display");
                    bool originalReadOnly = richTextBox1.ReadOnly;

                    // Temporarily set ReadOnly to false to enable editing
                    richTextBox1.ReadOnly = false;

                    // Perform the paste operation
                    Clipboard.SetData(DataFormats.Bitmap, byteArrayToImage(imageData));
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    richTextBox1.Paste();

                    // Restore the original ReadOnly status
                    richTextBox1.ReadOnly = originalReadOnly;
                  //  richTextBox1.AppendText(Environment.NewLine);

                    richTextBox1.ReadOnly = originalReadOnly;
                    addMessageRich("", "receiver");
                }
                else
                {
                    Debug.WriteLine("Error displaying image: Image data is empty or null.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error displaying image: " + ex.Message);
            }
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void addMessageRich(string message, string direction = "sender")
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string status = (direction == "sender") ? "Đã gửi" : "Đã nhận";

            if (direction == "sender")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
            else if (direction == "receiver")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
            richTextBox1.AppendText($"{message}\n{status} lúc {timestamp}\n\n");
        }

        private void MyConnect()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            iPAddress = IPAddress.Parse(ipLocal);
            Console.WriteLine("@@@@" + iPAddress);
            iPEndPoint = new IPEndPoint(iPAddress, port);
            try
            {
                client.Connect(iPEndPoint);
                Console.WriteLine("Connect success !!!");
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
                MessageBox.Show("Không có server để kết nối, hãy thử lại server đã bật !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Không có server để kết nối, hãy thử lại server đã bật !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread listens = new Thread(receiverMessage);
            listens.SetApartmentState(ApartmentState.STA);
            listens.IsBackground = true;
            listens.Start();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }

        private void btn_client_send(object sender, EventArgs e)
        {
            if (txt_client_messaage.Text != string.Empty)
            {
                byte[] textHeader = Encoding.UTF8.GetBytes("TEXTT");
                byte[] textMessageData = Encoding.UTF8.GetBytes(txt_client_messaage.Text);
                byte[] textData = textHeader.Concat(textMessageData).ToArray();

                client.Send(textData);
            }
            addMessageRich(txt_client_messaage.Text);
            txt_client_messaage.Clear();
        }

        private string deCode(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }
        private byte[] enCode(string data)
        {
            return Encoding.Unicode.GetBytes(data);
        }

        private void frmClient_Load(object sender, EventArgs e)
        {

        }
    }
}