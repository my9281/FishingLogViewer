namespace FishingLog.Model
{
    [Serializable]
    public partial class note
    {
        public note() { }
        /// <summary>
        /// auto_increment
        /// </summary>
        public int nid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string nuser { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string ntitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string ntext { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime ntime { get; set; }
        /// <summary>
        /// 发送IP
        /// </summary>
        public string nip { get; set; }
    }
}

