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
    /// Interaction logic for Thursday.xaml
    /// </summary>
    public partial class Thursday : Window
    {
        private MondayTableAdapter MTA = new MondayTableAdapter();
        private TuesdayTableAdapter TusTA = new TuesdayTableAdapter();
        private WednesdayTableAdapter WTA = new WednesdayTableAdapter();
        private ThursdayTableAdapter ThursTA = new ThursdayTableAdapter();
        private FridayTableAdapter FTA = new FridayTableAdapter();
        private SaturdayTableAdapter SatTA = new SaturdayTableAdapter();
        private SundayTableAdapter SunTA = new SundayTableAdapter();
      
        private DataSet DS = new DataSet();

        public Thursday()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ThursTA.Fill(DS.Thursday);
            DataContext = DS.Thursday;
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
            var query = from Thursday in DS.Thursday
                        where (Thursday.Date == Date.Text)
                        where (Thursday.Morning == Morning.Text)
                        where (Thursday.Afternoon == Afternoon.Text)
                        where (Thursday.Evening == Evening.Text)
                        where (Thursday.Notes == Notes.Text)
                        where (Thursday.Water == Water.Text)
                        where (Thursday.Sleep == Sleep.Text)
                        select Thursday;

            DataSet.ThursdayRow row = (DataSet.ThursdayRow)DS.Thursday.NewRow();
            row.Date = Date.Text;
            row.Morning = Morning.Text;
            row.Afternoon = Afternoon.Text;
            row.Evening = Evening.Text;
            row.Notes = Notes.Text;
            row.Water = Water.Text;
            row.Sleep = Sleep.Text;
            DS.Thursday.AddThursdayRow(row);
            ThursTA.Update(DS);
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
