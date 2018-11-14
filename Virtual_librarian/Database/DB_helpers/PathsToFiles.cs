using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class PathsToFiles
    {
        public static string pathToFacesFile= System.Configuration.ConfigurationManager.AppSettings["pathToFacesFile"];
        public static string pathToFacesFolder = System.Configuration.ConfigurationManager.AppSettings["pathToFacesFolder"];
        public static string pathToUsersFile = System.Configuration.ConfigurationManager.AppSettings["pathToUsersFile"];
        public static string pathToBooksFile = System.Configuration.ConfigurationManager.AppSettings["pathToBooksFile"];

    }
}
