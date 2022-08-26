using Model;
using DAL;
using System.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UserBLL
    {
        /// <summary>
        /// 判断此用户是否存在
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static bool IdentityIsAny(string iden) => UserDAL.IdentityIsAny(iden);
        /// <summary>
        /// 判断用户的身份证号与邮箱是否匹配
        /// </summary>
        /// <param name="iden"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool EamilIsMatch(string iden, string email) => UserDAL.EamilIsMatch(iden,email);
        /// <summary>
        /// 判断用户的身份证号与密码是否匹配
        /// </summary>
        /// <param name="iden"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool PasswordIsMatch(string iden, string pwd) => UserDAL.PasswordIsMatch(iden, pwd);
        /// <summary>
        /// 判断此用户输入的工号是否存在
        /// </summary>
        /// <param name="jobnm"></param>
        /// <returns></returns>
        public static bool JobNumberIsAny(string jobNm) => UserDAL.JobNumberIsAny(jobNm);
        /// <summary>
        /// 判断用户的工号与密码是否匹配
        /// </summary>
        /// <param name="jobNm"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool PasswordIsMatchJobNumber(string jobNm, string pwd) => UserDAL.PasswordIsMatchJobNumber(jobNm, pwd);
        /// <summary>
        /// 根据iden的值获取用户的姓名
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static string ReturnUserName(string iden) => UserDAL.ReturnUserName(iden);
        /// <summary>
        /// 根据uid找到此学生的性别
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentSex(string uid) => UserDAL.SelectStudentSex(uid);
        /// <summary>
        /// 根据uid找到此学生的班级
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentClass(string uid) => UserDAL.SelectStudentClass(uid);
        /// <summary>
        /// 查询ResultBoy表中属于特定班级的分配信息是否发布
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static int IssueInfoBoy(string major) => UserDAL.IssueInfoBoy(major);
        /// <summary>
        /// 查询某学生是否填写完信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static int FinishInfo(string uid) => UserDAL.FinishInfo(uid);
        /// <summary>
        /// 查询ResultGirl表中属于特定班级的分配信息是否发布
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static int IssueInfoGirl(string major) => UserDAL.IssueInfoGirl(major);
        /// <summary>
        /// 查询ResultGirl表中是否有属于特定班级的分配信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool IssueInfoGirlAny(string major) => UserDAL.IssueInfoGirlAny(major);
        /// <summary>
        /// 查找某一个学生的全部信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable AStudentInfo(string uid) => UserDAL.AStudentInfo(uid);
        /// <summary>
        /// 根据uid找到此学生的密码
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentPassword(string uid) => UserDAL.SelectStudentPassword(uid);
    }
}
