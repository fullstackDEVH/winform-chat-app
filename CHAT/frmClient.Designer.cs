namespace CHAT
{
    partial class frmClient
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
            textBox1 = new TextBox();
            button1 = new Button();
            txt_client_messaage = new TextBox();
            richTextBox1 = new RichTextBox();
            listBox1 = new ListBox();
            btn_fle = new Button();
            btn_icon = new Button();
            btn_img = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(566, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Chat Client";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(704, 363);
            button1.Name = "button1";
            button1.Size = new Size(62, 79);
            button1.TabIndex = 4;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btn_client_send;
            // 
            // txt_client_messaage
            // 
            txt_client_messaage.Location = new Point(115, 363);
            txt_client_messaage.Multiline = true;
            txt_client_messaage.Name = "txt_client_messaage";
            txt_client_messaage.Size = new Size(377, 79);
            txt_client_messaage.TabIndex = 6;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(115, 66);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(651, 291);
            richTextBox1.TabIndex = 16;
            richTextBox1.Text = "";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 66);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(97, 379);
            listBox1.TabIndex = 17;
            // 
            // btn_fle
            // 
            btn_fle.Location = new Point(564, 363);
            btn_fle.Name = "btn_fle";
            btn_fle.Size = new Size(60, 79);
            btn_fle.TabIndex = 21;
            btn_fle.Text = "FILE";
            btn_fle.UseVisualStyleBackColor = true;
            // 
            // btn_icon
            // 
            btn_icon.Location = new Point(498, 363);
            btn_icon.Name = "btn_icon";
            btn_icon.Size = new Size(60, 79);
            btn_icon.TabIndex = 20;
            btn_icon.Text = "ICON";
            btn_icon.UseVisualStyleBackColor = true;
            // 
            // btn_img
            // 
            btn_img.Location = new Point(630, 363);
            btn_img.Name = "btn_img";
            btn_img.Size = new Size(65, 79);
            btn_img.TabIndex = 19;
            btn_img.Text = "IMAGE";
            btn_img.UseVisualStyleBackColor = true;
            // 
            // frmClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_fle);
            Controls.Add(btn_icon);
            Controls.Add(btn_img);
            Controls.Add(listBox1);
            Controls.Add(richTextBox1);
            Controls.Add(txt_client_messaage);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "frmClient";
            Text = "Client";
            FormClosed += frmClient_FormClosed;
            Load += frmClient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox txt_client_messaage;
        private RichTextBox richTextBox1;
        private ListBox listBox1;
        private Button btn_fle;
        private Button btn_icon;
        private Button btn_img;
    }
}