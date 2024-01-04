using HotChocolate;
using System.Text.RegularExpressions;

namespace DatabaseManagementSystemDatabaseEngine
{
    public class Database
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; } = new List<Table>();
    }

    public class Table
    {
	    public string Name { get; set; }
        public List<IType> Types { get; set; } = new List<IType>();
	    public List<string> ColumnNames { get; set; } = new List<string>();
	    public List<Row> Rows { get; set; } = new List<Row>();
        public List<int> PrimaryKeysIndexes { get; set; } = new List<int>();
        public Dictionary<List<int>, string> ForeignKeysIndexesWithTableNames { get; set; } = new Dictionary<List<int>, string>();
        public bool IsReferenced { get; set; }
    }

    public class Row
    {
        public List<string> Values { get; set; } = new List<string>();
    }


    public interface IType
    {
        public bool IsValid(string value);
        public string GetTypeName()
        {
            return GetType().Name;
        }
    }

    public class Integer : IType
    {
        public bool IsValid(string value)
        {
            return int.TryParse(value, out _);
        }
        public string GetTypeName()
        {
            return GetType().Name;
        }

    }

    public class Real : IType
    {
        public bool IsValid(string value)
        {
            var pattern = @"^[-]?[0-9]+([.]?[0-9]+)?$";
            return Regex.IsMatch(value, pattern);
        }
        public string GetTypeName()
        {
            return GetType().Name;
        }
    }

    public class Char : IType
    {
        public bool IsValid(string value)
        {
            return char.TryParse(value, out _);
        }
        public string GetTypeName()
        {
            return GetType().Name;
        }
    }

    public class Str : IType
    {
        public bool IsValid(string value)
        {
            return true;
        }
        public string GetTypeName()
        {
            return GetType().Name;
        }
    }

    public class IntegerInterval : IType
    {
        public bool IsValid(string value)
        {
            var splitValue = value.Trim().Split(' ');
            var (firstInteger, secondInteger) = (splitValue[0], splitValue[1]);
            return int.TryParse(firstInteger, out var firstConvertedInteger) && int.TryParse(secondInteger, out var secondConvertedInteger) 
                                                                         && firstConvertedInteger <= secondConvertedInteger;
        }
        public string GetTypeName()
        {
            return GetType().Name;
        }
    }

    public class TxtFile : IType
    {
        public bool IsValid(string value)
        {
            return true;
        }
        public string GetTypeName()
        {
            return GetType().Name;
        }
    }
}
