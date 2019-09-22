using System;
using System.Collections.Generic;
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
            string[] _types = { "ОСМ", "ОСЗМ", "ОСМ1", "ОСВМ", "ТСМ", "ТСЗМ", "ТСМ1", "ТСВМ"};
            Types = new List<string>();
            Types.AddRange(_types);
        }

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


        public List<string> Types
        {
            get { return (List<string>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Types.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(List<string>), typeof(FilterViewModel), new PropertyMetadata(null));


        public string SelectedType
        {
            get { return (string)GetValue(SelectedTypeProperty); }
            set { SetValue(SelectedTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTypeProperty =
            DependencyProperty.Register("SelectedType", typeof(string), typeof(FilterViewModel), new PropertyMetadata(null));

    }
}
