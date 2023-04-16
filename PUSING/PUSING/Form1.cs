using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUSING
{
    public partial class Form1 : Form
    {
        string path = @".\movies\MOVIES.txt";
        List<string> judul = new List<string>();
        List<string> foto = new List<string>();
        Button[,] buttonArray = new Button[GridSize, GridSize];
        public const int GridSize = 10;
        public const int timeCount = 3;
        public static bool[,,,] buttonState = new bool[8, timeCount, GridSize, GridSize];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    judul.Add(parts[0]);
                    foto.Add(parts[1]);
                }
            }
            int count = 0;
            for (int i = 0; i < judul.Count; i++)
            {
                int row = i / 4;
                int col = i % 4;
                PictureBox picturebox = new PictureBox();
                picturebox.Image = Image.FromFile(foto[i]);
                picturebox.Size = new Size(150, 150);
                picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                picturebox.Location = new Point(col * 150 + 10, row * 150 + 100 + (row * 70));
                panel1.Controls.Add(picturebox);

                Label label = new Label();
                label.Text = judul[i];
                label.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Location = new Point(picturebox.Left + 25, picturebox.Bottom + 5);
                panel1.Controls.Add(label);
                count++;
                label.Tag = i;
                label.Click += Label_Click;

                Label Judul = new Label();
                label.Text = "Marvel Cinema";
                label.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                label.Location = new Point(270, 20);
                panel1.Controls.Add(label);
            }
        }
        private void Label_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Label label = sender as Label;
            if (label != null)
            {
                string posterPath = foto[int.Parse(label.Tag.ToString())] as string;
                if (!string.IsNullOrEmpty(posterPath))
                {
                    int index = foto.IndexOf(posterPath); 
                    if (index >= 0 && index < judul.Count) 
                    {
                        string judulFilm = judul[index]; 
                        Form2 form2 = new Form2();
                        form2.PosterPath = posterPath;
                        form2.JudulFilm = judulFilm;
                        form2.MainForm = this;
                        form2.idFilm = int.Parse(label.Tag.ToString());

                        form2.TopLevel = false;
                        panel1.Controls.Add(form2);
                        form2.FormBorderStyle = FormBorderStyle.None;
                        form2.Dock = DockStyle.Fill;
                        form2.Show();
                    }
                }
            }
        }
        public void SetButtonState(bool[,] buttonState)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (buttonState[i, j])
                    {
                        buttonArray[i, j].BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
