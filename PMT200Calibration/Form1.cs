﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PMT200Calibration
{
    public partial class PMT200 : Form
    {

        public byte[] a = new byte[13];
        private SerialPort com = new SerialPort();
        public USB usb;
        private Thread thread;
        public PMT200()
        {
            InitializeComponent();
            usb = new USB();
            init();
        }

        private void init()
        {
            try
            {
                List<string> list = new List<string>();
                string[] ports = USB.getPorts(); //SerialPort.GetPortNames();//

                comboBox_port.Items.Clear();
                for (int i = 0; i < ports.Length; i++)
                {
                    comboBox_port.Items.Add(ports[i]);
                }
                if (ports.Length > 0)
                {
                    comboBox_port.SelectedIndex = ports.Length - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void search_port_Click(object sender, EventArgs e)
        {
            init();
        }
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                // 点击winform右上关闭按钮 
                usb.closeCom();
                isExit = true;
            }
            base.WndProc(ref msg);
        }

        private Boolean isOpen = false;
        private void start_Port_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                open_port.Text = "关闭";
                String comName = comboBox_port.SelectedItem.ToString();
                Boolean isOpenSuccess = usb.setCom(comboBox_port.SelectedItem.ToString());
                if (isOpenSuccess)
                {
                    isOpen = true;
                }
                else
                {
                    isOpen = false;
                    open_port.Text = "打开";
                }
            }
            else
            {
                usb.closeCom();
                open_port.Text = "打开";
                isOpen = false;
            }
        }
        Boolean isExit = false;
        private void start_Click(object sender, EventArgs e)
        {
            a[0] = 0xaa;
            a[1] = 0x31;
            a[2] = 0x01;
            a[3] = 0x00;
            a[4] = 0x00;
            a[5] = 0x00;
            a[6] = 0x00;
            a[7] = 0x00;
            a[8] = 0x01;
            a[9] = 0x02;
            a[10] = 0x03;
            a[11] = 0x04;
            a[12] = 0x05;
            usb.SendData(a);
            //Thread.Sleep(100);
            //String msg = "";
                 thread = new Thread(new ThreadStart(getData));
               thread.Start();
        }
        public void getData()
        {
            String msg = "";

            Thread.Sleep(500);
            if (usb.ReadData().Contains("set ok"))
                isExit = false;
            else return;
            int i = 0;
            while (!isExit)
            {
                msg = usb.ReadData();
                if (msg.Contains("dBm"))
                {
                    if (!msg.Contains("=")) continue;
                    Action<int> action = (data) =>
                    {
                        int start = msg.IndexOf("=");
                        int length = "-00.0".Length;
                        String tmpValue = msg.Substring(start+2, length).Trim();
                        float value = float.Parse(tmpValue);
                        if(value > -18 || value < -22)
                        {
                            value_label.ForeColor = Color.Red;
                        }
                        else
                        {
                            value_label.ForeColor = Color.Black;
                        }
                        value_label.Text = "当前值：" + msg;
                    };
                    Invoke(action,i);
                    i++;
                }
                Thread.Sleep(1000);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            a[0] = 0xaa;
            a[1] = 0x31;
            a[2] = 0x02;
            a[3] = 0x00;
            a[4] = 0x00;
            a[5] = 0x00;
            a[6] = 0x00;
            a[7] = 0x00;
            a[8] = 0x01;
            a[9] = 0x02;
            a[10] = 0x03;
            a[11] = 0x04;
            a[12] = 0x05;
            usb.SendData(a);
            isExit = true;
            value_label.ForeColor = Color.Black;
            value_label.Text = "当前值：";
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
            //    thread.
            }
            a[0] = 0xaa;
            a[1] = 0x31;
            a[2] = 0x03;
            a[3] = 0x00;
            a[4] = 0x00;
            a[5] = 0x00;
            a[6] = 0x00;
            a[7] = 0x00;
            a[8] = 0x01;
            a[9] = 0x02;
            a[10] = 0x03;
            a[11] = 0x04;
            a[12] = 0x05;
            usb.SendData(a);
        }

   
    }
}
