using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class Class_DatagridView
{
    //listView条目上移
    public static void DatagridViewUpMove(DataGridView MyDataGridView)
    {
        //if (MyDataGridView.SelectedRows.Count == 0)
        //{ return; }
       
        //if (MyDataGridView.CurrentRow.Index > 0)
        //{
        //    foreach (DataGridViewRow DgvR in MyDataGridView.SelectedRows)
        //    {
        //        ListViewItem lviSelectedItem = lvi;
        //        int indexSelectedoItem = lvi.Index;
        //        MylistView.Items.RemoveAt(indexSelectedoItem);
        //        MylistView.Items.Insert(indexSelectedoItem - 1, lviSelectedItem);

        //    }
        //}
        //MylistView.EndUpdate();
        //if (MylistView.Items.Count > 0 && MylistView.SelectedItems.Count > 0)
        //{
        //    MylistView.Focus();
        //    MylistView.SelectedItems[0].Focused = true;
        //    MylistView.SelectedItems[0].EnsureVisible();
        //}
        //Class_ListView.Listview_Refresh_ID(MylistView);
    }
    //listView 条目下移
    public static void DatagridViewDownMove(DataGridView MyDataGridView)
    {
        //if (MylistView.SelectedItems.Count == 0)
        //{ return; }
        //MylistView.BeginUpdate();
        //int indexMaxSelectedItem = MylistView.SelectedItems[MylistView.SelectedItems.Count - 1].Index;
        //if (indexMaxSelectedItem < MylistView.Items.Count - 1)
        //{
        //    for (int i = MylistView.SelectedItems.Count - 1; i >= 0; i--)
        //    {
        //        ListViewItem lviSelectedItem = MylistView.SelectedItems[i];
        //        int indexSelectedItem = lviSelectedItem.Index;
        //        MylistView.Items.RemoveAt(indexSelectedItem);
        //        MylistView.Items.Insert(indexSelectedItem + 1, lviSelectedItem);
        //    }
        //}
        //MylistView.EndUpdate();
        //if (MylistView.Items.Count > 0 && MylistView.SelectedItems.Count > 0)
        //{
        //    MylistView.Focus();
        //    MylistView.SelectedItems[MylistView.SelectedItems.Count - 1].Focused = true;
        //    MylistView.SelectedItems[MylistView.SelectedItems.Count - 1].EnsureVisible();
        //}
        //Class_ListView.Listview_Refresh_ID(MylistView);
    }
    public static void DatagridViewRemove(DataGridView MyDataGridView)
    {
        //if (MylistView.SelectedItems.Count == 0)
        //{ return; }
        //MylistView.Items.Remove(MylistView.SelectedItems[0]);
        //Class_ListView.Listview_Refresh_ID(MylistView);
    }

    public static void DatagridViewAllRemove(DataGridView MyDataGridView)
    {
        MyDataGridView.Rows.Clear();
    }
}

