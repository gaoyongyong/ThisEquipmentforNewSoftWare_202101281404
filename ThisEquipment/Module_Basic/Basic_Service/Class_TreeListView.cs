using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

public class Class_TreeListView
{
    string path = @"此处添加路径";
    TreeListView treeListView1 = new TreeListView();
    public void LoadXmlTree(string xml)
    {
        XDocument xDoc = XDocument.Load(xml);

        TreeListViewItem item = new TreeListViewItem();
        string title = xDoc.Root.Attribute("Text")?.Value ?? xDoc.Root.Name.LocalName;
        item.ImageIndex = 0;
        item.Text = title;

        BuildTree(xDoc.Root, item.Items);
        treeListView1.Items.Add(item);
        treeListView1.ExpandAll();

    }
    public void BuildTree(XElement element, TreeListViewItemCollection items)
    {

        foreach (XElement node in element.Nodes())
        {
            TreeListViewItem item = new TreeListViewItem();
            string title = (string)node.Attribute("Text");
            item.Text = title;
            item.ImageIndex = 0;

            if (node.Name.LocalName.Trim() == "DDD")
            {
                item.Text = "DDD:  Size = " + node.Attribute("Size")?.Value;
                item.SubItems.Add(node.Attribute("Value")?.Value);

            }
            switch (title)
            {
                case "描述":
                    item.SubItems.Add(node.Attribute("Count")?.Value);
                    break;
                case "描述1":
                    item.SubItems.Add(node.Attribute("Size")?.Value);
                    break;
                case "描述2":
                    item.SubItems.Add(node.Attribute("Optional")?.Value);
                    break;
                case "描述3":
                    item.SubItems.Add(node.Attribute("Optional")?.Value);
                    break;
                case "描述4":
                    item.SubItems.Add(node.Attribute("Optional")?.Value);
                    break;
                default:
                    break;
            }

            item.SubItems.Add(node.Attribute("Value")?.Value);
            if (node.HasElements)
            {
                BuildTree(node, item.Items);
            }
            items.Add(item);
        }
    }

    //#region 移动节点
    //  /// <summary>
    //  /// 移动节点
    //  /// </summary>
    //  /// <param name="Index">目的地Index</param>
    //  public string XmlSavePath = @"D:\Program Files\ThisEquipment\PrjDatabase\Project\Xml";
    public void MoveTreeListView(int Index, TreeListView TreeListView1)
    {

        if (TreeListView1.SelectedItems.Count == 0)
        {
            return;
        }
        TreeListView1.BeginUpdate();
        if (TreeListView1.SelectedItems[0].Index > 0)
        {
            foreach (TreeListViewItem lvi in TreeListView1.SelectedItems)
            {
                TreeListViewItem lviSelectedItem = lvi;
                int indexSelectedItem = lvi.Index;
                TreeListView1.Items.RemoveAt(indexSelectedItem);

            }
        }
        TreeListView1.EndUpdate();
        if (TreeListView1.Items.Count > 0 && TreeListView1.SelectedItems.Count > 0)
        {
            TreeListView1.Focus();
            TreeListView1.SelectedItems[0].Focused = true;
            TreeListView1.SelectedItems[0].EnsureVisible();
        }
    }

}

