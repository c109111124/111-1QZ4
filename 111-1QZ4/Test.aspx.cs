using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace _111_1QZ4
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_Path = "";
            s_Path = "Data Source=(localdb)\\ProjectModels;" +
                "Initial Catalog=Test;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False;" +
                "User ID = sa; Password = today16";

            try
            {
                SqlConnection o_Conn = new SqlConnection(s_Path); //建立資料庫新連線

                SqlCommand o_com = new SqlCommand("select * from Users", o_Conn); //新增查詢
                o_Conn.Open(); //開啟資料庫
                SqlDataReader o_R = o_com.ExecuteReader(); //順向閱讀查詢結果
                for (;o_R.Read();) //逐行印出資料
                {
                    for (int i_col = 0; i_col < o_R.FieldCount; i_col++) //FieldCount是資料行計數
                    {
                        Response.Write("&nbsp;&nbsp;" + o_R[i_col].ToString()); 
                    }
                    Response.Write("<br /> ");
                }
                o_Conn.Close(); //關閉資料庫

            }
            catch (Exception o_Exc) //例外
            {
                Response.Write(o_Exc.ToString());
            }
        }
    }
}