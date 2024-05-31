using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagementSystemDatabaseEngine
{
    public class DatabaseFileManager
    {
        private TxtDatabaseFileEditor _txtEditor;
        private readonly string _databasesPath;

        public DatabaseFileManager(TxtDatabaseFileEditor editor, string databasesPath)
        {
            _txtEditor = editor;
            _databasesPath = databasesPath;
        }

        public List<string?> GetAllDatabaseNames()
        {
            return Directory.GetDirectories(_databasesPath)
                            .Select(Path.GetFileName)
                            .ToList();
        }

        public Database GetDatabase(string databaseName)
        {
            var path = BuildPath(databaseName);
            var tableNames = GetTableNames(databaseName);
            return new Database() { Name = databaseName, Tables = tableNames.Select(x => GetTable(databaseName, x)).ToList() };
        }

        public void CreateDatabaseFile(string databaseName)
        {
            var path = BuildPath(databaseName);
            Directory.CreateDirectory(path);
        }

        public void DeleteDatabaseFile(string databaseName)
        {
            var path = BuildPath(databaseName);
            Directory.Delete(path, true);
        }

        public void RenameDatabaseFile(string sourceDatabaseName, string destinationDatabaseName)
        {
            var sourcePath = BuildPath(sourceDatabaseName);
            var destinationPath = BuildPath(destinationDatabaseName);
            Directory.Move(sourcePath, destinationPath);
        }

        public List<string?> GetTableNames(string databaseName)
        {
            return Directory.GetFiles(BuildPath(databaseName))
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();
        }

        public Table GetTable(string databaseName, string tableName)
        {
            var path = BuildPath(databaseName, tableName);
            Table table = new Table();
            table.IsReferenced = _txtEditor.IsReferencedFile(path);
            table.Name = tableName;
            table.Types = _txtEditor.GetTypes(path);
            table.ColumnNames = _txtEditor.GetColumnNames(path);
            table.PrimaryKeysIndexes = _txtEditor.GetPrimaryKeyIndexes(path);
            table.ForeignKeysIndexesWithTableNames = _txtEditor.GetForeignKeys(path);
            table.Rows = _txtEditor.GetRows(path).Select(x => new Row() { Values = x}).ToList();
            return table;
        }

        public void AddTableToDatabaseFile(string databaseName, Table table)
        {
            var path = BuildPath(databaseName, table.Name);
            _txtEditor.AppendString(path, table.IsReferenced ? "R" : "");
            _txtEditor.AppendList(path, table.Types.Select(x => x.GetType().Name).ToList());
            _txtEditor.AppendList(path, table.ColumnNames);
            _txtEditor.WritePrimaryKeysIndexes(path, table.PrimaryKeysIndexes);
            _txtEditor.WriteForeignKeysIndexes(path, table.ForeignKeysIndexesWithTableNames);
            table.Rows.ForEach(x => _txtEditor.AppendList(path, x.Values));
        }

        public void RemoveTableFromDatabaseFile(string databaseName, string tableName)
        {
            var path = BuildPath(databaseName, tableName);
            File.Delete(path);
        }

        public void AddRowIntoTableFile(List<string> data, string tableName, string databaseName)
        {
            var path = BuildPath(databaseName, tableName);
            _txtEditor.AppendList(path, data);
        }

        public void CopyDirectory(string path)
        {
            var databaseName = new DirectoryInfo(path).Name;
            CreateDatabaseFile(databaseName);
            
            foreach (var file in Directory.GetFiles(path))
            {
                File.Copy(file, BuildPath(databaseName, Path.GetFileNameWithoutExtension(file)));
            }
        }

        private string BuildPath(string databaseName)
        {
            return $"{_databasesPath}\\{databaseName}";
        }

        private string BuildPath(string databaseName, string tableName)
        {
            return $"{_databasesPath}\\{databaseName}\\{tableName}.txt";
        }

        internal List<Database> GetDatabases()
        {
            var databasesNames = GetAllDatabaseNames();
            return databasesNames.Select(n => GetDatabase(n)).ToList();
        }
    }

}
