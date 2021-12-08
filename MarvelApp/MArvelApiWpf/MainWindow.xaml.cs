using MarvelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Unity;

namespace MArvelApiWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        MarvelApi marvelApi = new MarvelApi();
        List<Character> resultCharacters = new List<Character>(20);
        List<Comics> resultComics = new List<Comics>(20);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btShow_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            Img();
            lbLoading.IsEnabled = false;
        }

    
       
        public void Clear()
        {
  
            foreach (Character character in marvelApi.GetCharacters())
            {
                resultCharacters.Remove(character);
            }
            stackpanel.Children.Clear();
        }

        

        public  void Img()
        {
            MainWindow main = new MainWindow();
            try
            {
                int start = Convert.ToInt32(tbStart.Text);
                int finish = Convert.ToInt32(tbFinish.Text);
                foreach (Character character in marvelApi.GetCharacters(start, finish))
                {
                    string Name = character.Name;
                    var url = new Uri(character.ImageUrl);
                    var bitmap = new BitmapImage(url);
                    stackpanel.Children.Add(new Label
                    {
                        Content = Name,
                        Width = 350,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                    });
                    stackpanel.Children.Add(new Image
                    {

                        Source = bitmap,
                        Height = 300,
                        Width = 350
                    });

                    resultCharacters.Add(new Character(character.Id, character.Name));
                }
                
                main.UpdateLayout();
            }
            catch { }
        }

        private void DataGridCell_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Clear();
            MarvelApi marvel = new MarvelApi();
            try
            { 
                Character path = grid.SelectedItem as Character;
                int id = path.Id;
                foreach (Comics comics in marvel.GetComics(id))
                {
                    string Name = comics.Title;
                    var url = new Uri(comics.ImageUrl);
                    var bitmap = new BitmapImage(url);
                    stackpanel.Children.Add(new Label
                    {
                        Content = Name,
                        Width = 350,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                    });
                    stackpanel.Children.Add(new Image
                    {
                        Source = bitmap,
                        Height = 300,
                        Width = 350
                    });
                    resultComics.Add(new Comics(comics.Title, comics.ImageUrl));
                }
                MessageBox.Show("Id: " + path.Id + "Name: " + path.Name + "\n" + "ImageUrl: " + path.ImageUrl);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                int start = Convert.ToInt32(tbStart.Text);
                int finish = Convert.ToInt32(tbFinish.Text);
                List<Character> result = new List<Character>(20);
                MarvelApi marvelApi = new MarvelApi();
                foreach (Character character in marvelApi.GetCharacters(start, finish))
                {
                    result.Add(new Character(character.Id, character.Name));
                }
                grid.ItemsSource = result;
                // Invoke(new Action(() => { }));! 
                //как на grid вызвать Invoke?
                //не могу правильно написать этот метод 
            }
            catch { }

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void DataGridCell_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
