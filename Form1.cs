using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Hütchenspiel
{
    public partial class Form1 : Form
    {
        //Variablen
        public static int money = 10;
        public static bool[] upgradelist = { false, false, false, false };
        public string pathToSaveFile = @"..\..\..\saveFile.csv";

        public Form1()
        {
            InitializeComponent();
        }
              

        private void button5_Click(object sender, EventArgs e)
        {
            money = 10;

            Form2 mainGame = new Form2(money, upgradelist);
            this.Hide();
            mainGame.Show();
        }

        //Laden
        private void button6_Click(object sender, EventArgs e)
        {
            string save = File.ReadAllText(pathToSaveFile);

            if (save == "")
            {

            }
            else
            {
                string[] allContentInFile = save.Split("\n");
                string[] stringUpgrade = allContentInFile[1].Split(',');
                upgradelist = Array.ConvertAll(stringUpgrade, bool.Parse);
                money = Convert.ToInt32(allContentInFile[0]);
                Form2 mainGame = new Form2(money, upgradelist);
                mainGame.Show();
                this.Hide();
            }        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
