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
    public partial class DatabasesListForm : Form
    {
        private readonly DatabaseManagementSystemDatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm notificationForm;
        public DatabasesListForm(DatabaseManagementSystemDatabaseEngine.DatabaseEngine engine, NotificationForm form)
        {
            InitializeComponent();
            _databaseEngine = engine;
            notificationForm = form;
            DatabasesList.BeginUpdate();
            _databaseEngine.GetDatabaseNames().ForEach(name => DatabasesList.Items.Add(name));
            if(DatabasesList.Items.Count > 0 )
            {
                DatabasesList.SelectedItem = DatabasesList.Items[0];
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            this.Close();
        }

        private void DatabasesList_DoubleClick(object sender, EventArgs e)
        {
            DatabaseTablesListform form = new DatabaseTablesListform(_databaseEngine, notificationForm, DatabasesList.SelectedItem as string);
            form.Owner = this;
            form.Show();
            this.Visible = false;
        }

        private void RemoveDatabaseButton_Click(object sender, EventArgs e)
        {
            var selected = DatabasesList.SelectedItem;
            _databaseEngine.DeleteDatabase(selected as string);
            DatabasesList.Items.Remove(selected);
        }

        private void RenameDatabaseButton_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            DatabaseNameTextBox.Visible = true;
            ApplyButton.Visible = true;
            CancelRenamingButton.Visible = true;
        }

        private void CancelRenamingButton_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            DatabaseNameTextBox.Visible = false;
            ApplyButton.Visible = false;
            CancelRenamingButton.Visible = false;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var selected = DatabasesList.SelectedItem;
            var newName = DatabaseNameTextBox.Text;
            var validationResult = new ValidationResult();
            _databaseEngine.RenameDatabase(selected as string, newName, validationResult);

            if (validationResult.IsValid)
            {
                DatabasesList.Items.Remove(selected);
                DatabasesList.Items.Add(newName);
                CancelRenamingButton_Click(null, null);
            }

            notificationForm.Notify(validationResult.Message);
        }
    }
}
