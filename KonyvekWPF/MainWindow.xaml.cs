using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonyvekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Konyv> konyvek = new List<Konyv>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Betoltes_Click(object sender, RoutedEventArgs e)
        {
            konyvek.Clear();

            konyvek.Add(new Konyv("1984", "George Orwell", 328, "Sci-fi", true));
            konyvek.Add(new Konyv("A szolgálólány meséje", "Margaret Atwood", 311, "Disztópia", false));
            konyvek.Add(new Konyv("Az ember tragédiája", "Madách Imre", 250, "Dráma", true));
            konyvek.Add(new Konyv("Dűne", "Frank Herbert", 604, "Sci-fi", true));
            konyvek.Add(new Konyv("Egri csillagok", "Gárdonyi Géza", 552, "Történelmi", false));

            dgKonyvek.ItemsSource = null;
            dgKonyvek.ItemsSource = konyvek;

            progressBar.Value = 100;
        }

        private void Darab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {konyvek.Count} könyv van.","Könyvek száma");
        }

        private void Leghosszabb_Click(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltött könyvek!");
                return;
            }

            Konyv leghosszabb = konyvek.OrderByDescending(k => k.Oldalszam).First();

            MessageBox.Show($"A leghosszabb könyv:\n\n" +
                $"{leghosszabb.Cim}\n" +
                $"Szerző: {leghosszabb.Szerzo}\n" +
                $"Oldalszám: {leghosszabb.Oldalszam}",
                "Leghosszabb könyv"
            );
        }

        private void Atlag_Click(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltött könyvek!");
                return;
            }

            double atlag = konyvek.Average(k => k.Oldalszam);

            MessageBox.Show($"A könyvek átlagos oldalszáma: {atlag:F1}","Átlagos oldalszám"
            );
        }

        private void Elerheto_Click(object sender, RoutedEventArgs e)
        {
            var elerhetoKonyvek = konyvek.Where(k => k.Elerheto).ToList();

            dgKonyvek.ItemsSource = elerhetoKonyvek;
        }
        private void Cimek_Click(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count == 0)
            {
                MessageBox.Show("Nincsenek betöltött könyvek!");
                return;
            }

            string cimek = string.Join("\n",konyvek.Select(k => k.Cim)
            );

            MessageBox.Show(cimek, "Könyvek címei");
        }

        private void Rendezes_Click(object sender, RoutedEventArgs e)
        {
            var rendezett = konyvek.OrderBy(k => k.Szerzo).ToList();

            dgKonyvek.ItemsSource = rendezett;
        }
    }

   
}