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
    public partial class DatabaseTablesListform : Form
    {
        private readonly DatabaseManagementSystemDatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm notificationForm;
        private readonly string _databaseName;
        public DatabaseTablesListform(DatabaseManagementSystemDatabaseEngine.DatabaseEngine engine, NotificationForm form, string databaseName)
        {
            InitializeComponent();
            _databaseEngine = engine;
            notificationForm = form;
            _databaseName = databaseName;
            TablesList.BeginUpdate();
            _databaseEngine.GetTableNames(_databaseName).ForEach(name => TablesList.Items.Add(name));
            if (TablesList.Items.Count > 0)
            {
                TablesList.SelectedItem = TablesList.Items[0];
            }
        }

        public void UpdateList()
        {
            TablesList.Items.Clear();
            _databaseEngine.GetTableNames(_databaseName).ForEach(name => TablesList.Items.Add(name));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            this.Close();
        }

        private void CreateTableButton_Click(object sender, EventArgs e)
        {
            var form = new TableForm(_databaseEngine, notificationForm, _databaseName, this);
            form.Show();
            this.Visible = false;
        }

        private void TablesList_DoubleClick(object sender, EventArgs e)
        {
            var form = new TableForm(_databaseEngine, notificationForm, _databaseName, this, TablesList.SelectedItem as string);
            form.Show();
            this.Visible = false;
        }

        private void RemoveTableButton_Click(object sender, EventArgs e)
        {
            var validationResult = new ValidationResult();
            var selected = TablesList.SelectedItem;
            _databaseEngine.DeleteTable(_databaseName, selected as string, validationResult);

            notificationForm.Notify(validationResult.Message);
            TablesList.Items.Remove(selected);
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            var form = new TableJoinForm(_databaseEngine, notificationForm, _databaseName);
            form.Owner = this;
            form.Show();
            this.Visible = false;
        }
    }
}
