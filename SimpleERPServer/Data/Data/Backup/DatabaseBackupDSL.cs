using Database.Backup.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Data.Backup
{
    public class DatabaseBackupDSL : IDatabaseBackupDSL
    {
        private readonly string[] _systemDatabaseNames = { "master", "tempdb", "model", "msdb" };

        public bool BackupDatabase(DatabaseEntity model)
        {
            try
            {
                string filePath = BuildBackupPathWithFilename(model);

                using (var connection = new SqlConnection(model.ConnectionString))
                {
                    var query = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", model.DatabaseName, filePath);

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool RestoreDatabase(DatabaseEntity model)
        {
            try
            {
                string filePath = BuildBackupPathWithFilename(model);

                using (var connection = new SqlConnection(model.ConnectionString))
                {
                    var query = "use master RESTORE DATABASE " + model.DatabaseName + " FROM DISK = '" + filePath + "' WITH REPLACE";
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string BuildBackupPathWithFilename(DatabaseEntity model)
        {
            string filename = string.Format("{0}-{1}.bak", model.DatabaseName, DateTime.Now.ToString("yyyy-MM-dd"));
            return Path.Combine(model.FilePath, filename);
        }
    }
}
