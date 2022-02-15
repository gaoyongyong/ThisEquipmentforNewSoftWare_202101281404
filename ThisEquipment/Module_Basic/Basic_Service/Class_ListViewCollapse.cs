using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

class Class_ListViewCollapse
{
    public static void ADDAGroup(ListViewCollapse lvc1, string strHeader)
    {
        ListViewGroup listViewGroup = new ListViewGroup();
        listViewGroup.Header = strHeader;
        listViewGroup.HeaderAlignment = HorizontalAlignment.Left;
        lvc1.Groups.Add(listViewGroup);
        ListViewGroupState listViewGroupState = new ListViewGroupState();
        listViewGroupState = ListViewGroupState.Collapsible;
        lvc1.SetGroupState(listViewGroupState);
        lvc1.Refresh();

    }
    public static void AddItems(ListViewCollapse lvc1, int groupIndex, string itemText, int imageIndex)
    {
        ListViewItem MyItem = new ListViewItem();
        MyItem.Text = itemText;

        MyItem.ImageIndex = imageIndex;

        lvc1.Items.Insert(0, MyItem);

        lvc1.Groups[groupIndex].Items.Insert(0, MyItem);

        lvc1.Refresh();

    }

    public static void UpMove(ListViewCollapse MylistView) 
    {
        if (MylistView.SelectedItems.Count == 0)
        { return; }
        MylistView.BeginUpdate();
        if (MylistView.SelectedItems[0].Index > 0)
        {
            foreach (ListViewItem lvi in MylistView.SelectedItems)
            {
                ListViewItem lviSelectedItem = lvi;
                int indexSelectedoItem = lvi.Index;
                MylistView.Items.RemoveAt(indexSelectedoItem);
                MylistView.Items.Insert(indexSelectedoItem - 1, lviSelectedItem);

            }
        }
        MylistView.EndUpdate();
        if (MylistView.Items.Count > 0 && MylistView.SelectedItems.Count > 0)
        {
            MylistView.Focus();
            MylistView.SelectedItems[0].Focused = true;
            MylistView.SelectedItems[0].EnsureVisible();
        }
    }

}