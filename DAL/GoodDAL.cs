using System.Data;
using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using PCC;

namespace DAL
{
    public class GoodDAL : SqlSugarBase
    {
        /// <summary>
        /// 更新Good表中某一个学生的A部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateA(Good A)
        {
            var result = DB.Updateable(A)
                .UpdateColumns(it => new {
                    it.A1sleepTime,
                    it.A2upTime,
                    it.A3noonNap,
                    it.A4averageTime,
                    it.A5sleepQuality,
                    it.A6snore,
                })
                .Where(it => it.UserID == A.UserID)
                .ExecuteCommand();
            return result > 0;
        }
         /// <summary>
         /// 更新Good表中某一个学生的B部分的信息
         /// </summary>
         /// <param name="A1"></param>
         /// <returns></returns>
        public static bool UpdateB(Good B)
        {
            var result = DB.Updateable(B)
                .UpdateColumns(it => new {
                    it.B1fitCold,
                    it.B2fitHot,
                    it.B3airCon,
                    it.B4minTem,
                    it.B5maxTem
                })
                .Where(it => it.UserID == B.UserID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 更新Good表中某一个学生的C部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateC(Good C)
        {
            var result = DB.Updateable(C)
                .UpdateColumns(it => new {
                    it.C1shower,
                    it.C2cleanDesk,
                    it.C3cleanRubbish,
                    it.C4makeBed,
                    it.C5washCloth
                })
                .Where(it => it.UserID == C.UserID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 更新Good表中某一个学生的D部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateD(Good D)
        {
            var result = DB.Updateable(D)
                .UpdateColumns(it => new {
                    it.D1smoke,
                    it.D2game,
                    it.D3volume,
                    it.D4express,
                    it.D5coConsum,
                    it.D6elec,
                    it.D7con,
                    it.D8unCon,
                    it.D9coat,
                    it.D10uWear,
                    it.D11maq,
                    it.D12outSide
                })
                .Where(it => it.UserID == D.UserID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 更新Good表中某一个学生的E部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateE(Good E)
        {
            var result = DB.Updateable(E)
                .UpdateColumns(it => new {
                    it.E1income,
                    it.E2perConsum
                })
                .Where(it => it.UserID == E.UserID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 更新Good表中某一个学生的F部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateF(Good F)
        {
            var result = DB.Updateable(F)
                .UpdateColumns(it => new {
                    it.F1sing,
                    it.F2musIns,
                    it.F3dance,
                    it.F4draw,
                    it.F5white,
                    it.F6ball,
                    it.F7tennis,
                    it.F8run,
                    it.F9bodyBuild,
                    it.F10yoga,
                    it.F11swim,
                    it.F12movie,
                    it.F13live,
                    it.F14claMusic,
                    it.F15idol,
                    it.F16ktv
                })
                .Where(it => it.UserID == F.UserID)
                .ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        /// 更新Good表中某一个学生的G部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateG(Good G)
        {
            var result = DB.Updateable(G)
                .UpdateColumns(it => new {
                    it.G1sexOrient,
                    it.G2noSingle,
                    it.G3inDisea,
                    it.G4family,
                    it.G5parent,
                    it.G6interact
                })
                .Where(it => it.UserID == G.UserID)
                .ExecuteCommand();
            return result > 0;
        }
    }
}
