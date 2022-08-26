using System.Data;
using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using PCC;

namespace DAL
{
    public class AdminDAL : SqlSugarBase
    {
        /// <summary>
        /// 根据jobnumber找到名字
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectName(string uid)
        {
            var getCollege = DB.Queryable<Admin>().First(it => it.JobNumber == uid);//查询单条
            return getCollege.Name;
        }
        /// <summary>
        /// 根据jobnumber找到身份证号
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectIdentity(string uid)
        {
            var getCollege = DB.Queryable<Admin>().First(it => it.JobNumber == uid);//查询单条
            return getCollege.ID;
        }
        /// <summary>
        /// 根据jobnumber找到所在学院
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectCollege (string uid)
        {
            var getCollege = DB.Queryable<Admin>().First(it => it.JobNumber == uid);//查询单条
            return getCollege.College;
        }
        /// <summary>
        /// 根据jobnumber找到管理员类型
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int SelectType(string uid)
        {
            var getCollege = DB.Queryable<Admin>().First(it => it.JobNumber == uid);//查询单条
            return getCollege.Type;
        }
        /// <summary>
        /// 根据jobnumber找到联系方式
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectPhone(string uid)
        {
            var getCollege = DB.Queryable<Admin>().First(it => it.JobNumber == uid);//查询单条
            return getCollege.Phone;
        }
        /// <summary>
        /// 找到所有的学生信息
        /// </summary>
        /// <returns></returns>
        public static DataTable AllStudentInfo()
        {
            return DB.Queryable<User>().Select(it => new {
                it.Identity,
                it.Email,
                it.Password,
                it.Name,
                it.StudentNumber,
                it.College,
                it.Major,
                it.Class,
                it.Sex
            }).ToDataTable();
        }
        /// <summary>
        /// 查找对应学生是否填写了good表中的内容
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static bool GoodDetailIsAny(string iden)
        {
            return DB.Queryable<Good>().Where(it => it.UserID == iden&&it.State==1).Any();
        }
        /// <summary>
        /// 寻找特定uid的gooddetail
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static DataTable StudentGoodDetail(string uid)
        {
            return DB.Queryable<User,Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.UserID == uid && g.State == 1)
                .Select((u, g) => new {
                    u.Name,
                    u.Sex,
                    g.A1sleepTime,
                    g.A2upTime,
                    g.A3noonNap,
                    g.A4averageTime,
                    g.A5sleepQuality,
                    g.A6snore,
                    g.B1fitCold,
                    g.B2fitHot
                })
                .ToDataTable();
        }
        public static DataTable StudentGoodDetail2(string uid)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.UserID == uid && g.State == 1)
                .Select((u, g) => new {
                    g.B3airCon,
                    g.B4minTem,
                    g.B5maxTem,
                    g.C1shower,
                    g.C2cleanDesk,
                    g.C3cleanRubbish,
                    g.C4makeBed,
                    g.C5washCloth,
                    
                })
                .ToDataTable();
        }
        public static DataTable StudentGoodDetail3(string uid)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.UserID == uid && g.State == 1)
                .Select((u, g) => new {
                    g.D1smoke,
                    g.D2game,
                    g.D3volume,
                    g.D4express,
                    g.D5coConsum,
                    g.D6elec,
                    g.D7con,
                    g.D8unCon
                })
                .ToDataTable();
        }
        public static DataTable StudentGoodDetail4(string uid)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.UserID == uid && g.State == 1)
                .Select((u, g) => new {
                    g.D9coat,
                    g.D10uWear,
                    g.D11maq,
                    g.D12outSide,
                    g.E1income,
                    g.E2perConsum,
                    g.F1sing,
                    g.F2musIns
                })
                .ToDataTable();
        }
        public static DataTable StudentGoodDetail5(string uid)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.UserID == uid && g.State == 1)
                .Select((u, g) => new {
                    g.F3dance,
                    g.F4draw,
                    g.F5white,
                    g.F6ball,
                    g.F7tennis,
                    g.F8run,
                    g.F9bodyBuild,
                    g.F10yoga
                })
                .ToDataTable();
        }
        public static DataTable StudentGoodDetail6(string uid)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.UserID == uid && g.State == 1)
                .Select((u, g) => new {
                    g.F11swim,
                    g.F12movie,
                    g.F13live,
                    g.F14claMusic,
                    g.F15idol,
                    g.F16ktv,
                    g.G1sexOrient,
                    g.G2noSingle
                })
                .ToDataTable();
        }
        public static DataTable StudentGoodDetail7(string uid)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.UserID == uid && g.State == 1)
                .Select((u, g) => new {
                    g.G3inDisea,
                    g.G4family,
                    g.G5parent,
                    g.G6interact
                })
                .ToDataTable();
        }
        /// <summary>
        /// 查看班级为major的班级的是否存在未填写信息的学生
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool NotWriteGoodIsAny(string major)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.State == 0 && u.Major == major)
                .Any();
        }
        /// <summary>
        /// 查询该班级的男生是否已经进行了分配
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool AssignFinishBoy(string major)
        {
            return DB.Queryable<ResultBoy>().Where(it => it.Class == major).Any();
        }
        /// <summary>
        /// 查询该班级的女生是否已经进行了分配，在显示层中没有用到，因为这里默认只要一个班级的男生进行了分配，那么女生一定也进行了分配
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool AssignFinishGirl(string major)
        {
            return DB.Queryable<ResultGirl>().Where(it => it.Class == major).Any();
        }
        /// <summary>
        /// 查看班级为major的班级的未填写信息的同学
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static DataTable NotWriteGood(string major)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => g.State == 0 && u.Major == major)
                .Select((u, g) => new {
                    u.Name,
                    u.Major,
                    u.Sex,
                    u.Identity
                })
                .ToDataTable();
        }
        /// <summary>
        /// 查找同一班级同一性别的所有学生
        /// </summary>
        /// <param name="major"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static DataTable InCommonClassAndSex(string major,string sex)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => u.Major == major && g.State == 1&&u.Sex==sex)
                .Select((u, g) => new {
                    g.UserID,
                    g.A1sleepTime,
                    g.A2upTime,
                    g.A3noonNap,
                    g.A4averageTime,
                    g.A5sleepQuality,
                    g.A6snore,
                    g.B1fitCold,
                    g.B2fitHot,
                    g.B3airCon,
                    g.B4minTem,
                    g.B5maxTem,
                    g.C1shower,
                    g.C2cleanDesk,
                    g.C3cleanRubbish,
                    g.C4makeBed,
                    g.C5washCloth,
                    g.D1smoke,
                    g.D2game,
                    g.D3volume,
                    g.D4express,
                    g.D5coConsum,
                    g.D6elec,
                    g.D7con,
                    g.D8unCon,
                    g.D9coat,
                    g.D10uWear,
                    g.D11maq,
                    g.D12outSide,
                    g.E1income,
                    g.E2perConsum,
                    g.F1sing,
                    g.F2musIns,
                    g.F3dance,
                    g.F4draw,
                    g.F5white,
                    g.F6ball,
                    g.F7tennis,
                    g.F8run,
                    g.F9bodyBuild,
                    g.F10yoga,
                    g.F11swim,
                    g.F12movie,
                    g.F13live,
                    g.F14claMusic,
                    g.F15idol,
                    g.F16ktv,
                    g.G1sexOrient,
                    g.G2noSingle,
                    g.G3inDisea,
                    g.G4family,
                    g.G5parent,
                    g.G6interact
                })
                .ToDataTable();
        }
        /// <summary>
        /// 在goodCopy表中插入查找同一班级同一性别的所有学生的Good表信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool InsertNewGood(GoodCopy g)
        {
            var insert = DB.Insertable(g).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
            return insert > 0;
        }
        /// <summary>
        /// 查找所有的（已填写完good表的）同一性别、同一班级的用户的userID值
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static DataTable InCommonClassAndSex2(string major, string sex)
        {
            return DB.Queryable<User, Good>((u, g) => new JoinQueryInfos(JoinType.Left, u.Identity == g.UserID))
                .Where((u, g) => u.Major == major && g.State == 1 && u.Sex == sex)
                .Select((u, g) => new {
                    g.UserID
                })
                .ToDataTable();
        }
        /// <summary>
        /// 查看此uid是否存在
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool ExistByUID(string uid)
        {
            return DB.Queryable<GoodCopy>().Where(it => it.UserID == uid).Any();
        }
        /// <summary>
        /// 查找GoodCopy表中除myid之外是否还有其他人
        /// </summary>
        /// <param name="myid"></param>
        /// <returns></returns>
        public static bool PeopleGoodIsExist(string myid)
        {
            return DB.Queryable<GoodCopy>().Where(it => it.UserID != myid).Any();
        }
        /// <summary>
        /// 进行分配
        /// </summary>
        /// <param name="myid"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static DataTable AllInfo(string myid, int len)
        {
            DataTable mydt = new DataTable();
            Dictionary<string, Double> ins = PearsonCC.Pearson(len, MyGood(myid), PeopleGood(myid));

            mydt.Columns.Add(new DataColumn("UserID", typeof(string)));
            mydt.Columns.Add(new DataColumn("UserName", typeof(string)));
            mydt.Columns.Add(new DataColumn("datas", typeof(Double)));

            DataRow one = mydt.NewRow();
            one["UserID"] = myid;
            one["UserName"] = "a";//myid所对应的学生姓名，这里没有进行填写
            one["datas"] = 1;
            mydt.Rows.Add(one);

            foreach (KeyValuePair<string, Double> kv in ins)
            {
                var db = DB.Queryable<User>().Where(it => it.Identity.Equals(kv.Key)).Select(it => new {
                    it.Identity,
                    it.Name,
                    datas = kv.Value
                }).ToDataTable();
                //info.Merge(db, false, MissingSchemaAction.AddWithKey);

                DataTable myCartRow = db;
                DataRow dr = mydt.NewRow();
                dr["UserID"] = myCartRow.Rows[0]["Identity"];
                dr["UserName"] = myCartRow.Rows[0]["Name"];
                dr["datas"] = myCartRow.Rows[0]["datas"];
                mydt.Rows.Add(dr);
            }
            return mydt;
        }
        /// <summary>
        /// 在GoodCopy表中查找特定uid的用户的good详细信息[因为UI层是用不到这个方法的，所以没有将这个方法放在BLL层中]
        /// </summary>
        /// <param name="myid"></param>
        /// <returns></returns>
        public static List<GoodCopy> MyGood(string myid)
        {
            return DB.Queryable<GoodCopy>().Where(it => it.UserID == myid).ToList();
        }
        /// <summary>
        /// 在GoodCopy表中查找uid以外的用户的good的详细信息[因为UI层是用不到这个方法的，所以没有将这个方法放在BLL层中]
        /// </summary>
        /// <param name="myid"></param>
        /// <returns></returns>
        public static List<GoodCopy> PeopleGood(string myid)
        {
            return DB.Queryable<GoodCopy>().Where(it => it.UserID != myid).ToList();
        }
        /// <summary>
        /// 删除GoodCopy表中已经分配好的用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool DelectAGood(string uid)
        {
            var delect = DB.Deleteable<GoodCopy>().Where(it => it.UserID == uid).ExecuteCommand();
            return delect > 0;
        }
        /// <summary>
        /// 删除ResultBoy表中已经分配好的特定班级的信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool DelectBoyResult(string major)
        {
            var delect = DB.Deleteable<ResultBoy>().Where(it => it.Class == major).ExecuteCommand();
            return delect > 0;
        }
        /// <summary>
        ///  删除ResultGirl表中已经分配好的特定班级的信息
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static bool DelectGirlResult(string major)
        {
            var delect = DB.Deleteable<ResultGirl>().Where(it => it.Class == major).ExecuteCommand();
            return delect > 0;
        }
        /// <summary>
        /// 在ResultBoy表中插入一条分配结果信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool InsertResultBoy(ResultBoy info)
        {
            var insert = DB.Insertable(info).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
            return insert > 0;
        }
        /// <summary>
        /// 在ResultGirl表中插入一条分配结果信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool InsertResultGirl(ResultGirl info)
        {
            var insert = DB.Insertable(info).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
            return insert > 0;
        }
        /// <summary>
        /// 查找属于特定班级的ResultBoy表中的所有内容
        /// </summary>
        /// <param name="myid"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static DataTable AllResultBoy(string major)
        {
            return DB.Queryable<ResultBoy>().Where(it => it.Class == major)
                .Select(it => new {
                    it.One,
                    it.Two,
                    it.Three,
                    it.Four,
                    it.Building,
                    it.Room,
                    it.State
                })
                .ToDataTable();
        }
        /// <summary>
        /// 查找属于特定班级的ResultGirl表中的所有内容
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static DataTable AllResultGirl(string major)
        {
            return DB.Queryable<ResultGirl>().Where(it => it.Class == major)
                .Select(it => new {
                    it.One,
                    it.Two,
                    it.Three,
                    it.Four,
                    it.Building,
                    it.Room,
                    it.State
                })
                .ToDataTable();
        }
        /// <summary>
        /// 根据uid找到此学生的姓名
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentName(string uid)
        {
            var getName = DB.Queryable<User>().First(it => it.Identity == uid);//查询单条
            return getName.Name;
        }
        /// <summary>
        /// 根据床位1的男学生的uid找到对应行的RID值
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int SelectResultID(string uid)
        {
            var getRID = DB.Queryable<ResultBoy>().First(it => it.One == uid);//查询单条
            return getRID.RID;
        }
        /// <summary>
        /// 根据床位1的女学生的uid找到对应行的RID值
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int SelectResultIDGirl(string uid)
        {
            var getRID = DB.Queryable<ResultGirl>().First(it => it.One == uid);//查询单条
            return getRID.RID;
        }
        /// <summary>
        /// 更新ResultBoy中楼宇和寝室号的信息
        /// </summary>
        /// <param name="boy"></param>
        /// <returns></returns>
        public static bool UpdateRoomInfo(ResultBoy boy)
        {
            var result = DB.Updateable(boy)
                .UpdateColumns(it =>new { it.Building, it.Room})
                .Where(it => it.RID ==boy.RID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 更新ResultGirl中楼宇和寝室号的信息
        /// </summary>
        /// <param name="girl"></param>
        /// <returns></returns>
        public static bool UpdateRoomInfoGirl(ResultGirl girl)
        {
            var update = DB.Updateable(girl).UpdateColumns(it => new { it.Building, it.Room }).ExecuteCommand();
            return update > 0;
        }
        /// <summary>
        /// 将ResultBoy中的State值变为1——即变为已发布状态
        /// </summary>
        /// <param name="boy"></param>
        /// <returns></returns>
        public static bool IssueResult(ResultBoy boy)
        {
            var update = DB.Updateable(boy).UpdateColumns(it => new { it.State }).ExecuteCommand();
            return update > 0;
        }
        /// <summary>
        /// 将ResultGirl中的State值变为1——即变为已发布状态
        /// </summary>
        /// <param name="girl"></param>
        /// <returns></returns>
        public static bool IssueResultGirl(ResultGirl girl)
        {
            var update = DB.Updateable(girl).UpdateColumns(it => new { it.State }).ExecuteCommand();
            return update > 0;
        }
        /// <summary>
        /// 根据JobNumber查找Password
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectPassword(string uid)
        {
            var getCollege = DB.Queryable<Admin>().First(it => it.JobNumber == uid);//查询单条
            return getCollege.Password;
        }
        /// <summary>
        /// 根据uid查找此学生的Password
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string SelectStudentPassword(string uid)
        {
            var getCollege = DB.Queryable<User>().First(it => it.Identity == uid);//查询单条
            return getCollege.Password;
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="girl"></param>
        /// <returns></returns>
        public static bool UpdatePwd(Admin admin)
        {
            var update = DB.Updateable(admin).UpdateColumns(it => new { it.Password }).ExecuteCommand();
            return update > 0;
        }
        /// <summary>
        /// 更新特定学生的密码信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static bool UpdateStudentPwd(User admin)
        {
            var update = DB.Updateable(admin).UpdateColumns(it => new { it.Password }).ExecuteCommand();
            return update > 0;
        }
        /// <summary>
        /// 向数据库中插入新的学生信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static bool InsertNewStudents(User g)
        {
            var insert = DB.Insertable(g).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
            return insert > 0;
        }
        /// <summary>
        /// 向数据库Good表中插入新的学生信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static bool InsertNewStudentInGood(Good g)
        {
            var insert = DB.Insertable(g).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
            return insert > 0;
        }
    }
}
