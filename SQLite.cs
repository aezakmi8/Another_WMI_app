using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;

namespace Another_WMI_app
{
    class SQLite
    {
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteDataAdapter adapter;
        //-----------------------------SQLiteShit--------------------------

        public void InitialiseTables()
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = string.Format("CREATE TABLE Users; + CREATE TABLE Proc; + CREATE TABLE InsApps;");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
        }

        public void SaveDataTable(DataTable DT)
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM {0}", DT.TableName);
                adapter = new SQLiteDataAdapter(cmd);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                adapter.Update(DT);
                con.Close();
            }
            catch (Exception Ex)
            {
                System.Windows.MessageBox.Show(Ex.Message);
            }
        }

        public DataTable GetDataTable(string tablename)
        {
            DataTable DT = new DataTable();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM {0}", tablename);
            adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(DT);
            con.Close();
            DT.TableName = tablename;
            return DT;
        }
    }
}
