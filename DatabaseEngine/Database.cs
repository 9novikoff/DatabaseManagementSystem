using System.Text.RegularExpressions;

namespace DatabaseEngine
{
    public class Database
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; }
    }

    public class Table
    {
        public string Name { get; set; }
        public List<IType> Types { get; set; }
        public List<Row> Rows { get; set; }
        public List<int> PrimaryKeysIndexes { get; set; }
        public List<Dictionary<List<int>, string>> ForeignKeysIndexesWithTableNames { get; set; }
    }

    public class Row
    {
        public List<string> Values { get; set; }
    }


    public interface IType
    {
        public bool IsValid(string value);
    }

    public class Integer : IType
    {
        public bool IsValid(string value)
        {
            return int.TryParse(value, out _);
        }
    }

    public class Real : IType
    {
        public bool IsValid(string value)
        {
            var pattern = @"^[-]?[0-9]+([.]?[0-9]+)?$";
            return Regex.IsMatch(value, pattern);
        }
    }

    public class Char : IType
    {
        public bool IsValid(string value)
        {
            return char.TryParse(value, out _);
        }
    }

    public class String : IType
    {
        public bool IsValid(string value)
        {
            return true;
        }
    }

    public class IntegerInterval : IType
    {
        public bool IsValid(string value)
        {
            var splitValue = value.Trim().Split(',');
            var (firstInteger, secondInteger) = (splitValue[0], splitValue[1]);
            return int.TryParse(firstInteger, out var firstConvertedInteger) && int.TryParse(secondInteger, out var secondConvertedInteger) 
                                                                         && firstConvertedInteger <= secondConvertedInteger;
        }
    }

    public class TxtFile : IType
    {
        public bool IsValid(string value)
        {
            return true;
        }
    }
}
