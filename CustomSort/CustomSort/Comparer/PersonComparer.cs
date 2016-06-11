using System;
using System.ComponentModel;
using CustomSort.Base;
using CustomSort.Data;

namespace CustomSort.Comparer
{
    public class PersonCustomComparer : DataGridCustomSortComparerGenericBase<PersonCustomComparer, Person>
    {
        protected override int Compare(Person obj1, Person obj2)
        {
            var currentHeaderName = DataGridColumn.Header.ToString();

            switch (currentHeaderName)
            {
                case "Name":
                    return StringCompare(obj1.Name, obj2.Name);
                case "FamilyName":
                    return StringCompare(obj1.FamilyName, obj2.FamilyName);
            }
            return 0;
        }

        int StringCompare(string s1, string s2)
        {
            return ListSortDescription == ListSortDirection.Ascending ?
                string.Compare(s1, s2, StringComparison.Ordinal) :
                string.Compare(s2, s1, StringComparison.Ordinal);
        }
    }
}
