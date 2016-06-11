using System.Collections;
using System.ComponentModel;
using System.Windows.Controls;
using Extensions;

namespace CustomSort.Base
{
    public abstract class DataGridCustomSortComparerGenericBase<TConverter, TClass> : DataGridCustomSortComparerBase where TConverter : DataGridCustomSortComparerGenericBase<TConverter, TClass>, new() where TClass : class
    {
        public override int Compare(object x, object y)
        {
            return Compare(x.Cast<TClass>(), y.Cast<TClass>());
        }

        protected abstract int Compare(TClass obj1, TClass obj2);

        public override IComparer UpdateSortOrderInfo(DataGridColumn dataGridColumn, ListSortDirection listSortDirection)
        {
            var newComparer = new TConverter
            {
                DataGridColumn = dataGridColumn,
                ListSortDescription = listSortDirection
            };

            return newComparer;
        }

    }
}
