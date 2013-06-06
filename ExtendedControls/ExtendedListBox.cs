using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ExtendedControls
{
    public abstract class ExtendedListBox : ListBox
    {
        protected ExtendedListBox()
        {
            this.Loaded += (ExtendedListBoxLoaded);
        }

        public abstract ObservableCollection<string> InitialItems
        {
            get;
            set;
        }

        public abstract string GetChild(int index);

        #region Private Helpers
        
        /// <summary>
        /// Courtesy: http://social.msdn.microsoft.com/forums/en-US/wpf/thread/2d527831-43aa-4fd5-8b7b-08cb5c4ed1db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtendedListBoxLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var scrollViewer = this.GetVisualChild<ScrollViewer>();
            if (scrollViewer != null)
            {
                var scrollBar = scrollViewer.Template.FindName("PART_VerticalScrollBar", scrollViewer) as ScrollBar;
                if (scrollBar != null)
                {
                    scrollBar.ValueChanged += delegate
                    {
                        var count =  (int) scrollViewer.ViewportHeight;
                        var startIndex = (int) scrollViewer.VerticalOffset + count;
                        GetChildren(startIndex, count);
                    };
                }
            }
        }

        private void GetChildren(int startIndex, int count)
        {
            int finalIndex = startIndex + count;
            if (this.Items.Count > finalIndex)
            {
                return;
            }

            var currentItemsCount= startIndex;
            if (this.Items.Count < finalIndex && this.Items.Count > startIndex)
            {
                currentItemsCount = this.Items.Count;
            }

            var dumyList = new List<string>();
            for (int currentIndex = currentItemsCount; currentIndex < finalIndex; currentIndex++)
            {
                var child = GetChild(currentIndex);
                if (child != null)
                    dumyList.Add(child);
            }

            var itemSource = this.InitialItems;
            foreach (var listItem in dumyList)
            {
                itemSource.Add(listItem);
            }

            this.ItemsSource = itemSource;
        }

        #endregion

    }


}
