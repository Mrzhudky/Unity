using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My2048.Model
{
    class Chessboard
    {
        private NumCube[][] cubes = new NumCube[4][];
        private int[][] nums = new int[4][];
        private int score = 0;

        public Chessboard()
        {
            for (int i = 0; i < 4; i++)
            {
                nums[i] = new int[4];
                cubes[i] = new NumCube[4];
                for (int j = 0; j < 4; j++)
                {
                    nums[i][j] = 0;
                    cubes[i][j] = new NumCube();
                }
            }
            
        }

        public int getScore()
        {
            return score;
        }

        public void pushUpKey()
        {

            for (int i = 0; i < 4; i++)
            {
                int lastRow = 0;
                for (int j = 0; j < 4; j++)
                {
                    if(nums[j][i] != 0)
                    {
                        if(lastRow>0 && nums[lastRow-1][i] == nums[j][i])
                        {
                            score += nums[j][i] >> 1;
                            nums[lastRow - 1][i] *= 2;
                            nums[j][i] = 0;
                        }
                        else if(lastRow == j)
                        {
                            lastRow++;
                        }
                        else
                        {
                            nums[lastRow][i] = nums[j][i];
                            nums[j][i] = 0;
                            lastRow++;
                        }
                    }
                    
                }
               
            }
        }

        public void pushDownKey()
        {

            for (int i = 0; i < 4; i++)
            {
                int lastRow = 3;
                for (int j = 3; j >=0 ; j--)
                {
                    if (nums[j][i] != 0)
                    {
                        if (lastRow <3 && nums[lastRow + 1][i] == nums[j][i])
                        {
                            score += nums[j][i] >> 1;
                            nums[lastRow + 1][i] *= 2;
                            nums[j][i] = 0;
                        }
                        else if (lastRow == j)
                        {
                            lastRow--;
                        }
                        else
                        {
                            nums[lastRow][i] = nums[j][i];
                            nums[j][i] = 0;
                            lastRow--;
                        }
                    }

                }

            }
        }

        public void pushLeftKey()
        {

            for (int i = 0; i < 4; i++)
            {
                int lastColumn = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (nums[i][j] != 0)
                    {
                        if (lastColumn > 0 && nums[i][lastColumn - 1] == nums[i][j])
                        {
                            score += nums[j][i] >> 1;
                            nums[i][lastColumn - 1] *= 2;
                            nums[i][j] = 0;
                        }
                        else if (lastColumn == j)
                        {
                            lastColumn++;
                        }
                        else
                        {
                            nums[i][lastColumn] = nums[i][j];
                            nums[i][j] = 0;
                            lastColumn++;
                        }
                    }

                }

            }
        }

        public void pushRightKey()
        {

            for (int i = 0; i < 4; i++)
            {
                int lastColumn = 3;
                for (int j = 3; j >= 0; j--)
                {
                    if (nums[i][j] != 0)
                    {
                        if (lastColumn <3 && nums[i][lastColumn + 1] == nums[i][j])
                        {
                            score += nums[j][i] >> 1;
                            nums[i][lastColumn + 1] = nums[i][lastColumn + 1]<<1;
                            nums[i][j] = 0;
                        }
                        else if (lastColumn == j)
                        {
                            lastColumn--;
                        }
                        else
                        {
                            nums[i][lastColumn] = nums[i][j];
                            nums[i][j] = 0;
                            lastColumn--;
                        }
                    }

                }

            }
        }

        public void updateBoardShow()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cubes[i][j].updateShow(nums[i][j]);
                }
            }
        }

        public void bingShowAndCube(PictureBox[,] boxs, Label[,] labels)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cubes[i][j].setPictureBox(boxs[i, j]);
                    cubes[i][j].setLabel(labels[i, j]);

                }
            }
        }

        public bool isWin()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (nums[i][j] >= 2048)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool isFilled()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j <4 ; j++)
                {
                    if(nums[i][j] == 0 || nums[i][j] == 64)
                    {
                        return false;
                    }
                    if (i < 3)
                    {
                        if(nums[i][j] == nums[i + 1][j])
                        {
                            return false;
                        }
                    }
                    if (j < 3)
                    {
                        if (nums[i][j] == nums[i][j+1])
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }

        public void createNewNumber()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(nums[i][j] == 0)
                    {
                        list.Add(new int[] { i, j });
                    }
                }
            }
            if(list.Count >8)
            {
                Random r = new Random();
                int num = r.Next() * 10 < 1 ? 4 : 2;
                int index = r.Next(0, list.Count);
                int[] temp = (int[])list[index];
                nums[temp[0]][temp[1]] = num;

                num = r.Next() * 10 < 1 ? 4 : 2;
                index = r.Next(0, list.Count);
                temp = (int[])list[index];
                nums[temp[0]][temp[1]] = num;
            }
            else
            {
                Random r = new Random();
                int num = r.Next() * 10 < 1 ? 4 : 2;
                int index = r.Next(0, list.Count);
                int[] temp = (int[])list[index];
                nums[temp[0]][temp[1]] = num;
            }
        }

        public void setAllZero()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    nums[i][j] = 0;

                }
            }
        }
    }
}
