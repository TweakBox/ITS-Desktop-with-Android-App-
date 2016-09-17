using System;
using System.Windows.Forms;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/// <summary>
/// A class to handle most MySql transactions
/// </summary>
public class Database
{
    public MySqlConnection Connection;
    public MySqlCommand Command = new MySqlCommand();
    public MySqlDataReader Reader;

    /// <summary>
    /// A class to handle most MySql transactions
    /// </summary>
    /// <param name="database">The database to be used</param>
    /// <param name="datasource">The datasource to connect</param>
    public Database(string datasource = "127.0.0.1", string database = "jsla")
    {
        //while (true)
        //    try
        //    {
        //        _con = new MySqlConnection("datasource = " + datasource + "; user = root; database = " + database + ';');
        //        _con.Open();
        //        break;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        DialogResult result = MessageBox.Show("Unable to reach server. Would you like to try connecting?.\r\nError code:\r\n" + ex.Message, "Connection error!", MessageBoxButtons.RetryCancel);
        //        if (result != DialogResult.Retry)
        //        {
        //            Application.Exit();
        //            return;
        //        }
        //    }
        //_com = new MySqlCommand();
        //_com.Connection = _con;
        //_con.ChangeDatabase(database);
        Connection = new MySqlConnection("datasource=" + datasource + "; user=root; database=" + database + ';');
    }

    public bool TryOpenConnection()
    {
        if (Connection != null && Connection.State == System.Data.ConnectionState.Closed)
            try
            {
                Connection.Open();
                Command.Connection = Connection;
                return true;
            }
            catch (MySqlException) { return false; }
        else
            return true;
    }

    public bool TryCloseConnection()
    {
        if (Connection.State != System.Data.ConnectionState.Closed)
            try { Connection.Close(); return true; }
            catch (MySqlException) { return false; }
        else
            return true;
    }

    /////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Scans the selected table and returns a jagged string array as a result.
    /// </summary>
    /// <param name="table">The table to be scanned.</param>
    /// <param name="columns">The specific columns to be returned.</param>
    /// <param name="condition">The condition to be applied for retrieving the result</param>
    /// <returns>The scanned records.</returns>
    public object[,] ScanRecords(string table, string[] columns, string condition)
    {
        string selectedColumns = columns[0];
        for (int i = 1; i < columns.Length; i++)
            selectedColumns += ", " + columns[i];

        Command.CommandText = "select " + selectedColumns + " from " + table + " where " + condition;
        Reader = Command.ExecuteReader();
        if (Reader.HasRows)
        {
            int cnt = 0;
            while (Reader.Read())
                cnt++;

            object[,] records = new object[cnt, Reader.FieldCount];
            Reader.Close();

            Reader = Command.ExecuteReader();
            cnt = 0;
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                    records[cnt, i] = Reader[i];
                cnt++;
            }
            Reader.Close();

