using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сампо.Models;
using System.Data.SqlClient;

namespace Сампо
{
    static class HomeDBConnection
    {
        static public string ConnetionString = "Data Source=DESKTOP-ELQ12AO;Initial Catalog=sampo;User ID=sa;Password=Tok_Vol583;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static public bool AddDancer(Partner partner)
        {
            using (SqlConnection connection = new SqlConnection(ConnetionString))
            {
                SqlCommand search = new SqlCommand($"select * from Dancer where idsha = {partner.IDsha}");
                SqlCommand adddencer = new SqlCommand($"insert into Dancer values ({partner.Name} {partner.Surname} {partner.Phone} {partner.IDsha} {partner.Gender})");

                SqlDataReader reader = search.ExecuteReader();

                if (!reader.HasRows)
                {
                    adddencer.BeginExecuteNonQuery();
                    return true;
                }
                else return false;
            }
        }
    }
}
