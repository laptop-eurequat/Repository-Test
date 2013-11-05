using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Zero.DataLayer.Helper
{
    public static class DatSession
    {
        static void  CreateSession()
        {
            const string connectionString = @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae";
            var uow = new UnitOfWork() { ConnectionString = connectionString };
        }

        
    }
}
