using System;
using System.Media;
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
    public enum Level
    {
        easy,
        middle,
        hard,
    }
    public partial class GameForm : Form
    {
        private Timer removeTimer;

        private Random random = new Random();
        private Level level;
        private int score = 0;
        private int maxScore = 0;
        private int missedBalls = 0;
        private bool isPaused = false;

        public GameForm(Level level)
        {
            InitializeComponent();
            this.Load += GameForm_Load;
            this.level = level;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            shapeTimer.Start();
        }

        private void StartGame(Level level)
        {
            Shape shape;

            removeTimer = new Timer();
            removeTimer.Interval = 1500;

            int randomShape = random.Next(2);

            switch (level)
            {
                case Level.easy:
                    shape = GenerateCircle();
                    break;
                case Level.middle:
                    shape = (randomShape == 0) ? GenerateCircle(1) : GenerateStar(1);
                    break;
                case Level.hard:
                    shape = (randomShape == 0) ? GenerateCircle(1) : GenerateStar(1);
                    break;
                default:
                    shape = GenerateCircle();
                    break;

            }
            gamePanel.Controls.Add(shape);

            removeTimer.Tick += (sender, e) => Remove(sender, shape);
            removeTimer.Start();
        }

        private void ShapeTimer_Tick(object sender, EventArgs e)
        {
            StartGame(level);
        }

        private Shape GenerateCircle(int size = 0)
        {
            Shape circle = new Circle();
            circle.BackColor = GetRandomColor();
            circle.Location = GetRandomLocation();
            circle.Size = (size == 0) ? (new Size(50, 50)) : GetRandomSize();
            circle.Click += Shape_Click;

            return circle;
        }

        private Shape GenerateStar(int size = 0)
        {
            Shape star = new Star();
            star.BackColor = GetRandomColor();
            star.Location = GetRandomLocation();
            star.Size = (size == 0) ? (new Size(65, 65)) : GetRandomSize();
            star.Click += Shape_Click;

            return star;
        }

        private void Remove(object sender,  Shape shape)
        {
            (sender as Timer).Stop();
            (sender as Timer).Dispose();

            Color[] forbiddenColors = { Color.Green, Color.Blue, Color.DarkCyan, Color.Black, };

            if (gamePanel.Controls.Contains(shape)) {
                if (!forbiddenColors.Contains(shape.BackColor))
                {
                    missedBalls++;
                    UpdateMissedBallsLabel();
                }

                if (missedBalls == 5)
                {
                    shapeTimer.Enabled = false;
                    shapeTimer.Stop();
                    shapeTimer.Dispose();
                    EndGame();
                }

                gamePanel.Controls.Remove(shape);
            }
        }

        private Color GetRandomColor()
        {
            List<Color> colors = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Yellow };
            switch (level)
            {
                case Level.easy:
                    return colors[random.Next(colors.Count)];
                case Level.middle:
                    colors.Add(Color.Black);
                    colors.Add(Color.White);
                    colors.Add(Color.Pink);
                    return colors[random.Next(colors.Count)];
                case Level.hard:
                    colors.Add(Color.DarkCyan);
                    colors.Add(Color.White);
                    colors.Add(Color.Pink);
                    colors.Add(Color.Orange);
                    colors.Add(Color.Black);
                    return colors[random.Next(colors.Count)];
                default:
                    return colors[random.Next(colors.Count)];
            }
        }

        private Point GetRandomLocation()
        {
            int x = random.Next(0, gamePanel.ClientSize.Width - 50);
            int y = random.Next(0, gamePanel.ClientSize.Height - 50);
            return new Point(x, y);
        }

        private Size GetRandomSize()
        {
            int width, height;
            if (this is Circle)
            {
                width = height = random.Next(30, 55);
            }
            else
            {
                width = height = random.Next(45, 75);
            }
            
            return new Size(width, height);
        }

        private void Shape_Click(object sender, EventArgs e)
        {
            Shape shape = (Shape)sender;

            if (shape.BackColor == Color.Black)
            {
                string soundFilePath = "../../../sounds/bomba.wav";
                SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                soundPlayer.Play();
            }
            else
            {
                string soundFilePath = "../../../sounds/ball_hit.wav";
                SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                soundPlayer.Play();
            }

            gamePanel.Controls.Remove(shape);
            shapeTimer.Interval = (shapeTimer.Interval <= 400) ? 400 : shapeTimer.Interval - 10;

            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Pink, Color.White, Color.DarkCyan, Color.Black, };
            int[] points = { 10, -10, -1, 5, 7, 3, 1, -2, 0,};

            if (shape.BackColor == Color.Black)
            {
                foreach (Shape s in gamePanel.Controls)
                {
                    score += points[Array.IndexOf(colors, s.BackColor)];
                }
                gamePanel.Controls.Clear();
            }

            score += points[Array.IndexOf(colors, shape.BackColor)];

            MaxScore(score);
            UpdateScoreLabel();

            if (score < 0) EndGame();
        }

        private void MaxScore(int score)
        {
            if (score > maxScore)
                maxScore = score;
            UpdateMaxScoreLabel();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Кількість очків: {score}";
        }

        private void UpdateMissedBallsLabel()
        {
            missedLabel.Text = $"Пропущені: {missedBalls}";
        }

        private void UpdateMaxScoreLabel()
        {
            recordLabel.Text = $"Найкращий результат: {maxScore}";
        }

        private void EndGame()
        {
            string soundFilePath = "../../../sounds/game_over.wav";
            SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
            soundPlayer.Play();

            removeTimer?.Stop();
            shapeTimer.Stop();
            shapeTimer.Dispose();
            removeTimer?.Dispose();
            shapeTimer.Interval = 1000;
            pausedButton.Enabled = false;
            endButton.Enabled = false;
            gamePanel.Enabled = false;

            ShowResultDialog();
        }

        private void RestartGame()
        {
            shapeTimer.Stop();
            shapeTimer.Dispose();
            removeTimer?.Dispose();
            gamePanel.Controls.Clear();

            shapeTimer.Start();
            removeTimer?.Start();

            pausedButton.Enabled = endButton.Enabled = gamePanel.Enabled = true;
            score = maxScore = missedBalls = 0;

            UpdateScoreLabel();
            UpdateMaxScoreLabel();
            UpdateMissedBallsLabel();
        }

        private void ShowResultDialog()
        {
            Form resultForm = new Form();
            resultForm.Text = "Результат гри";
            resultForm.Size = new Size(500, 400);
            resultForm.BackColor = Color.AntiqueWhite;
            resultForm.MinimizeBox = false;
            resultForm.MaximizeBox = false;
            resultForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            resultForm.StartPosition = FormStartPosition.CenterScreen;

            Label resultLabel = new Label();
            resultLabel.Text = "Ваш найкращий результат:\n" + maxScore.ToString();
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
            nameTextBox.BackColor = Color.LightBlue;
            resultForm.Controls.Add(nameTextBox);

            Button mainMenuButton = new Button();
            mainMenuButton.Text = "Головне меню";
            mainMenuButton.Size = new Size(250, 50);
            mainMenuButton.BackColor = Color.SkyBlue;
            mainMenuButton.Location = new Point(-1, 305);
            mainMenuButton.Click += (sender, e) =>
            {
                if (nameTextBox.Text != String.Empty)
                {
                    Player player = new Player(nameTextBox.Text, maxScore);
                    SavePlayerData(player);
                }

                resultForm.Close();
                this.Close();
            };
            resultForm.Controls.Add(mainMenuButton);

            Button restartButton = new Button();
            restartButton.Text = "Почати заново";
            restartButton.Size = new Size(250, 50);
            restartButton.BackColor = Color.SkyBlue;
            restartButton.Location = new Point(247, 305);
            restartButton.Click += (sender, e) =>
            {
                if (nameTextBox.Text != String.Empty)
                {
                    Player player = new Player(nameTextBox.Text, maxScore);
                    SavePlayerData(player);
                }

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
                shapeTimer.Stop();
                removeTimer?.Stop();
                gamePanel.Enabled = false;
            }
            else
            {
                isPaused = false;
                pausedButton.Text = "Пауза";
                shapeTimer.Start();
                removeTimer?.Start();
                gamePanel.Enabled = true;
            }
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            endButton.Enabled = false;
            EndGame();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            shapeTimer.Stop();
            removeTimer?.Stop();
            gamePanel.Controls.Clear();

            this.Close();
        }

        private void SavePlayerData(Player player)
        {
            string fileName = "player_data.txt";

            string data = player + ", " + DateTime.Now.ToString();

            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine(data);
                }

                Console.WriteLine("Дані успішно записані у файл.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Помилка при записі даних у файл: " + e.Message);
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shapeTimer.Stop();
            removeTimer?.Stop();
        }
    }
}
