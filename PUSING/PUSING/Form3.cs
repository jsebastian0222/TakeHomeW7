using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUSING
{
    public partial class Form3 : Form
    {
        List<Button> clickedButtons = new List<Button>();
        Button[,] buttonArray = new Button[GridSize, GridSize];
        private bool[,,,] buttonState = Form1.buttonState;
        Random rand = new Random();
        public int selectedTime { get; set; }
        public int idFilm { get; set; }

        private const int ButtonSize = 20;
        private const int GridSize = 10;
        private const int Spacing = 5;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "SELECT SEAT";
            label.Font = new Font("Times New Roman", 15, FontStyle.Regular);
            label.Location = new Point(80, 20);
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            this.panel1.Controls.Add(label);
            buttonState = Form1.buttonState;
            
            this.ClientSize = new System.Drawing.Size((ButtonSize + Spacing) * GridSize - Spacing + 50, (ButtonSize + Spacing) * GridSize - Spacing + 50);
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button button = new Button();
                    int randomValue = rand.Next(2);

                    if (randomValue == 1)
                    {
                        // jika nilai acak adalah 1, set warna button menjadi merah
                        button.BackColor = Color.Red;
                    }
                    button.Size = new System.Drawing.Size(ButtonSize, ButtonSize);
                    button.Location = new System.Drawing.Point(j * (ButtonSize + Spacing) + 80, i * (ButtonSize + Spacing) + 50);
                    button.Click += new EventHandler(button_Click);
                    this.panel1.Controls.Add(button);
                    buttonArray[i, j] = button;
                    if (buttonState[idFilm, selectedTime, i, j])
                    {
                        button.BackColor = Color.Red;
                    }
                }
            }


            Button buttonsave = new Button();
            buttonsave.Text = "reserve";
            buttonsave.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            buttonsave.Location = new Point(350, 250);
            buttonsave.AutoSize = true;
            buttonsave.TextAlign = ContentAlignment.MiddleCenter;
            buttonsave.Click += new EventHandler(buttonsave_Click);
            this.panel1.Controls.Add(buttonsave);

            Button buttonback = new Button();
            buttonback.Text = "back";
            buttonback.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            buttonback.Location = new Point(80, 350);
            buttonback.AutoSize = true;
            buttonback.TextAlign = ContentAlignment.MiddleCenter;
            buttonback.Click += new EventHandler(buttonback_Click);
            this.panel1.Controls.Add(buttonback);

            Button buttonreset = new Button();
            buttonreset.Text = "reset";
            buttonreset.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            buttonreset.Location = new Point(160, 350);
            buttonreset.AutoSize = true;
            buttonreset.TextAlign = ContentAlignment.MiddleCenter;
            buttonreset.Click += new EventHandler(buttonreset_Click);
            this.panel1.Controls.Add(buttonreset);

        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int i = (button.Location.Y - 50) / (ButtonSize + Spacing);
            int j = (button.Location.X - 80) / (ButtonSize + Spacing);
            buttonState[idFilm, selectedTime, i, j] = !buttonState[idFilm, selectedTime, i, j];

           
            if (buttonState[idFilm, selectedTime, i, j])
            {
                button.BackColor = Color.Red;
            }
            else
            {
                button.BackColor = Color.Empty;
            }

        }
        private void buttonsave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button button = buttonArray[i, j];
                    if (button.BackColor == Color.Red)
                    {
                        clickedButtons.Add(button);
                    }
                }
            }
            
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            this.Hide();
            
           
            form1.Show();
        }

        private void buttonreset_Click(object sender, EventArgs e)
        {
            ResetButtons();
        }

        private void ResetButtons()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button button = buttonArray[i, j];
                    buttonState[idFilm, selectedTime, i, j] = false;
                    button.BackColor = Color.Empty;
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
