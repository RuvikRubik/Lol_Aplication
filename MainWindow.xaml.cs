using Lol_Aplication.Models;
using System.Net;
using System.Security.Policy;
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

namespace Lol_Aplication
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class TempChampionJson
    {
        [JsonPropertyName("data")]
        public Dictionary<string, ChampionData> Data { get; set; }
    }

    public class ChampionData
    {
        [JsonPropertyName("skins")]
        public List<Skin> Skins { get; set; }
    }
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
            ChampionsJSON = webClient.DownloadString(
                $"https://ddragon.leagueoflegends.com/cdn/{selectedVersion}/data/en_US/champion.json");

            var root = JsonSerializer.Deserialize<Json>(ChampionsJSON);

            // najpierw ustawiamy ImageUrl dla każdego championa
            foreach (var champ in root.champions.Values)
            {
                // podstawowy obrazek championa
                champ.ImageUrl = $"https://ddragon.leagueoflegends.com/cdn/{selectedVersion}/img/champion/{champ.ID}.png";

                // pobieramy JSON konkretnego championa
                string champJsonStr = webClient.DownloadString(
                    $"https://ddragon.leagueoflegends.com/cdn/{selectedVersion}/data/en_US/champion/{champ.ID}.json");

                var temp = JsonSerializer.Deserialize<TempChampionJson>(champJsonStr);
                champ.ModelId = temp.Data[champ.ID].Skins[0].Id;

            }

            // dopiero teraz ustawiamy ItemsSource
            ChampionsList.ItemsSource = root.champions.Values;
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

        private async void ChampionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChampionsList.SelectedItem is Champion selected)
            {
                string url = $"https://modelviewer.lol/model-viewer?id={selected.ModelId}";
                await ModelViewerWeb.EnsureCoreWebView2Async();
                ModelViewerWeb.Source = new Uri(url);

                // Poczekaj chwilę na załadowanie strony, potem fullscreen
                await Task.Delay(500);
                GoFullScreen();
            }
        }

        private async void GoFullScreen()
        {
            await Task.Delay(300);

            // Szukamy przycisku Full Screen i wywołujemy jego kliknięcie
            string script = @"
    let btn = Array.from(document.querySelectorAll('button'))
                   .find(b => b.innerText.includes('Full Screen'));
    if (btn) btn.click();
";

            await ModelViewerWeb.ExecuteScriptAsync(script);
        }
    }
}