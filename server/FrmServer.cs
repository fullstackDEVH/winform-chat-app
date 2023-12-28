using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace server
{
    public partial class FrmServer : Form
    {


        private Socket server;
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

        public FrmServer()
        {
            InitializeComponent();
            MyConnect();
            clientSockets = new List<Socket>();
        }

        private void receiverMessage(object obj)
        {
            string ipSendTo = "";
            Socket client = obj as Socket;
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
                    else if (header == "TEXTT" && bytesRead > 5)
                    {
                        // Skip the header and extract the text message
                        string message = Encoding.UTF8.GetString(data, 0, bytesRead);
                        foreach (Socket item in clientSockets)
                        {
                            if (item != client)
                            {
                                if (header == "TEXTT")
                                {
                                    // Send the text data to other clients
                                    byte[] textHeader = Encoding.UTF8.GetBytes("TEXTT");
                                    byte[] textMessageData = Encoding.UTF8.GetBytes(message);
                                    byte[] textData = textHeader.Concat(textMessageData).ToArray();
                                    item.Send(textData);
                                }
                            }
                        }

                        addMessageRich(message, "receiver");
                    }
                }
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                clientSockets.Remove(client);
                client.Close();

                string strListClient = "";


                foreach (Socket item in clientSockets)
                {
                    strListClient += item.LocalEndPoint.ToString() + "&";

                }
                foreach (Socket item in clientSockets)
                {
                    item.Send(enCode(strListClient + ";"));
                }
                Console.WriteLine("Một Client đã ngắt kết nối");
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
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            iPAddress = IPAddress.Parse(ipLocal);
            Console.WriteLine("@@@@" + iPAddress);
            iPEndPoint = new IPEndPoint(IPAddress.Any, port);
            server.Bind(iPEndPoint);
            Console.WriteLine("Connect iPEndPoint success client!!!");


            Control.CheckForIllegalCrossThreadCalls = false;
            Thread thread1 = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        string strListClient = "";
                        server.Listen(100);
                        Socket client = server.Accept();
                        Console.WriteLine("Connect success client!!!");
                        clientSockets.Add(client);
                        list_box.Items.Add(client.RemoteEndPoint.ToString());


                        /* Console.WriteLine("clientSockets : " + clientSockets);
                         foreach (Socket item in clientSockets)
                         {
                             strListClient += item.LocalEndPoint.ToString() + "&";
                         }
                         foreach (Socket item in clientSockets)
                         {
                             item.Send(enCode(strListClient + ";"));
                             Console.WriteLine(strListClient + ";");
                         }
                        */
                        Thread threadReceive = new Thread(receiverMessage);
                        threadReceive.SetApartmentState(ApartmentState.STA);
                        threadReceive.IsBackground = true;
                        threadReceive.Start(client);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine("Looix guiw foile");
                        iPEndPoint = new IPEndPoint(iPAddress, port);
                        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Một Client mất điện !!!!");

                    }
                }

            });
            thread1.SetApartmentState(ApartmentState.STA);
            thread1.IsBackground = true;
            thread1.Start();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void sendImages()
        {
            OpenFileDialog imageDialog = new OpenFileDialog();
            imageDialog.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif";

            if (imageDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = imageDialog.FileName;
                Image image = Image.FromFile(imagePath);
                byte[] imageData = ImageToByteArray(image);


                DisplayImageInRichTextBox(imageData);

                foreach (Socket socket in clientSockets)
                {

                    // Add a header to indicate that the data is an 
                    byte[] header = Encoding.UTF8.GetBytes("IMAGE");
                    byte[] dataToSend = header.Concat(imageData).ToArray();
                    socket.Send(dataToSend);
                }
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

        private void DisplayImageInRichTextBox(byte[] imageData)
        {
            try
            {
                if (imageData != null && imageData.Length > 0)
                {
                    bool originalReadOnly = richTextBox1.ReadOnly;

                    richTextBox1.ReadOnly = false;

                    Clipboard.SetData(DataFormats.Bitmap, byteArrayToImage(imageData));
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    richTextBox1.Paste();
                   // richTextBox1.AppendText(Environment.NewLine);

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

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }


        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }

        private string deCode(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }
        private byte[] enCode(string data)
        {
            return Encoding.Unicode.GetBytes(data);
        }

        private void btn_server_send_Click(object sender, EventArgs e)
        {

            foreach (Socket socket in clientSockets)
            {
                if (txt_client_messaage.Text != string.Empty)
                {
                    byte[] textData = Encoding.UTF8.GetBytes("TEXTT" + txt_client_messaage.Text);
                    socket.Send(textData);
                }
            }
            addMessageRich(txt_client_messaage.Text);
            txt_client_messaage.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendImages();
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            FileDialog fDg = new OpenFileDialog();
            if (fDg.ShowDialog() == DialogResult.OK)
            {
                clientSockets[1].SendFile(fDg.FileName);
            }
        }

        private void xoa_message()
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn xóa tất cả các tin nhắn !!!", "Error", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                richTextBox1.ReadOnly = false;
                richTextBox1.SelectAll();
                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectedText = richTextBox1.SelectedText.Replace(richTextBox1.SelectedText, "");
                    richTextBox1.ReadOnly = true;
                }
            }

        }
    }
}