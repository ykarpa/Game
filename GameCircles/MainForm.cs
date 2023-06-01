using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCircles
{
    public partial class MainForm : Form
    {
        private Level level;
        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm(level);
            gameForm.ShowDialog();
            this.Show();
        }

        private void HowToPlayButton_Click(object sender, EventArgs e)
        {
            ShowRulesDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowRulesDialog()
        {
            Form howToPlayForm = new Form();
            howToPlayForm.Text = "Як грати";
            howToPlayForm.Size = new Size(500, 500);
            howToPlayForm.BackColor = Color.LemonChiffon;
            howToPlayForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            howToPlayForm.MaximizeBox = false;
            howToPlayForm.MinimizeBox = false;
            howToPlayForm.StartPosition = FormStartPosition.CenterScreen;

            Panel rulesPanel = new Panel();
            rulesPanel.BackColor = Color.LemonChiffon;
            rulesPanel.Size = new Size(480, 350);
            rulesPanel.Location = new Point(0, 35);
            rulesPanel.AutoScroll = true;
            howToPlayForm.Controls.Add(rulesPanel);

            Label howToPlayLabel = new Label()
            {
                Text = "Як грати?",
                Font = new Font(Font.FontFamily, 12, FontStyle.Regular),
                BackColor = Color.LemonChiffon,
                AutoSize = true,
                Location = new Point(180, 5),
            };
            howToPlayForm.Controls.Add(howToPlayLabel);

            Label rulesLabel = new Label();
            rulesLabel.Text = "На екрані з'являються кульки або зірочки, Вам потрібно клацати по ним.\n" +
                "Якщо ви пропустите 5 фігурок, Ви програли.\nЗа збиті фігурки вам нараховують або знімають очки\n" +
                "Червона – +10 очків\nПомаранчева – +7 очків\nЖовта – +5 очків\nРожева – +3 очки\nБіла - +1 очко\n" +
                "Чорна - 0 очків\nСиня - -1 очко\nТемно-блакитний - -2 очки\nЗелена - -10 очків\nЧорна кулька особлива," +
                " при натисканні на неї, зникають всі кульки на екрані, і вам нараховуються очки за кожну, що була.";
            rulesLabel.Size = new Size(430, 500); ;
            rulesLabel.Margin = new Padding(5);
            rulesLabel.Font = new Font(rulesLabel.Font.FontFamily, 12, FontStyle.Regular);
            rulesLabel.Location = new Point(20, 20);
            rulesPanel.Controls.Add(rulesLabel);

            Button okButton = new Button();
            okButton.Text = "Зрозуміло";
            okButton.Size = new Size(500, 50);
            okButton.BackColor = Color.SkyBlue;
            okButton.Location = new Point(-2, 405);
            okButton.Click += (sender, e) =>
            {
                howToPlayForm.Close();
            };
            howToPlayForm.Controls.Add(okButton);

            howToPlayForm.ShowDialog();
        }

        private void PlayerRatingButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RatingForm ratingForm = new RatingForm();
            ratingForm.ShowDialog();
            this.Show();
        }

        private void LevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem?.ToString();

            switch (selectedValue)
            {
                case "Легкий":
                    level = Level.easy;
                    break;
                case "Середній":
                    level = Level.middle;
                    break;
                case "Важкий":
                    level = Level.hard;
                    break;
            }
        }
    }
}
