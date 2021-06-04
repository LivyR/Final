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
    /// Interaction logic for Sunday.xaml
    /// </summary>
    public partial class Sunday : Window
    {
        private MondayTableAdapter MTA = new MondayTableAdapter();
        private TuesdayTableAdapter TusTA = new TuesdayTableAdapter();
        private WednesdayTableAdapter WTA = new WednesdayTableAdapter();
        private ThursdayTableAdapter ThursTA = new ThursdayTableAdapter();
        private FridayTableAdapter FTA = new FridayTableAdapter();
        private SaturdayTableAdapter SatTA = new SaturdayTableAdapter();
        private SundayTableAdapter SunTA = new SundayTableAdapter();
    
        private DataSet DS = new DataSet();

        public Sunday()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SunTA.Fill(DS.Sunday);
            DataContext = DS.Sunday;
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
            var query = from Sunday in DS.Sunday
                        where (Sunday.Date == Date.Text)
                        where (Sunday.Morning == Morning.Text)
                        where (Sunday.Afternoon == Afternoon.Text)
                        where (Sunday.Evening == Evening.Text)
                        where (Sunday.Notes == Notes.Text)
                        where (Sunday.Water == Water.Text)
                        where (Sunday.Sleep == Sleep.Text)
                        select Sunday;

            DataSet.SundayRow row = (DataSet.SundayRow)DS.Sunday.NewRow();
            row.Date = Date.Text;
            row.Morning = Morning.Text;
            row.Afternoon = Afternoon.Text;
            row.Evening = Evening.Text;
            row.Notes = Notes.Text;
            row.Water = Water.Text;
            row.Sleep = Sleep.Text;
            DS.Sunday.AddSundayRow(row);
            SunTA.Update(DS);
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
