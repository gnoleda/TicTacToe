/*Purpose:              PROG 2370 Assignment 2             
 *Created By:           Aubrey Delong 7677545          
 * 
 * Revision History:    Created Oct.5'2017
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADelongAssignment2
{
    /// <summary>
    /// Main Class for TicTacToe
    /// </summary>
    public partial class TicTacToeForm : Form
    {
        const int NUMBER_OF_TURNS = 9;
        int clickNumber = 0;
        Bitmap x = ADelongAssignment2.Properties.Resources.x2;
        Bitmap o = ADelongAssignment2.Properties.Resources.o2;

        /// <summary>
        /// the constructor for TicTacToe class
        /// </summary>
        public TicTacToeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set image of picturebox
        /// Also, determine who wins, based on return value of CheckResult()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            //holds the value of the picbox most recently clicked
            PictureBox currentPic = (PictureBox)sender;

            if (clickNumber % 2 == 0)
            {
                currentPic.Image = x;
                clickNumber++;
                currentPic.Enabled = false;
            }
            else
            {
                currentPic.Image = o;
                clickNumber++;
                currentPic.Enabled = false;
            }

            if (CheckResult() == true)
            {
                if(currentPic.Image == x)
                {
                    MessageBox.Show(txtPlayer1.Text+" wins!");
                }
                else
                {
                    MessageBox.Show(txtPlayer2.Text +" wins!");
                }

                StartNewGame();
            }
            else if (clickNumber == NUMBER_OF_TURNS)
            {
                MessageBox.Show("Tie Game!");
                StartNewGame();
            }

        }

        /// <summary>
        /// Detemine if a player has won by comparing images
        /// </summary>
        /// <returns></returns>
        bool CheckResult()
        {
            //check for horizontal win            
            if (pic0.Image == pic1.Image && pic1.Image == pic2.Image && pic1.Image != null)
            {
                return true;
            }
            else if (pic3.Image == pic4.Image && pic4.Image == pic5.Image && pic3.Image != null)
            {
                return true;
            }
            else if (pic6.Image == pic7.Image && pic7.Image == pic8.Image && pic6.Image != null)
            {
                return true;
            }

            //check for a vertical win            
            else if (pic0.Image == pic3.Image && pic3.Image == pic6.Image && pic0.Image != null)
            {
                return true;
            }
            else if (pic1.Image == pic4.Image && pic4.Image == pic7.Image && pic1.Image != null)
            {
                return true;
            }
            else if (pic2.Image == pic5.Image && pic5.Image == pic8.Image && pic2.Image != null)
            {
                return true;
            }

            //check for diagonal win
            else if (pic0.Image == pic4.Image && pic4.Image == pic8.Image && pic0.Image != null)
            {
                return true;
            }
            else if (pic2.Image == pic4.Image && pic4.Image == pic6.Image && pic2.Image != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Set all images to null and enable all picture boxes
        /// </summary>
        public void StartNewGame()
        {
            //restart the game (make all picBox's empty)
            pic0.Image = pic1.Image = pic2.Image = pic3.Image = pic4.Image = pic5.Image = pic6.Image = pic7.Image = pic8.Image = null;

            //enable all buttons so they can be clicked again
            pic0.Enabled = pic1.Enabled = pic2.Enabled = pic3.Enabled = pic4.Enabled = pic5.Enabled = pic6.Enabled = pic7.Enabled = pic8.Enabled = true;

            //restart counter
            clickNumber = 0;
        }

        /// <summary>
        /// call StartNewGame method when user clicks button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}



