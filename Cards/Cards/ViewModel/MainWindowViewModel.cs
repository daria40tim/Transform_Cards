using Cards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Cards.ViewModel
{
    public class MainWindowViewModel: DependencyObject
    {
        static string query = "";

        public MainWindowViewModel()
        {
            query = "select card_id, tr_type, tr_power, pr_voltage, sec_voltage, is_shielded, bd_date, author, bid, is_not_tested, picture, card_file, addition, conn_type, coil_num, measure from tp_card where";
            Collection.FillData();
            DataGridVM = new DataGridViewModel();
            FilterVM = new FilterViewModel();
            SelectedType = FilterVM.Types[0];
            CardsCollection = Collection.Cards;
            SelectedCard = DataGridVM.SelectedCard;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            OpenFileCommand = new BaseCommand(OpenFileMethod);
            SearchCommand = new BaseCommand(SearchMethod);
        }

        private void SearchMethod()
        {
            if (Power != null) { query += " (tr_power = " + Power + ") and "; }
            //if (Pr_Voltage != null) { query += " (pr_voltage = '" + Pr_Voltage + "') and "; }
            //if (Sec_Voltage != null) { query += " (sec_voltage = '" + Sec_Voltage + "') and "; }
            if (Is_Schielded != null) { query += " (is_shielded = " + Is_Schielded + ") and "; }
            if (Bid != null) { query += " (bid = '" + Bid + "') and "; }
            if (Is_Not_Tested != null) { query += " (is_not_tested = " + Is_Not_Tested + ") and"; }
            if (Conn_Type != null) { query += " (conn_type = '" + Conn_Type + "') and "; }
            if (Coil_Num != 0) { query += " (coil_num = " + Coil_Num + ") and "; }
            if (Measure != null) { query += " (measure = '" + Measure + "') and"; }
            if (SelectedType != null) { query += " (tr_type = '" + SelectedType + "')"; }
            try
                {
                    Collection.Cards = Collection.ReadCards(query);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Произошла ошибка. Проверьте введенные данные.");
                    Collection.Cards = Collection.ReadCards("");
                }
            if (Pr_Voltage != "" && Sec_Voltage != "") { Collection.Cards = FindPrVoltage(Pr_Voltage, Sec_Voltage); }
            if (Collection.Cards.Count == 0)
            {
                MessageBox.Show("Не найдено. Введите меньше параметров и попытайтесь осуществить поиск вручную");
            }
            else { DataGridVM = new DataGridViewModel(); }
            query = "select card_id, tr_type, tr_power, pr_voltage, sec_voltage, is_shielded, bd_date, author, bid, is_not_tested, picture, card_file, addition, conn_type, coil_num, measure from tp_card where";
            //MessageBox.Show(query);
        }

        private ObservableCollection<Card> FindPrVoltage(string pr, string sec)
        {
            ObservableCollection<Card> res = new ObservableCollection<Card>(); 
            string[] volt;
            Voltage a = null;
            if (pr != null)
            {
                volt = pr.Split('-');
                a = new Voltage(volt);
            }
            List<Voltage> b = new List<Voltage>();
            if (sec != null)
            {
                volt = sec.Split('/');
                b = new List<Voltage>();
                foreach (var item in volt)
                {
                    Voltage c = new Voltage(item.Split('-'));
                    b.Add(c);
                }
            }
            bool contains = false;
            foreach (var item in Collection.Cards)
            {
                foreach (var i in a.Values)
                {
                    contains = item.Pr_Voltage.Values.Contains(i);
                    if (!contains) { break; }
                }
                if (contains) { res.Add(item); }
            }
            contains = false;
            ObservableCollection<Card> res1 = new ObservableCollection<Card>();
            foreach (var item in res)
            {
                foreach (var iter in item.Sec_Voltage)
                {
                    foreach (var intel in b)
                    {
                        foreach (var intellij in intel.Values)
                        {
                            contains = iter.Values.Contains(intellij);
                            if (!contains) { break; }
                        }
                    }
                }
                if (contains) { res1.Add(item); }
            }
            return res1;
        }

        private void OpenFileMethod()
        {
            System.Diagnostics.Process.Start(@"F:\ \Учеба\диплом\Transform_Cards\"+SelectedCard.CardFile);
        }

        public BaseCommand OpenFileCommand
        {
            get { return (BaseCommand)GetValue(OpenFileCommandProperty); }
            set { SetValue(OpenFileCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenFileCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenFileCommandProperty =
            DependencyProperty.Register("OpenFileCommand", typeof(BaseCommand), typeof(DataGridViewModel), new PropertyMetadata(null));

        public DataGridViewModel DataGridVM
        {
            get { return (DataGridViewModel)GetValue(DataGridVMProperty); }
            set { SetValue(DataGridVMProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataGridVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataGridVMProperty =
            DependencyProperty.Register("DataGridVM", typeof(DataGridViewModel), typeof(MainWindowViewModel), new PropertyMetadata(null));


        public FilterViewModel FilterVM
        {
            get { return (FilterViewModel)GetValue(FilterVMProperty); }
            set { SetValue(FilterVMProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterVM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterVMProperty =
            DependencyProperty.Register("FilterVM", typeof(FilterViewModel), typeof(MainWindowViewModel), new PropertyMetadata(null));

        public Card SelectedCard
        {
            get { return (Card)GetValue(SelectedCardProperty); }
            set { SetValue(SelectedCardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCard.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCardProperty =
            DependencyProperty.Register("SelectedCard", typeof(Card), typeof(MainWindowViewModel), new PropertyMetadata(null));



        public string SelectedType
        {
            get { return (string)GetValue(SelectedTypeProperty); }
            set { SetValue(SelectedTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTypeProperty =
            DependencyProperty.Register("SelectedType", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(null));



        public ObservableCollection<Worker> Workers
        {
            get { return (ObservableCollection<Worker>)GetValue(WorkersProperty); }
            set { SetValue(WorkersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Workers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkersProperty =
            DependencyProperty.Register("Workers", typeof(ObservableCollection<Worker>), typeof(MainWindowViewModel), new PropertyMetadata(null));


        public ObservableCollection<Card> CardsCollection
        {
            get { return (ObservableCollection<Card>)GetValue(CardsCollectionProperty); }
            set { SetValue(CardsCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardsCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardsCollectionProperty =
            DependencyProperty.Register("CardsCollection", typeof(ObservableCollection<Card>), typeof(MainWindowViewModel), new PropertyMetadata(null));

    
        public string Power
        {
            get { return (string)GetValue(PowerProperty); }
            set { SetValue(PowerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Power.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PowerProperty =
            DependencyProperty.Register("Power", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));


        public string Pr_Voltage
        {
            get { return (string)GetValue(Pr_VoltageProperty); }
            set { SetValue(Pr_VoltageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Pr_Voltage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Pr_VoltageProperty =
            DependencyProperty.Register("Pr_Voltage", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));

        public string Sec_Voltage
        {
            get { return (string)GetValue(Sec_VoltageProperty); }
            set { SetValue(Sec_VoltageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sec_Voltage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Sec_VoltageProperty =
            DependencyProperty.Register("Sec_Voltage", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));

        public bool Is_Schielded
        {
            get { return (bool)GetValue(Is_SchieldedProperty); }
            set { SetValue(Is_SchieldedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Is_Schielded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Is_SchieldedProperty =
            DependencyProperty.Register("Is_Schielded", typeof(bool), typeof(FilterViewModel), new PropertyMetadata(null));

        public bool Bid
        {
            get { return (bool)GetValue(BidProperty); }
            set { SetValue(BidProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Bid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BidProperty =
            DependencyProperty.Register("Bid", typeof(bool), typeof(FilterViewModel), new PropertyMetadata(null));


        public bool Is_Not_Tested
        {
            get { return (bool)GetValue(Is_Not_TestedProperty); }
            set { SetValue(Is_Not_TestedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Is_Not_Tested.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Is_Not_TestedProperty =
            DependencyProperty.Register("Is_Not_Tested", typeof(bool), typeof(FilterViewModel), new PropertyMetadata(null));

        public string Conn_Type
        {
            get { return (string)GetValue(Conn_TypeProperty); }
            set { SetValue(Conn_TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Conn_Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Conn_TypeProperty =
            DependencyProperty.Register("Conn_Type", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));


        public int Coil_Num
        {
            get { return (int)GetValue(Coil_NumProperty); }
            set { SetValue(Coil_NumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Coil_Num.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Coil_NumProperty =
            DependencyProperty.Register("Coil_Num", typeof(int), typeof(FilterViewModel), new PropertyMetadata(null));


        public string Measure
        {
            get { return (string)GetValue(MeasureProperty); }
            set { SetValue(MeasureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Measure.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MeasureProperty =
            DependencyProperty.Register("Measure", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));
        

        public BaseCommand SearchCommand
        {
            get { return (BaseCommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(BaseCommand), typeof(FilterViewModel), new PropertyMetadata(null));



    }
}
