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




namespace SpelunkyClassicSaveEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public void LoadFromRegistry()
        {
            this.TextboxScore.Text = SpelunkySaveManager.GetScore().ToString();
            this.TextboxTime.Text = SpelunkySaveManager.GetTime().ToString();
            this.TextboxKills.Text = SpelunkySaveManager.GetKills().ToString();
            this.TextboxSaves.Text = SpelunkySaveManager.GetSaves().ToString();
            this.TextboxPlays.Text = SpelunkySaveManager.GetPlays().ToString();
            this.TextboxWins.Text = SpelunkySaveManager.GetWins().ToString();
            this.TextboxDeaths.Text = SpelunkySaveManager.GetDeaths().ToString();
            this.TextboxTunnel1.Text = SpelunkySaveManager.GetTunnel1().ToString();
            this.TextboxTunnel2.Text = SpelunkySaveManager.GetTunnel2().ToString();
            var minigames = SpelunkySaveManager.GetMinigames();
            this.TextboxSunChallenge.Text = SpelunkySaveManager.GetSunChallenge(minigames).ToString();
            this.TextboxMoonChallenge.Text = SpelunkySaveManager.GetMoonChallenge(minigames).ToString();
            this.TextboxStarsChallenge.Text = SpelunkySaveManager.GetStarsChallenge(minigames).ToString();
        }

        public void SaveToRegistry()
        {
            SpelunkySaveManager.SetScore(UInt32.Parse(this.TextboxScore.Text));
            SpelunkySaveManager.SetTime(UInt32.Parse(this.TextboxTime.Text));
            SpelunkySaveManager.SetKills(UInt32.Parse(this.TextboxKills.Text));
            SpelunkySaveManager.SetSaves(UInt32.Parse(this.TextboxSaves.Text));
            SpelunkySaveManager.SetPlays(UInt32.Parse(this.TextboxPlays.Text));
            SpelunkySaveManager.SetWins(UInt32.Parse(this.TextboxWins.Text));
            SpelunkySaveManager.SetDeaths(UInt32.Parse(this.TextboxDeaths.Text));
            SpelunkySaveManager.SetTunnel1(UInt32.Parse(this.TextboxTunnel1.Text));
            SpelunkySaveManager.SetTunnel2(UInt32.Parse(this.TextboxTunnel2.Text));

            var sun = UInt32.Parse(this.TextboxSunChallenge.Text);
            var moon = UInt32.Parse(this.TextboxMoonChallenge.Text);
            var stars = UInt32.Parse(this.TextboxStarsChallenge.Text);
            SpelunkySaveManager.SetMinigames(sun, moon, stars);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.SaveToRegistry();
        }
    }
}
