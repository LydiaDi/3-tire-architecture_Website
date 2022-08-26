using SqlSugar;
namespace Model
{
    [SugarTable("sr_user")]
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Identity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public string College { get; set; }
        public string Major { get; set; }
        public string Class{ get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
    }
}
