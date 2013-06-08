using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ExtendedControls
{
    public abstract class ExtendedListBox : ListBox
    {
        protected ExtendedListBox()
        {
            this.Loaded += (ExtendedListBoxLoaded);
            this.LayoutUpdated += (EventLayoutUpdated); 
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

        #region Public Methods
        
        public abstract ObservableCollection<object> InitialItems
        {
            get;
            set;
        }
       
        public abstract object GetChild(int index);

        #endregion

        #region Private Helpers

        private void EventLayoutUpdated(object sender, EventArgs e)
        {
            // Keep adding Children until Scroll Is Visible
            if (!this.IsScrollVisible)
            {
               LoadChildren();
            }
        }

        /// <summary>
        /// Courtesy: http://social.msdn.microsoft.com/forums/en-US/wpf/thread/2d527831-43aa-4fd5-8b7b-08cb5c4ed1db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtendedListBoxLoaded(object sender, System.Windows.RoutedEventArgs e)
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
                var count = (int) this.ScrollViewer.ViewportHeight;
                var startIndex = (int) this.ScrollViewer.VerticalOffset + count;
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

        #endregion
    }
}
