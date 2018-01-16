using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadBanker
{
    abstract class Backup
    {
        static string data_backup, local_backup;

        public static string Data_backup
        {
            get
            {
                return data_backup;
            }

            set
            {
                data_backup = value;
            }
        }

        public static string Local_backup
        {
            get
            {
                return local_backup;
            }

            set
            {
                local_backup = value;
            }
        }
    }
}
