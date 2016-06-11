using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using CustomSort.Base;
using WpfExtensions;

namespace CustomSort.Behaviors
{
    public class DataGridCompositeCollectionCustomSortBehavior : Behavior<DataGrid>
    {
        public static readonly DependencyProperty DataGridCustomSortComparerBaseProperty = DependencyProperty.Register(
            "DataGridCustomSortComparerBase", typeof(DataGridCustomSortComparerBase), typeof(DataGridCompositeCollectionCustomSortBehavior), new PropertyMetadata(default(DataGridCustomSortComparerBase)));

        private ListCollectionView _listCollectionView;

        public DataGridCustomSortComparerBase DataGridCustomSortComparerBase
        {
            get { return (DataGridCustomSortComparerBase)GetValue(DataGridCustomSortComparerBaseProperty); }
            set { SetValue(DataGridCustomSortComparerBaseProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Sorting += AssociatedObjectSorting;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            _listCollectionView = AssociatedObject.GetListCollectionView();
        }

        private void AssociatedObjectSorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
            var newSortDirection = e.Column.SortDirection != null && e.Column.SortDirection.Value == ListSortDirection.Ascending
                                       ? ListSortDirection.Descending
                                       : ListSortDirection.Ascending;

            e.Column.SortDirection = newSortDirection;
            var newComparer = DataGridCustomSortComparerBase.UpdateSortOrderInfo(e.Column, newSortDirection);

            _listCollectionView.CustomSort = newComparer;
        }
    }
}
