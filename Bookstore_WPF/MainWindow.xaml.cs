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


       public void Clear()
        {
            TextBox_Amount.Clear();
            TextBox_Author.Clear();
            TextBox_Duration.Clear();
            TextBox_ISBN.Clear();
            TextBox_Price.Clear();
            TextBox_Title.Clear();
            TextBox_STock.Clear();
            DatePicker_Date.SelectedDate = null;
            Combox_Category.SelectedItem = null; 
        }





        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RadioButton_All.IsChecked == true)
                {
                    MessageBox.Show("Ist nicht zulässig");
                }
                else
                {
                    if (RadioButton_Book.IsChecked == true)
                    {
                     
                     
                        MessageBox.Show("Test");
                        string Titel = TextBox_Title.Text;
                        string Test_Price = TextBox_Price.Text;
                        decimal Price = Convert.ToDecimal(TextBox_Price.Text);
                        string TestStock = TextBox_STock.Text;
                        int Stock = Convert.ToInt32(TextBox_STock.Text);
                        string Author = TextBox_Author.Text;
                        string ISBN = TextBox_ISBN.Text;
                        Category category = (Category)Combox_Category.SelectedItem;

                        if (String.IsNullOrEmpty(Titel) || String.IsNullOrEmpty(Test_Price) || String.IsNullOrEmpty(TestStock) || String.IsNullOrEmpty(Author) || String.IsNullOrEmpty(ISBN))
                        {
                            MessageBox.Show("Sie müssen alle Benötigten Felder ausfüllen", "Warnung", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            Book B1 = new Book(Price, Stock, Titel, Author, ISBN, category);
                            ListeItems.Add(B1);
                            ListBox_Ausgabe.Items.Add(B1);

                            MessageBox.Show("Erfolgreich");
                        }

                        Clear();


                    }
                    else if (RadioButton_Audiobook.IsChecked == true)
                    {
                        string Titel = TextBox_Title.Text;
                        string Test_Price = TextBox_Price.Text;
                        decimal Price = Convert.ToDecimal(TextBox_Price.Text);
                        int Stock = Convert.ToInt32(TextBox_STock.Text);
                        string TestStock = TextBox_STock.Text;
                        string Author = TextBox_Author.Text;
                        string ISBN = TextBox_ISBN.Text;
                        string TestDuration = TextBox_Duration.Text;
                        int duration = Convert.ToInt32(TextBox_Duration.Text);
                        Category category = (Category)Combox_Category.SelectedItem;


                        if (String.IsNullOrEmpty(Titel) || String.IsNullOrEmpty(Test_Price) || String.IsNullOrEmpty(TestStock) || String.IsNullOrEmpty(Author) || String.IsNullOrEmpty(ISBN)|| String.IsNullOrEmpty(TestDuration))
                        {
                            MessageBox.Show("Sie müssen alle Benötigten Felder ausfüllen", "Warnung", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            AudioBook A1 = new AudioBook(Price, Stock, Titel, Author, ISBN, duration, category);
                            ListeItems.Add(A1);
                            foreach (var item in ListeItems)
                            {
                                ListBox_Ausgabe.Items.Add(item);
                            }

                            MessageBox.Show("Erfolgreich");
                        }

                        Clear();
                          
                    }
                    else if (RadioButton_Newspaper.IsChecked == true)
                    {
                        string Titel = TextBox_Title.Text;
                        string Test_price = TextBox_Price.Text;
                        decimal Price = Convert.ToDecimal(TextBox_Price.Text);
                        string Test_Stock = TextBox_STock.Text;
                        int Stock = Convert.ToInt32(TextBox_STock.Text);
                        DateTime date = (DateTime)DatePicker_Date.SelectedDate;

                        if (String.IsNullOrEmpty(Titel) || String.IsNullOrEmpty(Test_price) || String.IsNullOrEmpty(Test_Stock))
                        {
                            MessageBox.Show("Sie müssen alle Benötigten Felder ausfüllen", "Warnung", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            Newspaper N1 = new Newspaper(Price, Stock, Titel, date);
                            ListeItems.Add(N1);
                            foreach (var item in ListeItems)
                            {
                                ListBox_Ausgabe.Items.Add(item);
                            }

                            MessageBox.Show("Erfolgreich");

                            Clear();
                        }

                        
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

        private void Button_Delete_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListBox_Ausgabe.Items.Remove(ListBox_Ausgabe.SelectedItem);

                foreach (var item in ListeItems)
                {
                    if (((Item)ListBox_Ausgabe.SelectedItem).Titel == item.Titel)
                    {
                        ListeItems.Remove(item);
                    }
                }
                ListBox_Ausgabe.Items.Refresh();

                MessageBox.Show("Erfolgreich gelöscht");

                foreach (var item in ListeItems)
                {
                    MessageBox.Show(item.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        private void Button_Sell_Click(object sender, RoutedEventArgs e)
        {

            int anzahl = Convert.ToInt32(TextBox_Amount.Text);
            Item selected_Item = (Item)ListBox_Ausgabe.SelectedItem;

            if (anzahl >= 1)
            {
                if (selected_Item.TrySell(anzahl))
                {
                    MessageBox.Show($"Es wurden {anzahl} Bücher verkauft");
                }
                else
                    MessageBox.Show("Es ist etwas schiefgelaufen");
            }
            else
                MessageBox.Show("Die Zahl darf nicht 0 oder kleiner sein !");

            Clear();
            ListBox_Ausgabe.Items.Refresh();
        }

        private void Button_Purchase_Click(object sender, RoutedEventArgs e)
        {
            int anzahl = Convert.ToInt32(TextBox_Amount.Text);
            Item selected_Item = (Item)ListBox_Ausgabe.SelectedItem;

            if (anzahl >= 1)
            {
                if (selected_Item.TryPurchase(anzahl))
                {
                    MessageBox.Show($"Es wurden {anzahl} Bücher gekauft");
                }
                else
                    MessageBox.Show("Es ist etwas schiefgelaufen");
            }
            else
                MessageBox.Show("Die Zahl darf nicht 0 oder kleiner sein !");

            Clear();
            ListBox_Ausgabe.Items.Refresh();
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            string suche = TextBox_Search.Text.ToLower();

            if ((suche == " " || suche == "") && RadioButton_All.IsChecked == true)
            {

            }
            else if(RadioButton_Book.IsChecked == true)
            {

            }

            
        }
    }
}
