using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using ExtendedControls;

namespace LoadOnScroll
{
    public sealed class MyExtendedDataGrid : ExtendedDataGrid
    {
        public MyExtendedDataGrid()
        {
            this.PersonCollection = new PersonCollection();

            for (int i = 0; i < 15; i++)
            {
                this.PersonCollection.Add(new Person() { Name = "Name" + i, Age = i.ToString() });
            }

            this.InitialItems = this.PersonCollection;

            this.DataBase = new PersonCollection();
            for (int i = 10; i < 100; i++)
            {
                this.DataBase.Add(new Person() { Name = "Name" + i, Age = i.ToString() });
            }

            this.ItemsSource = this.InitialItems;
        }
        
        private PersonCollection PersonCollection { get; set; }

        public override ObservableCollection<object> InitialItems { get; set; }

        public override object GetChild(int index)
        {
            return this.DataBase.Count > index ? this.DataBase[index] : null;
        }

        private PersonCollection DataBase
        {
            get;
            set;
        }

    }

    public class Person
    {
        public string Name { get; set; }

        public string Age { get; set; }
    }

    public class PersonCollection : ObservableCollection<object>
    {

    } 
}
