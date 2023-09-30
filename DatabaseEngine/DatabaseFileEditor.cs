using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEngine
{
    public abstract class DatabaseFileEditor
    {
        protected readonly string DatabasesPath;
        protected readonly string DatabaseName;
        protected readonly string TableName;
		protected readonly string FullPath;
        public DatabaseFileEditor(string databasesPath, string databaseName, string tableName)
        {
            DatabasesPath = databasesPath;
            DatabaseName = databaseName;
            TableName = tableName;
            FullPath = $"{databasesPath}/{DatabaseName}/{TableName}";
        }
    }

    public class TxtDatabaseFileEditor : DatabaseFileEditor
    {
        public TxtDatabaseFileEditor(string databasesPath, string databaseName, string tableName) : base(databasesPath, databaseName, tableName)
        { }

        public Dictionary<List<int>, string> GetForeignKeys(string tableName)
        {
	        try
	        {
                var result = new Dictionary<List<int>, string>();
                using var sr = new StreamReader(FullPath);
                var line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (!line.StartsWith("FK:"))
                        line = null;
                    line = line.Substring(0, 3);
                    var index = line.IndexOf(':');
                    var refferencedTableName = line.Substring(index + 1);
                    line = line.Substring(0, index);
                    var indexes = line.Split(',').Select(i => int.Parse(i)).ToList();
                    result.Add(indexes, refferencedTableName);
					line = sr.ReadLine();
				}

                return result;
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        throw;
	        }
        }

        public List<int> GetPrimaryKeyIndexes()
        {
	        try
	        {
		        using var sr = new StreamReader(FullPath);
                var line = sr.ReadLine();
		        var startIndex = 3;
		        var lineWithoutPk = line.Remove(startIndex);
		        var indexes = lineWithoutPk.Split(',');
		        return indexes.Select(x => int.Parse(x)).ToList();
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        throw;
	        }
		}

        public IEnumerable<List<string>> GetRows()
        {
			using var sr = new StreamReader(FullPath);
			SkipTableInfoRows(sr);
			var line = sr.ReadLine();
			while (line != null)
			{
				var row = line.Split(',').ToList();
				yield return row;
			}
		}

		public void WritePrimaryKeysIndexes(List<int> indexes)
		{
			try
			{
				using var sw = new StreamWriter(FullPath);
				sw.WriteLine($"PK:{string.Join(",", indexes.ToArray())}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public void WriteForeignKeysIndexes(Dictionary<List<int>, string> indexesWithTableName)
		{
			try
			{
				using var sw = new StreamWriter(FullPath);
				foreach (var item in indexesWithTableName)
				{
					sw.WriteLine($"FK:{string.Join(",", item.Key.ToArray())}:{item.Value}");
				}
				sw.WriteLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public void WriteRow(List<string> row) 
		{
			try
			{
				using var sw = new StreamWriter(FullPath);
				sw.WriteLine($"{string.Join(",", row.ToArray())}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private void SkipTableInfoRows(StreamReader writer)
        {
			try
			{
				var line = writer.ReadLine();
				while (line != null)
				{
					if (!(line.StartsWith("PK:") || line.StartsWith("FK:")))
					{
						line = null;
					}
					line = writer.ReadLine();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}


	}
}
