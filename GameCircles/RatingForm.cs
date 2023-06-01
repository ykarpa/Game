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
    public partial class RatingForm : Form
    {
        private List<Player> players = new List<Player>();
        public RatingForm()
        {
            InitializeComponent();
            players = LoadPlayersData();
            this.Load += RatingForm_Load;
        }
        private void RatingForm_Load(object sender, EventArgs e)
        {

        }
        private void DisplayTopPlayers(int count)
        {
            ratingPanel?.Controls.Clear();
            topNLabel?.Controls.Clear();

            topNLabel.Text = $"Топ {count} гравців";

            int position = 1;
            Label label = new Label
            {
                Text = "",
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 12),
                Margin = new Padding(5),
                Location = new Point(20, 0),
            };
            Dictionary<string, Player> uniquePlayers = new Dictionary<string, Player>();
            foreach (Player player in players)
            {
                if (uniquePlayers.ContainsKey(player.Name))
                {
                    if (player.Score > uniquePlayers[player.Name].Score)
                    {
                        uniquePlayers[player.Name] = player;
                    }
                }
                else
                {
                    uniquePlayers.Add(player.Name, player);
                }
            }
            var topPlayers = uniquePlayers.OrderByDescending(p => p.Value.Score).Take(count);

            foreach (var player in topPlayers)
            {
                string playerInfo = $"{position}. {player.Value.Name} - {player.Value.Score}\n";
                label.Text += playerInfo;
                position++;
            }

            ratingPanel?.Controls.Add(label);
        }

        private List<Player> LoadPlayersData()
        {
            try
            {
                using (StreamReader reader = new StreamReader("player_data.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(", ");
                        if (parts.Length == 3)
                        {
                            string name = parts[0];
                            int score;
                            DateTime dateTime = DateTime.Parse(parts[2]);
                            if (int.TryParse(parts[1], out score))
                            {
                                Player player = new Player { Name = name, Score = score, DateTime = dateTime };
                                players.Add(player);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні даних гравців: " + ex.Message);
            }

            return players;
        }

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem?.ToString();

            switch (selectedValue)
            {
                case "Топ 5 гравців":
                    DisplayTopPlayers(5);
                    break;
                case "Топ 10 гравців":
                    DisplayTopPlayers(10);
                    break;
                case "Топ 20 гравців":
                    DisplayTopPlayers(20);
                    break;
                case "Топ 50 гравців":
                    DisplayTopPlayers(50);
                    break;
                case "Топ 100 гравців":
                    DisplayTopPlayers(100);
                    break;
                case "Топ 1000 гравців":
                    DisplayTopPlayers(1000);
                    break;
            }
        }
    }
}
