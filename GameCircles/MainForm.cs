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
        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm();
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

            Label rulesLabel = new Label();
            rulesLabel.Text = "Як грати?\nНа екрані з'являються кульки, Вам потрібно клацати по ним.\n" +
                "Якщо ви пропустите 5 кульок, Ви програли.\nЗа збиті кульки вам нараховують або знімають очки\n" +
                "Зелена – -10 очків\nСиня – 0 очків\nЖовта – 5 очків\nЧервона – 10 очків";
            rulesLabel.Size = new Size(460, 300);
            rulesLabel.Font = new Font(rulesLabel.Font.FontFamily, 12, FontStyle.Regular);
            rulesLabel.Location = new Point(20, 20);
            howToPlayForm.Controls.Add(rulesLabel);

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
    }
}