            return records;
        }
        else
        {
            Reader.Close();
            return new object[0, 0];
        }
    }

    /// <summary>
    /// Scans the selected table and returns a jagged string array as a result.
    /// </summary>
    /// <param name="table">The table to be scanned.</param>
    /// <param name="columns">The specific columns to be returned.</param>
    /// <returns>The scanned records.</returns>
    public object[,] ScanRecords(string table, params string[] columns)
    {
        string selectedColumns = columns[0];
        for (int i = 1; i < columns.Length; i++)
            selectedColumns += ", " + columns[i];

        Command.CommandText = "select " + selectedColumns + " from " + table;
        Reader = Command.ExecuteReader();
        if (Reader.HasRows)
        {
            int cnt = 0;
            while (Reader.Read())
                cnt++;

            object[,] records = new object[cnt, Reader.FieldCount];
            Reader.Close();

            Reader = Command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                for (int i2 = 0; i2 < Reader.FieldCount; i2++)
                    records[i, i2] = Reader[i2];
                i++;
            }
            Reader.Close();

            return records;
        }
        else
        {
            Reader.Close();
            return new object[0, 0];
        }
    }

    /// <summary>
    /// Scans the selected table and returns a jagged string array as a result.
    /// </summary>
    /// <param name="table">The table to be scanned.</param>
    /// <returns>The scanned records.</returns>
    public object[,] ScanRecords(string table)
    {

        Command.CommandText = "select * from " + table;
        Reader = Command.ExecuteReader();
        if (Reader.HasRows)
        {
            int cnt = 0;
            while (Reader.Read())
                cnt++;

            object[,] records = new object[cnt, Reader.FieldCount];
            Reader.Close();

            Reader = Command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                for (int i2 = 0; i2 < Reader.FieldCount; i2++)
                    records[i, i2] = Reader[i2];
                i++;
            }
            Reader.Close();

            return records;
        }
        else
        {
            Reader.Close();
            return new object[0, 0];
        }
    }

    public string ScanRecordScalar(string table, string column)
    {
        Command.CommandText = "select " + column + " from " + table;
        return Command.ExecuteScalar().ToString();
    }

    public string ScanRecordScalar(string table, string column, string condition)
    {
        Command.CommandText = "select " + column + " from " + table + " where " + condition;
        return Command.ExecuteScalar().ToString();
    }

    /////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Inserts a record to a specified table in the database.
    /// </summary>
    /// <example>insertRecord("tblUserAccounts", {"username", "password", "fullname"})</example>
    /// <param name="table">The table to be inserted.</param>
    /// <param name="columns">The columns where the records are to be inserted</param>
    /// <param name="values">The values of the record to be added.</param>
    public bool InsertRecord(string table, string[] columns, string[] values)
    {
        string command = "insert into " + table + "(";

        for (int i = 0; i < columns.Length; i++)
        {
            command += columns[i];
            if (i != columns.Length - 1)
                command += ", ";
        }
        command += ") values(";

        for (int i = 0; i < values.Length; i++)
        {
            command += values[i] != "null" ? "'" + values[i] + "'" : "null";
            if (i != values.Length - 1)
                command += ", ";
        }
        command += ");";


        Command.CommandText = command;
        try
        {
            Command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Exception Occured!", ex.Message + (ex.InnerException != null ? ex.InnerException.Message : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Inserts a record to a specified table in the database.
    /// </summary>
    /// <example>insertRecord("tblUserAccounts", {"username", "password", "fullname"})</example>
    /// <param name="table">The table to be inserted.</param>
    /// <param name="values">The Values of the record to be added.</param>
    public bool InsertRecord(string table, params string[] values)
    {
        string command = "insert into " + table + " values(";
        for (int i = 0; i < values.Length; i++)
        {
            command += values[i] != "null" ? "'" + values[i] + "'" : "null";
            if (i != values.Length - 1)
                command += ", ";
        }
        command += ");";


        Command.CommandText = command;
        try
        {
            Command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Exception Occured!", ex.Message + (ex.InnerException != null ? ex.InnerException.Message : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    /////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Updates a record from a specified table in the database.
    /// </summary>
    /// <param name="table">The table to be updated.</param>
    /// <param name="column">The specific column that contains the specific value of the record to be updated.</param>
    /// <param name="columnValue">A specific value of the record to be updated.</param>
    /// <param name="columns">The columns of the record to be updated.</param>
    /// <param name="values">The values of the record to be updated.</param>
    public bool UpdateRecord(string table, string column, string columnValue, string[] columns, string[] values)
    {
        string setFields = columns[0] + " = '" + values[0] + "'";
        for (int i = 1; i < columns.Length; i++)
            setFields += ", " + columns[i] + " = '" + values[i] + "'";

        Command.CommandText = "update " + table + " set " + setFields + " where " + column + " = '" + columnValue + "';";
        try
        {
            Command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Exception Occured!", ex.Message + (ex.InnerException != null ? ex.InnerException.Message : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    /////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Deletes a record from a specified table in the database.
    /// </summary>
    /// <param name="table">The table to be updated.</param>
    /// <param name="column">The column that contains the specific value of the record to be deleted.</param>
    /// <param name="columnValue">A specific value of the record to be deleted.</param>
    public void DeleteRecord(string table, string column, string columnValue)
    {
        Command.CommandText = "delete from " + table + " where " + column + " = '" + columnValue + "';";
        Command.ExecuteNonQuery();
    }

    /////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Executes a non-query command.
    /// </summary>
    /// <param name="command">The command to execute</param>
    /// <returns>True if executed successfully</returns>
    public bool ExecuteNonQuery(string command)
    {
        Command.CommandText = command;
        try
        {
            Command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : "", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Executes a query command.
    /// </summary>
    /// <param name="command">The command to execute</param>
    /// <returns>A two-dimensional array of result from the query</returns>
    public object[,] ExecuteQuery(string command)
    {
        Command.CommandText = command;
        Reader = Command.ExecuteReader();
        if (Reader.HasRows)
        {
            int cnt = 0;
            while (Reader.Read())
                cnt++;

            object[,] records = new object[cnt, Reader.FieldCount];
            Reader.Close();

            Reader = Command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                for (int i2 = 0; i2 < Reader.FieldCount; i2++)
                    records[i, i2] = Reader[i2];
                i++;
            }
            Reader.Close();

            return records;
        }
        else
        {
            Reader.Close();
            return new object[0, 0];
        }
    }
}
