using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public enum player { x,o}
        player currentplayer;
        Random rana = new Random();
        int countplayer = 0;
        int countcomputer = 0;
        List<Button> buttons;
        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void player_chek_buttons(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentplayer = player.x;
            button.Text = currentplayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Red;
            buttons.Remove(button);
            checkGame();
            timercpu.Start();
            
        }

        private void player_again(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void btn_exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cpumove(object sender, EventArgs e)
        {
            if (buttons.Count > 0) 
            { int index = rana.Next(buttons.Count);
            buttons[index].Enabled = false;
            currentplayer = player.o;
            buttons[index].Text = currentplayer.ToString();
            buttons[index].BackColor = Color.Green;
            buttons.RemoveAt(index);
            checkGame();
            timercpu.Stop();
            }
        }

        private void checkGame()
        {
            if  ( 
                btn1.Text == "x" && btn2.Text == "x" && btn3.Text == "x"
                || btn4.Text == "x" && btn5.Text == "x" && btn6.Text == "x"
                || btn7.Text == "x" && btn8.Text == "x" && btn9.Text == "x"
                || btn1.Text == "x" && btn4.Text == "x" && btn7.Text == "x"
                || btn2.Text == "x" && btn5.Text == "x" && btn8.Text == "x"
                || btn3.Text == "x" && btn6.Text == "x" && btn9.Text == "x"
                || btn1.Text == "x" && btn5.Text == "x" && btn9.Text == "x"
                || btn3.Text == "x" && btn5.Text == "x" && btn7.Text == "x"
                )
            { timercpu.Stop();
            MessageBox.Show("THE PLAYER IS THE WINNER!", "~");
            countplayer++;
            lbl1.Text = countplayer.ToString();
            RestartGame();
            }
            else if (
                    btn1.Text == "o" && btn2.Text == "o" && btn3.Text == "o"
                    || btn4.Text == "o" && btn5.Text == "o" && btn6.Text == "o"
                    || btn7.Text == "o" && btn8.Text == "o" && btn9.Text == "o"
                    || btn1.Text == "o" && btn4.Text == "o" && btn7.Text == "o"
                    || btn2.Text == "o" && btn5.Text == "o" && btn8.Text == "o"
                    || btn3.Text == "o" && btn6.Text == "o" && btn9.Text == "o"
                    || btn1.Text == "o" && btn5.Text == "o" && btn9.Text == "o"
                    || btn3.Text == "o" && btn5.Text == "o" && btn7.Text == "o"
                    )
            { timercpu.Stop();
            MessageBox.Show("THE COPUTER IS THE WINNER","~");
            countcomputer++;
            lbl2.Text = countcomputer.ToString();
            RestartGame();
            }
        }
        private void RestartGame()
        { buttons = new List<Button> { btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8,btn9};
        foreach (Button c in buttons)
        { c.Enabled = true;
        c.Text = "";
        c.BackColor = DefaultBackColor;
        }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void remove_the_count(object sender, EventArgs e)
        {
            MessageBox.Show("the result now is [ 0 _ 0 ]", "!");
            countcomputer= 0;
            lbl2.Text = countcomputer.ToString();
            countplayer = 0;
            lbl1.Text = countplayer.ToString();
            RestartGame();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
