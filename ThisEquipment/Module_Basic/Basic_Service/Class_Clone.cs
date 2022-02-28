using Inovance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


public static class ObjectCopier
{

    public static ToolInfo Clone<ToolInfo>(ToolInfo source)
    {
        if (!typeof(ToolInfo).IsSerializable)
        {
            throw new ArgumentException("The type must be serializable.", "source");
        }

        if (Object.ReferenceEquals(source, null))
        {
            return default(ToolInfo);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        using (stream)
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (ToolInfo)formatter.Deserialize(stream);
        }
    }

    //Model_Inovance克隆
    public static Model_Inovance CloneModelInovance<Model_Inovance>(Model_Inovance source)
    {
        if (!typeof(Model_Inovance).IsSerializable)
        {
            throw new ArgumentException("The type must be serializable.", "source");
        }

        if (Object.ReferenceEquals(source, null))
        {
            return default(Model_Inovance);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        using (stream)
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (Model_Inovance)formatter.Deserialize(stream);
        }
    }



}

