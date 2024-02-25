using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document
{
    class Function
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter Sda;
        private string Constring;

        public Function()
        {
            Constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\App project\Pange\base de donnee c#\Documentation.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(Constring);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }
        public DataTable RecupererDonnee(String Req)
        {
            dt = new DataTable();
            Sda = new SqlDataAdapter(Req, Constring);
            Sda.Fill(dt);
            return dt;
        }
        public int EnvoyerDonner(string Req)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Req;
            cnt = Cmd.ExecuteNonQuery();
            return cnt;
        }
    }
}
