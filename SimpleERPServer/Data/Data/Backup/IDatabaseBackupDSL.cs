using Database.Backup.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Data.Backup
{
    public interface IDatabaseBackupDSL
    {
        public bool BackupDatabase(DatabaseEntity model);
        public bool RestoreDatabase(DatabaseEntity model);
    }
}
