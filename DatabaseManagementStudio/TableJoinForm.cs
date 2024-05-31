using DatabaseManagementSystemDatabaseEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseManagementStudio
{
    public partial class TableJoinForm : Form
    {
        private readonly DatabaseManagementSystemDatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm notificationForm;
        private readonly string _databaseName;
        public TableJoinForm(DatabaseManagementSystemDatabaseEngine.DatabaseEngine engine, NotificationForm form, string databaseName)
        {
            InitializeComponent();
            _databaseEngine = engine;
            notificationForm = form;
            _databaseName = databaseName;
            firstTableColumnComboBox.Enabled = false;
            secondTableColumnComboBox.Enabled = false;
            firstTableComboBox.Items.AddRange(_databaseEngine.GetTableNames(_databaseName).ToArray());
            secondTableComboBox.Items.AddRange(_databaseEngine.GetTableNames(_databaseName).ToArray());
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Owner.Visible = true;
            this.Close();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (firstTableComboBox.Text.Equals("") || firstTableColumnComboBox.Text.Equals("") || secondTableComboBox.Text.Equals("") || secondTableColumnComboBox.Text.Equals(""))
            {
                notificationForm.Notify("Fill all fields");
                return;
            }

            var firstTable = _databaseEngine.GetTable(_databaseName, firstTableComboBox.Text);
            var secondTable = _databaseEngine.GetTable(_databaseName, secondTableComboBox.Text);
            var resultTable = _databaseEngine.InnerJoin(firstTable, secondTable, firstTable.ColumnNames.IndexOf(firstTableColumnComboBox.Text), secondTable.ColumnNames.IndexOf(secondTableColumnComboBox.Text));
            
            var columnHeaders = Enumerable.Range(0, resultTable.ColumnNames.Count).Select(i => resultTable.ColumnNames[i] + $" ({resultTable.Types[i].GetType().Name}) {(resultTable.PrimaryKeysIndexes.Contains(i) ? "*" : "")}").ToList();
            Enumerable.Range(0, resultTable.ColumnNames.Count).ToList().ForEach(i => resultTableDataGrid.Columns.Add(resultTable.ColumnNames[i], columnHeaders[i]));
            if (resultTable.Rows.Count > resultTableDataGrid.RowCount)
            {
                Enumerable.Range(0, resultTable.Rows.Count - resultTableDataGrid.RowCount).ToList().ForEach(r => resultTableDataGrid.Rows.Add());
            }
            Enumerable.Range(0, resultTable.Rows.Count).ToList().ForEach(i => Enumerable.Range(0, resultTable.ColumnNames.Count).ToList().ForEach(j => resultTableDataGrid.Rows[i].Cells[j].Value = resultTable.Rows[i].Values[j]));
        }

        private void firstTableComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            firstTableColumnComboBox.Enabled = true;
            firstTableColumnComboBox.Items.AddRange(_databaseEngine.GetTable(_databaseName, firstTableComboBox.Text).ColumnNames.ToArray());
        }

        private void secondTableComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            secondTableColumnComboBox.Enabled = true;
            secondTableColumnComboBox.Items.AddRange(_databaseEngine.GetTable(_databaseName, secondTableComboBox.Text).ColumnNames.ToArray());
        }
    }
}
