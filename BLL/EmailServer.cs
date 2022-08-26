using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace BLL
{
    public class EmailServer
    {
        private class EmailServers
        {
            public string strSmtpServer = "smtp.qq.com";//邮箱
            public string strFrom = "2460696169@qq.com";//邮箱账号
            public string strFromPass = "mdhdntgharmkebcd";//邮箱授权码
            public string strSubject = "天津师范大学住宿管理系统";//标题
            public string strBody = "天津师范大学住宿管理系统邮箱验证中心，非本人操作请忽略，注册验证码为：";//发送内容
        }
        public static string Code = string.Empty;
        public static bool SendSMTPEMail(string strto)
        {
            EmailServers server = new EmailServers();
            string strSmtpServer = server.strSmtpServer;
            string strFrom = server.strFrom;
            string strFromPass = server.strFromPass;
            string strSubject = server.strSubject;
            Code = CreateRandom();

            string strBody = server.strBody + "<br/>" + Code;
            SmtpClient client = new SmtpClient(strSmtpServer);
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(strFrom, strFromPass);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage(strFrom, strto, strSubject, strBody);
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            try
            {
                client.Send(message);
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 创建邮箱验证码
        /// </summary>
        /// <returns></returns>
        public static string CreateRandom()
        {
            int rep = 0;
            int codelengh = 4;//6位验证码
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codelengh; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
    }
}
