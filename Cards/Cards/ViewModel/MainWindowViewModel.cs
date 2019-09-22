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
        //public string standart_location = "F:\ \Учеба\диплом\Transform_Cards\";
        public MainWindowViewModel()
        {
            Collection.FillData();
            DataGridVM = new DataGridViewModel();
            FilterVM = new FilterViewModel();
            SelectedCard = DataGridVM.SelectedCard;
            SelectedType = FilterVM.SelectedType;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            OpenFileCommand = new BaseCommand(OpenFileMethod);
            SearchCommand = new BaseCommand(SearchMethod);
        }
        private void SearchMethod()
        {
            SelectedType = FilterVM.SelectedType;
            string typo = "";
            string pow = "";
            string first = "";
            string sec = "";
            string shield = "";
            string bid = "";
            string test = "";
            string conn = "";
            string coils = "";
            string mesh = "";
            string searchStr = "select card_id, tr_type, tr_power, pr_voltage, sec_voltage, is_shielded, bd_date, author, bid, is_not_tested, picture, card_file, addition, conn_type, coil_num, measure from tp_card where";
            if (FilterVM.SelectedType != null)
            {
                typo = " tr_type = '" + SelectedType+"'";
            }
            if (true)
            {

            }
            MessageBox.Show(searchStr);
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


        public BaseCommand SearchCommand
        {
            get { return (BaseCommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(BaseCommand), typeof(MainWindowViewModel), new PropertyMetadata(null));



    }
}
