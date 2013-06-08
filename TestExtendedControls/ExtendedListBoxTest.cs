using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TestExtendedControls
{
    public class ExtendedListBoxTest
    {
        [Test]
        [RequiresSTA]
        public void CheckCount()
        {
            var extendedListBoxContol = new MockExtendedListBox();

            Assert.AreEqual(extendedListBoxContol.Items.Count, 2);

            extendedListBoxContol.GetChildren(2, 4);
            Assert.AreEqual(extendedListBoxContol.Items.Count, 6);

            extendedListBoxContol.GetChildren(3, 4);
            Assert.AreEqual(extendedListBoxContol.Items.Count, 7);

            extendedListBoxContol.GetChildren(6, 4);
            Assert.AreEqual(extendedListBoxContol.Items.Count, 10);
        }
    }

    
}
