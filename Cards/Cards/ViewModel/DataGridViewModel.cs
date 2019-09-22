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
    public class DataGridViewModel: DependencyObject
    {
        public DataGridViewModel()
        {
            Collection.FillData();
            CardsCollection = Collection.Cards;
            
        }

        public ObservableCollection<Card> CardsCollection
        {
            get { return (ObservableCollection<Card>)GetValue(CardsCollectionProperty); }
            set { SetValue(CardsCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardsCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardsCollectionProperty =
            DependencyProperty.Register("CardsCollection", typeof(ObservableCollection<Card>), typeof(DataGridViewModel), new PropertyMetadata(null));


        public Card SelectedCard
        {
            get { return (Card)GetValue(SelectedCardProperty); }
            set { SetValue(SelectedCardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCard.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCardProperty =
            DependencyProperty.Register("SelectedCard", typeof(Card), typeof(DataGridViewModel), new PropertyMetadata(null));



    }
}
