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
using Buchgeschaeft;

namespace Bookstore_WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Item> ListeItems = new List<Item> { };

        
        public MainWindow()
        {
            InitializeComponent();

            Combox_Category.ItemsSource = Enum.GetValues(typeof(Category));
            
            
        }

        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RadioButton_Book.IsChecked == true)
                {
                    string Titel = TextBox_Title.Text;
                    decimal Price = Convert.ToDecimal(TextBox_Price.Text);
                    int Stock = Convert.ToInt32(TextBox_STock.Text);
                    string Author = TextBox_Author.Text;
                    string ISBN = TextBox_ISBN.Text;
                    Category category = (Category)Combox_Category.SelectedItem;

                  

                    Book B1 = new Book(Price, Stock, Titel, Author, ISBN, category);
                    ListeItems.Add(B1);
                    foreach (var item in ListeItems)
                    {
                        ListBox_Ausgabe.Items.Add(item);
                    }
                    

                }
                else if(RadioButton_Audiobook.IsChecked == true)
                {
                    string Titel = TextBox_Title.Text;
                    decimal Price = Convert.ToDecimal(TextBox_Price.Text);
                    int Stock = Convert.ToInt32(TextBox_STock.Text);
                    string Author = TextBox_Author.Text;
                    string ISBN = TextBox_ISBN.Text;
                    int duration = Convert.ToInt32(TextBox_Duration.Text);
                    Category category = (Category)Combox_Category.SelectedItem;



                    AudioBook A1 = new AudioBook(Price, Stock, Titel, Author, ISBN, duration, category);
                    ListeItems.Add(A1);
                    foreach (var item in ListeItems)
                    {
                        ListBox_Ausgabe.Items.Add(item);
                    }
                }
                else if (RadioButton_Newspaper.IsChecked == true)
                {
                    string Titel = TextBox_Title.Text;
                    decimal Price = Convert.ToDecimal(TextBox_Price.Text);
                    int Stock = Convert.ToInt32(TextBox_STock.Text);
                    DateTime date = (DateTime)DatePicker_Date.SelectedDate;



                    Newspaper N1 = new Newspaper(Price, Stock, Titel, date);
                    ListeItems.Add(N1);
                    foreach (var item in ListeItems)
                    {
                        ListBox_Ausgabe.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
