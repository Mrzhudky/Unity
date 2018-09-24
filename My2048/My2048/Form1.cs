using My2048.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My2048
{
    public partial class Form1 : Form
    {

        private Chessboard chessBoard = new Chessboard();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar =='w')
            {
                chessBoard.pushUpKey();
            }
            else if (e.KeyChar == 's')
            {
                chessBoard.pushDownKey();
            }
            else if (e.KeyChar == 'a')
            {
                chessBoard.pushLeftKey();
            }
            else if (e.KeyChar == 'd')
            {
                chessBoard.pushRightKey();
            }
            else
            {
                return;
            }
            tboxScore.Text = chessBoard.getScore().ToString();
            chessBoard.createNewNumber();
            chessBoard.updateBoardShow();

        }



        private void timer_Tick(object sender, EventArgs e)
        {
            if (chessBoard.isWin())
            {
                timer.Stop();
                MessageBox.Show("GameOver!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (chessBoard.isFilled())
            {
                timer.Stop();
                MessageBox.Show("GameOver!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chessBoard.createNewNumber();
            chessBoard.createNewNumber();

            PictureBox[,] pBoxs = new PictureBox[4, 4];
            Label[,] labels = new Label[4, 4];

            pBoxs[0, 0] = pBox_0_0;
            pBoxs[0, 1] = pBox_0_1;
            pBoxs[0, 2] = pBox_0_2;
            pBoxs[0, 3] = pBox_0_3;
            pBoxs[1, 0] = pBox_1_0;
            pBoxs[1, 1] = pBox_1_1;
            pBoxs[1, 2] = pBox_1_2;
            pBoxs[1, 3] = pBox_1_3;
            pBoxs[2, 0] = pBox_2_0;
            pBoxs[2, 1] = pBox_2_1;
            pBoxs[2, 2] = pBox_2_2;
            pBoxs[2, 3] = pBox_2_3;
            pBoxs[3, 0] = pBox_3_0;
            pBoxs[3, 1] = pBox_3_1;
            pBoxs[3, 2] = pBox_3_2;
            pBoxs[3, 3] = pBox_3_3;

            labels[0, 0] = num_0_0;
            labels[0, 1] = num_0_1;
            labels[0, 2] = num_0_2;
            labels[0, 3] = num_0_3;
            labels[1, 0] = num_1_0;
            labels[1, 1] = num_1_1;
            labels[1, 2] = num_1_2;
            labels[1, 3] = num_1_3;
            labels[2, 0] = num_2_0;
            labels[2, 1] = num_2_1;
            labels[2, 2] = num_2_2;
            labels[2, 3] = num_2_3;
            labels[3, 0] = num_3_0;
            labels[3, 1] = num_3_1;
            labels[3, 2] = num_3_2;
            labels[3, 3] = num_3_3;
            chessBoard.bingShowAndCube(pBoxs, labels);

            chessBoard.updateBoardShow();
            panel1.Focus();
            timer.Start();
        }

        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chessBoard.setAllZero();
            chessBoard.createNewNumber();
            chessBoard.createNewNumber();
            chessBoard.updateBoardShow();
            this.Focus();
        }

        private void 关闭游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);
        }
    }
}
