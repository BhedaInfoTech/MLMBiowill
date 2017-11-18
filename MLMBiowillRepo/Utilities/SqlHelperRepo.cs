using MLMBiowillHelper.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillRepo.Utilities
{
    public class SqlHelperRepo
    {
        private static string _sqlCon;

        public SqlHelperRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }

        public DataSet ExecuteDataSet(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;
                        sqlCmd.CommandTimeout = 300;
                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                        sqlDA.Fill(ds);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public DataTable ExecuteDataTable(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            DataTable dt = new DataTable();
            try
            {
                Logger.Debug(" Sql Connection : " + _sqlCon + ";");

                Logger.Debug(" Store Procedure/Query Called : " + sqlQuery + ";");

                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    Logger.Debug(" Connection Is Open : " + con.State.ToString() + ";");
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {                                                                
                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;

                        sqlCmd.CommandTimeout = 300;

                        if (sqlParams != null)
                        {   
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                Logger.Debug(" SqlParameter Name and Value   : " + sqlPrm.ParameterName + " ~" +sqlPrm.Value + ";");

                                if (sqlPrm.Value == null)

                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        Logger.Debug(" Sql Parameters Added ;");
                        SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);

                        sqlDA.Fill(dt);

                        Logger.Debug(" Sql Data Recd. Successfully;");

                        sqlCmd.Parameters.Clear();

                    }
                    con.Close();

                    Logger.Debug(" Connection Is Closed : " + con.State.ToString() + ";");
                }
            }
            catch (SqlException sqlEx)
            {
                Logger.Error(" SQL Excepcetion Stack Trace: " + sqlEx.StackTrace + ";");
                Logger.Error(" SQL Excepcetion : " + sqlEx.Message + ";");
                throw sqlEx;
            }
            catch (Exception ex)
            {
                Logger.Error(" Excepcetion Stack Trace: " + ex.StackTrace + ";");
                Logger.Error(" Excepcetion : " + ex.Message + ";");
                throw ex;
            }
            Logger.Debug(" Data Table Return with Rows : " + dt.Rows.Count.ToString() + ";");
            return dt;
        }

        public SqlDataReader ExecuteDataReader(SqlConnection con, List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            SqlDataReader dr;

            try
            {
                using (con)
                {
                    //con.Open();
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.CommandType = cmdType;
                    sqlCmd.CommandTimeout = 300;

                    if (sqlParams != null)
                    {
                        foreach (SqlParameter sqlPrm in sqlParams)
                        {
                            if (sqlPrm.Value == null)
                                sqlPrm.Value = DBNull.Value;
                        }
                        sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                    }

                    dr = sqlCmd.ExecuteReader();
                    //con.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }

            return dr;
        }

        public void ExecuteNonQuery(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;

                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        sqlCmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }
        }

        public object ExecuteScalerObj(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection();

            object result = 0;
            try
            {
                using (con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;

                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        result = sqlCmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }
            return result;
        }


        public void ExecuteNonQueryWithTransaction(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType, SqlTransaction transaction, SqlConnection con)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con, transaction);

                sqlCmd.CommandType = cmdType;

                if (sqlParams != null)
                {
                    foreach (SqlParameter sqlPrm in sqlParams)
                    {
                        if (sqlPrm.Value == null)
                            sqlPrm.Value = DBNull.Value;
                    }
                    sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                }

                sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    throw ex;
            }
        }

        public object ExecuteScalerObjWithTransaction(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType, SqlTransaction transaction, SqlConnection con)
        {

            object result = 0;

            try
            {
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con, transaction);

                sqlCmd.CommandType = cmdType;

                if (sqlParams != null)
                {
                    foreach (SqlParameter sqlPrm in sqlParams)
                    {
                        if (sqlPrm.Value == null)
                            sqlPrm.Value = DBNull.Value;
                    }
                    sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                }

                result = sqlCmd.ExecuteScalar();
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    throw ex;
            }

            return result;
        }


        public void BulkSqlUpload(DataTable dt, string destinationTableName)
        {
            using (var bulkCopy = new SqlBulkCopy(_sqlCon, SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName.Contains("_-"))
                    {
                        col.ColumnName = col.ColumnName.Replace("_-", "/");
                    }

                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }
                //bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = destinationTableName;
                bulkCopy.WriteToServer(dt);
            }
        }
    }
}
