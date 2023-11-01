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

            _manager.AddTableToDatabaseFile(databaseName, table);
        }

        public void SaveTableInDatabase(string databaseName, Table table) 
        {
            _manager.AddTableToDatabaseFile(databaseName, table);
        }
    }
}
