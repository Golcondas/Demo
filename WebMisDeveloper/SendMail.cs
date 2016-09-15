using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace WebMisDeveloper
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.To.Add("ovenjackchain@gmail.com");

            msg.From = new MailAddress("710782046@qq.com", "AlphaWu", System.Text.Encoding.UTF8);

            /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/

            msg.Subject = "这是测试邮件";//邮件标题 

            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 

            msg.Body = "邮件内容";//邮件内容 

            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 

            msg.IsBodyHtml = false;//是否是HTML邮件 

            msg.Priority = MailPriority.High;//邮件优先级 




            SmtpClient client = new SmtpClient();

            client.Host = "localhost";

            object userState = msg;

            try
            {

                client.SendAsync(msg, userState);

                //简单一点儿可以client.Send(msg); 

                MessageBox.Show("发送成功");

            }

            catch (System.Net.Mail.SmtpException ex)
            {

                MessageBox.Show(ex.Message, "发送邮件出错");

            }
        }



    }
}
