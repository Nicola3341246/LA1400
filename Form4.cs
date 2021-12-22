using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hütchenspiel
{
    public partial class Form4 : Form
    {

        public bool[] upgradeList = new bool[4];
        public int money;

        public Form4(int getMoney, bool[] getUpgradeList)
        {
            InitializeComponent();
            money = getMoney;
            upgradeList = getUpgradeList;
            if (upgradeList[0] == true)
            {
                button1.Visible = false;
            }
            if (upgradeList[1] == true)
            {
                button2.Visible = false;
            }
            if (upgradeList[2] == true)
            {
                button3.Visible = false;
            }
            if (upgradeList[3] == true)
            {
                button4.Visible = false;
            }

            label2.Text = $"Geld: {money}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (money > 21)
            {
                upgradeList[0] = true;
                money = money - 20;
                label2.Text = $"Geld: {money}";
                button1.Visible = false;
            }
            else
            {
                MessageBox.Show("Sie haben nicht genug Geld");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (money > 31)
            {
                upgradeList[1] = true;
                money = money - 30;
                label2.Text = $"Geld: {money}";
                button2.Visible = false;
            }
            else
            {
                MessageBox.Show("Sie haben nicht genug Geld");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (money > 41)
            {
                upgradeList[2] = true;
                money = money - 40;
                label2.Text = $"Geld: {money}";
                button3.Visible = false;
            }
            else
            {
                MessageBox.Show("Sie haben nicht genug Geld");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (money > 21)
            {
                upgradeList[3] = true;
                money = money - 20;
                label2.Text = $"Geld: {money}";
                button4.Visible = false;
            }
            else
            {
                MessageBox.Show("Sie haben nicht genug Geld");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 mainGame = new Form2(money, upgradeList);
            mainGame.Show();
            this.Hide();
        }
    }
}
