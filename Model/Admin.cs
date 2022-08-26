using SqlSugar;
using System;

namespace Model
{
    [SugarTable("sr_admin")]
    public class Admin
    {
        /// <summary>
        /// ID
        /// </summary>
        public string JobNumber { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public int Type{ get; set; }
        public string Phone { get; set; }
    }
}
