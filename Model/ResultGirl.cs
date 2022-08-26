using SqlSugar;
using System;

namespace Model
{
    [SugarTable("sr_resultGirl")]
    public class ResultGirl
    {
        /// <summary>
        /// ID
        /// </summary>
        public int RID { get; set; }
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }
        public string Class { get; set; }
        public int State { get; set; }
        public int Building { get; set; }
        public int Room { get; set; }
    }
}
