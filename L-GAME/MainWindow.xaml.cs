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

        /*public enum types {RED, BLUE, CIRCLE, EMPTY};
        public types[,] board = {   {types.CIRCLE, types.RED, types.RED, types.EMPTY}, 
                                    {types.EMPTY, types.RED, types.BLUE, types.EMPTY}, 
                                    {types.EMPTY, types.RED, types.BLUE, types.EMPTY}, 
                                    {types.EMPTY, types.BLUE, types.BLUE, types.CIRCLE}};
        */

        public int[,] red = { { 1, 0 }, { 2, 0 }, { 1, 1 }, { 1, 2 } };
        public int[,] blue = { { 2, 1 }, { 2, 2 }, { 2, 3 }, { 1, 3 } };
        public int[,] circle = { { 0, 0 }, { 3, 3 } };

        public Boolean turn = true; //true is red, false is blue
        public Boolean movingCircle = false;
        public int currentCircle = 0;

        public MainWindow()
        {
            InitializeComponent();

            //drawBoard(board);
            drawBoard(red, blue, circle);
        }
        /*public void drawBoard(types[,] drawingBoard)
        {
            Rectangle[] redDraw = { Red0, Red1, Red2, Red3 };
            Rectangle[] blueDraw = { Blue0, Blue1, Blue2, Blue3 };
            Ellipse[] circleDraw = { Circle0, Circle1 };

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
                        redDraw[redNum].Margin = (new Thickness(50 + j * 100, 50 + 100 * i, 0, 0));
                        redNum++;
                    }
                    else if (drawingBoard[i, j] == types.BLUE)
                    {
                        blueDraw[blueNum].Margin = (new Thickness(50 + j * 100, 50 + 100 * i, 0, 0));
                        blueNum++;
                    }
                    else if (drawingBoard[i, j] == types.CIRCLE)
                    {
                        circleDraw[circleNum].Margin = (new Thickness(60 + j * 100, 60 + 100 * i, 0, 0));
                        circleNum++;
                    }
                }
            }
        }*/

        /*public Boolean checkTurn(types[,] tempBoard)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] != tempBoard[i, j]) return false;
                }
            }
            return true;
        }*/

        public void drawBoard(int[,] red, int[,] blue, int[,] circle)
        {
            Rectangle[] redDraw = { Red0, Red1, Red2, Red3 };
            Rectangle[] blueDraw = { Blue0, Blue1, Blue2, Blue3 };
            Ellipse[] circleDraw = { Circle0, Circle1 };

            for (int i = 0; i < 4; i++)
            {
                redDraw[i].Margin = (new Thickness(50 + red[i, 0] * 100, 50 + 100 * red[i, 1], 0, 0));
                blueDraw[i].Margin = (new Thickness(50 + blue[i, 0] * 100, 50 + 100 * blue[i, 1], 0, 0));
                if (i < 2)
                {
                    circleDraw[i].Margin = (new Thickness(60 + circle[i, 0] * 100, 60 + 100 * circle[i, 1], 0, 0));
                }
            }

            if (turn) 
            {
                TurnLabel.Text = "RED";
                TurnLabel.Foreground = Brushes.Red;
            }
            else
            {
                TurnLabel.Text = "BLUE";
                TurnLabel.Foreground = Brushes.DeepSkyBlue;
            }
        }

        private void moveButtonClick(object sender, RoutedEventArgs e)
        {
            int[,] moving;
            //Up, Down, Left, Right
            if (!movingCircle) {
                if (turn) moving = red;
                else moving = blue;
            }
            else moving = circle;

            if (sender.Equals(Up)) {
                if (movingCircle) moving[currentCircle, 1]--;
                else {
                    for (int i = 0; i < 4; i++) {
                        moving[i, 1]--;
                    }
                }
            }
            if (sender.Equals(Down)) {
                if (movingCircle) moving[currentCircle, 1]++;
                else {
                    for (int i = 0; i < 4; i++) {
                        moving[i, 1]++;
                    }
                }
            }
            if (sender.Equals(Left)) {
                if (movingCircle) moving[currentCircle, 0]--;
                else {
                    for (int i = 0; i < 4; i++) {
                        moving[i, 0]--;
                    }
                }
            }
            if (sender.Equals(Right)) {
                if (movingCircle) moving[currentCircle, 0]++;
                else {
                    for (int i = 0; i < 4; i++) {
                        moving[i, 0]++;
                    }
                }
            }

            if (!movingCircle) {
                if (turn) drawBoard(moving, blue, circle);
                else drawBoard(red, moving, circle);
            }
            else drawBoard(red, blue, moving);
        }

        
    }
}
