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
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Inventory
    {
        public string Name { get; set; }
        public Inventory(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }


    public class Drink
    {
        public string Name { get; set; }
        public Drink(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Colour
    {
        public string Name { get; set; }
        public Colour(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class MainWindow : Window
    {
        ObservableCollection<Drink> Drink = new ObservableCollection<Drink>();
        ObservableCollection<Colour> Colour = new ObservableCollection<Colour>();
        ObservableCollection<Inventory> inventory = new ObservableCollection<Inventory>();
        ObservableCollection<Inventory> inventory1 = new ObservableCollection<Inventory>();
        ObservableCollection<Inventory> inventory2 = new ObservableCollection<Inventory>();



        public MainWindow()
        {
            InitializeComponent();
            populateComboBox();
        }

        public void populateComboBox()
        {
            this.dataGrid1.ItemsSource = inventory1;
            this.dataGrid2.ItemsSource = inventory2;
            this.dataGrid3.ItemsSource = inventory;
            this.DrinkComboBox.ItemsSource = Drink;
            this.ColourComboBox.ItemsSource = Colour; ;

            Drink.Add(new Drink("Water"));
            Drink.Add(new Drink("Pop"));
            Drink.Add(new Drink("Orange Juice"));
            Drink.Add(new Drink("Milk"));
            Drink.Add(new Drink("Coke"));

            Colour.Add(new Colour("Red"));
            Colour.Add(new Colour("Blue"));
            Colour.Add(new Colour("Green"));
            Colour.Add(new Colour("Purple"));
            Colour.Add(new Colour("Yellow"));
        }
        private void call_ComboBox_Drink(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;

            if (item == null) return;

            Drink dr = (Drink)item;

            inventory1.Add(new Inventory(dr.Name));
        }

        private void call_ComboBox_Colour(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;

            if (item == null) return;

            Colour cl = (Colour)item;
            inventory2.Add(new Inventory(cl.Name));
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void dataGrid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (dataGrid1.SelectedItem == null)
                return;

            else
            {
                var item = (sender as ComboBox).SelectedItem;

                if (item == null) return;

                Drink dr = (Drink)item;

                inventory.Add(new Inventory(dr.Name));
            }

        }

        private void dataGrid2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (dataGrid2.SelectedItem == null)
                return;

            else
            {
                var item = (sender as ComboBox).SelectedItem;

                if (item == null) return;

                Colour cl = (Colour)item;
                inventory2.Add(new Inventory(cl.Name));
            }

        }


        private void call_reset(object sender, RoutedEventArgs e)
        {
            inventory.Clear();
            inventory1.Clear();
            inventory2.Clear();

            DrinkComboBox.Text = "Pick a Drink";
            ColourComboBox.Text = "Pick a Colour";
        }

        private void call_delete_selected_row(object sender, RoutedEventArgs e)
        {

            Inventory i = (Inventory)dataGrid1.SelectedItem;
            Inventory j = (Inventory)dataGrid2.SelectedItem;
            Inventory k = (Inventory)dataGrid3.SelectedItem;

            inventory.Remove(i);
            inventory.Remove(j);
            inventory.Remove(k);

            inventory1.Remove(i);
            inventory1.Remove(j);
            inventory1.Remove(k);

            inventory2.Remove(i);
            inventory2.Remove(j);
            inventory2.Remove(k);
        }

    }
}
