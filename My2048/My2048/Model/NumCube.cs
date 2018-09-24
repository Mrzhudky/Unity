using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace My2048.Model
{
    class NumCube
    {
        //private int value = 0;
        private PictureBox pBox = null;
        private Label label = null;
        private Chessboard board = null;


        public void setPictureBox(PictureBox box)
        {
            pBox = box;
        }
        public void setLabel(Label label)
        {
            this.label = label;
        }

        //public void updateValue(int val)
        //{
        //    value = val;
        //}
        public void updateShow(int value)
        {
            if(value > 0)
            {
                pBox.BackColor = System.Drawing.Color.LightBlue;
                label.BackColor = System.Drawing.Color.LightBlue;
                label.Text = value.ToString();
            }
            else
            {
                pBox.BackColor = System.Drawing.Color.Transparent;
                label.Text = "";
                return;
            }

            
            if (value > 512)
            {
                label.Font = new System.Drawing.Font("华文彩云", 16F);                
            }
            else if(value > 64)
            {
                label.Font = new System.Drawing.Font("华文彩云", 20F);
            }
            else if(value > 8)
            {
                label.Font = new System.Drawing.Font("华文彩云", 25F);
            }
            else
            {
                label.Font = new System.Drawing.Font("华文彩云", 30F);
            }
        }

    }
}
