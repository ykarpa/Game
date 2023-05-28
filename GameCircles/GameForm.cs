using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using Timer = System.Windows.Forms.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GameCircles
{
    public partial class GameForm : Form
    {
        private Timer removeTimer;

        private Random random = new Random();
        private int score = 0;
        private int maxScore = 0;
        private int missedBalls = 0;
        private bool isPaused = false;

        private DateTime startTime;

        public GameForm()
        {
            InitializeComponent();
            this.Load += GameForm_Load;
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

            gamePanel.Controls.Add(circle);

            removeTimer = new Timer();
            removeTimer.Interval = 1500;
            removeTimer.Tick += (sender, e) => remove(sender, circle);
            removeTimer.Start();
        }

        private void remove(object sender,  Circle circle)
        {
            (sender as Timer).Stop();
            (sender as Timer).Dispose();

            if (gamePanel.Controls.Contains(circle)) {
                if (circle.BackColor != Color.Green)
                {
                    missedBalls++;
                    UpdateMissedBallsLabel();
                }

                if (missedBalls >= 5)
                {
                    EndGame();
                }

                gamePanel.Controls.Remove(circle);
            }
        }

        private Color GetRandomColor()
        {
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow};
            return colors[random.Next(colors.Length)];
        }

        private Point GetRandomLocation()
        {
            int x = random.Next(0, gamePanel.ClientSize.Width - 50);
            int y = random.Next(0, gamePanel.ClientSize.Height - 50);
            return new Point(x, y);
        }

        private void circle_Click(object sender, EventArgs e)
        {
            Circle circle = (Circle)sender;
            gamePanel.Controls.Remove(circle);
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
            UpdateMaxScoreLabel();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = "Кількість очків: " + score.ToString();
        }

        private void UpdateMissedBallsLabel()
        {
            missedLabel.Text = "Пропущені: " + missedBalls.ToString();
        }

        private void UpdateMaxScoreLabel()
        {
            recordLabel.Text = "Найкращий результат: " + maxScore.ToString();
        }

        private void EndGame()
        {
            ballTimer.Enabled = false;
            if (removeTimer != null)
                removeTimer.Enabled = false;
            pausedButton.Enabled = false;

            ShowResultDialog();
        }

        private void RestartGame()
        {
            ballTimer.Dispose();
            if (removeTimer != null)
                removeTimer.Dispose();
            gamePanel.Controls.Clear();

            ballTimer.Start();
            if (removeTimer != null)
                removeTimer.Start();

            pausedButton.Enabled = true;
            endButton.Enabled = true;

            score = 0;
            maxScore = 0;
            missedBalls = 0;

            UpdateScoreLabel();
            UpdateMaxScoreLabel();
            UpdateMissedBallsLabel();
        }

        private void ShowResultDialog()
        {
            Form resultForm = new Form();
            resultForm.Text = "Результат гри";
            resultForm.Size = new Size(500, 400);
            resultForm.MinimizeBox = false;
            resultForm.MaximizeBox = false;
            resultForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            resultForm.StartPosition = FormStartPosition.CenterScreen;

            Label resultLabel = new Label();
            resultLabel.Text = "Ваш найкращий результат:\n" + score.ToString();
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font(resultLabel.Font.FontFamily, 12, FontStyle.Bold);
            resultLabel.Location = new Point((resultForm.Width - 3 * resultLabel.Width) / 2, 20);
            resultForm.Controls.Add(resultLabel);

            Label nameLabel = new Label();
            nameLabel.Text = "Введіть своє ім'я:";
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font(nameLabel.Font.FontFamily, 10);
            nameLabel.Location = new Point(20, 100 + resultLabel.Height);
            resultForm.Controls.Add(nameLabel);

            TextBox nameTextBox = new TextBox();
            nameTextBox.Location = new Point(50 + nameLabel.Width, 98 + resultLabel.Height);
            nameTextBox.Width = 200;
            resultForm.Controls.Add(nameTextBox);

            Button mainMenuButton = new Button();
            mainMenuButton.Text = "Головне меню";
            mainMenuButton.Size = new Size(250, 50);
            mainMenuButton.Location = new Point(-1, 305);
            mainMenuButton.Click += (sender, e) =>
            {
                resultForm.Close();
                this.Close();
            };
            resultForm.Controls.Add(mainMenuButton);

            Button restartButton = new Button();
            restartButton.Text = "Почати заново";
            restartButton.Size = new Size(250, 50);
            restartButton.Location = new Point(247, 305);
            restartButton.Click += (sender, e) =>
            {
                resultForm.Close();
                RestartGame();

            };
            resultForm.Controls.Add(restartButton);

            resultForm.ShowDialog();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                isPaused = true;
                pausedButton.Text = "Продовжити";
                ballTimer.Stop();
                if (removeTimer != null)
                    removeTimer.Stop();
                gamePanel.Enabled = false;
            }
            else
            {
                isPaused = false;
                pausedButton.Text = "Пауза";
                ballTimer.Start();
                if (removeTimer != null)
                    removeTimer.Start();
                gamePanel.Enabled = true;
            }
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            endButton.Enabled = false;
            EndGame();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
