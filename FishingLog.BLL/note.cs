using System.Data;
namespace FishingLog.BLL 
{
	/// <summary>
	/// note
	/// </summary>
	public partial class note
	{
		private readonly FishingLog.DAL.note dal=new FishingLog.DAL.note();
		public note()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int nid)
		{
			return dal.Exists(nid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FishingLog.Model.note model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishingLog.Model.note model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int nid)
		{
			
			return dal.Delete(nid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string nidlist )
		{
			return dal.DeleteList(nidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishingLog.Model.note GetModel(int nid)
		{
			
			return dal.GetModel(nid);
		}

 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishingLog.Model.note> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishingLog.Model.note> DataTableToList(DataTable dt)
		{
			List<FishingLog.Model.note> modelList = new List<FishingLog.Model.note>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                FishingLog.Model.note model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

        public bool AddNote(Model.note content)
        {
            return dal.AddNote(content);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

