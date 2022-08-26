using SqlSugar;
namespace Model
{
    [SugarTable("sr_good_copy")]
    public class GoodCopy
    {
        /// <summary>
        /// ID
        /// </summary>
        public int GID { get; set; }
        public int State { get; set; }
        public string UserID { get; set; }
        public double A1sleepTime { get; set; }
        public double A2upTime { get; set; }
        public double A3noonNap { get; set; }
        public double A4averageTime { get; set; }
        public double A5sleepQuality { get; set; }
        public double A6snore { get; set; }
        public double B1fitCold { get; set; }
        public double B2fitHot { get; set; }
        public double B3airCon { get; set; }
        public double B4minTem { get; set; }
        public double B5maxTem { get; set; }
        public double C1shower { get; set; }
        public double C2cleanDesk { get; set; }
        public double C3cleanRubbish { get; set; }
        public double C4makeBed { get; set; }
        public double C5washCloth { get; set; }
        public double D1smoke { get; set; }
        public double D2game { get; set; }
        public double D3volume { get; set; }
        public double D4express { get; set; }
        public double D5coConsum { get; set; }
        public double D6elec { get; set; }
        public double D7con { get; set; }
        public double D8unCon { get; set; }
        public double D9coat { get; set; }
        public double D10uWear { get; set; }
        public double D11maq { get; set; }
        public double D12outSide { get; set; }
        public double E1income { get; set; }
        public double E2perConsum { get; set; }
        public double F1sing { get; set; }
        public double F2musIns { get; set; }
        public double F3dance { get; set; }
        public double F4draw { get; set; }
        public double F5white { get; set; }
        public double F6ball { get; set; }
        public double F7tennis { get; set; }
        public double F8run { get; set; }
        public double F9bodyBuild { get; set; }
        public double F10yoga { get; set; }
        public double F11swim { get; set; }
        public double F12movie { get; set; }
        public double F13live { get; set; }
        public double F14claMusic { get; set; }
        public double F15idol { get; set; }
        public double F16ktv { get; set; }
        public double G1sexOrient { get; set; }
        public double G2noSingle { get; set; }
        public double G3inDisea { get; set; }
        public double G4family { get; set; }
        public double G5parent { get; set; }
        public double G6interact { get; set; }
    }
}
