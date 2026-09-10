using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    internal static class clsDataAccessSettings
    {
        internal static string ConnectionString { get; set; }
            = "Server=.\\PUBLISHER;Database=DVLD;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
