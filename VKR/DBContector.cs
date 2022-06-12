using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VKR
{
    class DBContector
    {
        private string connectionString;
        private Exception lastException;
        private SqlConnection connection;
        public string ConnectionString { get => connectionString; private set => connectionString = value; }
        public Exception LastException { get => lastException; private set => lastException = value; }

        public DBContector(string connectionString)
        {
            this.ConnectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public DBContector(string DataSource, string InitialCatolog, string UserID, string Password)
        {
            var ConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = DataSource,
                InitialCatalog = InitialCatolog,
                UserID = UserID,
                Password = Password
            };

            this.ConnectionString = ConnectionStringBuilder.ConnectionString;

            connection = new SqlConnection(ConnectionString);
        }
        public void Dispose()
        {
            connection.Dispose();
        }
        public bool CheckConnection()
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                LastException = ex;
                return false;
            }
            return true;
        }
        public void InsertRow(DataRow dataRow)
        {
            connection.Open();
            string request = $"INSERT INTO {dataRow.Table.TableName} VALUES(";
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                if (dataRow.Table.Columns[i].DataType.Name == "String" ||
                    dataRow.Table.Columns[i].DataType.Name == "DateTime")
                    request += "\'" + dataRow[i].ToString() + "\'";
                else
                    request += dataRow[i].ToString();

                if (i < dataRow.Table.Columns.Count - 1)
                    request += ",";
            }
            request += ")";
            SqlCommand command = new SqlCommand(request, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateRow(DataRow OldDataRow, DataRow NewDataRow)
        {
            connection.Open();
            string request = $"UPDATE {OldDataRow.Table.TableName} SET ";
            for (int i = 0; i < OldDataRow.Table.Columns.Count; i++)
            {
                request += OldDataRow.Table.Columns[i].ColumnName + " = ";
                if (OldDataRow.Table.Columns[i].DataType.Name == "String" ||
                    OldDataRow.Table.Columns[i].DataType.Name == "DateTime")
                    request += "\'" + NewDataRow[i].ToString() + "\'";
                else
                    request += NewDataRow[i].ToString();

                if (i < OldDataRow.Table.Columns.Count - 1)
                    request += ", ";
            }
            request += " WHERE ";
            for (int i = 0; i < OldDataRow.Table.Columns.Count; i++)
            {
                request += OldDataRow.Table.Columns[i].ColumnName + " = ";
                if (OldDataRow.Table.Columns[i].DataType.Name == "String" ||
                    OldDataRow.Table.Columns[i].DataType.Name == "DateTime")
                    request += "\'" + OldDataRow[i].ToString() + "\'";
                else
                    request += OldDataRow[i].ToString();

                if (i < OldDataRow.Table.Columns.Count - 1)
                    request += " AND ";
            }
            SqlCommand command = new SqlCommand(request, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void DeleteRow(DataRow dataRow)
        {
            connection.Open();
            string request = $"DELETE {dataRow.Table.TableName} WHERE ";
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                request += dataRow.Table.Columns[i].ColumnName + " = ";
                if (dataRow.Table.Columns[i].DataType.Name == "String" ||
                    dataRow.Table.Columns[i].DataType.Name == "DateTime")
                    request += "\'" + dataRow[i].ToString() + "\'";
                else
                    request += dataRow[i].ToString();

                if (i < dataRow.Table.Columns.Count - 1)
                    request += " AND ";
            }
            SqlCommand command = new SqlCommand(request, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public string[] GetTableName()
        {
            connection.Open();
            List<string> result = new List<string>();
            SqlCommand command = new SqlCommand($"SELECT INF.TABLE_NAME FROM INFORMATION_SCHEMA.TABLES" +
                                                $" INF WHERE inf.TABLE_NAME != 'sysdiagrams'", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(dataReader.GetString(0));
                }
            }
            connection.Close();
            return result.ToArray();
        }
        public DataTable SelectTable(string tableName)
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();
            return dataTable;
        }
        public DataTable SelectView(string textQuery)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(textQuery, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.Close();
            return dataTable;
        }
        public void ExecuteProcedure(string ProcedureName, params ProcedureParametr[] procedureParametrs)
        {

            connection.Open();
            SqlCommand command = new SqlCommand(ProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < procedureParametrs.Length; i++)
            {
                SqlParameter parameter = new SqlParameter()
                {
                    ParameterName = procedureParametrs[i].Name,
                    Value = procedureParametrs[i].Value
                };
                command.Parameters.Add(parameter);
            }
            command.ExecuteScalar();
            connection.Close();
        }
    }
    public struct ProcedureParametr
        {
            string name;
            object value;

            public ProcedureParametr(string name, object value)
            {
                this.name = name;
                this.value = value;
            }

            public string Name { get => name; set => name = value; }
            public object Value { get => value; set => this.value = value; }
        }
    

}

