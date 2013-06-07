using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ExtendedControls;

namespace LoadOnScroll
{
    public sealed class MyExtendedTestListBox : ExtendedListBox
    {
        public MyExtendedTestListBox()
        {
            this.DataBase  = from i in Enumerable.Range(0, 10) select "Item" + i.ToString();

            var someList = from i in Enumerable.Range(0, 6) select "Item" + i.ToString();

            this.InitialItems = new ObservableCollection<object>(someList.ToList<string>());

            this.ItemsSource = this.InitialItems;
        }

        private IEnumerable<string> DataBase
        {
            get; set;
        }

        public override ObservableCollection<object> InitialItems
        {
            get; set; 
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
