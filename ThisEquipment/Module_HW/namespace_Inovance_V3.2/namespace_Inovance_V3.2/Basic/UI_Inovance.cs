using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovance
{
    public class UI_Inovance: DataGridView
    {
        


        /// <summary>
        /// 弹出窗口
        /// </summary>
        private ContextMenuStrip contextMenuStrip_mouse;

        public UI_Inovance() 
        {
           

            ScrollBars = ScrollBars.Both;
            //列自动填充
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //允许编辑
            Enabled = true;
            //编辑模式为输入后编辑
            EditMode = DataGridViewEditMode.EditOnEnter;
            //定义弹出框
            contextMenuStrip_mouse = new ContextMenuStrip();
            //去除DataGridView自带的一行
            //AllowUserToAddRows = false;
            //// 行头隐藏
            //RowHeadersVisible = false;
            //拷贝时不拷贝头
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

        }

       
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (SelectedRows.Count < 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                //////清除右键选项框
                contextMenuStrip_mouse.Items.Clear();
                contextMenuStrip_mouse.Items.Add("复制");
                contextMenuStrip_mouse.Items.Add("粘贴");
                contextMenuStrip_mouse.Items.Add("插入行");
                contextMenuStrip_mouse.Items.Add("删除行");
               
                contextMenuStrip_mouse.Items[0].Click += new System.EventHandler(复制ToolStripMenuItem_Click);
                contextMenuStrip_mouse.Items[1].Click += new System.EventHandler(粘贴ToolStripMenuItem_Click);
                contextMenuStrip_mouse.Items[2].Click += new System.EventHandler(插入行ToolStripMenuItem_Click);
                contextMenuStrip_mouse.Items[3].Click += new System.EventHandler(删除行ToolStripMenuItem_Click);
               

                contextMenuStrip_mouse.Show(this,e.Location);
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           CopyData();

        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteData();

        }
        private void 插入行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Rows.Add();

        }
        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteData();

        }

        private void PasteData()
        {
            int index;
            try
            {
                string clipboardText = Clipboard.GetText(); //获取剪贴板中的内容
                if (string.IsNullOrEmpty(clipboardText))
                {
                    return;
                }
                int colnum = 0;
                int rownum = 0;
                for (int i = 0; i < clipboardText.Length; i++)
                {
                    if (clipboardText.Substring(i, 1) == "\t")
                    {
                        colnum++;
                    }
                    if (clipboardText.Substring(i, 1) == "\n")
                    {
                        rownum++;
                    }
                }
                //粘贴板上的数据来源于EXCEL时，每行末尾都有\n，来源于DataGridView是，最后一行末尾没有\n
                if (clipboardText.Substring(clipboardText.Length - 1, 1) == "\n")
                {
                    rownum--;
                }
                colnum = colnum / (rownum + 1);
                object[,] data; //定义object类型的二维数组
                data = new object[rownum + 1, colnum + 1];  //根据剪贴板的行列数实例化数组
                string rowStr = "";
                //对数组各元素赋值
                for (int i = 0; i <= rownum; i++)
                {

                    for (int j = 0; j <= colnum; j++)
                    {
                        //一行中的其它列
                        if (j != colnum)
                        {
                            rowStr = clipboardText.Substring(0, clipboardText.IndexOf("\t"));
                            clipboardText = clipboardText.Substring(clipboardText.IndexOf("\t") + 1);
                        }
                        //一行中的最后一列
                        if (j == colnum && clipboardText.IndexOf("\r") != -1)
                        {
                            rowStr = clipboardText.Substring(0, clipboardText.IndexOf("\r"));
                        }
                        //最后一行的最后一列
                        if (j == colnum && clipboardText.IndexOf("\r") == -1)
                        {
                            rowStr = clipboardText.Substring(0);
                        }
                        data[i, j] = rowStr;
                    }
                    //截取下一行及以后的数据
                    clipboardText = clipboardText.Substring(clipboardText.IndexOf("\n") + 1);
                }
                //获取当前选中单元格的列序号
                int colIndex = this.CurrentRow.Cells.IndexOf(this.CurrentCell);
                //获取当前选中单元格的行序号
                int rowIndex = this.CurrentRow.Index;
                if ((rownum + rowIndex) >= (this.Rows.Count - 1))
                {
                    int Add_Row = (rownum + rowIndex - this.Rows.Count + 2);
                    //添加新行
                    for (int i = 0; i < Add_Row; i++)
                    {
                        this.Rows.Add();
                    }

                }
                for (int i = 0; i <= rownum; i++)
                {

                    for (int j = 0; j <= colnum; j++)
                    {
                        Type CellType = this.Rows[i + rowIndex].Cells[j].GetType();
                        switch (CellType.Name)
                        {
                            case "DataGridViewComboBoxCell":
                                if (((DataGridViewComboBoxCell)this.Rows[i + rowIndex].Cells[j]).Items.Contains(data[i, j]))
                                {
                                    ((DataGridViewComboBoxCell)this.Rows[i + rowIndex].Cells[j]).Value = data[i, j];
                                }                               
                                break;
                            case "DataGridViewTextBoxCell":
                                this.Rows[i + rowIndex].Cells[j].Value = data[i, j];
                                break;

                            case "DataGridViewCheckBoxCell":
                                bool Result;
                                if (bool.TryParse((string)data[i, j], out Result))
                                {
                                    ((DataGridViewCheckBoxCell)this.Rows[i + rowIndex].Cells[j]).Value = Result;
                                }
                                
                                
                                break;
                            default:
                                break;
                        };
                       
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("粘贴区域大小不一致");
                return;
            }
        }

        private void DeleteData()
        {
            //如果全部删除，则先添加一行再删除
            if (SelectedRows.Count == Rows.Count)
            {
                DataGridViewRow row = new DataGridViewRow();                
                Rows.Add(row);

                for (int i = Rows.Count-1; i > 0; i--)
                {
                    Rows.RemoveAt(i-1);
                }
                
               
            }
            else
            {
                for (int i = SelectedRows.Count; i > 0; i--)
                {
                    Rows.RemoveAt(SelectedRows[i - 1].Index);
                }
            }
        }

        private void CopyData()
        {
            try
            {
                Clipboard.SetDataObject(GetClipboardContent());
            }
            catch 
            {
            }
            
            
        }



    }
}
