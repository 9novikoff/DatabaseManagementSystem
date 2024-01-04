using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagementSystemDatabaseEngine
{
    public abstract class DatabaseFileEditor
    {
        public DatabaseFileEditor()
        {

        }
    }

    public class TxtDatabaseFileEditor : DatabaseFileEditor
    {
        public TxtDatabaseFileEditor() : base()
        { }

        public bool IsReferencedFile(string fullPath)
		{
            try
            {
                string line = File.ReadLines(fullPath).Take(1).First();
				if (!string.IsNullOrEmpty(line) && line[0].Equals('R'))
				{
					return true;
				}
				return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

		public List<IType> GetTypes(string fullPath)
		{
            try
            {
				var res = new List<IType>();
                string line = File.ReadLines(fullPath).Skip(1).Take(1).First();
				var typeNames = line.Split(',').ToList();
                foreach (var typeName in typeNames)
                {
                    var type = Activator.CreateInstance(Type.GetType("DatabaseManagementSystemDatabaseEngine." + typeName + ", DatabaseEngine")) as IType;
					res.Add(type);
                }
				return res;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

		public List<string> GetColumnNames(string fullPath)
		{
            try
            {
                string line = File.ReadLines(fullPath).Skip(2).Take(1).First();
                return line.Split(',').ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<int> GetPrimaryKeyIndexes(string fullPath)
        {
            try
            {
                string line = File.ReadLines(fullPath).Skip(3).Take(1).First();
                return line.Split(',').Select(int.Parse).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Dictionary<List<int>, string> GetForeignKeys(string fullPath)
        {
	        try
	        {
                var result = new Dictionary<List<int>, string>();
                string line = File.ReadLines(fullPath).Skip(4).Take(1).First();
				var multipleForeignKeysTables = line.Split(';');
                foreach (var foreignKeys in multipleForeignKeysTables.Where(s => !string.IsNullOrEmpty(s)))
                {
                    var splitedKeysAndTableName = foreignKeys.Split(':');
                    result.Add(splitedKeysAndTableName[0].Split(',').Select(int.Parse).ToList(), splitedKeysAndTableName[1]);
                }
                return result;
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        throw;
	        }
        }

		
        public List<List<string>> GetRows(string fullPath)
        {
            try
            {
                var result = new List<List<string>>();
                var lines = File.ReadLines(fullPath).Skip(5);
                foreach (var line in lines) 
                {
                    result.Add(line.Split(',').ToList());
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public void WritePrimaryKeysIndexes(string fullPath, List<int> indexes)
		{
            try
            {
                File.AppendAllLines(fullPath, new List<string>() {$"{string.Join(",", indexes.ToArray())}"});
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public void WriteForeignKeysIndexes(string fullPath, Dictionary<List<int>, string> indexesWithTableName)
		{
			try
			{
                var line = "";
				foreach (var item in indexesWithTableName)
				{
					line += $"{string.Join(",", item.Key.ToArray())}:{item.Value};";
				}
                File.AppendAllLines(fullPath, new List<string>() { line });
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public void AppendList(string fullPath, List<string> row) 
		{
			try
			{
				File.AppendAllLines(fullPath, new List<string>() { $"{string.Join(",", row.ToArray())}" });
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

        public void AppendString(string  fullPath, string str) 
        {
            try
            {
                File.AppendAllLines(fullPath, new List<string>() { str });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

		public List<string> GetAllFileLines(string fullPath)
		{
            try
            {
				return File.ReadAllLines(fullPath).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

		public void RewriteLines(string fullPath, List<string> lines)
		{
            try
            {
				File.WriteAllLines(fullPath, lines);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
	}
}
