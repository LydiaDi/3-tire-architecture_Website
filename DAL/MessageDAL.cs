using System.Data;
using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using PCC;

namespace DAL
{
    public class MessageDAL : SqlSugarBase
    {
        /// <summary>
        /// 查看某一管理员所收到的全部信息(不包括回复)
        /// </summary>
        /// <param name="jobnum"></param>
        /// <returns></returns>
        public static DataTable AdminAllReceiveMes(string jobnum)
        {
            return DB.Queryable<Admin,  Message, User>((a,m,u) => new JoinQueryInfos(JoinType.Left, a.JobNumber == m.Accept, JoinType.Left,  m.Send== u.Identity ))
                .Where((a,m,u) => m.Accept == jobnum && m.Delect == 1).OrderBy((a, m, u) => m.Read)
            .Select((a,m,u) => new
            {
                u.Name,
                u.Major,
                m.Time,
                m.Read,
                m.MID,
                m.Content,
                m.reContent
            }).ToDataTable();
        }
        /// <summary>
        /// 查询某个管理员收到的未读信息的个数
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int ReceiveMesCount(string jobnum)
        {
            var query = DB.Queryable<Admin, Message, User>((a, m, u) => new JoinQueryInfos(JoinType.Left, a.JobNumber == m.Accept, JoinType.Left, m.Send == u.Identity))
                .Where((a, m, u) => m.Accept == jobnum && m.Delect == 1 && m.Read == 0).Distinct();

            var count = query.Clone().Count();
            return count;
        }
        /// <summary>
        /// 查询某个学生是否收到了信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool AcceptMessage(string uid)
        {
            return DB.Queryable<Admin, Message, User>((a, m, u) => new JoinQueryInfos(JoinType.Left, a.JobNumber == m.Send, JoinType.Left, m.Accept == u.Identity))
                .Where((a, m, u) => m.Accept == uid && m.Delect == 1).Any();
        }
        /// <summary>
        /// 查询某个学生是否收到的未读信息的个数
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int AcceptMessageCount(string uid)
        {
            var query= DB.Queryable<Admin, Message, User>((a, m, u) => new JoinQueryInfos(JoinType.Left, a.JobNumber == m.Send, JoinType.Left, m.Accept == u.Identity))
                .Where((a, m, u) => m.Accept == uid && m.Delect == 1 && m.Read == 0).Distinct();

            var count = query.Clone().Count();
            return count;
        }
        /// <summary>
        /// 查看某一学生所收到的全部信息(不包括回复)
        /// </summary>
        /// <param name="jobnum"></param>
        /// <returns></returns>
        public static DataTable StudentAllReceiveMes(string uid)
        {
            return DB.Queryable<Admin, Message, User>((a, m, u) => new JoinQueryInfos(JoinType.Left, a.JobNumber == m.Send, JoinType.Left, m.Accept == u.Identity))
                .Where((a, m, u) => m.Accept == uid && m.Delect == 1).OrderBy((a, m, u) => m.Read).OrderBy((a, m, u) => m.reContent, OrderByType.Desc)
            .Select((a, m, u) => new
            {
                a.College,
                u.Identity,
                m.Time,
                m.Read,
                m.MID,
                m.Content,
                m.reContent
            }).ToDataTable();
        }
        /// <summary>
        /// 在对应信息中加入回复内容
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static bool AddReplyInfo(Message mes)
        {
            //var update = DB.Updateable(mes).UpdateColumns(it => new { it.reContent}).ExecuteCommand();
            //return update > 0;
            var result = DB.Updateable(mes)
                .UpdateColumns(it => it.reContent)
                .Where(it => it.MID == mes.MID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 管理员给某一个特定学生发送信息
        /// </summary>
        /// <param name="urge"></param>
        /// <returns></returns>
        public static bool InsertNewMessage(Message mes)
        {
            var insert = DB.Insertable(mes).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
            return insert > 0;
        }
        /// <summary>
        /// 查询某个学生是否发送过信息
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static bool SendMessage(string iden)
        {
            return DB.Queryable<Message>().Where(it => it.Send == iden).Any();
        }
        /// <summary>
        /// 查看所有接收的消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable AllMesSend(string uid)
        {
            return DB.Queryable<User, Message>((u, m) => new JoinQueryInfos(JoinType.Left, u.Identity == m.Send))
                .Where((u, m) => m.Send == uid && m.Delect == 1)
                .Select((u, m) => new {
                    u.College,
                    u.Name,
                    u.Major,
                    m.Time,
                    m.Read,
                    m.MID,
                    m.Content,
                    m.Type
                })
                .ToDataTable();
        }
        /// <summary>
        /// 向未填写信息的学生发送催促信息
        /// </summary>
        /// <param name="urge"></param>
        /// <returns></returns>
        public static bool InsertUrgeMessage(Message urge)
        {
            var insert = DB.Insertable(urge).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
            return insert > 0;
        }
        /// <summary>
        /// 查看所有接收的消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable AllMesReceive(string uid)
        {
            return DB.Queryable<User, Message>((u, m) => new JoinQueryInfos(JoinType.Left, u.Identity == m.Accept))
                .Where((u, m) => m.Accept == uid && m.Delect ==1)
                .Select((u, m) => new {
                    u.Name,
                    u.Major,
                    m.Time,
                    m.Read,
                    m.MID,
                    m.Content
                })
                .ToDataTable();
        }
        /// <summary>
        /// 查询出某一学生所属学院
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        public static string SelectCollege(string uid)
        {
            var getCollege = DB.Queryable<User>().First(it => it.Identity ==uid);//查询单条
            return getCollege.College;
        }
        /// <summary>
        /// 查询出某一学院的管理员的工号
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public static string SelectJobNumber(string college)
        {
            var getJobNumber = DB.Queryable<Admin>().First(it => it.College ==college);//查询单条
            return getJobNumber.JobNumber;

        }
        /// <summary>
        /// 查询出某一信息的具体内容
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string SelectContent(int mid)
        {
            var getContent = DB.Queryable<Message>().First(it => it.MID==mid);//查询单条
            return getContent.Content;

        }
        /// <summary>
        /// 查询出某一信息的回复内容
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string SelectReContent(int mid)
        {
            var getContent = DB.Queryable<Message>().First(it => it.MID == mid);//查询单条
            return getContent.reContent;

        }
        /// <summary>
        /// 更新——信息变为已读
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static bool ReadSuccess(Message mes)
        {
            //var update = DB.Updateable(mes).UpdateColumns(it => new { it.Read}).ExecuteCommand();
            //return update > 0;
            var result = DB.Updateable(mes)
                .UpdateColumns(it => it.Read)
                .Where(it => it.MID == mes.MID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 表面上删除信息
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static bool Delect(Message mes)
        {
            //前两行之前用过可以实现修改数据库，但是后来不怎么了，不能使用了，于是使用了现在正在使用的代码
            //var update = DB.Updateable(mes).UpdateColumns(it => new { it.Delect }).ExecuteCommand();
            //return update > 0;
            var result = DB.Updateable(mes)
                .UpdateColumns(it => it.Delect)
                .Where(it => it.MID == mes.MID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 查看曾经申请过的信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable EverApply(string uid)
        {
            return DB.Queryable<User, Message>((u, m) => new JoinQueryInfos(JoinType.Left, u.Identity == m.Send))
                .Where((u, m) => m.Send == uid).OrderBy((u, m) => m.Read, OrderByType.Desc).OrderBy((u, m) => m.reContent, OrderByType.Desc)
                .Select((u, m) => new {
                    u.College,
                    u.Name,
                    u.Major,
                    u.Sex,
                    m.Time,
                    m.Read,
                    m.Type,
                    m.MID,
                    m.reContent,
                    u.StudentNumber
                })
                .ToDataTable();
        }
    }
}
