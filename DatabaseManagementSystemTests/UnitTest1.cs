using System.ComponentModel.DataAnnotations;
using DatabaseManagementSystemDatabaseEngine;
using ValidationResult = DatabaseManagementSystemDatabaseEngine.ValidationResult;

namespace DatabaseManagementSystemTests
{
    public class UnitTest1
    {

        [Fact]
        public void CreateDatabase_ShouldCreateNewDatabase()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var validationResult = new ValidationResult();

            engine.CreateDatabase(databaseName, validationResult);

            Assert.True(Directory.Exists(@"C:\Users\Novikov\source\repos\DatabaseManagementSystem\DatabaseEngine\Databases\TestDatabase"));
        }

        [Fact]
        public void CreateDatabase_ShouldNotCreateExistingDatabase()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var validationResult = new ValidationResult();

            engine.CreateDatabase(databaseName, validationResult);
            engine.CreateDatabase(databaseName, validationResult);

            Assert.False(validationResult.IsValid);
            Assert.Contains("Database with that name already exists", validationResult.Message);
        }

        [Fact]
        public void GetDatabase_ShouldReturnDatabaseIfExists()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var validationResult = new ValidationResult();

            var result = engine.GetDatabase(databaseName, validationResult);

            Assert.True(validationResult.IsValid);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetDatabase_ShouldNotReturnNonexistentDatabase()
        {
            var engine = new DatabaseEngine();
            var databaseName = "NonexistentDatabase";
            var validationResult = new ValidationResult();

            var result = engine.GetDatabase(databaseName, validationResult);

            Assert.False(validationResult.IsValid);
            Assert.Contains("Database with that name does not exist", validationResult.Message);
            Assert.Null(result);
        }

        [Fact]
        public void CreateTable_ShouldCreateNewTable()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var tableName = "TestTable";
            var validationResult = new ValidationResult();

            var table = new Table
            {
                Name = tableName,
                Types = new List<IType> { new Integer() },
                Rows = new List<Row> { new Row() { Values = new List<string>() { "1" } } },
                ColumnNames = new List<string>() { "TestColumn" },
                PrimaryKeysIndexes = new List<int>() { 0 }
            };
            engine.CreateTable(databaseName, table, validationResult);

            Assert.True(validationResult.IsValid);
            Assert.True(engine.GetTableNames(databaseName).Contains(tableName));
        }

        [Fact]
        public void CreateTable_ShouldNotCreateExistingTable()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var tableName = "TestTable";
            var validationResult = new ValidationResult();

            var table = new Table
            {
                Name = tableName,
                Types = new List<IType> { new Integer() },
                Rows = new List<Row> { new Row() { Values = new List<string>() { "1" } } },
                ColumnNames = new List<string>() { "TestColumn" },
                PrimaryKeysIndexes = new List<int>() { 0 }
            }; 
            engine.CreateTable(databaseName, table, validationResult);

            Assert.False(validationResult.IsValid);
            Assert.Contains("Table with that name already exists", validationResult.Message);
        }

        [Fact]
        public void CreateTable_ShouldNotCreateInvalidTable()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var tableName = "InvalidTable";
            var validationResult = new ValidationResult();

            var invalidTable = new Table
            {
                Name = tableName,
                Types = new List<IType> { new Integer() },
                Rows = new List<Row> { new Row() { Values = new List<string>() { "1" } } },
                ColumnNames = new List<string>() { "TestColumn" },
            };
            engine.CreateTable(databaseName, invalidTable, validationResult);

            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void DeleteTable_ShouldRemoveExistingTable()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var tableName = "TestTable";
            var validationResult = new ValidationResult();

            engine.DeleteTable(databaseName, tableName, validationResult);

            Assert.True(validationResult.IsValid);
            Assert.False(engine.GetTableNames(databaseName).Contains(tableName));
        }

        [Fact]
        public void SaveTableInDatabase_ShouldEditTableSuccessfully()
        {
            var engine = new DatabaseEngine();
            var databaseName = "TestDatabase";
            var sourceTableName = "SourceTable";
            var targetTableName = "TargetTable";
            var validationResult = new ValidationResult();

            var targetTable = new Table
            {
                Name = targetTableName,
                Types = new List<IType> { new Integer() },
                Rows = new List<Row> { new Row() { Values = new List<string>() { "1" } } },
                ColumnNames = new List<string>() { "TestColumn" },
                PrimaryKeysIndexes = new List<int>() { 0 }
            };
            engine.SaveTableInDatabase(databaseName, sourceTableName, targetTable, validationResult);

            Assert.True(validationResult.IsValid);
            Assert.False(engine.GetTableNames(databaseName).Contains(sourceTableName));
            Assert.True(engine.GetTableNames(databaseName).Contains(targetTableName));
        }
    }
}