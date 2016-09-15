using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

/*
 * 陈杰
 * 2009-11-9
 * 准备框架 
 */
namespace Core
{
    public class CreateFiles
    {
        public string BuildFrame(string destFolder,string dbtype)
        {
            string srcFile = ".\\WebBasic\\";
            string Folder=FileReady(destFolder, "T.cj", srcFile, "jiasoud&()&JDFJOUIOEWlsdq2312");
            string Files = FileReady(".\\", "F.cj", srcFile, "LJ(&(#_DSJFL234iouiaosdjfla+_");
            if (dbtype == "Oracle")
            {
                try
                {
                    File.Copy(srcFile + "Dao.xml", destFolder + "\\WebMisDeveloper\\App_Cfg\\Dao.xml", true);
                    File.Copy(srcFile + "newsInfo.hbm.xml", destFolder + "\\WebMisDeveloper\\Model\\Mappings\\newsInfo.hbm.xml", true);
                    File.Copy(srcFile + "rolefun.hbm.xml", destFolder + "\\WebMisDeveloper\\Model\\Mappings\\rolefun.hbm.xml", true);
                    File.Copy(srcFile + "roles.hbm.xml", destFolder + "\\WebMisDeveloper\\Model\\Mappings\\roles.hbm.xml", true);
                    File.Copy(srcFile + "userinfo.hbm.xml", destFolder + "\\WebMisDeveloper\\Model\\Mappings\\userinfo.hbm.xml", true);
                    File.Copy(srcFile + "newsinfoDao.cs", destFolder + "\\WebMisDeveloper\\DAO\\newsinfoDao.cs", true);
                }
                catch(Exception error)
                {
                    Files +="  部分文件准备失败:" + error.Message;
                }
            }
            if (Folder == "OK" && Files == "OK")
                return "OK";
            else
                return "框架准备：" + Folder + "   模板准备：" + Files;
        }
        /// <summary>
        /// 准备框架文件和模板文件
        /// </summary>
        /// <param name="path">解压目录地址</param>
        /// <param name="rarName">压缩文件名</param>
        /// <param name="rarPath">压缩文件地址</param>
        /// <param name="pwd">压缩文件密码</param>
        /// <returns></returns>
        public string FileReady(string path,string rarName,string rarPath,string pwd)
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
                cmd = string.Format("x {0} {1} -y -p{2}",rarName,path, pwd);
                #region 执行命令
                startinfo = new ProcessStartInfo();
                startinfo.FileName ="WinRAR.exe";
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

        //开发助理页面 准备文件
        public string SetFilesReady()
        {
            string srcFile = ".\\WebBasic\\";
            string Files = FileReady(".\\", "F.cj", srcFile, "LJ(&(#_DSJFL234iouiaosdjfla+_");
            return Files;
        }

    }
}
