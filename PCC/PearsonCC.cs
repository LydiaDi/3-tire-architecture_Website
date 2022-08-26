using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCC
{
    public class PearsonCC
    {
        /// <summary>
        /// 对最终计算出的值进行排序
        /// </summary>
        /// <param name="len"></param>
        /// <param name="my"></param>
        /// <param name="people"></param>
        /// <returns></returns>
        public static Dictionary<String, Double> Pearson(int len, List<GoodCopy> my, List<GoodCopy> people)
        {
            //my = Norm(my);
            //people = Norm(people);
            Dictionary<String, Double> P = Pearson(my,people);//计算每一个其他人与“my”这个人的相似度
            if (P.Count<1)//表示没有其它人，返回值为null
            {
                return null;
            }
            var d = P.OrderByDescending(s1 => s1.Value);//排序方法
            Dictionary<String, Double> dat = new Dictionary<string, Double>();//新建一个词典用来存存储排序后的数据
            foreach (KeyValuePair<String, Double> kv in d)//便历d，实现在dat词典中存储排序后的数据
            {
                dat[kv.Key] = Math.Round(kv.Value, 6);//数字6是可改的——表示将计算出来的相似度数据保留几位小数
            }
            if (P.Count>len)//当排序后的数据总数大于传进来的len值时进行如下操作
            {
                Dictionary<String, Double> datas = new Dictionary<string, Double>();//再新建一个词典用来存存储排序后的数据的前len个数据
                int index = 1;
                foreach (KeyValuePair<String, Double> kv in dat)
                {
                    datas[kv.Key] = kv.Value;
                    index++;//用来记录字典datas已经存储了几个数据
                    if (index>len)//当datas中存储了的数据达到了len个时，停止便历字典dat
                    {
                        break;
                    }
                }
                return datas;
            }
            else
            {
                return dat;
            }
        }
        /// <summary>
        /// 计算出people中每个人于my这个人的相似度值
        /// </summary>
        /// <param name="my"></param>
        /// <param name="people"></param>
        /// <returns></returns>
        private static Dictionary<String,Double> Pearson(List<GoodCopy> my, List<GoodCopy> people)
        {
            Dictionary<string, List<Double>> one = Methed(my);//计算my数组中每一组数据中的每一个数据的标准分数（比较特别的是，my数组中只有一组数据）
            List<Double> my_data = one[my[0].UserID];//新建一个列表my_data用来存储one中的一组数据

            Dictionary<string, List<Double>> people_data = Methed(people);//计算people数组中每一组数据中的每一个数据的标准分数

            Double sum = 0;
            Dictionary<String, Double> data = new Dictionary<string, Double>();
            foreach (GoodCopy g in people)//遍历people中的内容
            {
                for (int i = 0; i < my_data.Count; i++)//my_data.Count表示了数据维度的个数——即本系统一共设置了几个问题
                {
                    sum += my_data[i] * people_data[g.UserID][i];//通过[g.UserID][i]可以找到people_data中键为[g.UserID]的数据中第i维度的数据
                }
                data[g.UserID] = sum / (my_data.Count - 1);//通过皮尔逊相关系数计算公式计算出people中每个人于my这个人的相似度值,并将计算出来的值存储在data这个字典中
                sum = 0;//每次sum值都归零，进而进行下一次计算
            }
            return data;
        }
        /// <summary>
        /// 对传进来的List<GoodCopy>类型的数据的每一组数据计算皮尔逊相关系数公式中的标准分数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        private static Dictionary<string, List<Double>> Methed(List<GoodCopy> X)
        {
            List<Double> allData = null;
            Dictionary<string, List<Double>> info = new Dictionary<string, List<Double>>();
            for (int i=0;i< X.Count;i++)
            {
                allData = new List<Double>();//新建一个Double类型的列表用于存储某一组具体数据的值，方便计算标准分数
                GoodCopy g = X[i];
                allData.Add(g.A1sleepTime);
                allData.Add(g.A2upTime);
                allData.Add(g.A3noonNap);
                allData.Add(g.A4averageTime);
                allData.Add(g.A5sleepQuality);
                allData.Add(g.A6snore);
                allData.Add(g.B1fitCold);
                allData.Add(g.B2fitHot);
                allData.Add(g.B3airCon);
                allData.Add(g.B4minTem);
                allData.Add(g.B5maxTem);
                allData.Add(g.C1shower);
                allData.Add(g.C2cleanDesk);
                allData.Add(g.C3cleanRubbish);
                allData.Add(g.C4makeBed);
                allData.Add(g.C5washCloth);
                allData.Add(g.D1smoke);
                allData.Add(g.D2game);
                allData.Add(g.D3volume);
                allData.Add(g.D4express);
                allData.Add(g.D5coConsum);
                allData.Add(g.D6elec);
                allData.Add(g.D7con);
                allData.Add(g.D8unCon);
                allData.Add(g.D9coat);
                allData.Add(g.D10uWear);
                allData.Add(g.D11maq);
                allData.Add(g.D12outSide);
                allData.Add(g.E1income);
                allData.Add(g.E2perConsum);
                allData.Add(g.F1sing);
                allData.Add(g.F2musIns);
                allData.Add(g.F3dance);
                allData.Add(g.F4draw);
                allData.Add(g.F5white);
                allData.Add(g.F6ball);
                allData.Add(g.F7tennis);
                allData.Add(g.F8run);
                allData.Add(g.F9bodyBuild);
                allData.Add(g.F10yoga);
                allData.Add(g.F11swim);
                allData.Add(g.F12movie);
                allData.Add(g.F13live);
                allData.Add(g.F14claMusic);
                allData.Add(g.F15idol);
                allData.Add(g.F16ktv);
                allData.Add(g.G1sexOrient);
                allData.Add(g.G2noSingle);
                allData.Add(g.G3inDisea);
                allData.Add(g.G4family);
                allData.Add(g.G5parent);
                allData.Add(g.G6interact);

                Double Mean_ = Mean(X)[i];//计算这一组数据的平均值
                Double SD_ = SD(X)[i];//计算这一组数据的标准差
                for (int j=0;j<allData.Count;j++)
                {
                    allData[j] = (allData[j] - Mean_) / SD_;//计算这一组数据的标准差
                }
                info[X[i].UserID] = allData;//将计算出来的标准差值以对应人的id为键存进字典allData中
            }
            return info;
        }
        /// <summary>
        /// 计算标准差
        /// </summary>
        /// <param name="DBa"></param>
        /// <returns></returns>
        private static List<Double> SD(List<GoodCopy> DB)
        {
            List<Double> D = new List<Double>();
            List<Double> M = Mean(DB);
            List<Double> D_ = null;
            int index = 0;
            foreach (GoodCopy u in DB)
            {
                D_ = new List<Double>();
                D_.Add(u.A1sleepTime);
                D_.Add(u.A2upTime);
                D_.Add(u.A3noonNap);
                D_.Add(u.A4averageTime);
                D_.Add(u.A5sleepQuality);
                D_.Add(u.A6snore);
                D_.Add(u.B1fitCold);
                D_.Add(u.B2fitHot);
                D_.Add(u.B3airCon);
                D_.Add(u.B4minTem);
                D_.Add(u.B5maxTem);
                D_.Add(u.C1shower);
                D_.Add(u.C2cleanDesk);
                D_.Add(u.C3cleanRubbish);
                D_.Add(u.C4makeBed);
                D_.Add(u.C5washCloth);
                D_.Add(u.D1smoke);
                D_.Add(u.D2game);
                D_.Add(u.D3volume);
                D_.Add(u.D4express);
                D_.Add(u.D5coConsum);
                D_.Add(u.D6elec);
                D_.Add(u.D7con);
                D_.Add(u.D8unCon);
                D_.Add(u.D9coat);
                D_.Add(u.D10uWear);
                D_.Add(u.D11maq);
                D_.Add(u.D12outSide);
                D_.Add(u.E1income);
                D_.Add(u.E2perConsum);
                D_.Add(u.F1sing);
                D_.Add(u.F2musIns);
                D_.Add(u.F3dance);
                D_.Add(u.F4draw);
                D_.Add(u.F5white);
                D_.Add(u.F6ball);
                D_.Add(u.F7tennis);
                D_.Add(u.F8run);
                D_.Add(u.F9bodyBuild);
                D_.Add(u.F10yoga);
                D_.Add(u.F11swim);
                D_.Add(u.F12movie);
                D_.Add(u.F13live);
                D_.Add(u.F14claMusic);
                D_.Add(u.F15idol);
                D_.Add(u.F16ktv);
                D_.Add(u.G1sexOrient);
                D_.Add(u.G2noSingle);
                D_.Add(u.G3inDisea);
                D_.Add(u.G4family);
                D_.Add(u.G5parent);
                D_.Add(u.G6interact);

                double sum = 0;
                for (int i = 0; i < 52; i++)
                {
                    sum = Math.Pow((D_[i] - M[index]), 2.0) + sum;
                }

                //Double a = Math.Pow((D_[0] - M[index]), 2.0) + Math.Pow((D_[1] - M[index]), 2.0) + Math.Pow((D_[2] - M[index]), 2.0);
                Double a = sum;
                Double c = a / 51.0;//注意:计算标准差时，分母除的是n-1!
                Double b = Math.Sqrt(c);//开方
                D.Add(b);
                index++;
            }
            return D;
        }
        /// <summary>
        /// 计算平均值
        /// </summary>
        /// <returns>返回平均值</returns>
        private static List<Double> Mean(List<GoodCopy> DB)
        {
            List<Double> Mean_= null;
            List<Double> Avg = new List<Double>();

            foreach (GoodCopy u in DB)
            {
                Mean_ = new List<Double>();
                Mean_.Add(u.A1sleepTime);
                Mean_.Add(u.A2upTime);
                Mean_.Add(u.A3noonNap);
                Mean_.Add(u.A4averageTime);
                Mean_.Add(u.A5sleepQuality);
                Mean_.Add(u.A6snore);
                Mean_.Add(u.B1fitCold);
                Mean_.Add(u.B2fitHot);
                Mean_.Add(u.B3airCon);
                Mean_.Add(u.B4minTem);
                Mean_.Add(u.B5maxTem);
                Mean_.Add(u.C1shower);
                Mean_.Add(u.C2cleanDesk);
                Mean_.Add(u.C3cleanRubbish);
                Mean_.Add(u.C4makeBed);
                Mean_.Add(u.C5washCloth);
                Mean_.Add(u.D1smoke);
                Mean_.Add(u.D2game);
                Mean_.Add(u.D3volume);
                Mean_.Add(u.D4express);
                Mean_.Add(u.D5coConsum);
                Mean_.Add(u.D6elec);
                Mean_.Add(u.D7con);
                Mean_.Add(u.D8unCon);
                Mean_.Add(u.D9coat);
                Mean_.Add(u.D10uWear);
                Mean_.Add(u.D11maq);
                Mean_.Add(u.D12outSide);
                Mean_.Add(u.E1income);
                Mean_.Add(u.E2perConsum);
                Mean_.Add(u.F1sing);
                Mean_.Add(u.F2musIns);
                Mean_.Add(u.F3dance);
                Mean_.Add(u.F4draw);
                Mean_.Add(u.F5white);
                Mean_.Add(u.F6ball);
                Mean_.Add(u.F7tennis);
                Mean_.Add(u.F8run);
                Mean_.Add(u.F9bodyBuild);
                Mean_.Add(u.F10yoga);
                Mean_.Add(u.F11swim);
                Mean_.Add(u.F12movie);
                Mean_.Add(u.F13live);
                Mean_.Add(u.F14claMusic);
                Mean_.Add(u.F15idol);
                Mean_.Add(u.F16ktv);
                Mean_.Add(u.G1sexOrient);
                Mean_.Add(u.G2noSingle);
                Mean_.Add(u.G3inDisea);
                Mean_.Add(u.G4family);
                Mean_.Add(u.G5parent);
                Mean_.Add(u.G6interact);

                double sum = 0;
                for(int i=0;i<52; i++)
                {
                    sum = Mean_[i] + sum;
                }
                Avg.Add((sum) / 52.0);
            }
            return Avg;
        }
    }
}
