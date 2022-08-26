using System.Data;
using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using PCC;

namespace DAL
{
    /// <summary>
    /// 用户数据库操作类
    /// </summary>
    public class UserDAL:SqlSugarBase
    {
        /// <summary>
        /// 判断此用户输入的身份证号是否存在
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
       public static bool IdentityIsAny(string iden)
       {
            return DB.Queryable<User>().Where(it => it.Identity ==iden).Any();
       }
        /// <summary>
        /// 判断用户的身份证号与邮箱是否匹配
        /// </summary>
        /// <param name="iden"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool EamilIsMatch(string iden,string email)
        {
            return DB.Queryable<User>().Where(it => it.Identity == iden && it.Email==email).Any();
        }
        /// <summary>
        /// 判断用户的身份证号与密码是否匹配
        /// </summary>
        /// <param name="iden"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool PasswordIsMatch(string iden,string pwd)
        {
            return DB.Queryable<User>().Where(it => it.Identity == iden && it.Password == pwd).Any();
        }
        /// <summary>
        /// 判断此用户输入的工号是否存在
        /// </summary>
        /// <param name="jobnm"></param>
        /// <returns></returns>
        public static bool JobNumberIsAny(string jobNm)
        {
            return DB.Queryable<Admin>().Where(it => it.JobNumber == jobNm).Any();
        }
        /// <summary>
        /// 判断用户的工号与密码是否匹配
        /// </summary>
        /// <param name="jobNm"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool PasswordIsMatchJobNumber(string jobNm, string pwd)
        {
            return DB.Queryable<Admin>().Where(it => it.JobNumber == jobNm && it.Password == pwd).Any();
        }
        /// <summary>
        /// 根据iden的值获取用户的姓名
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static string ReturnUserName(string iden)
        {
            var getName = DB.Queryable<User>().First(it => it.Identity == iden);
            return getName.Name;
        }
        /// <summary>
        /// 根据uid找到此学生的性别
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentSex(string uid)
        {
            var getName = DB.Queryable<User>().First(it => it.Identity == uid);//查询单条
            return getName.Sex;
        }
        /// <summary>
        /// 根据uid找到此学生的密码
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentPassword(string uid)
        {
            var getName = DB.Queryable<User>().First(it => it.Identity == uid);//查询单条
            return getName.Password;
        }
        /// <summary>
        /// 根据uid找到此学生的班级
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentClass(string uid)
        {
            var getName = DB.Queryable<User>().First(it => it.Identity == uid);//查询单条
            return getName.Major;
        }
        /// <summary>
        /// 查询ResultBoy表中属于特定班级的分配信息是否发布
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static int IssueInfoBoy(string major)
        {
            var getName = DB.Queryable<ResultBoy>().First(it => it.Class == major);//查询单条
            return getName.State;
        }
        /// <summary>
        /// 查询某学生是否填写完信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static int FinishInfo(string uid)
        {
            var getName = DB.Queryable<Good>().First(it => it.UserID == uid);//查询单条
            return getName.State;
        }
        /// <summary>
        /// 查询ResultGirl表中属于特定班级的分配信息是否发布
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static int IssueInfoGirl(string major)
        {
            var getName = DB.Queryable<ResultGirl>().First(it => it.Class == major);//查询单条
            return getName.State;
        }
        /// <summary>
        /// 查询ResultGirl表中是否有属于特定班级的分配信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool IssueInfoGirlAny(string major)
        {
            return DB.Queryable<ResultGirl>().Where(it => it.Class == major).Any();
        }
        /// <summary>
        /// 查找某一个学生的全部信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable AStudentInfo(string uid)
        {
            return DB.Queryable<User>().Where(it => it.Identity == uid).Select(it => new {
                it.Identity,
                it.Email,
                it.Password,
                it.Name,
                it.StudentNumber,
                it.College,
                it.Major,
                it.Class,
                it.Sex,
                it.Phone
            }).ToDataTable();
        }
        /// <summary>
        /// 测试用
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static bool UserIsAny(User u)
        {
            return true;
        }
    }
}
