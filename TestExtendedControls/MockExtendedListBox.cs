using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestExtendedControls
{
    public sealed class MockExtendedListBox : ExtendedControls.ExtendedListBox
    {
        public MockExtendedListBox()
        {
            this.DataBase = from i in Enumerable.Range(0, 1000) select "Item" + i;

            var someList = from i in Enumerable.Range(0, 2) select "Item" + i;

            this.InitialItems = new ObservableCollection<object>(someList.ToList<string>());

            this.ItemsSource = this.InitialItems;
        }
        private IEnumerable<string> DataBase
        {
            get;
            set;
        }

        public override ObservableCollection<object> InitialItems
        {
            get;
            set;
        }

        public override object GetChild(int index)
        {
            if (this.DataBase.Count() > index)
            {
                return this.DataBase.ToList<object>()[index];
            }
            return null;
        }
    }
}
