using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using Timer = System.Windows.Forms.Timer;

namespace GameCircles
{
    public partial class GameForm : Form
    {
        private Timer removeTimer;
        private Random random = new Random();
        private int score = 0;
        private int maxScore = 0;
        private int missedBalls = 0;
        private DateTime startTime;

        public GameForm()
        {
            InitializeComponent();
            this.Load += GameForm_Load;
            continueButton.Enabled = false;
        }

        private void GameForm_Load(object sender, EventArgs e)
        { 
            ballTimer.Start();
        }

        private void ballTimer_Tick(object sender, EventArgs e)
        {
            Circle circle = new Circle();
            circle.Size = new Size(50, 50);
            circle.BackColor = GetRandomColor();
            circle.Location = GetRandomLocation();
            circle.Click += circle_Click;

            game_Panel.Controls.Add(circle);

            removeTimer = new Timer();
            removeTimer.Interval = 1500;
            removeTimer.Tick += (sender, e) => remove(sender, circle);
            removeTimer.Start();
        }

        private void remove(object sender,  Circle circle)
        {
            (sender as Timer).Stop();
            (sender as Timer).Dispose();

            if (game_Panel.Controls.Contains(circle)) {
                if (circle.BackColor != Color.Green)
                {
                    missedBalls++;
                    UpdateMissedLabel();
                }

                if (missedBalls >= 5)
                {
                    EndGame();
                }

                game_Panel.Controls.Remove(circle);
            }
        }

        private Color GetRandomColor()
        {
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow};
            return colors[random.Next(colors.Length)];
        }

        private Point GetRandomLocation()
        {
            int x = random.Next(0, game_Panel.ClientSize.Width - 50);
            int y = random.Next(0, game_Panel.ClientSize.Height - 50);
            return new Point(x, y);
        }

        private void circle_Click(object sender, EventArgs e)
        {
            Circle circle = (Circle)sender;
            game_Panel.Controls.Remove(circle);
            ballTimer.Interval = (ballTimer.Interval <= 300) ? 300 : ballTimer.Interval - 20;

            if (circle.BackColor == Color.Yellow)
                score += 5;
            if (circle.BackColor == Color.Green)
                score -= 10;
            if (circle.BackColor == Color.Blue)
                score += 1;
            if (circle.BackColor == Color.Red)
                score += 10;

            Record(score);
            UpdateScoreLabel();

            if (score < 0) 
            {
                EndGame();
            }
        }

        private void Record(int score)
        {
            if (score > maxScore)
                maxScore = score;
            UpdateRecordLabel();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = "Кількість очків: " + score.ToString();
        }

        private void UpdateMissedLabel()
        {
            missedLabel.Text = "Пропущені: " + missedBalls.ToString();
        }

        private void UpdateRecordLabel()
        {
            recordLabel.Text = "Найкращий результат: " + maxScore.ToString();
        }

        private void EndGame()
        {
            ballTimer.Enabled = false;
            removeTimer.Enabled = false;
            
            MessageBox.Show("Ваш найкращий результат: " + maxScore.ToString(), "Гра завершена");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ballTimer.Enabled = false;
            removeTimer.Enabled = false;
            game_Panel.Enabled = false;
            continueButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            ballTimer.Enabled = true;
            removeTimer.Enabled = true;
            game_Panel.Enabled = true;
            continueButton.Enabled = false;
            stopButton.Enabled = true;
        }
    }
}
