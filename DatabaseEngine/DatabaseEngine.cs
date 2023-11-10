using System.Configuration;

namespace DatabaseEngine
{
    public class DatabaseEngine
    {
        private readonly string _databasesPath;
        private readonly DatabaseFileManager _manager;
        public DatabaseEngine()
        {
            _databasesPath = ConfigurationManager.AppSettings.Get("DatabasesPath");
            _manager = new DatabaseFileManager(new TxtDatabaseFileEditor(), _databasesPath);
        }

        public void CreateDatabase(string databaseName, ValidationResult validationResult)
        {
            var names = GetDatabaseNames();
            if (names.Contains(databaseName))
            {
                validationResult.IsValid = false;
                validationResult.Message = "Database with that name already exists";
                return;
            }

            validationResult.IsValid = true;
            validationResult.Message = "Database has been successfully created";

            _manager.CreateDatabaseFile(databaseName);
        }

        public List<string?> GetDatabaseNames()
        {
            return _manager.GetAllDatabaseNames();
        }

        public Database? GetDatabase(string databaseName, ValidationResult validationResult)
        {
            var names = GetDatabaseNames();
            if (!names.Contains(databaseName))
            {
                validationResult.IsValid = false;
                validationResult.Message = "Database with that name does not exist";
                return null;
            }

            validationResult.IsValid = true;
            validationResult.Message = "Database successfully received";

            return _manager.GetDatabase(databaseName);
        }

        public Table GetTable(string databaseName, string tableName)
        {
            return _manager.GetTable(databaseName, tableName);
        }

        public List<string?> GetTableNames(string databaseName)
        {
            return _manager.GetTableNames(databaseName);
        }

        public void CreateTable(string databaseName, Table table, ValidationResult validationResult)
        {
            var names = GetTableNames(databaseName);
            if (names.Contains(table.Name))
            {
                validationResult.IsValid = false;
                validationResult.Message = "Table with that name already exists";
                return;
            }

            var isValidTable = ValidateTable(databaseName, table, validationResult);
            if (!isValidTable)
            {
                return;
            }

            _manager.AddTableToDatabaseFile(databaseName, table);
            validationResult.Message = "Table was successfully created";
        }

        public void SaveTableInDatabase(string databaseName, string sourceTableName, Table table, ValidationResult validationResult) 
        {
            var isValidTable = ValidateTable(databaseName, table, validationResult);
            if (!isValidTable)
            {
                return;
            }

            _manager.RemoveTableFromDatabaseFile(databaseName, sourceTableName);
            _manager.AddTableToDatabaseFile(databaseName, table);
            validationResult.Message = "Table was successfully edited";
        }

        public void DeleteDatabase(string databaseName)
        {
            _manager.DeleteDatabaseFile(databaseName);
        }

        public void RenameDatabase(string sourceDatabaseName, string destinationDatabaseName, ValidationResult validationResult)
        {
            var names = GetDatabaseNames();
            if (names.Contains(destinationDatabaseName))
            {
                validationResult.IsValid = false;
                validationResult.Message = "Database with that name already exists";
                return;
            }

            validationResult.IsValid = true;
            validationResult.Message = "Database has been successfully renamed";

            _manager.RenameDatabaseFile(sourceDatabaseName, destinationDatabaseName);
        }

        private bool ValidateTable(string databaseName, Table table, ValidationResult validationResult)
        {
            if (string.IsNullOrEmpty(table.Name))
            {
                validationResult.IsValid = false;
                validationResult.Message = "Invalid table name";
                return false;
            }

            if (table.ColumnNames.Count == 0)
            {
                validationResult.IsValid = false;
                validationResult.Message = "Table must contain at least one column";
                return false;
            }

            if (table.PrimaryKeysIndexes.Count == 0)
            {
                validationResult.IsValid = false;
                validationResult.Message = "Table must contain at least one primary key";
                return false;
            }

            if (table.Rows.Select(r => r.Values.Contains("")).Contains(true))
            {
                validationResult.IsValid = false;
                validationResult.Message = "All table cells must be filled";
                return false;
            }

            var invalidCellces = Enumerable.Range(0, table.Types.Count).SelectMany(i => table.Rows.Select(r => r.Values[i]).Where(s => table.Types[i].IsValid(s) == false)).ToList();
            if (invalidCellces.Count > 0)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"Invalid cells: {string.Join(", ", invalidCellces)}";
                return false;
            }

            if(table.PrimaryKeysIndexes.Select(i => table.Rows.Select(r => r.Values[i]).GroupBy(v => v).All(g => g.Count() == 1)).Contains(false))
            {
                validationResult.IsValid = false;
                validationResult.Message = "All primary cellc must be unique";
                return false;
            }

            return true;
        }
    }
}
