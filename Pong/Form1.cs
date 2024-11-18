using Microsoft.VisualBasic.Devices;

namespace Pong
{
    public partial class Form1 : Form
    {
        // Controls the speed of the ball
        int ballXspeed = 4;
        int ballYspeed = 4;
        // Speed for the CPU
        int speed = 2;
        // Random speed for the ball and CPU
        Random rand = new Random();
        // Determines when the player can go up and udown 
        bool goDown, goUp;
        // Interval for the when the CPU speed would change 
        int computer_speed_change = 50;
        // Determines player and CPU score
        int playerScore = 0;
        int computerScore = 0;
        // Value for the player slider speed
        int playerSpeed = 8;
        // CPU speed values for random outputs
        int[] i = { 5, 6, 8, 9 };
        // Values for ball speed for random selection
        int[] j = { 10, 9, 8, 11, 12 };

        public Form1()
        {
            InitializeComponent();
        }

        // Making the timer for the intervals of the ball traveling
        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Sets the ball Left and Top range to the ball X and Y speed in each interval, going negative and positive
            Ball.Top -= ballYspeed;
            Ball.Left -= ballXspeed;
            // Shows the player and computer score
            this.Text = "Player Score: " + (playerScore) + "-- Computer Score: " + (computerScore);

            // If statement to ensure ball is only within the client play area, reversing speed in a direction opposite of what it is approaching once it hits its limit
            if (Ball.Top < 0 || Ball.Bottom > this.ClientSize.Height)
            {
                ballYspeed = -ballYspeed;
            }

            // If the ball gets beyond the -2 area, it will reset back to the middle of the screen, it will move in the opposite direction, and add a point to the score for the CPU
            if (Ball.Left < -2)
            {
                Ball.Left = 300;
                ballXspeed = -ballXspeed;
                computerScore++;
            }

            // If the ball gets beyond the + 2 area, it will reset back to the middle of the screen, it will move in the opposite direction, and add a point to the score for the Player
            if (Ball.Right > this.ClientSize.Width + 2)
            {
                Ball.Left = 300;
                ballXspeed = -ballXspeed;
                playerScore++;
            }
            // Checks if the cpu top is less than or equal to 1 to keep the CPU in the game box
            if (CPU.Top <= 1)
            {
                CPU.Top = 0;
            }
            // This does this does the same as the top formula, but for the bottom of the client play area. the CPU top will be equal to the client hieght - the CPU height to stay in the zone
            else if (CPU.Bottom >= this.ClientSize.Height)
            {
                CPU.Top = this.ClientSize.Height - CPU.Height;
            }

            // If the ball is in the top area and is less than CPU.Top + the CPU.Height / 2 or is greater than the 300 pixel mark of the left side of the board, the CPU direction will go upwards
            if (Ball.Top < CPU.Top + (CPU.Height / 2) && Ball.Left > 300)
            {
                CPU.Top -= speed;
            }
            // If the ball is in the bottom area and is less than CPU.Top + the CPU.Height / 2 or is greater than the 300 pixel mark of the left side of the board, the CPU direction will go down
            if (Ball.Top > CPU.Top + (CPU.Height / 2) && Ball.Left > 300)
            {
                CPU.Top += speed;
            }

            // The speed will decrease unti it hits 1, then if it goes below 0, it will choose a random speed in the i array to give to the value of the speed int
            // computer_speed_change hitting 0 will reset the speed change int back to the 50

            computer_speed_change -= 1;

            if (computer_speed_change < 0)
            {
                speed = i[rand.Next(i.Length)];
                computer_speed_change = 50;
            }
            // Checks if the goDown var is true or the player Top/Height is less than the client size height. if either is the case, the player will go down
            if (goDown && Player.Top + Player.Height < this.ClientSize.Height)
            {
                Player.Top += playerSpeed;
            }

            // If the player is greater then the height of 0 or goUp is true. the player will move up until they are greater then 0
            if (goUp && Player.Top > 0)
            {
                Player.Top -= playerSpeed;
            }

            /*Establishing the picOne, picTwo, and the values for the CPU and Player Offsets.
              The offset is so that the ball wont clip into the player or CPU picture box when colliding to bounce it back.
              We use a positive number for the player becuase they are on the left, and negative number for the CPU since they are on the right
             */

            CheckColision(Ball, Player, Player.Right + 5);
            CheckColision(Ball, CPU, CPU.Left - 35);

            // Checks if the player or CPU has reach the number of points to win the game, if the CPU reaches it first, they win, if the player reaches it first, they win.
            if (computerScore > 4)
            {
                GameOVer("You lose!");
            }

            else if (playerScore > 4)
            {
                GameOVer("You win!");
            }
        }

        //  Arguments for when a key is pressed
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Logic so that when the keys of Up or Down are pressed, something happens
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }

        }

        // Arguments for when the key is relased
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

        }

        // Arguments for when the ball has hit a colision 
        private void CheckColision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            // Checks if picOne is colliding with picTwo, the CPU or PLayer, then it runs the function if the function is true
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                // Gives the value for the exact moment the ball hits a player or computer
                PicOne.Left = offset;

                // Will take a random value fromt he j array for its entire length of values
                int x = j[rand.Next(j.Length)];
                int y = j[rand.Next(j.Length)];

                // Checks if the ball speed is currently less than 0, so if it's moving left, itll be less than 0, if it moves right it's greater than 0
                if (ballXspeed < 0)
                {
                    ballXspeed = x;
                }
                else
                {
                    ballXspeed = -x;
                }


                // If the ball is moving up, it'll move faster going up, and the same happens vice versa
                if (ballYspeed < 0)
                {
                    ballYspeed = -y;
                }
                else
                {
                    ballYspeed = y;
                }
            }
        }

        // Functions for the ending of a game
        private void GameOVer(string message)
        {
            // Stops the game
            GameTimer.Stop();
            // Shows the game ending mesage
            MessageBox.Show(message, "Game over: ");
            // Resets the player and CPU scores
            computerScore = 0;
            playerScore = 0;
            // Resets the position of the ball and its speed
            ballXspeed = ballYspeed = 4;
            computer_speed_change = 50;
            // Starts the game back up again
            GameTimer.Start();
        }
    }
}
