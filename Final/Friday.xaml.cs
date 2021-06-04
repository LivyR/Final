using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Final.DataSetTableAdapters;

namespace Final
{
    /// <summary>
    /// Interaction logic for Friday.xaml
    /// </summary>
    public partial class Friday : Window
    {
        private MondayTableAdapter MTA = new MondayTableAdapter();
        private TuesdayTableAdapter TusTA = new TuesdayTableAdapter();
        private WednesdayTableAdapter WTA = new WednesdayTableAdapter();
        private ThursdayTableAdapter ThursTA = new ThursdayTableAdapter();
        private FridayTableAdapter FTA = new FridayTableAdapter();
        private SaturdayTableAdapter SatTA = new SaturdayTableAdapter();
        private SundayTableAdapter SunTA = new SundayTableAdapter();
    
        private DataSet DS = new DataSet();

        public Friday()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FTA.Fill(DS.Friday);
            DataContext = DS.Friday;
        }

        private void MonOnClick(object sender, RoutedEventArgs e)
        {
            DataContext = DS.Monday;
        }

        private void TuesOnClick(object sender, RoutedEventArgs e)
        {
            DataContext = DS.Tuesday;
        }

        private void WedOnClick(object sender, RoutedEventArgs e)
        {
            DataContext = DS.Wednesday;
        }

        private void ThursOnClick(object sender, RoutedEventArgs e)
        {
            DataContext = DS.Thursday;
        }

        private void FriOnClick(object sender, RoutedEventArgs e)
        {
            DataContext = DS.Friday;
        }

        private void SatOnClick(object sender, RoutedEventArgs e)
        {
            DataContext = DS.Saturday;
        }

        private void SunOnClick(object sender, RoutedEventArgs e)
        {
            DataContext = DS.Sunday;
        }


        private void SaveOnClick(object sender, RoutedEventArgs e)
        {
            var query = from Friday in DS.Friday
                        where (Friday.Date == Date.Text)
                        where (Friday.Morning == Morning.Text)
                        where (Friday.Afternoon == Afternoon.Text)
                        where (Friday.Evening == Evening.Text)
                        where (Friday.Notes == Notes.Text)
                        where (Friday.Water == Water.Text)
                        where (Friday.Sleep == Sleep.Text)
                        select Friday;

            DataSet.FridayRow row = (DataSet.FridayRow)DS.Friday.NewRow();
            row.Date = Date.Text;
            row.Morning = Morning.Text;
            row.Afternoon = Afternoon.Text;
            row.Evening = Evening.Text;
            row.Notes = Notes.Text;
            row.Water = Water.Text;
            row.Sleep = Sleep.Text;
            DS.Friday.AddFridayRow(row);
            FTA.Update(DS);
        }

        public partial class ClassDate : UserControl, INotifyPropertyChanged
        {

            private string date;

            public string Date
            {
                get { return date; }
                set
                {
                    date = value;
                    NotifyPropertyChanged("date");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyDate)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyDate));
            }
        }
    }
}
