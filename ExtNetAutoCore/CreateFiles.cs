using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ExtNetAutoCore
{
    public class CreateFiles
    {
        public string BuildFrame(string destFolder, string dbtype)
        {
            string srcFile = ".\\WebBasic\\";
            string Folder = FileReady(destFolder, "ET.cj", srcFile, "NSoisuowerU&(32_+@Hdussjk8");
            string Files = FileReady(".\\", "EF.cj", srcFile, "Jxc<IOU#:Jois09()32)(#*$#@jksdj");
            if (Folder == "OK" && Files == "OK")
                return "OK";
            else
                return "框架准备：" + Folder + "   模板准备：" + Files;
        }
        //开发助理页面 准备文件
        public string SetFilesReady()
        {
            string srcFile = ".\\WebBasic\\";
            string Files = FileReady(".\\", "EF.cj", srcFile, "Jxc<IOU#:Jois09()32)(#*$#@jksdj");
            return Files;
        }
        /// <summary>
        /// 准备框架文件和模板文件
        /// </summary>
        /// <param name="path">解压目录地址</param>
        /// <param name="rarName">压缩文件名</param>
        /// <param name="rarPath">压缩文件地址</param>
        /// <param name="pwd">压缩文件密码</param>
        /// <returns></returns>
        public string FileReady(string path, string rarName, string rarPath, string pwd)
        {
            #region 变量
            bool flag = false;
            string cmd;
            ProcessStartInfo startinfo;
            Process process;
            #endregion
            try
            {
                Directory.CreateDirectory(path);
                //解压缩命令，相当于在要压缩文件(rarName)上点右键->WinRAR->解压到当前文件夹
                cmd = string.Format("x {0} {1} -y -p{2}", rarName, path, pwd);
                #region 执行命令
                startinfo = new ProcessStartInfo();
                startinfo.FileName = "WinRAR.exe";
                startinfo.Arguments = cmd;
                startinfo.WindowStyle = ProcessWindowStyle.Hidden;
                startinfo.WorkingDirectory = rarPath;
                process = new Process();
                process.StartInfo = startinfo;
                process.Start();
                process.WaitForExit();
                if (process.HasExited)
                {
                    flag = true;
                }
                process.Close();
                #endregion
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
