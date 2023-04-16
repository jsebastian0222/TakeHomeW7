using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PUSING;

namespace PUSING
{
    public partial class Form2 : Form
    {
        public string PosterPath { get; set; }
        public string JudulFilm { get; set; }
        public Form1 MainForm { get; set; }
        public int idFilm { get; set; }

        private int selectedTime = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PictureBox picturebox = new PictureBox();
            picturebox.Image = Image.FromFile(PosterPath);
            picturebox.Size = new Size(200, 200);
            picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            picturebox.Location = new Point(20, 20);
            this.panel1.Controls.Add(picturebox);

            Label label = new Label();
            label.Text = JudulFilm;
            label.Font = new Font("Times New Roman", 30, FontStyle.Regular);
            label.Location = new Point(250, 45);
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            this.panel1.Controls.Add(label);

            Button backButton = new Button();
            backButton.Text = "Back";
            backButton.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            backButton.Location = new Point(20, 240);
            backButton.Click += new EventHandler(BackButton_Click);
            this.panel1.Controls.Add(backButton);

            Button buttonjam1 = new Button();
            buttonjam1.Text = "12:00";
            buttonjam1.Location = new Point(220, 120);
            buttonjam1.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            buttonjam1.Click += new EventHandler(buttonjam1_Click);
            this.panel1.Controls.Add(buttonjam1);

            Button buttonjam2 = new Button();
            buttonjam2.Text = "14:00";
            buttonjam2.Location = new Point(220, 150);
            buttonjam2.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            buttonjam2.Click += new EventHandler(buttonjam2_Click);
            this.panel1.Controls.Add(buttonjam2);

            Button buttonjam3 = new Button();
            buttonjam3.Text = "12:00";
            buttonjam3.Location = new Point(220, 180);
            buttonjam3.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            buttonjam3.Click += new EventHandler(buttonjam3_Click);
            this.panel1.Controls.Add(buttonjam3);

        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.ControlBox = false;
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            form.Show();
        }

        private void buttonjam1_Click(object sender, EventArgs e)
        {
            selectedTime = 0;
            showform3();
        }

        private void buttonjam2_Click(object sender, EventArgs e)
        {
            selectedTime = 1;
            showform3();
        }

        private void buttonjam3_Click(object sender, EventArgs e)
        {
            selectedTime = 2;
            showform3();
        }

        private void showform3()
        {
            Form3 form3 = new Form3();
            form3.Dock = DockStyle.Fill;
            form3.TopLevel = false;
            form3.ControlBox = false;
            form3.FormBorderStyle = FormBorderStyle.None;
            form3.idFilm = idFilm;
            form3.selectedTime = selectedTime;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form3);
            form3.Show();
        }
    }
}
