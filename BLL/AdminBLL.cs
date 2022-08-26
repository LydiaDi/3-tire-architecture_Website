using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class AdminBLL
    {
        /// <summary>
        /// 根据jobnumber找到名字
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectName(string uid) => AdminDAL.SelectName(uid);
        /// <summary>
        /// 根据jobnumber找到身份证号
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectIdentity(string uid) => AdminDAL.SelectIdentity(uid);
        /// <summary>
        /// 根据jobnumber找到所在学院
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectCollege(string uid) => AdminDAL.SelectCollege(uid);
        /// <summary>
        /// 根据jobnumber找到管理员类型
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int SelectType(string uid) => AdminDAL.SelectType(uid);
        /// <summary>
        /// 根据jobnumber找到联系方式
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectPhone(string uid) => AdminDAL.SelectPhone(uid);
        /// <summary>
        /// 找到所有的学生信息
        /// </summary>
        /// <returns></returns>
        public static DataTable AllStudentInfo() => AdminDAL.AllStudentInfo();
        /// <summary>
        /// 查找对应学生是否填写了good表中的内容
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static bool GoodDetailIsAny(string iden) => AdminDAL.GoodDetailIsAny(iden);
        /// <summary>
        /// 寻找特定uid的gooddetail
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable StudentGoodDetail(string uid) => AdminDAL.StudentGoodDetail(uid);
        public static DataTable StudentGoodDetail2(string uid) => AdminDAL.StudentGoodDetail2(uid);
        public static DataTable StudentGoodDetail3(string uid) => AdminDAL.StudentGoodDetail3(uid);
        public static DataTable StudentGoodDetail4(string uid) => AdminDAL.StudentGoodDetail4(uid);
        public static DataTable StudentGoodDetail5(string uid) => AdminDAL.StudentGoodDetail5(uid);
        public static DataTable StudentGoodDetail6(string uid) => AdminDAL.StudentGoodDetail6(uid);
        public static DataTable StudentGoodDetail7(string uid) => AdminDAL.StudentGoodDetail7(uid);
        /// <summary>
        /// 查看班级为major的班级的是否存在未填写信息的学生
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool NotWriteGoodIsAny(string major) => AdminDAL.NotWriteGoodIsAny(major);
        /// <summary>
        /// 查询该班级的男生是否已经进行了分配
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool AssignFinishBoy(string major) => AdminDAL.AssignFinishBoy(major);
        /// <summary>
        /// 查询该班级的女生是否已经进行了分配，在显示层中没有用到，因为这里默认只要一个班级的男生进行了分配，那么女生一定也进行了分配
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool AssignFinishGirl(string major) => AdminDAL.AssignFinishGirl(major);
        /// <summary>
        /// 查看班级为major的班级的未填写信息的同学
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static DataTable NotWriteGood(string major) => AdminDAL.NotWriteGood(major);
        /// <summary>
        /// 查找同一班级同一性别的所有学生
        /// </summary>
        /// <param name="major"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static DataTable InCommonClassAndSex(string major, string sex) => AdminDAL.InCommonClassAndSex(major,sex);

        /// <summary>
        /// 在goodCopy表中插入查找同一班级同一性别的所有学生的Good表信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool InsertNewGood(GoodCopy g) => AdminDAL.InsertNewGood(g);
        /// <summary>
        /// 查找所有的（已填写完good表的）同一性别、同一班级的用户的userID值
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static DataTable InCommonClassAndSex2(string major, string sex) => AdminDAL.InCommonClassAndSex2(major, sex);
        /// <summary>
        /// 查看此uid是否存在
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool ExistByUID(string uid) => AdminDAL.ExistByUID(uid);
        /// <summary>
        /// 查找GoodCopy表中除myid之外是否还有其他人
        /// </summary>
        /// <param name="myid"></param>
        /// <returns></returns>
        public static bool PeopleGoodIsExist(string myid) => AdminDAL.PeopleGoodIsExist(myid);
        /// <summary>
        /// 进行分配
        /// </summary>
        /// <param name="myid"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static DataTable AllInfo(string myid, int len) => AdminDAL.AllInfo(myid, len);

        /// <summary>
        /// 删除GoodCopy表中已经分配好的用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool DelectAGood(string uid) => AdminDAL.DelectAGood(uid);
        /// <summary>
        /// 删除ResultBoy表中已经分配好的特定班级的信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool DelectBoyResult(string major) => AdminDAL.DelectBoyResult(major);
        /// <summary>
        ///  删除ResultGirl表中已经分配好的特定班级的信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool DelectGirlResult(string major) => AdminDAL.DelectGirlResult(major);
        // <summary>
        /// 在ResultBoy表中插入一条分配结果信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool InsertResultBoy(ResultBoy info) => AdminDAL.InsertResultBoy(info);
        /// <summary>
        /// 在ResultGirl表中插入一条分配结果信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool InsertResultGirl(ResultGirl info) => AdminDAL.InsertResultGirl(info);
        /// <summary>
        /// 查找属于特定班级的ResultBoy表中的所有内容
        /// </summary>
        /// <param name="myid"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static DataTable AllResultBoy(string major) => AdminDAL.AllResultBoy(major);
        /// <summary>
        /// 查找属于特定班级的ResultGirl表中的所有内容
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static DataTable AllResultGirl(string major) => AdminDAL.AllResultGirl(major);
        /// <summary>
        /// 根据uid找到此学生的姓名
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentName(string uid) => AdminDAL.SelectStudentName(uid);
        /// <summary>
        /// 根据床位1的男学生的uid找到对应行的RID值
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int SelectResultID(string uid) => AdminDAL.SelectResultID(uid);
        /// <summary>
        /// 根据床位1的女学生的uid找到对应行的RID值
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int SelectResultIDGirl(string uid) => AdminDAL.SelectResultIDGirl(uid);
        /// <summary>
        /// 更新ResultBoy中楼宇和寝室号的信息
        /// </summary>
        /// <param name="boy"></param>
        /// <returns></returns>
        public static bool UpdateRoomInfo(ResultBoy boy) => AdminDAL.UpdateRoomInfo(boy);
        /// <summary>
        /// 更新ResultGirl中楼宇和寝室号的信息
        /// </summary>
        /// <param name="girl"></param>
        /// <returns></returns>
        public static bool UpdateRoomInfoGirl(ResultGirl girl) => AdminDAL.UpdateRoomInfoGirl(girl);
        /// <summary>
        /// 将ResultBoy中的State值变为1——即变为已发布状态
        /// </summary>
        /// <param name="boy"></param>
        /// <returns></returns>
        public static bool IssueResult(ResultBoy boy) => AdminDAL.IssueResult(boy);
        /// <summary>
        /// 将ResultGirl中的State值变为1——即变为已发布状态
        /// </summary>
        /// <param name="girl"></param>
        /// <returns></returns>
        public static bool IssueResultGirl(ResultGirl girl) => AdminDAL.IssueResultGirl(girl);
        /// <summary>
        /// 根据JobNumber查找Password
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectPassword(string uid) => AdminDAL.SelectPassword(uid);
        /// <summary>
        /// 根据uid查找此学生的Password
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentPassword(string uid) => AdminDAL.SelectStudentPassword(uid);
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="girl"></param>
        /// <returns></returns>
        public static bool UpdatePwd(Admin admin) => AdminDAL.UpdatePwd( admin);
        /// <summary>
        /// 更新特定学生的密码信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static bool UpdateStudentPwd(User admin) => AdminDAL.UpdateStudentPwd(admin);
        /// <summary>
        /// 向数据库中插入新的学生信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static bool InsertNewStudents(User g) => AdminDAL.InsertNewStudents(g);
        /// <summary>
        /// 向数据库Good表中插入新的学生信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static bool InsertNewStudentInGood(Good g) => AdminDAL.InsertNewStudentInGood(g);
    }
}
