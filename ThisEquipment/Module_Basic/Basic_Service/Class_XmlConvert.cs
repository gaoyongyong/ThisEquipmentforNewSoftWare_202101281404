using Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


public class XmlObjConvert
{

    //序列化对象成xml字符串
    public static bool SerializeObject(object myObj, string Paths)
    {
        try
        {
            var xmlStr = string.Empty;
            if (myObj != null)
            {
                XmlSerializer xs = new XmlSerializer(myObj.GetType());

                using (var stringWriter = new StringWriter())
                {
                    xs.Serialize(stringWriter, myObj);
                    xmlStr = stringWriter + "";
                }
            }
            //将xml写入文件
            
            if (!Directory.Exists(Path.GetDirectoryName(Paths)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Paths));
            }
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();//新建对象

            doc.LoadXml(xmlStr);//符合xml格式的字符串

            doc.Save(Paths);
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }



    }

    //序列化对象成xml字符串
    public static string SerializeObjecttoXml(object myObj)
    {
        try
        {
            var xmlStr = string.Empty;
            if (myObj != null)
            {
                XmlSerializer xs = new XmlSerializer(myObj.GetType());

                using (var stringWriter = new StringWriter())
                {
                    xs.Serialize(stringWriter, myObj);
                    xmlStr = stringWriter + "";
                }
            }
            ////将xml写入文件
            //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();//新建对象

            //doc.LoadXml(xmlStr);//符合xml格式的字符串

            //doc.Save(@"d:\1.xml");
            return xmlStr;
        }
        catch (Exception ex)
        {
            //Frm_Output.Instance.OutputMsg(ex.ToString(), Color.Red);
            return "";
        }



    }


    //xml反序列化成对象
    public static T DeserializeObject<T>(string xml, out bool Result) where T : new()
    {
        try
        {
            T t = default(T);
            if (!string.IsNullOrEmpty(xml))
            {
                t = new T();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                StringReader reader = new StringReader(xml);//将xml字符串转换成stream
                t = (T)xs.Deserialize(reader);
                reader.Close();
            }
            Result = true;
            return t;

        }
        catch (Exception ex)
        {
            Result = false;
            return new T();
        }

    }

    //xml反序列化成对象
    public static T DeserializeObjectFromPath<T>(string xmlPath, out bool Result) where T : new()
    {
        try
        {
            T t = default(T);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlPath);
            if (!string.IsNullOrEmpty(xmldoc.ToString()))
            {
                t = new T();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                StringReader reader = new StringReader(xmldoc.InnerXml);//将xml字符串转换成stream
                t = (T)xs.Deserialize(reader);
                reader.Close();
            }
            Result = true;
            return t;
        }
        catch (Exception ex)
        {
            Result = false;
            return new T();
        }

    }



}


