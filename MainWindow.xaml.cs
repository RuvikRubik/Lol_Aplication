using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Lol_Aplication.Models;

namespace Lol_Aplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ChampionsJSON;
        string versionJSON;
        string selectedVersion; // aktualnie wybrana wersja gry

        public MainWindow()
        {
            InitializeComponent();
            GetVersions();

            this.Loaded += MainWindow_Loaded;
        }

        // Pobiera danych championów z Data Dragon i tworzenie listy
        private void GenerateChapions(object sender, SelectionChangedEventArgs e)
        {
            WebClient webClient = new WebClient();
            selectedVersion = VersionsComboBox.SelectedItem.ToString();
            ChampionsJSON = webClient.DownloadString($"https://ddragon.leagueoflegends.com/cdn/{selectedVersion}/data/en_US/champion.json");
            var root = JsonSerializer.Deserialize<Json>(ChampionsJSON);

            ChampionsList.ItemsSource = root.champions.Values;
            foreach (var champ in root.champions.Values)
            {
                champ.ImageUrl = $"https://ddragon.leagueoflegends.com/cdn/{selectedVersion}/img/champion/{champ.ID}.png";
            }
        }

        // Pobranie wersji gry League of Legends
        private void GetVersions()
        {
            WebClient webClient = new WebClient();
            versionJSON = webClient.DownloadString("https://ddragon.leagueoflegends.com/api/versions.json");
            List<string> versions = JsonSerializer.Deserialize<List<string>>(versionJSON);

            VersionsComboBox.ItemsSource = versions;
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            SetTextMode();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            SetImageMode();
        }

        // Funkcja zmiany trybu wyswietlana postaci na textowy
        private void SetTextMode()
        {
            ChampionsList.ItemTemplate = (DataTemplate)Resources["TextTemplate"];
            var panelTemplate = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(StackPanel)));
            ChampionsList.ItemsPanel = panelTemplate;
        }

        // Funkcja zmiany trybu wyswietlana postaci na graficzny
        private void SetImageMode()
        {
            ChampionsList.ItemTemplate = (DataTemplate)Resources["ImageTemplate"];
            var factory = new FrameworkElementFactory(typeof(UniformGrid));
            factory.SetValue(UniformGrid.ColumnsProperty, 3);
            ChampionsList.ItemsPanel = new ItemsPanelTemplate(factory);
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetTextMode();
            VersionsComboBox.SelectedIndex = 0;
        }
    }
}