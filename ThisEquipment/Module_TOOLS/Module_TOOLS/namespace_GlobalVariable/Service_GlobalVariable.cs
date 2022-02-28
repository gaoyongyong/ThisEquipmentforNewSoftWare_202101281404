using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tools
{
    class GlobalVariableServices
    {
        #region 1公用变量
        public static GlobelVariable GlobelVariables = null;
        #endregion

        #region 2私有变量
        private string Xml_Addr = "";// @"D:\Program Files\ThisEquipment\Database\SwParameter\GlobelVariable.xml";
       
        #endregion


        #region 3构造函数
        public GlobalVariableServices(string FilePath)
        {

            bool Result;
            Xml_Addr = FilePath + @"\GlobelVariable.xml";
            GlobelVariables = XmlObjConvert.DeserializeObjectFromPath<GlobelVariable>(Xml_Addr, out Result);
            
           
        }
        #endregion

        public void Save()
        {
            
            XmlObjConvert.SerializeObject(GlobelVariables, Xml_Addr);
        }


       
    }

    [Serializable]
    public class GlobelVariable
    {

        public List<Variable> L_variable = null;

        public GlobelVariable()
        {
            L_variable = new List<Variable>();
            
        }
        /// <summary>
        /// 根据名字找值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal object GetGlobalVariableValue(string name)
        {
            for (int i = 0; i < L_variable.Count; i++)
            {
                if (L_variable[i].name == name)
                    return L_variable[i].value;
            }
            return null;
        }

        /// <summary>
        /// 根据名字找变量
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal object GetGlobalVariable(string name)
        {
            for (int i = 0; i < L_variable.Count; i++)
            {
                if (L_variable[i].name == name)
                    return L_variable[i];
            }
            return null;
        }
        /// <summary>
        /// 设置变量的值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        internal bool SetGlobalVariableValue(string name, object value)
        {
            string variableType = L_variable.Find(e1 => e1.name == name).type;
            if (variableType == "int")
            {
                int int_Value = 0;
                if (int.TryParse((string)value, out int_Value))
                {
                    L_variable.Find(e1 => e1.name == name).value = int_Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (variableType == "double")
            {
                double double_Value = 0;
                if (double.TryParse((string)value, out double_Value))
                {
                    L_variable.Find(e1 => e1.name == name).value = double_Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (variableType == "bool")
            {
                bool bool_Value = false;
                if (bool.TryParse((string)value, out bool_Value))
                {
                    L_variable.Find(e1 => e1.name == name).value = bool_Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (variableType == "string")
            {
               
                 L_variable.Find(e1 => e1.name == name).value = value;
                return true;

            }
            return false;
        }
        /// <summary>
        /// 查询名称是否存在
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal string GetNewName(string type)
        {
            int i;
            for (i = 0; i < 1000; i++)
            {
                bool exist = false;
                for (int j = 0; j < L_variable.Count; j++)
                {
                    if (L_variable[j].name == type + i)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    return type + i;
                }
            }

            return "";
        }

        


    }
}
