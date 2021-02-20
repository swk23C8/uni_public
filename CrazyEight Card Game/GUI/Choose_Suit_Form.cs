using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GameObjects;
using Games;
namespace GUI
{
    public partial class Choose_Suit_Form : Form
    {
        public Choose_Suit_Form()
        {
            InitializeComponent();
   
        }
        public Suit GetChosenSuit()
        {
            if (radioButton1.Checked)
                return Suit.Clubs;

            if (radioButton2.Checked)
                return Suit.Diamonds;

            if (radioButton3.Checked)
                return Suit.Hearts;

            return Suit.Spades;
        }

        private void PlayCard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
