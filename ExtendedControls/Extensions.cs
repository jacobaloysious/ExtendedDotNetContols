using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ExtendedControls
{
    public static class Extensions
    {
        /// <summary>
        /// Courtesy: http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/8543eaa7-bd43-41ad-aee8-874d9b30799c
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="referenceVisual"></param>
        /// <returns></returns>
        public static T GetVisualChild<T>(this Visual referenceVisual) where T : Visual
        {
            Visual child = null;
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(referenceVisual); i++)
            {
                child = VisualTreeHelper.GetChild(referenceVisual, i) as Visual;
                if (child != null && child is T)
                {
                    break;
                }
                else if (child != null)
                {
                    child = GetVisualChild<T>(child);
                    if (child != null && child is T)
                    {
                        break;
                    }
                }
            }
            return child as T;
        }
    } 

}
