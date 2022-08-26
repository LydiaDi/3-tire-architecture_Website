using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class GoodBLL
    {
        /// <summary>
        /// 更新Good表中某一个学生的A1部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateA1(Good A) => GoodDAL.UpdateA(A);
        /// <summary>
        /// 更新Good表中某一个学生的B部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateB(Good B) => GoodDAL.UpdateB(B);
        /// <summary>
        /// 更新Good表中某一个学生的C部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateC(Good C) => GoodDAL.UpdateC(C);
        /// <summary>
        /// 更新Good表中某一个学生的D部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateD(Good D) => GoodDAL.UpdateD(D);
        /// <summary>
        /// 更新Good表中某一个学生的E部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateE(Good E) => GoodDAL.UpdateE(E);
        /// <summary>
        /// 更新Good表中某一个学生的F部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateF(Good F) => GoodDAL.UpdateF(F);
        /// <summary>
        /// 更新Good表中某一个学生的G部分的信息
        /// </summary>
        /// <param name="A1"></param>
        /// <returns></returns>
        public static bool UpdateG(Good G) => GoodDAL.UpdateG(G);
    }
}
