using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoWebApi.Infrastracture
{
    public class MongoDBConfig
    {
      
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty("root") || string.IsNullOrEmpty("example"))
                    return "mongodb://root:27017";
                return "mongodb://root:example@localhost:27017";
            }
        }
    }
}
