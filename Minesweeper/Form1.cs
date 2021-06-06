using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();
            int mine1 = rdn.Next(1, 12); //da stavi jednu bombu na broj od 1 do 12 random
            int mine2 = rdn.Next(13, 18);//da stavi jednu bombu na broj od 13 do 18 random
            int mine3 = rdn.Next(19, 35);//da stavi jednu bombu na broj od 19 do 25 random
            for (int i = 1; i <= 35; i++)
            {
                Button btnTemp = new Button();

               btnTemp.Name = "btnTemp"+i.ToString();
               btnTemp.Size = new System.Drawing.Size(40, 40);
               btnTemp.Text = i.ToString();
                btnTemp.BackColor = Color.Azure;
               btnTemp.UseVisualStyleBackColor = true;

                if (mine1 == i || mine2 == i || mine3 == i)
                    btnTemp.Tag = true; //Ako je mina nekom od i true
                else
                    btnTemp.Tag = false;
               
               btnTemp.Click+= BtnTemp_Click; 
               flowLayoutPanel1.Controls.Add(btnTemp); //Dodaju se dugmici

            }
        }

        private void BtnTemp_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            bool tag = (bool)btnTemp.Tag;

            if (tag) //Ako je pronadjena bomba 
            {
                btnTemp.BackColor = Color.Red;
                int score = int.Parse(label4.Text);
                score++;
                label4.Text = score.ToString();
                btnTemp.Enabled = false;

                if (score == 1) {
                    MessageBox.Show("Izgubili ste!","Rezultat igre",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                                  
                }
            }
            else {
                btnTemp.BackColor = Color.Green;
                int boom = int.Parse(label2.Text);
                boom++;
                label2.Text = boom.ToString();

                btnTemp.Enabled = false;

                
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Radila Ajla", "Igrica Minesweeper");

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
