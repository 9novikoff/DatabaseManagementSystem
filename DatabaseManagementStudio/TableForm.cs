using DatabaseManagementSystemDatabaseEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DatabaseManagementStudio
{
    public partial class TableForm : Form
    {
        private readonly DatabaseManagementSystemDatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm notificationForm;
        private readonly DatabaseTablesListform _owner;
        private readonly string _databaseName;
        private readonly bool _isModify = false;
        private readonly string _sourceTableName;
        private Table table;
        public TableForm(DatabaseManagementSystemDatabaseEngine.DatabaseEngine engine, NotificationForm form, string databaseName, DatabaseTablesListform owner)
        {
            InitializeComponent();
            _databaseEngine = engine;
            notificationForm = form;
            _owner = owner;
            _databaseName = databaseName;
            foreach (var type in Assembly.GetAssembly(typeof(IType)).GetTypes().Where(myType => myType.IsClass && typeof(IType).IsAssignableFrom(myType)))
            {
                ColumnTypeComboBox.Items.Add(type.Name);
            }
            table = new Table();
        }

        public TableForm(DatabaseManagementSystemDatabaseEngine.DatabaseEngine engine, NotificationForm form, string databaseName, DatabaseTablesListform owner, string tableName) : this(engine, form, databaseName, owner)
        {
            _isModify = true;
            _sourceTableName = tableName;
            table = _databaseEngine.GetTable(databaseName, tableName);

            TableNameTextBox.Text = table.Name;

            var columnHeaders = Enumerable.Range(0, table.ColumnNames.Count).Select(i => table.ColumnNames[i] + $" ({table.Types[i].GetType().Name}) {(table.PrimaryKeysIndexes.Contains(i) ? "*" : "")}").ToList();
            Enumerable.Range(0, table.ColumnNames.Count).ToList().ForEach(i => TableDataGrid.Columns.Add(table.ColumnNames[i], columnHeaders[i]));
            if(table.Rows.Count > TableDataGrid.RowCount)
            {
                Enumerable.Range(0, table.Rows.Count - TableDataGrid.RowCount).ToList().ForEach(r => TableDataGrid.Rows.Add());
            }
            Enumerable.Range(0, table.Rows.Count).ToList().ForEach(i => Enumerable.Range(0, table.ColumnNames.Count).ToList().ForEach(j => TableDataGrid.Rows[i].Cells[j].Value = table.Rows[i].Values[j]));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _owner.UpdateList();
            _owner.Visible = true;
            this.Close();
        }

        private void AddColumnButton_Click(object sender, EventArgs e)
        {
            if (ColumnTypeComboBox.SelectedItem == null || string.IsNullOrEmpty(ColumnNameTextBox.Text))
            {
                notificationForm.Notify("Please fill the required fields");
                return;
            }

            var columnName = ColumnNameTextBox.Text;
            var columnType = ColumnTypeComboBox.SelectedItem as string;
            var isChecked = IsPrimaryCheckBox.Checked;

            table.ColumnNames.Add(columnName);
            table.Types.Add(Activator.CreateInstance(Type.GetType("DatabaseManagementSystemDatabaseEngine." + columnType + ", DatabaseEngine")) as IType);

            if (isChecked)
            {
                table.PrimaryKeysIndexes.Add(table.ColumnNames.Count - 1);
            }

            TableDataGrid.Columns.Add(columnName, columnName + $" ({columnType}) {(isChecked ? "*" : "")}");
        }

        private void RemoveColumnButton_Click(object sender, EventArgs e)
        {
            var index = table.ColumnNames.Count - 1;

            if (index < 0)
            {
                notificationForm.Notify("Table contains less than 1 column");
                return;
            }

            table.ColumnNames.RemoveAt(index);
            table.Types.RemoveAt(index);

            TableDataGrid.Columns.RemoveAt(index);
        }

        private void CreateTableButton_Click(object sender, EventArgs e)
        {
            var newTable = new Table();
            table.Name = TableNameTextBox.Text;

            table.Rows = new List<Row>();
            Enumerable.Range(0, TableDataGrid.RowCount).ToList().ForEach(i => table.Rows.Add(new Row()));
            Enumerable.Range(0, TableDataGrid.RowCount).ToList().ForEach(i => Enumerable.Range(0, table.ColumnNames.Count).ToList().ForEach(j => table.Rows[i].Values.Add(TableDataGrid.Rows[i].Cells[j].Value as string)));

            if (table.Rows.Count > 0 && table.Rows.Last().Values.Any(v => string.IsNullOrEmpty(v)))
                table.Rows.RemoveAt(table.Rows.Count - 1);

            var validationResult = new ValidationResult();

            if (!_isModify)
                _databaseEngine.CreateTable(_databaseName, table, validationResult);
            else
                _databaseEngine.SaveTableInDatabase(_databaseName, _sourceTableName, table, validationResult);

            notificationForm.Notify(validationResult.Message);
        }
    }
}
