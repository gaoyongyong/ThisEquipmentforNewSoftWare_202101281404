//using PropertyGridEx;
//using SkinSharpBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserCoord
{
    #region 数据类型
    /// <summary>
    /// CheckAxis资源包用到的数据类型
    /// </summary>
    /// 

    public class basemod_UserCoord
    {
        #region 定义功能块需要的变量
        /// <summary>
        /// 用户坐标系
        /// </summary>
        [TypeConverter(typeof(CollectionConverter))]//指定编辑器特性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//设定序列化特性
        [Category("用户坐标系"), Description("点位集")]
        public List<Coord_Point> UserCoord_List { get; set; } = new List<Coord_Point>();

        /// <summary>
        /// 用户坐标系基准
        /// </summary>
        [TypeConverter(typeof(System.ComponentModel.CollectionConverter))]//指定编辑器特性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//设定序列化特性
        [Category("用户坐标系基准"), Description("点位集")]
        public List<Coord_Point> BasicCoord_List { get; set; } = new List<Coord_Point>();


        /// <summary>
        /// 机械坐标系
        /// </summary>
        [TypeConverter(typeof(CollectionConverter))]//指定编辑器特性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//设定序列化特性
        [Category("机械坐标系"), Description("点位集")]
        public List<Coord_Point> MachineCoord_List { get; set; } = new List<Coord_Point>();


        /// <summary>
        /// 机械坐标系基准
        /// </summary>
        [TypeConverter(typeof(CollectionConverter))]//指定编辑器特性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//设定序列化特性
        [Category("机械坐标系基准"), Description("点位集")]
        public List<Coord_Point> BasicCoord_CS_List { get; set; } = new List<Coord_Point>();




        /// <summary>
        /// 坐标系单点
        /// </summary>
        //[TypeConverter(typeof(TypeConverterGeneral<Coord_Point>))]//指定编辑器特性
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//设定序列化特性
        [Category("机械坐标系单点基准"), Description("点位")]
        public Coord_Point BasicCoord_CS { get; set; } = new Coord_Point();

        /// <summary>
        /// 用户坐标系单点
        /// </summary>
        /// 

        //[TypeConverter(typeof(TypeConverterGeneral<Coord_Point>))]//指定编辑器特性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//设定序列化特性
        [Category("用户坐标系单点基准"), Description("点位")]
        public Coord_Point UserCoord { get; set; } = new Coord_Point();


        /// <summary>
        /// 文件存储地址
        /// </summary>

        [Category("文件存储地址")]
        public string PathFile_CoordExchange { get; set; }


        /// <summary>
        /// 文件存储地址
        /// </summary>

        [Category("文件存储地址")]
        public string PathFile_BasicCoord { get; set; } = Application.StartupPath + @"\Config\BasicCoord.csv";





        #endregion
    }

    [Serializable]
    /// <summary>
    ///点位组
    /// </summary>
    public class Coord_Point
    {
        /// <summary>
        /// ID
        /// </summary>

        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double ID { get; set; }

        /// <summary>
        /// X轴点位
        /// </summary>

        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double X_Position { get; set; }


        /// <summary>
        /// Y轴点位
        /// </summary>

        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double Y_Position { get; set; }

        /// <summary>
        /// Z轴点位
        /// </summary>
        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double Z_Position { get; set; }

        /// <summary>
        /// R轴点位
        /// </summary>
        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double R_Position { get; set; }

        /// <summary>
        /// X轴速度
        /// </summary>
        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double X_Speed { get; set; }

        /// <summary>
        /// Y轴速度
        /// </summary>
        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double Y_Speed { get; set; }

        /// <summary>
        /// Z轴速度
        /// </summary>
        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double Z_Speed { get; set; }

        /// <summary>
        /// R轴速度
        /// </summary>
        [CategoryAttribute("点位设置"), DefaultValueAttribute(1)]
        public double R_Speed { get; set; }

        

    }


} 
    #endregion

