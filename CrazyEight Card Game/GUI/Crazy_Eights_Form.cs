using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GameObjects;
using Games;

namespace GUI {
    public partial class Crazy_Eights_Form : Form {
        public Crazy_Eights_Form()
        {
            InitializeComponent();

            Hand userHand = new Hand(new List<Card>
            {
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.King)
            });
           
            Hand comHand = new Hand(new List<Card>
            {
                new Card(Suit.Clubs, FaceValue.Ace),
                new Card(Suit.Clubs, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            DisplayHand(userHand, tblUserHand);
            DisplayHand(comHand, tblComHand);


            picDrawPile.Image = Images.GetBackOfCardImage();
            picDiscardPile.Image = Images.GetCardImage(new Card(Suit.Hearts, FaceValue.Queen));
        }
        private void UpdateInstructions(string message, bool wait = false)
        {
            lblInstructions.Text = message;
            lblInstructions.Refresh();
            if (wait)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }
        private void DisplayHand(Hand hand, TableLayoutPanel panel)
        {     // remove any previous card images     
            panel.Controls.Clear();

            // repeat for each card in the hand     
            for (int i = 0; i < hand.GetCount(); i++)
            {
                // add a picture box to the panel with the appropriate image        
                PictureBox picCard = new PictureBox();
                picCard.SizeMode = PictureBoxSizeMode.AutoSize;
                picCard.Image = Images.GetCardImage(hand.GetCard(i));
                panel.Controls.Add(picCard, i, 0);

                // add an event handler if it is being added to the user’s panel        
                if (panel == tblUserHand)
                {
                    picCard.Click += new System.EventHandler(this.picPlayCard_Click);
                }
            }
        }

        private void picPlayCard_Click(object sender, EventArgs e)
        {     // get the picturebox that was clicked     
            PictureBox picCard = (PictureBox)sender;

            // determine the position of the picturebox that was clicked     
            int columnNum = ((TableLayoutPanel)((Control)sender).Parent).GetPositionFromControl(picCard).Column;

            // ...you will need to continue this yourself in part C...     
            MessageBox.Show(string.Format("Clicked column {0}", columnNum));
            // temporary 
        }

        private void DealBtn_Click(object sender, EventArgs e)
        {
            Choose_Suit_Form suitForm = new Choose_Suit_Form();
            suitForm.ShowDialog();

            Suit chosenSuit = suitForm.GetChosenSuit();
            UpdateInstructions(string.Format("You chose {0}.", chosenSuit.ToString()), true);
            UpdateInstructions("Click Deal to start the game.");
        }
    }

    }
