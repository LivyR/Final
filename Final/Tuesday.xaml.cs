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
    /// Interaction logic for Tuesday.xaml
    /// </summary>
    public partial class Tuesday : Window
    {
        private MondayTableAdapter MTA = new MondayTableAdapter();
        private TuesdayTableAdapter TusTA = new TuesdayTableAdapter();
        private WednesdayTableAdapter WTA = new WednesdayTableAdapter();
        private ThursdayTableAdapter ThursTA = new ThursdayTableAdapter();
        private FridayTableAdapter FTA = new FridayTableAdapter();
        private SaturdayTableAdapter SatTA = new SaturdayTableAdapter();
        private SundayTableAdapter SunTA = new SundayTableAdapter();
       
        private DataSet DS = new DataSet();

        public Tuesday()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TusTA.Fill(DS.Tuesday);
            DataContext = DS.Tuesday;
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
            var query = from Tuesday in DS.Tuesday
                        where (Tuesday.Date == Date.Text)
                        where (Tuesday.Morning == Morning.Text)
                        where (Tuesday.Afternoon == Afternoon.Text)
                        where (Tuesday.Evening == Evening.Text)
                        where (Tuesday.Notes == Notes.Text)
                        where (Tuesday.Water == Water.Text)
                        where (Tuesday.Sleep == Sleep.Text)
                        select Tuesday;

            DataSet.TuesdayRow row = (DataSet.TuesdayRow)DS.Tuesday.NewRow();
            row.Date = Date.Text;
            row.Morning = Morning.Text;
            row.Afternoon = Afternoon.Text;
            row.Evening = Evening.Text;
            row.Notes = Notes.Text;
            row.Water = Water.Text;
            row.Sleep = Sleep.Text;
            DS.Tuesday.AddTuesdayRow(row);
            TusTA.Update(DS);

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
