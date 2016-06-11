using CustomSort.Base;

namespace CustomSort.Data
{
    public class Person : BindingBase
    {
        private string _name;
        private string _familyName;

        public Person(string name, string familyName)
        {
            Name = name;
            FamilyName = familyName;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }


        public string FamilyName
        {
            get { return _familyName; }
            set
            {
                if (_familyName != value)
                {
                    _familyName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
