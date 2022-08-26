using SqlSugar;
using System;

namespace Model
{
    [SugarTable("sr_message")]
    public class Message
    {
        /// <summary>
        /// ID
        /// </summary>
        public int MID { get; set; }
        public string Send { get; set; }
        public string Accept { get; set; }
        public int Read { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public string reContent { get; set; }
        public string Type { get; set; }
        public int Delect { get; set; }
    }
}
