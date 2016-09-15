using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


/*
 * 陈杰
 * 2009-11-10
 * 由于CJ组件中的文件读写没有指定编码方式，所以会出现部分汉字不识别
 * 不得不再重写一个类。
 */
namespace Core
{
    public class FileOperator
    {
        public static void WriteFile(string filepath, string text)
        {
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
            writer.Write(text);
            writer.Flush();//把内存中未写盘的内容写盘。
            writer.Close();
        }
        public static string ReadFile(string path)
        {
            string content = "";
            FileStream fs = new FileStream(path, FileMode.Open);//为读文件建立文件流
            StreamReader reader = new StreamReader(fs, Encoding.UTF8);
            content = reader.ReadToEnd();//把流中的全部内容放入文本框中显示出来。
            fs.Close();
            return content;
        }
    }
}
