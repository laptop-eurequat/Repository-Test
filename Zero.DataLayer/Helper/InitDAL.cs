using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.DataLayer.Donnees;

namespace Zero.DataLayer.Helper
{
    public static class InitDAL
    {
        public static void Init()
        {
            var connectionString = @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae";

            DevExpress.Xpo.Metadata.XPDictionary dict =
            new DevExpress.Xpo.Metadata.ReflectionDictionary();
            // Initialize the XPO dictionary.
            dict.GetDataStoreSchema(typeof(AudienceJournal), typeof(AudienceRadio), typeof(AudienceTV), typeof(Individu), typeof(Signalitique), typeof(Vague), typeof(XpoSupportPresse), typeof(XpoSupportRadio), typeof(XpoSupportTV));


            DevExpress.Xpo.DB.IDataStore store = DevExpress.Xpo.XpoDefault.GetConnectionProvider(connectionString,
                DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.ThreadSafeDataLayer(dict, store);
            DevExpress.Xpo.XpoDefault.Session = null;
        }
    }
}
