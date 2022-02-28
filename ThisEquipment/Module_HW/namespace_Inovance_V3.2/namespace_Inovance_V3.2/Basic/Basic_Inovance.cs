using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Inovance
{
    public class Basic_Inovance
    {
        public static string InvancePLCip = "192.168.1.88";

        public enum SoftElemType
        {
            //AM600
            ELEM_QX = 0,            //QX元件
            ELEM_MW = 1,            //MW元件
            ELEM_X = 2,		        //X元件(对应QX200~QX300)
            ELEM_Y = 3,		        //Y元件(对应QX300~QX400)

            //H3U
            REGI_H3U_Y = 0x20,      //Y元件的定义	
            REGI_H3U_X = 0x21,		//X元件的定义							
            REGI_H3U_S = 0x22,		//S元件的定义				
            REGI_H3U_M = 0x23,		//M元件的定义							
            REGI_H3U_TB = 0x24,		//T位元件的定义				
            REGI_H3U_TW = 0x25,		//T字元件的定义				
            REGI_H3U_CB = 0x26,		//C位元件的定义				
            REGI_H3U_CW = 0x27,		//C字元件的定义				
            REGI_H3U_DW = 0x28,		//D字元件的定义				
            REGI_H3U_CW2 = 0x29,    //C双字元件的定义
            REGI_H3U_SM = 0x2a,		//SM
            REGI_H3U_SD = 0x2b,		//
            REGI_H3U_R = 0x2c		//18576659938

        }

        #region //标准库
        [DllImport("StandardModbusApi.dll", EntryPoint = "Init_ETH_String", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Init_ETH_String(string sIpAddr, int nNetId = 0, int IpPort = 502);

        [DllImport("StandardModbusApi.dll", EntryPoint = "Exit_ETH", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Exit_ETH(int nNetId = 0);

        /******************************************************************************
         1.功能描述 :设置超时时间，            
         2.返 回 值 :TRUE 成功  FALSE 失败
         3.参    数 : nNetId:网络链接编号,与Init_ETH（）调用的ID一样
         4.注意事项 : 在建立连接前调用，如果建立连接前没有调用，默认超时时间为500ms
        ******************************************************************************/
        [DllImport("StandardModbusApi.dll", EntryPoint = "Set_ETH_TimeOut", CallingConvention = CallingConvention.Cdecl)]
        //STANDARD_MODBUS_FUNC_EXPORT 
        public static extern bool Set_ETH_TimeOut(int nTime, int nNetId = 0);

        // [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int H3u_Write_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        //  [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        //  public static extern int H3u_Read_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);

        //  [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem_Float", CallingConvention = CallingConvention.Cdecl)]
        //  public static extern int H3u_Read_Soft_Elem_Float(SoftElemType eType, int nStartAddr, int nCount, float[] pValue, int nNetId = 0);

        /******************************************************************************
         1.功能描述 : 写H3u软元件
         2.返 回 值 :1 成功  0 失败
         3.参    数 : nNetId:网络链接编号
                      eType：软元件类型  
                          REGI_H3U_Y    = 0x20,     //Y元件的定义	
                          REGI_H3U_X    = 0x21,		//X元件的定义							
                          REGI_H3U_S    = 0x22,		//S元件的定义				
                          REGI_H3U_M    = 0x23,		//M元件的定义							
                          REGI_H3U_TB   = 0x24,		//T位元件的定义				
                          REGI_H3U_TW   = 0x25,		//T字元件的定义				
                          REGI_H3U_CB   = 0x26,		//C位元件的定义				
                          REGI_H3U_CW   = 0x27,		//C字元件的定义				
                          REGI_H3U_DW   = 0x28,		//D字元件的定义				
                          REGI_H3U_CW2  = 0x29,	    //C双字元件的定义
                          REGI_H3U_SM   = 0x2a,		//SM
                          REGI_H3U_SD   = 0x2b,		//SD
                          REGI_H3U_R    = 0x2c		//SD
                      nStartAddr:软元件起始地址
                      nCount：软元件个数
                      pValue：数据缓存区
         4.注意事项 : 1.x和y元件地址需为8进制; 2. 当元件位C元件双字寄存器时，每个寄存器需占4个字节的数据
        ******************************************************************************/


        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Write_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem_Int16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Write_Soft_Elem_Int16(SoftElemType eType, int nStartAddr, int nCount, short[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem_Int32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Write_Soft_Elem_Int32(SoftElemType eType, int nStartAddr, int nCount, long[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem_UInt16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Write_Soft_Elem_UInt16(SoftElemType eType, int nStartAddr, int nCount, ushort[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem_UInt32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Write_Soft_Elem_UInt32(SoftElemType eType, int nStartAddr, int nCount, ulong[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Write_Soft_Elem_Float", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Write_Soft_Elem_Float(SoftElemType eType, int nStartAddr, int nCount, float[] pValue, int nNetId = 0);

        /******************************************************************************
         1.功能描述 : 读H3u软元件
         2.返 回 值 :1 成功  0 失败
         3.参    数 : nNetId:网络链接编号
			          eType：软元件类型  
				          REGI_H3U_Y    = 0x20,     //Y元件的定义	
				          REGI_H3U_X    = 0x21,		//X元件的定义							
				          REGI_H3U_S    = 0x22,		//S元件的定义				
				          REGI_H3U_M    = 0x23,		//M元件的定义							
				          REGI_H3U_TB   = 0x24,		//T位元件的定义				
				          REGI_H3U_TW   = 0x25,		//T字元件的定义				
				          REGI_H3U_CB   = 0x26,		//C位元件的定义				
				          REGI_H3U_CW   = 0x27,		//C字元件的定义				
				          REGI_H3U_DW   = 0x28,		//D字元件的定义				
				          REGI_H3U_CW2  = 0x29,	    //C双字元件的定义
				          REGI_H3U_SM   = 0x2a,		//SM
				          REGI_H3U_SD   = 0x2b,		//SD
				          REGI_H3U_R    = 0x2c		//SD
			          nStartAddr:软元件起始地址
			          nCount：软元件个数
			          pValue：返回数据缓存区
         4.注意事项 : 1.x和y元件地址需为8进制; 
                      2. 当元件位C元件双字寄存器时，每个寄存器需占4个字节的数据
			          3.如果是读位元件，每个位元件的值存储在一个字节中，pValue数据缓存区字节数必须是8的整数倍
        ******************************************************************************/
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem_Int16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem_Int16(SoftElemType eType, int nStartAddr, int nCount, short[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem_Int32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem_Int32(SoftElemType eType, int nStartAddr, int nCount, long[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem_UInt16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem_UInt16(SoftElemType eType, int nStartAddr, int nCount, ushort[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem_UInt32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem_UInt32(SoftElemType eType, int nStartAddr, int nCount, ulong[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "H3u_Read_Soft_Elem_Float", CallingConvention = CallingConvention.Cdecl)]
        public static extern int H3u_Read_Soft_Elem_Float(SoftElemType eType, int nStartAddr, int nCount, float[] pValue, int nNetId = 0);

        /******************************************************************************
         1.功能描述 : 写Am600软元件
         2.返 回 值 :1 成功  0 失败
         3.参    数 : nNetId:网络链接编号
                      eType：软元件类型    ELEM_QX = 0//QX元件  ELEM_MW = 1 //MW元件
                      nStartAddr:软元件起始地址（QX元件由于带小数点，地址需要乘以10去掉小数点，如QX10.1，请输入101，MW元件直接就是它的元件地址不用处理）
                      nCount：软元件个数
                      pValue：数据缓存区
        4.注意事项 :  1.x和y元件地址需为8进制; 
                      2. 当元件位C元件双字寄存器时，每个寄存器需占4个字节的数据
                      3.如果是写位元件，每个位元件的值存储在一个字节中
        ******************************************************************************/
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Write_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Write_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Write_Soft_Elem_Int16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Write_Soft_Elem_Int16(SoftElemType eType, int nStartAddr, int nCount, short[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Write_Soft_Elem_Int32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Write_Soft_Elem_Int32(SoftElemType eType, int nStartAddr, int nCount, long[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Write_Soft_Elem_UInt16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Write_Soft_Elem_UInt16(SoftElemType eType, int nStartAddr, int nCount, ushort[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Write_Soft_Elem_UInt32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Write_Soft_Elem_UInt32(SoftElemType eType, int nStartAddr, int nCount, ulong[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Write_Soft_Elem_Float", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Write_Soft_Elem_Float(SoftElemType eType, int nStartAddr, int nCount, float[] pValue, int nNetId = 0);

        /******************************************************************************
         1.功能描述 : 读Am600软元件
         2.返 回 值 :1 成功  0 失败
         3.参    数 : nNetId:网络链接编号
                      eType：软元件类型   ELEM_QX = 0//QX元件  ELEM_MW = 1 //MW元件
                      nStartAddr:软元件起始地址（QX元件由于带小数点，地址需要乘以10去掉小数点，如QX10.1，请输入101，其它元件不用处理）
                      nCount：软元件个数
                      pValue：返回数据缓存区
         4.注意事项 : 如果是读位元件，每个位元件的值存储在一个字节中，pValue数据缓存区字节数必须是8的整数倍
        ******************************************************************************/
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Read_Soft_Elem", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Read_Soft_Elem(SoftElemType eType, int nStartAddr, int nCount, byte[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Read_Soft_Elem_Int16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Read_Soft_Elem_Int16(SoftElemType eType, int nStartAddr, int nCount, short[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Read_Soft_Elem_Int32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Read_Soft_Elem_Int32(SoftElemType eType, int nStartAddr, int nCount, long[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Read_Soft_Elem_UInt16", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Read_Soft_Elem_UInt16(SoftElemType eType, int nStartAddr, int nCount, ushort[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Read_Soft_Elem_UInt32", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Read_Soft_Elem_UInt32(SoftElemType eType, int nStartAddr, int nCount, ulong[] pValue, int nNetId = 0);
        [DllImport("StandardModbusApi.dll", EntryPoint = "Am600_Read_Soft_Elem_Float", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Am600_Read_Soft_Elem_Float(SoftElemType eType, int nStartAddr, int nCount, float[] pValue, int nNetId = 0);
        #endregion


        public bool open()
        {
            int nNetId = 0;
            int nIpPort = 502;
            bool result = Init_ETH_String("192.168.1.88", nNetId, nIpPort);

            return result;
        }

        public bool close()
        {
            int nNetId = 0;
            bool result = Exit_ETH(nNetId);
            return result;
        }

        /// <summary>
        /// 写入AM600 系列PLC 输出端口某个点位的值
        /// </summary>
        /// <param name="Addr">地址，端口*10</param>
        /// <param name="value">写入值</param>
        /// <returns></returns>
        public bool writeQX(int Addr, int value) //AM600
        {
            object obj4 = new object();
            lock (obj4)
            {
                int nStartAddr = Addr;
                int nCount = 1;
                short[] pValue = new short[1];//缓冲区
                int nNetId = 0;

                short nValue = (short)value;
                pValue[0] = nValue;
                int nRet = Am600_Write_Soft_Elem_Int16(SoftElemType.ELEM_QX, nStartAddr, nCount, pValue, nNetId);

                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        /// <summary>
        /// 读取AM600 系列PLC 输出端口某个点位的值
        /// </summary>
        /// <param name="Addr">地址，端口*10</param>
        /// <param name="fValue">返回值</param>
        /// <returns></returns>
        public bool readQX(int Addr, ref int fValue) //AM600
        {
            object obj2 = new object();
            lock (obj2)
            {
                int nStartAddr = Addr;
                int nCount = 1;
                short[] pValue = new short[1];//缓冲区
                int nNetId = 0;

                int nRet = Am600_Read_Soft_Elem_Int16(SoftElemType.ELEM_QX, nStartAddr, nCount, pValue, nNetId);

                
                fValue = pValue[0];
                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 读取AM600 系列PLC 输出端口多个点位的值
        /// </summary>
        /// <param name="Addr">地址，端口*10</param>
        /// <param name="fValue">返回值</param>
        /// <returns></returns>
        public bool readQX(int Addr,int count, ref int[] fValue) //AM600
        {
            object obj2 = new object();

            lock (obj2)
            {
                try
                {
                    fValue = new int[count];
                    int nStartAddr = Addr;
                    int nCount = count;
                    byte[] pValue = new byte[count];//缓冲区
                    int nNetId = 0;

                    int nRet = Am600_Read_Soft_Elem(SoftElemType.ELEM_QX, nStartAddr, nCount, pValue, nNetId);
                    //Am600_Read_Soft_Elem_UInt16
                    for (int i = 0; i < pValue.Length; i++)
                    {
                        fValue[i] = Convert.ToInt16(pValue[i]);
                    }
                    if (1 == nRet)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Inovance readQX Error:" + ex.Message);
                    fValue = new int[1];
                    fValue[0] = 0;
                    return false;
                }
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Addr"></param>
        ///// <param name="value"></param>
        ///// <param name="count">count=2</param>
        ///// <returns></returns>
        //public bool writeMW_int32(int Addr, int value, int count) //AM600
        //{
        //    object obj1 = new object();
        //    lock (obj1)
        //    {
        //        int nStartAddr = Addr;
        //        int nCount = count;
        //        long[] pValue = new long[1];//缓冲区
        //        int nNetId = 0;

        //        Int32 nValue = (Int32)value;
        //        pValue[0] = nValue;
        //        int nRet = Am600_Write_Soft_Elem_Int32(SoftElemType.ELEM_MW, nStartAddr, nCount, pValue, nNetId);

        //        if (1 == nRet)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}


        
        public bool writeMW_int32(int Addr, int value) //AM600
        {
            object obj1 = new object();
            lock (obj1)
            {
                int nStartAddr = Addr;
                int nCount = 2;
                long[] pValue = new long[1];//缓冲区
                int nNetId = 0;
                Int32 nValue = (Int32)value;
                pValue[0] = nValue;
                int nRet = Am600_Write_Soft_Elem_Int32(SoftElemType.ELEM_MW, nStartAddr, nCount, pValue, nNetId);
                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool writeMW_float(int Addr, float value) //AM600
        {
            object obj5 = new object();
            lock (obj5)
            {
                int nStartAddr = Addr;
                int nCount = 2;
                float[] pValue = new float[1];//缓冲区
                int nNetId = 0;

                float nValue = value;
                pValue[0] = nValue;
                int nRet = Am600_Write_Soft_Elem_Float(SoftElemType.ELEM_MW, nStartAddr, nCount, pValue, nNetId);

                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool readMW_float(int Addr, ref float value)
        {
            object obj7 = new object();
            lock (obj7)
            {
                int nStartAddr = Addr;
                int nCount = 2;//原始为2
                float[] pValue = new float[1];//缓冲区
                int nNetId = 0;
                int nRet = Am600_Read_Soft_Elem_Float(SoftElemType.ELEM_MW, nStartAddr, nCount, pValue, nNetId);
                value = pValue[0];
                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public bool readMW_int32(int Addr, ref int fValue) //AM600
        {
            object obj2 = new object();
            lock (obj2)
            {
                int nStartAddr = Addr;
                int nCount = 1;
                long[] pValue = new long[1];//缓冲区
                int nNetId = 0;

                int nRet = Am600_Read_Soft_Elem_Int32(SoftElemType.ELEM_MW, nStartAddr, nCount, pValue, nNetId);

                fValue = Convert.ToInt32(pValue[0]);
                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public bool readDW(int Addr, ref int fValue)
        {
            object obj11 = new object();
            lock (obj11)
            {
                int nStartAddr = Addr;
                int nCount = 1;
                short[] pValue = new short[1];//缓冲区
                int nNetId = 0;

                //int nRet = Am600_Read_Soft_Elem_Int16(SoftElemType.REGI_H3U_DW, nStartAddr, nCount, pValue, nNetId);
                int nRet = Am600_Read_Soft_Elem_Int16(SoftElemType.ELEM_Y, nStartAddr, nCount, pValue, nNetId);

                fValue = pValue[0];
                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool writeDW(int Addr, int value)
        {
            object obj12 = new object();
            lock (obj12)
            {
                int nStartAddr = Addr;
                int nCount = 1;
                short[] pValue = new short[1];//缓冲区
                int nNetId = 0;
                pValue[0] = Convert.ToInt16(value);
                int nRet = H3u_Write_Soft_Elem_Int16(SoftElemType.ELEM_Y, nStartAddr, nCount, pValue, nNetId);
                if (1 == nRet)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}



        
