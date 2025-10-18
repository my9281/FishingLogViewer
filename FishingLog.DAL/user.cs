using FishingLog.DBUtility;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
namespace FishingLog.DAL
{
    /// <summary>
    /// 数据访问类:user
    /// </summary>
    public partial class user
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "user");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from user");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(FishingLog.Model.user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into user(");
            strSql.Append("username,password,nickname,birthday,isadmin,location)");
            strSql.Append(" values (");
            strSql.Append("@username,@password,@nickname,@birthday,@isadmin,@location)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,50),
                    new MySqlParameter("@password", MySqlDbType.VarChar,50),
                    new MySqlParameter("@nickname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@birthday", MySqlDbType.Date),
                    new MySqlParameter("@isadmin", MySqlDbType.Bit,1),
                    new MySqlParameter("@location", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.password;
            parameters[2].Value = model.nickname;
            parameters[3].Value = model.birthday;
            parameters[4].Value = model.isadmin;
            parameters[5].Value = model.location;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FishingLog.Model.user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update user set ");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("nickname=@nickname,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("isadmin=@isadmin,");
            strSql.Append("location=@location");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,50),
                    new MySqlParameter("@password", MySqlDbType.VarChar,50),
                    new MySqlParameter("@nickname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@birthday", MySqlDbType.Date),
                    new MySqlParameter("@isadmin", MySqlDbType.Bit,1),
                    new MySqlParameter("@location", MySqlDbType.VarChar,50),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.password;
            parameters[2].Value = model.nickname;
            parameters[3].Value = model.birthday;
            parameters[4].Value = model.isadmin;
            parameters[5].Value = model.location;
            parameters[6].Value = model.id;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public FishingLog.Model.user? GetModel(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username,password,nickname,birthday,isadmin,location from user ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id",id)
            };
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public FishingLog.Model.user DataRowToModel(DataRow row)
        {
            FishingLog.Model.user model = new FishingLog.Model.user();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["nickname"] != null)
                {
                    model.nickname = row["nickname"].ToString();
                }
                if (row["birthday"] != null && row["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(row["birthday"].ToString());
                }
                if (row["isadmin"] != null)
                {
                    model.isadmin = row["isadmin"]?.ToString().Equals("true", StringComparison.CurrentCultureIgnoreCase);
                }
                if (row["location"] != null)
                {
                    model.location = row["location"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username,password,nickname,birthday,isadmin,location ");
            strSql.Append(" FROM user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from user T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }



        #region  ExtensionMethod
        public string? GetListByPage(string username, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username,password,nickname,birthday,isadmin,location from user ");
            strSql.Append(" where username=@username and password=@password");
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha512.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                var ps = sb.ToString().Substring(0, 32);
                MySqlParameter[] parameters = { new MySqlParameter("@username", username), new MySqlParameter("@password", ps) };
                DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return DataRowToModel(ds.Tables[0].Rows[0]).id.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public string? Regist(Model.user user)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(user.password ?? "");
                byte[] hashBytes = sha512.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                var ps = sb.ToString().Substring(0, 32);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("CALL `user_insert`(@username, @password, @nickname,@birthday, 0, @location);");
                MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,50),
                    new MySqlParameter("@password", MySqlDbType.VarChar,50),
                    new MySqlParameter("@nickname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@birthday", MySqlDbType.Date),
                    new MySqlParameter("@isadmin", MySqlDbType.Bit,1),
                    new MySqlParameter("@location", MySqlDbType.VarChar,50)};
                parameters[0].Value = user.username;
                parameters[1].Value = ps;
                parameters[2].Value = user.nickname;
                parameters[3].Value = user.birthday;
                parameters[4].Value = 0;
                parameters[5].Value = "";

                DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
                var row = ds?.Tables?[0].Rows?[0]?[0]?.ToString();
                return row;
            }
        }
        #endregion  ExtensionMethod
    }
}

