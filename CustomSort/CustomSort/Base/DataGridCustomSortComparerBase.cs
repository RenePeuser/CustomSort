using System.Collections;
using System.ComponentModel;
using System.Windows.Controls;

namespace CustomSort.Base
{
    public abstract class DataGridCustomSortComparerBase : IComparer
    {
        public abstract int Compare(object x, object y);

        public DataGridColumn DataGridColumn { get; set; }

        public ListSortDirection ListSortDescription { get; set; }

        public abstract IComparer UpdateSortOrderInfo(DataGridColumn dataGridColumn, ListSortDirection listSortDirection);
    }
}
