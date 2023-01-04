using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L_GAME
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public enum types {RED, BLUE, CIRCLE, EMPTY};
        public types[,] board = {   {types.CIRCLE, types.RED, types.RED, types.EMPTY}, 
                                    {types.EMPTY, types.RED, types.BLUE, types.EMPTY}, 
                                    {types.EMPTY, types.RED, types.BLUE, types.EMPTY}, 
                                    {types.EMPTY, types.BLUE, types.BLUE, types.CIRCLE}};

        public Boolean turn = false; //false is red, true is blue

        public MainWindow()
        {
            InitializeComponent();

            drawBoard(board);
        }
        public void drawBoard(types[,] drawingBoard)
        {
            Rectangle[] red = { Red0, Red1, Red2, Red3 };
            Rectangle[] blue = { Blue0, Blue1, Blue2, Blue3 };
            Ellipse[] circle = { Circle0, Circle1 };

            int redNum = 0;
            int blueNum = 0;
            int circleNum = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0;j < 4; j++)
                {
                    if (drawingBoard[i,j] == types.EMPTY) continue;
                    else if (drawingBoard[i, j] == types.RED)
                    {
                        red[redNum].Margin = (new Thickness(50 + j * 100, 50 + 100 * i, 0, 0));
                        redNum++;
                    }
                    else if (drawingBoard[i, j] == types.BLUE)
                    {
                        blue[blueNum].Margin = (new Thickness(50 + j * 100, 50 + 100 * i, 0, 0));
                        blueNum++;
                    }
                    else if (drawingBoard[i, j] == types.CIRCLE)
                    {
                        circle[circleNum].Margin = (new Thickness(60 + j * 100, 60 + 100 * i, 0, 0));
                        circleNum++;
                    }
                }
            }
        }

        public Boolean checkTurn(types[,] tempBoard)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] != tempBoard[i, j]) return false;
                }
            }
            return true;
        }
    }
}
