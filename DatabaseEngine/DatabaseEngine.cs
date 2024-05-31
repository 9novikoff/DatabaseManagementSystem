using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace DatabaseManagementSystemDatabaseEngine
{
    public class DatabaseEngine
    {
        private readonly string _databasesPath;
        private readonly DatabaseFileManager _manager;
        public DatabaseEngine()
        {
            //_databasesPath = ConfigurationManager.AppSettings.Get("DatabasesPath");
            _databasesPath = @"C:\Users\Novikov\source\repos\DatabaseManagementSystem\DatabaseEngine\Databases";
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

        public List<Database> GetDatabases() 
        {
            return _manager.GetDatabases();
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

        public void LoadDatabase(string path, ValidationResult validationResult)
        {
            _manager.CopyDirectory(path);
            validationResult.IsValid = true;
            validationResult.Message = "Database was succesfully loaded";
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
            validationResult.IsValid = true;
            validationResult.Message = "Table was successfully created";
        }

        public void DeleteTable(string databaseName, string tableName, ValidationResult validationResult)
        {
            _manager.RemoveTableFromDatabaseFile(databaseName, tableName);
            validationResult.IsValid = true;
            validationResult.Message = "Table was successfully removed";
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
            validationResult.IsValid = true;
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

            if (table.Rows.Where(r => r.Values.Contains("") || r.Values.Contains(null) ).Count() > 0)
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

            if (table.PrimaryKeysIndexes.Select(i => table.Rows.Select(r => r.Values[i]).GroupBy(v => v).All(g => g.Count() == 1)).Contains(false))
            {
                validationResult.IsValid = false;
                validationResult.Message = "All primary cellc must be unique";
                return false;
            }

            return true;
        }

        public Table InnerJoin(Table firstTable, Table secondTable, int firstTableColumnIndex, int secondTableColumnIndex)
        {
            var resultTable = new Table();
            resultTable.ColumnNames.AddRange(firstTable.ColumnNames);
            resultTable.ColumnNames.AddRange(secondTable.ColumnNames);
            resultTable.Types.AddRange(firstTable.Types);
            resultTable.Types.AddRange(secondTable.Types);

            foreach (var firstTableRow in firstTable.Rows)
            {
                foreach (var secondTableRow in secondTable.Rows)
                {
                    if (firstTableRow.Values[firstTableColumnIndex] == secondTableRow.Values[secondTableColumnIndex])
                    {
                        firstTableRow.Values.AddRange(secondTableRow.Values);
                        resultTable.Rows.Add(firstTableRow);
                    }
                }
            }

            return resultTable;
        }
    }
}
