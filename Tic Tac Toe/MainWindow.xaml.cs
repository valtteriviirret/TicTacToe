
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current results of the cells during active game
        /// </summary>
        private Mark[] mResults;

        /// <summary>
        /// True if player1(X) turn or player2 turn(0)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if game is ended
        /// </summary>
        private bool mGameEnded;
        #endregion

        #region Constructor
        /// <summary>
        /// This is the Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();

            
        }
        #endregion

        /// <summary>
        /// Starts a new game and clears values to the start
        /// </summary>
        private void NewGame()
        {
            //Create a new blank array of free cells
            mResults = new Mark[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = Mark.Free;
            }
            
             

            //Player 1 always start the game
            mPlayer1Turn = true;

            //Iterating every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            //Make sure the game is not finished
            mGameEnded = false;
        }

        /// <summary>
        /// Handles button click event
        /// </summary>
        /// <param name="sender">The clicked button</param>
        /// <param name="e">The event of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //starts a new game on the click adter it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }
            //cast the sender to button
            var button = (Button)sender;

            //Find the buttons in an array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            //do nothing if the cell already has value
            if (mResults[index] != Mark.Free)
            {
                return;
            }

            //set the cell value based on which player turn it is
            if (mPlayer1Turn)
            {
                mResults[index] = Mark.Cross;
            }
            else
            {
                mResults[index] = Mark.Zero;
            }

            //set the button text
            if(mPlayer1Turn)
            {
                button.Content = "X";
            }
            else
            {
                button.Content = "O";
            }

            //Change zeros to red
            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }
            //toggle players turns
            mPlayer1Turn ^= true;

            //Check for a winner
            CheckWinner();
        }

        /// <summary>
        /// Check if there is 3 line straigt aka winner
        /// </summary>
        private void CheckWinner()
        {
            //if statement for different wins and then switch statement
            //this seems kinda unnesessary but I just wanna do it like this
            int caseSwitch = 0;
            var row1 =(mResults[0] & mResults[1] & mResults[2]) == mResults[0];
            var row1win = mResults[0] != Mark.Free && row1;
            
            if (row1win)
            {
                caseSwitch = 1;
            }

            var row2 = mResults[3] && mResults[4] && mResults[5] == mResults[3];
            
            switch(caseSwitch)
            {
                case 1:
                //Game ended
                mGameEnded = true;

                //Highlight winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
                break;
            }







            //check if board is full without winner
            if(!mResults.Any(result => result== Mark.Free))
            {
                //Game ended
                mGameEnded = true;

                //turn all cells to gray

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Gray;
                });

            }
        }
    }
}
