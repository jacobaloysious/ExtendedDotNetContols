using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ExtendedControls
{
    public abstract class ExtendedDataGrid : DataGrid 
    {
        protected ExtendedDataGrid()
        {
            this.Loaded += new System.Windows.RoutedEventHandler(ExtendedDataGrid_Loaded);
        }
        
        #region Public Methods

        public abstract ObservableCollection<object> InitialItems
        {
            get;
            set;
        }

        public abstract object GetChild(int index);

        #endregion

        private void ExtendedDataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.ScrollBar != null)
            {
                this.ScrollBar.ValueChanged += delegate { LoadChildren(); };
            }
        }

        private void LoadChildren()
        {
            if (this.ScrollBar != null)
            {
                var count = (int)this.ScrollViewer.ViewportHeight;
                var startIndex = (int)this.ScrollViewer.VerticalOffset + count;
                GetChildren(startIndex, count);
            }
        }

        public void GetChildren(int startIndex, int count)
        {
            int finalIndex = startIndex + count;
            if (this.Items.Count > finalIndex)
            {
                return;
            }

            var currentItemsCount = this.Items.Count > startIndex ? this.Items.Count : startIndex;

            var dumyList = new List<object>();
            for (int currentIndex = currentItemsCount; currentIndex < finalIndex; currentIndex++)
            {
                var child = GetChild(currentIndex);
                if (child != null)
                    dumyList.Add(child);
            }

            foreach (var listItem in dumyList)
            {
                this.InitialItems.Add(listItem);
            }

            //Reset the item source
            this.ItemsSource = this.InitialItems;
        }


        #region Private Members

        private bool IsScrollVisible
        {
            get
            {
                var scrollViewer = this.ScrollViewer;
                if (scrollViewer != null)
                {
                    var visibility = scrollViewer.ComputedVerticalScrollBarVisibility;
                    if (visibility.ToString() == "Visible")
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private ScrollViewer ScrollViewer
        {
            get { return this.GetVisualChild<ScrollViewer>(); }
        }

        private ScrollBar ScrollBar
        {
            get
            {
                var scrollViewer = this.ScrollViewer;
                if (scrollViewer != null)
                {
                    return scrollViewer.Template.FindName("PART_VerticalScrollBar", scrollViewer) as ScrollBar;
                }
                return null;
            }
        }

        #endregion
    }
}
