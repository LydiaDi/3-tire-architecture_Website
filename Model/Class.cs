using SqlSugar;
namespace Model
{
    [SugarTable("sr_class")]
    public class Class
    {
        /// <summary>
        /// ID
        /// </summary>
        public string College { get; set; }
        public string MajorClass { get; set; }
    }
}
