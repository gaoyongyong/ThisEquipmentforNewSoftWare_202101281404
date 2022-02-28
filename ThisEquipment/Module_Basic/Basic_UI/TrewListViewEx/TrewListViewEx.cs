using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class TreeListViewEx : TreeListView
    {
        public TreeListViewEx()
        {
            InitializeComponent();
        }

        public TreeListViewEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            if (e.ItemIndex % 2 == 0)
            {
                e.Item.BackColor = Color.White;
            }
            else
            {
                e.Item.BackColor = Color.WhiteSmoke;
            }
            base.OnDrawItem(e);
        }
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (e.ItemIndex % 2 == 0)
            {
                e.SubItem.BackColor = Color.White;
            }
            else
            {
                e.SubItem.BackColor = Color.WhiteSmoke;
            }
            base.OnDrawSubItem(e);
        }
    }
}
