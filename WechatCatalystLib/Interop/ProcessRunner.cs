using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMasson.WechatCatalyst.BaseLib.Interop
{
    public class ProcessRunner
    {
        public string ExcuteRawToEnd(string rawCommand) 
        {
            Process p = new Process();
            p.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            p.StartInfo.FileName = "cmd.exe";//要执行的程序名称
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            
            p.Start();//启动程序

            //向CMD窗口发送输入信息：
            p.StandardInput.WriteLine(rawCommand);

            //获取CMD窗口的输出信息：
            //string sOutput = p.StandardOutput.ReadToEnd();

            return rawCommand;
        }
    }
}
