using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace CECode.Logging
{
    public static class Logger
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Logger));

        public static ILog Log
        {
            get
            {
                return _log;
            }
        }

        static Logger()
        {
            XmlConfigurator.Configure();
        }
    }
}
