using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
    
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {

            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public short PlayCount;
            public bool GameOver;

        }


        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }


            return false;
        }
        void EndGame()
        {

            lblWhoPlayer.Text = "Game Over";

            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lblWhoWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWhoWinner.Text = "Player2";
                    break;

                default:

                    lblWhoWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void CheckWinner()
        {

            if(GameStatus.GameOver)
                return;

            //Check Rows
            //Check Row 1
            if (CheckValues(button1, button2, button3))
                return;

            //Check Row 2
            if (CheckValues(button4, button5, button6))
                return;

            //Check Row 3
            if (CheckValues(button7, button8, button9))
                return;



            //Check Columns
            //Check Column 1
            if (CheckValues(button1, button4, button7))
                return;

            //Check Column 2
            if (CheckValues(button2, button5, button8))
                return;

            //Check Column 3 
            if (CheckValues(button3, button6, button9))
                return;

            //Check Diagonals

            //Check Diagonal 1
            if (CheckValues(button1, button5, button9))
                return;

            //Check Diagonal 2
            if (CheckValues(button3, button5, button7))
                return;

        }

        public void ChangeImage(Button btn)
        {
            if(btn.Tag.ToString()=="?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        btn.Tag = "X";
                        lblWhoPlayer.Text = "Player 2";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        btn.Tag = "O";
                        lblWhoPlayer.Text = "Player 1";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;
                }
            }
            else
            {
                         MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount == 9 && !GameStatus.GameOver)
            {
                GameStatus.Winner = enWinner.Draw;
                GameStatus.GameOver = true;
                EndGame();
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage( (Button) sender);
        }

   
        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Black;
        }

        private void RestartGame()
        {
            RestButton(button1);    
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            GameStatus.GameOver = false;
            GameStatus.PlayCount = 0;
            GameStatus.Winner = enWinner.GameInProgress;

            lblWhoPlayer.Text = "Player 1";
            lblWhoWinner.Text = "In Progress";
            PlayerTurn = enPlayer.Player1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);

            Pen Whitepen = new Pen(White);
            Whitepen.Width = 15;

            Whitepen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Whitepen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(Whitepen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(Whitepen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(Whitepen, 610, 140, 610, 620);
            e.Graphics.DrawLine(Whitepen, 840, 140, 840, 620);
        }

    }
}






    
