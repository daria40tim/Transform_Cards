using Cards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cards.ViewModel
{
    public class FilterViewModel: DependencyObject
    {
        public FilterViewModel()
        {
            CardCollection = new ObservableCollection<Card>();
            string[] _types = { "ОСМ", "ОСЗМ", "ОСМ1", "ОСВМ", "ТСМ", "ТСЗМ", "ТСМ1", "ТСВМ"};
            Types = new List<string>();
            Types.AddRange(_types);
            //SearchCommand = new BaseCommand(SearchMethod);
        }

        //private void SearchMethod()
        //{
        //    string typo = SelectedType.ToString();
        //    string pow = Power;
        //    string first = Pr_Voltage;
        //    string sec = Sec_Voltage;
        //    string shield = Is_Schielded.ToString();
        //    string bid = Bid.ToString();
        //    string test = Is_Not_Tested.ToString();
        //    string conn = Conn_Type;
        //    string coils = Coil_Num.ToString();
        //    string mesh = Measure;
        //    string searchStr = "select card_id, tr_type, tr_power, pr_voltage, sec_voltage, is_shielded, bd_date, author, bid, is_not_tested, picture, card_file, addition, conn_type, coil_num, measure from tp_card where";
        //    if (Power != null) { searchStr += " (tr_power = " + pow + ") and "; }
        //    else { pow = ""; }
        //    if (Pr_Voltage != null) { searchStr += " (pr_voltage = '" + first + "') and "; }
        //    else { first = ""; }
        //    if (Sec_Voltage != null) { searchStr += " (sec_voltage = '" + sec + "') and "; }
        //    else { sec = ""; }
        //    if (shield != null) { searchStr += " (is_shielded = " + shield + ") and "; }
        //    else { shield = ""; }
        //    if (bid != null) { searchStr += " (bid = '" + bid + "') and "; }
        //    else { bid = ""; }
        //    if (test != null) { searchStr += " (is_not_tested = " + test + ") and"; }
        //    else { test = ""; }
        //    if (conn != null) { searchStr += " (conn_type = '" + conn + "') and "; }
        //    else { conn = ""; }
        //    if (coils != null) { searchStr += " (coil_num = " + coils + ") and "; }
        //    else { coils = ""; }
        //    if (mesh != null) { searchStr += " (measure = '" + mesh + "') and"; }
        //    else { mesh = ""; }
        //    if (SelectedType != null) { searchStr += " (tr_type = '" + typo + "')"; }
        //    else { typo = ""; }
        //    CardCollection = Collection.ReadCards(searchStr);
        //}

        //public string Power
        //{
        //    get { return (string)GetValue(PowerProperty); }
        //    set { SetValue(PowerProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Power.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PowerProperty =
        //    DependencyProperty.Register("Power", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));


        //public string Pr_Voltage
        //{
        //    get { return (string)GetValue(Pr_VoltageProperty); }
        //    set { SetValue(Pr_VoltageProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Pr_Voltage.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Pr_VoltageProperty =
        //    DependencyProperty.Register("Pr_Voltage", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));

        //public string Sec_Voltage
        //{
        //    get { return (string)GetValue(Sec_VoltageProperty); }
        //    set { SetValue(Sec_VoltageProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Sec_Voltage.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Sec_VoltageProperty =
        //    DependencyProperty.Register("Sec_Voltage", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));

        //public bool Is_Schielded
        //{
        //    get { return (bool)GetValue(Is_SchieldedProperty); }
        //    set { SetValue(Is_SchieldedProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Is_Schielded.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Is_SchieldedProperty =
        //    DependencyProperty.Register("Is_Schielded", typeof(bool), typeof(FilterViewModel), new PropertyMetadata(null));

        //public bool Bid
        //{
        //    get { return (bool)GetValue(BidProperty); }
        //    set { SetValue(BidProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Bid.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty BidProperty =
        //    DependencyProperty.Register("Bid", typeof(bool), typeof(FilterViewModel), new PropertyMetadata(null));


        //public bool Is_Not_Tested
        //{
        //    get { return (bool)GetValue(Is_Not_TestedProperty); }
        //    set { SetValue(Is_Not_TestedProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Is_Not_Tested.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Is_Not_TestedProperty =
        //    DependencyProperty.Register("Is_Not_Tested", typeof(bool), typeof(FilterViewModel), new PropertyMetadata(null));

        //public string Conn_Type
        //{
        //    get { return (string)GetValue(Conn_TypeProperty); }
        //    set { SetValue(Conn_TypeProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Conn_Type.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Conn_TypeProperty =
        //    DependencyProperty.Register("Conn_Type", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));


        //public int Coil_Num
        //{
        //    get { return (int)GetValue(Coil_NumProperty); }
        //    set { SetValue(Coil_NumProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Coil_Num.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Coil_NumProperty =
        //    DependencyProperty.Register("Coil_Num", typeof(int), typeof(FilterViewModel), new PropertyMetadata(null));


        //public string Measure
        //{
        //    get { return (string)GetValue(MeasureProperty); }
        //    set { SetValue(MeasureProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Measure.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MeasureProperty =
        //    DependencyProperty.Register("Measure", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));


        public List<string> Types
        {
            get { return (List<string>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Types.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(List<string>), typeof(FilterViewModel), new PropertyMetadata(null));


        //public string SelectedType
        //{
        //    get { return (string)GetValue(SelectedTypeProperty); }
        //    set { SetValue(SelectedTypeProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedType.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedTypeProperty =
        //    DependencyProperty.Register("SelectedType", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));



        //public BaseCommand SearchCommand
        //{
        //    get { return (BaseCommand)GetValue(SearchCommandProperty); }
        //    set { SetValue(SearchCommandProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SearchCommand.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SearchCommandProperty =
        //    DependencyProperty.Register("SearchCommand", typeof(BaseCommand), typeof(FilterViewModel), new PropertyMetadata(null));



        public ObservableCollection<Card> CardCollection
        {
            get { return (ObservableCollection<Card>)GetValue(CardCollectionProperty); }
            set { SetValue(CardCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardCollectionProperty =
            DependencyProperty.Register("CardCollection", typeof(ObservableCollection<Card>), typeof(FilterViewModel), new PropertyMetadata(null));

    }
}
