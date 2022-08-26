using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class MessageBLL
    {
        /// <summary>
        /// 查看某一管理员所收到的全部信息(不包括回复)
        /// </summary>
        /// <param name="jobnum"></param>
        /// <returns></returns>
        public static DataTable AdminAllReceiveMes(string jobnum) => MessageDAL.AdminAllReceiveMes(jobnum);
        /// <summary>
        /// 查询某个管理员收到的未读信息的个数
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int ReceiveMesCount(string jobnum) => MessageDAL.ReceiveMesCount(jobnum);
        /// <summary>
        /// 查询某个学生是否收到了信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool AcceptMessage(string uid) => MessageDAL.AcceptMessage(uid);
        /// <summary>
        /// 查询某个学生是否收到的未读信息的个数
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int AcceptMessageCount(string uid) => MessageDAL.AcceptMessageCount( uid);
        /// <summary>
        /// 查看某一学生所收到的全部信息(不包括回复)
        /// </summary>
        /// <param name="jobnum"></param>
        /// <returns></returns>
        public static DataTable StudentAllReceiveMes(string uid) => MessageDAL.StudentAllReceiveMes(uid);
        /// <summary>
        /// 在对应信息中加入回复内容
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static bool AddReplyInfo(Message mes) => MessageDAL.AddReplyInfo(mes);
        /// <summary>
        /// 管理员给某一个特定学生发送信息
        /// </summary>
        /// <param name="urge"></param>
        /// <returns></returns>
        public static bool InsertNewMessage(Message mes) => MessageDAL.InsertNewMessage(mes);
        /// <summary>
        /// 查询某个学生是否发送过信息
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static bool SendMessage(string iden) => MessageDAL.SendMessage(iden);
        /// <summary>
        /// 查看所有接收的消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable AllMesSend(string uid) => MessageDAL.AllMesSend(uid);
        /// <summary>
        /// 向未填写信息的学生发送催促信息
        /// </summary>
        /// <param name="urge"></param>
        /// <returns></returns>
        public static bool InsertUrgeMessage(Message urge)=> MessageDAL.InsertUrgeMessage(urge);
        /// <summary>
        /// 查看所有接收的消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable AllMesReceive(string uid) => MessageDAL.AllMesReceive(uid);
        /// <summary>
        /// 查询出某一学生所属学院
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        public static string SelectCollege(string uid) => MessageDAL.SelectCollege(uid);
        /// <summary>
        /// 查询出某一学院的管理员的工号
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public static string SelectJobNumber(string college) => MessageDAL.SelectJobNumber(college);
        /// <summary>
        /// 查询出某一信息的具体内容
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string SelectContent(int mid) => MessageDAL.SelectContent(mid);
        /// <summary>
        /// 查询出某一信息的回复内容
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string SelectReContent(int mid) => MessageDAL.SelectReContent(mid);
        /// <summary>
        /// 更新——信息变为已读
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static bool ReadSuccess(Message mes) => MessageDAL.ReadSuccess(mes);
        /// <summary>
        /// 表面上删除信息
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static bool Delect(Message mes) => MessageDAL.Delect(mes);
        /// <summary>
        /// 查看曾经申请过的信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable EverApply(string uid) => MessageDAL.EverApply(uid);
    }
}
