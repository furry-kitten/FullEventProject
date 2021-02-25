using System;
using System.Collections.Generic;
using System.Text;

namespace DBLib
{
    public static class Constants
    {
        public static readonly string HomeConnectionString = @"Data Source=DESKTOP-491MMIU\SQLDEV1101;User ID=sa;Password=Tok_Vol583;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static readonly string OutSorceConnectionString = "";
        public static readonly string CreatingString = @"Server=DESKTOP-491MMIU\SQLDEV1101;Database=EventDataBase;Trusted_Connection=True;";
        public static readonly string DefaultAPIUrl = @"https://localhost:44388/";
    }
}
