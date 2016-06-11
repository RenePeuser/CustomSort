using System.Collections.ObjectModel;
using CustomSort.Data;

namespace CustomSort
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            SourceA = new ObservableCollection<Person>();
        }


        public void AddItemToSourceA()
        {
            SourceA.Add(new Person("Max - " + SourceA.Count, "M" + SourceA.Count));
        }


        public ObservableCollection<Person> SourceA { get; }
    }
}
