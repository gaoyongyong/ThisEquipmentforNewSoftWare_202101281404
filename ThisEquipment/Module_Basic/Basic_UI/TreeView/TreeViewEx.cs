using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThisEquipment.Properties;

namespace Tools
{
    public partial class TreeViewEx : TreeView
    {
        //Color backColor = Color.FromArgb(227, 251, 244);
        //Font foreFont = new Font("微软雅黑", 9F, FontStyle.Bold);

        //Brush foreBrush = new SolidBrush(Color.FromArgb(81, 81, 81));
        //Brush recBrush = new SolidBrush(Color.FromArgb(82, 218, 163));
        //Brush recSelectedBrush = new SolidBrush(Color.FromArgb(248, 248, 255));

        //Pen recPen = new Pen(new SolidBrush(Color.FromArgb(226, 226, 226)));
        //Pen recHoverPen = new Pen(new SolidBrush(Color.FromArgb(82, 218, 163)));
        //Pen linePen = new Pen(Color.FromArgb(226, 226, 226), 1);

        //Image icon;

        public TreeViewEx()
        {
            InitializeComponent();

            //this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            //this.ItemHeight = 30;//节点行高          
            //this.BackColor = backColor;
            //this.ShowLines = true;
            //this.HotTracking = true;
            //this.Indent = 20;//节点X值缩进量
            //this.Scrollable = true;
            //this.BorderStyle = BorderStyle.None;
            //this.Font = foreFont;
        }

        //protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        //{
        //    if (e.Node.Level == 0)//根节点
        //    {
        //        if (!e.Node.IsExpanded)//根节点未展开
        //        {
        //            //icon = Resources.list_plus;
        //        }
        //        else//根节点展开
        //        {
        //            //icon = Resources.list_zhankai;
        //        }
        //        //刷新背景色防止字体图标重绘叠加
        //        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(227, 251, 244)), e.Bounds);
        //        //重绘图标，一级节点X值默认为23，padding-left为6,17 = 23 - 6
        //        e.Graphics.DrawImage(icon, e.Node.Bounds.X - 17, e.Node.Bounds.Y + 5);
        //        //重绘字体
        //        e.Graphics.DrawString(e.Node.Text, foreFont, foreBrush, e.Node.Bounds.Left + 16, e.Node.Bounds.Top + 4);
        //    }
        //    else
        //    {
        //        if (!e.Bounds.IsEmpty)//如果子节点的Bounds属性不为空(Empty），绘制该节点
        //        {
        //            e.Graphics.FillRectangle(Brushes.White, e.Bounds);

        //            //绘制连接线,30 = 20 + 10,10为图标宽的一半，保证topEnd点在图标中心，15为行高一半
        //            Point start = new Point(e.Node.Bounds.X + 15, e.Node.Bounds.Y + 15);
        //            Point middle = new Point(e.Node.Bounds.X - 30, e.Node.Bounds.Y + 15);
        //            Point topEnd = new Point(e.Node.Bounds.X - 30, e.Node.Bounds.Y);
        //            Point bottomEnd = new Point(e.Node.Bounds.X - 30, e.Node.Bounds.Y + 30);
        //            e.Graphics.DrawLine(linePen, start, middle);
        //            e.Graphics.DrawLine(linePen, middle, topEnd);
        //            if (null != e.Node.NextNode)
        //            {
        //                e.Graphics.DrawLine(linePen, middle, bottomEnd);
        //            }

        //            //绘制文本框，宽145px可容纳十个10.5pt的字，55 = 23 + 20 + 12，文本框距离上下边界4px
        //            Rectangle box = new Rectangle(e.Bounds.Left + 55, e.Bounds.Top + 4, this.Width - 55 - 25, e.Bounds.Height - 8);

        //            if (e.Node.IsSelected)//二级节点被选中
        //            {
        //                e.Graphics.FillRectangle(recBrush, box);
        //                e.Graphics.DrawString(e.Node.Text, foreFont, recSelectedBrush, e.Node.Bounds.Left + 12, e.Node.Bounds.Top + 4);
        //            }
        //            else
        //            {
        //                if ((e.State & TreeNodeStates.Hot) != 0)//鼠标指针在二级节点上
        //                {
        //                    e.Graphics.DrawRectangle(recHoverPen, box);
        //                }
        //                else
        //                {
        //                    e.Graphics.DrawRectangle(recPen, box);
        //                }
        //                e.Graphics.DrawString(e.Node.Text, foreFont, foreBrush, e.Node.Bounds.Left + 12, e.Node.Bounds.Top + 4);
        //            }
        //        }
        //    }

        //}

        //protected override void OnMouseClick(MouseEventArgs e)
        //{
        //    base.OnMouseClick(e);
        //    TreeNode tn = this.GetNodeAt(e.Location);
        //    if (0 != tn.Level)//点击一级节点不使二级节点的选中效果消失
        //    {
        //        this.SelectedNode = tn;
        //    }

        //    //图标中心点向右的区域也能单击折叠与展开
        //    Rectangle bounds = new Rectangle(tn.Bounds.Left - 17, tn.Bounds.Y, tn.Bounds.Width - 16, tn.Bounds.Height);
        //    if (tn != null && bounds.Contains(e.Location) == false)
        //    {
        //        if (tn.IsExpanded == false)
        //            tn.Expand();
        //        else
        //            tn.Collapse();
        //    }
        //}

        //TreeNode currentNode = null;
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    TreeNode tn = this.GetNodeAt(e.Location);
        //    Graphics g = this.CreateGraphics();
        //    if (currentNode != tn)
        //    {
        //        //绘制当前节点的hover背景
        //        if (null != tn)
        //        {
        //            OnDrawNode(new DrawTreeNodeEventArgs(g, tn, new Rectangle(0, tn.Bounds.Y, this.Width - 4, tn.Bounds.Height), TreeNodeStates.Hot));
        //        }

        //        //取消之前hover的节点背景
        //        if (null != currentNode)
        //        {
        //            OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width - 4, currentNode.Bounds.Height), TreeNodeStates.Default));
        //        }
        //    }
        //    currentNode = tn;
        //    g.Dispose();//释放Graphics资源
        //}

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    //移出控件时取消Hover背景
        //    if (currentNode != null)
        //    {
        //        Graphics g = this.CreateGraphics();
        //        OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width - 4, currentNode.Bounds.Height), TreeNodeStates.Default));

        //        currentNode = null;//同一个节点Leave后Move有Hover效果            
        //    }
        //}



        //protected override void OnMouseDoubleClick(MouseEventArgs e)
        //{
        //    base.OnMouseDoubleClick(e);
        //    TreeNode tn = this.GetNodeAt(e.Location);
        //    //图标中心点向右的区域双击折叠与展开
        //    Rectangle bounds = new Rectangle(tn.Bounds.Left - 17, tn.Bounds.Y, tn.Bounds.Width - 16, tn.Bounds.Height);
        //    if (tn != null && bounds.Contains(e.Location) == false)
        //    {
        //        if (tn.IsExpanded == false)
        //            tn.Expand();
        //        else
        //            tn.Collapse();
        //    }
        //}

    }
}
