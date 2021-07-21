using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace YIIDP
{
    class cSQL
    {
        SqlConnection cn;
       // OleDbConnection cn;
        string ConnectionString;

        public void cSQL_init(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public void Connect()
        {
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = ConnectionString;
                cn.Open();
            }

            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect to SQL Server" + exp.Message);
                return;
            }
        }

        public void Disconnect()
        {
            try
            {
                cn.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect to SQL Server" + exp.Message);
                return;
            }
        }

        public DataTable Query(string SQLstring)
        {
           SqlCommand cm = null;
            try
            {
                cm = new SqlCommand(SQLstring, cn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                
                DataTable _table = new DataTable();
                da.Fill(_table);
                da.Dispose();
                cm.Dispose();
                return _table;
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                cm.Dispose();
                return null;
            }

        }

        public int SetCommand(string SQLstring)
        {
            SqlCommand cm = null;
            int res = -1;
            try
            {
                cm = new SqlCommand(SQLstring, cn);
                res = cm.ExecuteNonQuery();
                cm.Dispose();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("SQL Base Drive.\n" + exp.Message);
                cm.Dispose();
                return res;
            }
            return res;

        }

    }
}
