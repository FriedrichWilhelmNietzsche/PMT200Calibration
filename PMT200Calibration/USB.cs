using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMT200Calibration
{
    public class USB
    {
        #region 根据获取的系统串口列表，查找对应的设备串口
        private System.IO.Ports.SerialPort _spPon1;

        public Boolean setCom(String comName)
        {

            try
            {
                _spPon1 = new SerialPort(comName, 9600, Parity.None, 8, StopBits.One);
                _spPon1.ReadTimeout = 2000;
                _spPon1.WriteTimeout = 1000;
                if (!_spPon1.IsOpen)
                {
                    _spPon1.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        public static string[] getPorts()
        {
            return SerialPort.GetPortNames();
        }

        public void closeCom()
        {
            try
            {
                if (_spPon1 != null && _spPon1.IsOpen)
                {
                    _spPon1.Close();
                }
                _spPon1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public bool SendData(byte[] send)
        {
            bool flag = false;
            try
            {
                Console.WriteLine(send);
                _spPon1.Write(send, 0, send.Length);
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口未打开", "提示");
            }
            return flag;
        }

        public String ReadData()
        {
            try
            {
                int n = _spPon1.BytesToRead;
                byte[] buf = new byte[n + 1];
                //  received_count += n;
                _spPon1.Read(buf, 0, n);
                String SerialIn = System.Text.Encoding.ASCII.GetString(buf, 0, n);
                return SerialIn;
                //builder.Clear();

                //this.Invoke((EventHandler)(delegate
                //{
                //    //直接按ASCII规则转换成字符串
                //    builder.Append(Encoding.ASCII.GetString(buf));
                //    //}
                //    //追加的形式添加到文本框末端，并滚动到最后。
                //    tB1.AppendText(builder.ToString());
                //    series.Points.AddY(builder.ToString());
                //    //修改接收计数
                //    //label1.Text = "Get:" + received_count.ToString();
                //}));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
    }
}
