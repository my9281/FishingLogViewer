using FishingLog.DBUtility;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
namespace FishingLog.DAL
{
	/// <summary>
	/// 数据访问类:note
	/// </summary>
	public partial class note
	{
		public note()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("nid", "note"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int nid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from note");
			strSql.Append(" where nid=@nid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@nid", MySqlDbType.Int32)
			};
			parameters[0].Value = nid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FishingLog.Model.note model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into note(");
			strSql.Append("nuser,ntitle,ntext,ntime,nip)");
			strSql.Append(" values (");
			strSql.Append("@nuser,@ntitle,@ntext,@ntime,@nip)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@nuser", MySqlDbType.VarChar,50),
					new MySqlParameter("@ntitle", MySqlDbType.VarChar,50),
					new MySqlParameter("@ntext", MySqlDbType.Text),
					new MySqlParameter("@ntime", MySqlDbType.DateTime),
					new MySqlParameter("@nip", MySqlDbType.VarChar,30)};
			parameters[0].Value = model.nuser;
			parameters[1].Value = model.ntitle;
			parameters[2].Value = model.ntext;
			parameters[3].Value = model.ntime;
			parameters[4].Value = model.nip;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishingLog.Model.note model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update note set ");
			strSql.Append("nuser=@nuser,");
			strSql.Append("ntitle=@ntitle,");
			strSql.Append("ntext=@ntext,");
			strSql.Append("ntime=@ntime,");
			strSql.Append("nip=@nip");
			strSql.Append(" where nid=@nid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@nuser", MySqlDbType.VarChar,50),
					new MySqlParameter("@ntitle", MySqlDbType.VarChar,50),
					new MySqlParameter("@ntext", MySqlDbType.Text),
					new MySqlParameter("@ntime", MySqlDbType.DateTime),
					new MySqlParameter("@nip", MySqlDbType.VarChar,30),
					new MySqlParameter("@nid", MySqlDbType.Int32,11)};
			parameters[0].Value = model.nuser;
			parameters[1].Value = model.ntitle;
			parameters[2].Value = model.ntext;
			parameters[3].Value = model.ntime;
			parameters[4].Value = model.nip;
			parameters[5].Value = model.nid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int nid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from note ");
			strSql.Append(" where nid=@nid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@nid", MySqlDbType.Int32)
			};
			parameters[0].Value = nid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string nidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from note ");
			strSql.Append(" where nid in ("+nidlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishingLog.Model.note GetModel(int nid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select nid,nuser,ntitle,ntext,ntime,nip from note ");
			strSql.Append(" where nid=@nid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@nid", MySqlDbType.Int32)
			};
			parameters[0].Value = nid;

            FishingLog.Model.note model=new FishingLog.Model.note();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishingLog.Model.note DataRowToModel(DataRow row)
		{
			FishingLog.Model.note model = new Model.note();
			if (row != null)
			{
				if(row["nid"]!=null && row["nid"].ToString()!="")
				{
					model.nid=int.Parse(row["nid"].ToString());
				}
				if(row["nuser"]!=null)
				{
					model.nuser=row["nuser"].ToString();
				}
				if(row["ntitle"]!=null)
				{
					model.ntitle=row["ntitle"].ToString();
				}
				if(row["ntext"]!=null)
				{
					model.ntext=row["ntext"].ToString();
				}
				if(row["ntime"]!=null && row["ntime"].ToString()!="")
				{
					model.ntime=DateTime.Parse(row["ntime"].ToString());
				}
				if(row["nip"]!=null)
				{
					model.nip=row["nip"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select nid,nuser,ntitle,ntext,ntime,nip ");
			strSql.Append(" FROM note ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM note ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.nid desc");
			}
			strSql.Append(")AS Row, T.*  from note T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

        public bool AddNote(Model.note model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into note(");
            strSql.Append("nuser,ntitle,ntext,ntime,nip)");
            strSql.Append(" values (");
            strSql.Append("@nuser,@ntitle,@ntext,@ntime,@nip)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@nuser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ntitle", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ntext", MySqlDbType.Text),
                    new MySqlParameter("@ntime", MySqlDbType.DateTime),
                    new MySqlParameter("@nip", MySqlDbType.VarChar,30)};
            parameters[0].Value = model.nuser;
            parameters[1].Value = model.ntitle;
            parameters[2].Value = model.ntext;
            parameters[3].Value = model.ntime;
            parameters[4].Value = model.nip;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "note";
			parameters[1].Value = "nid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

