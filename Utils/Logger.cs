using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace HW_2_IntreductionInSelenium.Utils
{
    public class Logger
    {
        private static NLog.Logger log;

        public static NLog.Logger getLogger()
        {
            if (log == null)
            {
                log = LogManager.GetCurrentClassLogger();
            }
            return log;
        }
    }
}
