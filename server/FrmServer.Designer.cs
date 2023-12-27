namespace server
{
    partial class FrmServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox2 = new ListBox();
            textBox1 = new TextBox();
            txt_client_messaage = new TextBox();
            btn_server_send = new Button();
            textBox2 = new TextBox();
            list_box = new CheckedListBox();
            richTextBox1 = new RichTextBox();
            btn_img = new Button();
            btn_icon = new Button();
            btn_fle = new Button();
            SuspendLayout();
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(117, 361);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(368, 79);
            listBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(117, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(566, 23);
            textBox1.TabIndex = 6;
            textBox1.Text = "Chat Server";
            // 
            // txt_client_messaage
            // 
            txt_client_messaage.Location = new Point(117, 361);
            txt_client_messaage.Multiline = true;
            txt_client_messaage.Name = "txt_client_messaage";
            txt_client_messaage.Size = new Size(368, 79);
            txt_client_messaage.TabIndex = 13;
            // 
            // btn_server_send
            // 
            btn_server_send.Location = new Point(694, 361);
            btn_server_send.Name = "btn_server_send";
            btn_server_send.Size = new Size(64, 79);
            btn_server_send.TabIndex = 11;
            btn_server_send.Text = "SEND";
            btn_server_send.UseVisualStyleBackColor = true;
            btn_server_send.Click += btn_server_send_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(117, 10);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(566, 23);
            textBox2.TabIndex = 10;
            textBox2.Text = "Chat Server";
            // 
            // list_box
            // 
            list_box.FormattingEnabled = true;
            list_box.Location = new Point(2, 64);
            list_box.Name = "list_box";
            list_box.Size = new Size(109, 382);
            list_box.TabIndex = 14;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ButtonHighlight;
            richTextBox1.Location = new Point(117, 64);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(641, 291);
            richTextBox1.TabIndex = 15;
            richTextBox1.Text = "";
            // 
            // btn_img
            // 
            btn_img.Location = new Point(623, 361);
            btn_img.Name = "btn_img";
            btn_img.Size = new Size(65, 79);
            btn_img.TabIndex = 16;
            btn_img.Text = "IMAGE";
            btn_img.UseVisualStyleBackColor = true;
            btn_img.Click += button2_Click;
            // 
            // btn_icon
            // 
            btn_icon.Location = new Point(491, 361);
            btn_icon.Name = "btn_icon";
            btn_icon.Size = new Size(60, 79);
            btn_icon.TabIndex = 17;
            btn_icon.Text = "ICON";
            btn_icon.UseVisualStyleBackColor = true;
            btn_icon.Click += btn_file_Click;
            // 
            // btn_fle
            // 
            btn_fle.Location = new Point(557, 361);
            btn_fle.Name = "btn_fle";
            btn_fle.Size = new Size(60, 79);
            btn_fle.TabIndex = 18;
            btn_fle.Text = "FILE";
            btn_fle.UseVisualStyleBackColor = true;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_fle);
            Controls.Add(btn_icon);
            Controls.Add(btn_img);
            Controls.Add(richTextBox1);
            Controls.Add(list_box);
            Controls.Add(txt_client_messaage);
            Controls.Add(btn_server_send);
            Controls.Add(textBox2);
            Controls.Add(listBox2);
            Controls.Add(textBox1);
            Name = "FrmServer";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox2;
        private TextBox textBox1;
        private TextBox txt_client_messaage;
        private Button btn_server_send;
        private TextBox textBox2;
        private CheckedListBox list_box;
        private RichTextBox richTextBox1;
        private Button btn_img;
        private Button btn_icon;
        private Button btn_fle;
    }
}