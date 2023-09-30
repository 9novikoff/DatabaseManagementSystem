using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEngine
{
    public class DatabaseFileManager
    {
        private DatabaseFileEditor _editor;

        public DatabaseFileManager(DatabaseFileEditor editor)
        {
            _editor = editor;
        }

        public void CreateDatabaseFile(string databaseName)
        {

        }

        public void DeleteDatabaseFile(string databaseName)
        {

        }

        public void RenameDatabaseFile(string databaseName)
        {

        }

        public void AddTableToDatabaseFile(string databaseName, Table table)
        {

        }

        public void RemoveTableFromDatabaseFile(string databaseName, string tableName)
        {

        }

        public void AddAttributeToTableFile(IType type, string name, string tableName, string databaseName)
        {

        }

        public void RemoveAttributeFromTableFile(IType type, string name, string tableName, string databaseName)
        {

        }

		public void EditAttributeNameInTableFile(IType type, string name, string newName, string tableName)
		{

		}

		public void AddRowIntoTableFile(List<string> data, string tableName, string databaseName)
		{

		}

		public void RemoveRowFromTableFile(List<string> primaryKeyValues, string tableName, string databaseName)
		{

		}

		public void EditRowFromTableFile(List<string> primaryKeyValues, List<string> data, string tableName, string databaseName)
		{

		}

	}

}
