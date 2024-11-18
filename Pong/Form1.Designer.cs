namespace Pong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify.
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Player = new PictureBox();
            CPU = new PictureBox();
            Ball = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CPU).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Ball).BeginInit();
            SuspendLayout();
            // 
            // Player
            // 
            Player.Image = Properties.Resources.player;
            Player.Location = new Point(12, 157);
            Player.Name = "Player";
            Player.Size = new Size(28, 152);
            Player.SizeMode = PictureBoxSizeMode.StretchImage;
            Player.TabIndex = 0;
            Player.TabStop = false;
            // 
            // CPU
            // 
            CPU.Image = Properties.Resources.computer;
            CPU.Location = new Point(760, 157);
            CPU.Name = "CPU";
            CPU.Size = new Size(28, 152);
            CPU.SizeMode = PictureBoxSizeMode.StretchImage;
            CPU.TabIndex = 1;
            CPU.TabStop = false;
            // 
            // Ball
            // 
            Ball.Image = Properties.Resources.ball;
            Ball.Location = new Point(392, 220);
            Ball.Name = "Ball";
            Ball.Size = new Size(30, 35);
            Ball.SizeMode = PictureBoxSizeMode.StretchImage;
            Ball.TabIndex = 2;
            Ball.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(Ball);
            Controls.Add(CPU);
            Controls.Add(Player);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)CPU).EndInit();
            ((System.ComponentModel.ISupportInitialize)Ball).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Player;
        private PictureBox CPU;
        private PictureBox Ball;
        private System.Windows.Forms.Timer GameTimer;
    }
}
