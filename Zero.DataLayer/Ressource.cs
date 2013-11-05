using DevExpress.Xpo.DB;

namespace Zero.DataLayer
{
    public class Ressource
    {
        public string GetConnection()
        {
            return AccessConnectionProvider.GetConnectionString(@"C:\MedSim\Data.mdb", "admin", "");
        }
    }
}
