using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class Form_Tool : Form
    {
        #region 1.公有变量
        /// <summary>
        /// 工具组变量
        /// </summary>
         public static List<ToolGroupModel> toolGroupModel = new List<ToolGroupModel>();


        #endregion
        #region 2.私有变量
        /// <summary>
        /// Xml地址
        /// </summary>
        private string Xml_Addr = "";


        /// <summary>
        /// 正在拖拽的节点
        /// </summary>
        internal static TreeNode DragNode = null;

        #endregion
        #region 3.构造函数
        public Form_Tool(string Addr)
        {
            InitializeComponent();
           
            //1.实例化Form服务
            //ToolService = new ToolServices();

            //2.初始化Form
            Init_Form();

            //3.加载Xml
            bool result = true;
            Xml_Addr = @"D:\Program Files\ThisEquipment\PrjDatabase\Project\" + Dialog_ProjectChoose.ProjectChoose.ProjectName + @"\ToolGroups.xml";
            toolGroupModel = XmlObjConvert.DeserializeObjectFromPath<List<ToolGroupModel>>(Xml_Addr, out result);

            //4.Model实例化Form
            ModelToForm(listViewCollapseTool);

            //5.实例化FORM,OBJECT
            ModelToObject();

        }
        #endregion
        #region 4.私有方法

        private void Init_Form() 
        {
            //允许托拽
            listViewCollapseTool.MultiSelect = false;      //禁止ListView选择多项
            listViewCollapseTool.AllowDrop = true;
            listViewCollapseTool.ItemDrag += new ItemDragEventHandler(lvc1_ItemDrag);
            listViewCollapseTool.DragEnter += new DragEventHandler(lvc1_DragEnter);
            listViewCollapseTool.DragDrop += new DragEventHandler(lvc1_DragDrop);
        }
        /// <summary>
        /// 当拖动某项时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvc1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem node = e.Item as ListViewItem;
            DragNode = new TreeNode();
            DragNode.Tag = node.Tag;
            listViewCollapseTool.DoDragDrop(node, DragDropEffects.Move);
        }
        /// <summary>
        /// 当拖动结束时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvc1_DragDrop(object sender, DragEventArgs e)
        {
            DragNode = null;
        }

        /// <summary>
        /// 鼠标拖动某项至该控件的区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvc1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        /// <summary>
        /// 根据Model实例化Form
        /// </summary>
        /// <param name="lvc1"></param>
        /// <param name="toolGroupModel"></param>
        private void ModelToForm(ListViewCollapse lvc1)
        {
            //1.加入工具组
            int groupCount = toolGroupModel.Count();
            for (int i = 0; i < groupCount; i++)
            {
                ListViewGroup listViewGroup = new ListViewGroup();
                listViewGroup.Header = toolGroupModel[i].GroupName;
                listViewGroup.HeaderAlignment = HorizontalAlignment.Left;
                lvc1.Groups.Add(listViewGroup);
            }
            ListViewGroupState listViewGroupState = new ListViewGroupState();
            listViewGroupState = ListViewGroupState.Collapsible;
            lvc1.SetGroupState(listViewGroupState);
            lvc1.Refresh();
 
            //2.加入工具组方法
            for (int i = 0; i < groupCount; i++)
            {
                int groupToolsCount = toolGroupModel[i].tools.Count();
                for (int j = 0; j < groupToolsCount; j++)
                {
                    ListViewItem MyItem = new ListViewItem();
                    MyItem.Text = toolGroupModel[i].tools[j].toolName;
                    MyItem.ImageIndex = toolGroupModel[i].tools[j].toolID;
                    MyItem.Tag = toolGroupModel[i].tools[j];
                    lvc1.Items.Insert(0, MyItem);                    
                    lvc1.Groups[i].Items.Insert(0, MyItem);
                    
                }
            }
            lvc1.Refresh();
        }
        /// <summary>
        /// Model生成Object
        /// </summary>
        private void ModelToObject()
        {
            try
            {
                for (int i = 0; i < toolGroupModel.Count; i++)
                {
                    if (toolGroupModel[i].Model != null)
                    {
                        toolGroupModel[i].GroupFormObject = Activator.CreateInstance(Type.GetType(toolGroupModel[i].GroupFormName), toolGroupModel[i].Model);
                    }
                    else 
                    {
                        toolGroupModel[i].GroupFormObject = Activator.CreateInstance(Type.GetType(toolGroupModel[i].GroupFormName));
                    }
                    
                    
                    String Class_Name = toolGroupModel[i].GroupClassName;
                   


                    toolGroupModel[i].GroupClassObject = toolGroupModel[i].GroupFormObject?.GetType().GetField(Class_Name)?.GetValue(toolGroupModel[i].GroupFormObject);
                }
            }
            catch (Exception ex)
            {

                Basic_UI.Log.SaveError(ex);
            }
            
            
        }
        #endregion
        #region 5.公有方法
        public bool SaveGroupModel()
        {
            try
            {
                for (int i = 0; i < toolGroupModel.Count; i++)
                {
                    if (toolGroupModel[i].GroupModelName != null)
                    {
                        toolGroupModel[i].Model = toolGroupModel[i].GroupClassObject?.GetType().GetField(toolGroupModel[i].GroupModelName)?.GetValue(toolGroupModel[i].GroupClassObject);
                    }
                   
                }
                return(XmlObjConvert.SerializeObject(toolGroupModel, Xml_Addr));
            }
            catch
            {
                return false;
                
            }
            



        }
        #endregion

    }
}
