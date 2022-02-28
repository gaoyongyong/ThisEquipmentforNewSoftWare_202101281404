using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using System.Text;
using System.Xml.Linq;
using System.Drawing;
using Tools;


class Class_TreeView
{

    #region 移动节点
    /// <summary>
    /// 移动节点
    /// </summary>
    /// <param name="Index">目的地Index</param>
    public string XmlSavePath =Application.StartupPath + @"\Config";
    public void MoveNode(int Index, TreeView treeview)
    {
        TreeNode MoveNode = treeview.SelectedNode; //要移动的节点
        if (treeview.SelectedNode.FullPath == treeview.SelectedNode.Text)//判断是不是根节点
        {
            treeview.SelectedNode.Remove();
            treeview.Nodes.Insert(Index, MoveNode);
        }
        else
        {
            TreeNode ParentNode = MoveNode.Parent;  //父节点
            treeview.SelectedNode.Remove();
            ParentNode.Nodes.Insert(Index, MoveNode);
        }
        treeview.SelectedNode = MoveNode;
    }
    #endregion

    #region 生成XML
    //使用Linq方式实现生成XML
    public void SaveToXml(TreeView treeview)
    {
        XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");
        XDocument xml = new XDocument(dec);
        XElement root = new XElement("Tree");
        foreach (TreeNode node in treeview.Nodes)
        {
            XElement e = CreateElements(node);
            root.Add(e);
        }
        xml.Add(root);
        if (!File.Exists(XmlSavePath))
        {
            Directory.CreateDirectory(XmlSavePath);
        }
        xml.Save(XmlSavePath + @"\TreeXml.xml");
    }
    //递归
    private XElement CreateElements(TreeNode node)
    {
        XElement root = CreateAllElement(node);

        foreach (TreeNode n in node.Nodes)
        {
            XElement e = CreateElements(n);
            root.Add(e);
        }
        return root;
    }

    private XElement CreateElement(TreeNode node)
    {

        return new XElement("Node", new XAttribute("Text", node.Text), new XAttribute("Name", node.Name));
    }


    private XElement CreateAllElement(TreeNode node)
    {
        string XmlObj = "";
        if (node.Tag != null)
        {
            XmlObj = node.Tag.GetType().ToString() + "," + XmlObjConvert.SerializeObjecttoXml(node.Tag);

        }
        else
        {
        }

        return new XElement("Node", new XAttribute("Text", node.Text), new XAttribute("Name", node.Name),
        new XAttribute("TagXml", XmlObj));
    }
    #endregion

}

