using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hütchenspiel
{
    public partial class Form2 : Form
    {
        public int money;
        public int userEntry;
        public int multiplicator = 1;
        public int rightAnswer;
        public int secRightAnswer;
        public bool[] upgradeBought = new bool[4];
        public string pathToSaveFile = @"..\..\..\saveFile.csv";
        public Form2(int tempMoney, bool[] tempUpgradeList)
        {
            InitializeComponent();
            money = tempMoney;
            upgradeBought = tempUpgradeList;
            Save(money, upgradeBought);

            //Multiplicator
            if (upgradeBought[0])
            {
                multiplicator = multiplicator * 2;
            }
            if (upgradeBought[1])
            {
                multiplicator = multiplicator * 2;
            }
            if (upgradeBought[3])
            {
                multiplicator = multiplicator * 2;
            }

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label2.Text = $"Geld: {money}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                userEntry = Convert.ToInt32(textBox1.Text);
                if (userEntry > money)
                {
                    throw new Exception();
                }

                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                button1.Visible = false;
                textBox1.Visible = false;
                label1.Text = "Wählen Sie ein Hütchen aus";
            }
            catch (Exception)
            {
                label1.Text = "         Input incorrect\nBitte geben Sie Ihren Einsatz ein.";
                textBox1.Text = "";
            }

            Random rd = new Random();
            rightAnswer = rd.Next(1, 4);
            secRightAnswer = rd.Next(1, 4);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GameReset(1, true);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GameReset(2, true);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GameReset(3, true);
        }

        public void GameReset(int userGuess, bool checkTry)
        {
            if (checkTry)
            {
                if (upgradeBought[3])
                {
                    if (rightAnswer == userGuess)
                    {
                        money = money + (userEntry * multiplicator);
                    }
                    else
                    {
                        money = money - userEntry;
                    }
                }
                else
                {
                    if (rightAnswer == userGuess)
                    {
                        money = money + (userEntry * multiplicator);
                    }
                    else
                    {
                        money = money - userEntry;
                    }
                }

            }
            label2.Text = $"Geld: {money}";

            if (money == 0)
            {
                File.WriteAllText(pathToSaveFile, "");
                Form3 gameOverScreen = new Form3();
                this.Hide();
                gameOverScreen.Show();
            }
            else
            {
                Save(money, upgradeBought);                
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                textBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Text = "";
                label1.Text = "Bitte geben Sie Ihren Einsatz ein.";
            }
        }

        static void Save(int money, bool[] upgradeList)
        {
            string allToSave = Convert.ToString(money) + "\n";
            for (int i = 0; i < upgradeList.Length; i++)
            {
                if (i < 3)
                {
                    allToSave = allToSave + Convert.ToString(upgradeList[i]) + ",";
                }
                else
                {
                    allToSave = allToSave + Convert.ToString(upgradeList[i]);
                }
            }

            File.WriteAllText(@"..\..\..\saveFile.csv", allToSave);
            return;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 Shop = new Form4(money, upgradeBought);
            Shop.Show();
            this.Hide();
        }

    }
}
