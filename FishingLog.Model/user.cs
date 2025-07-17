namespace FishingLog.Model
{
    /// <summary>
    /// user:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
	public partial class user
	{ 
		public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? nickname { get; set; }
        public bool? isadmin { get; set; }
        public string? location { get; set; }
        public DateTime birthday { get; set; }

    }
}

