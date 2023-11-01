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
        private readonly DatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm notificationForm;
        public DatabasesListForm(DatabaseEngine.DatabaseEngine engine, NotificationForm form)
        {
            InitializeComponent();
            _databaseEngine = engine;
            notificationForm = form;
            DatabasesList.BeginUpdate();
            _databaseEngine.GetDatabaseNames().ForEach(name => DatabasesList.Items.Add(name));
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            this.Close();
        }

        private void DatabasesList_DoubleClick(object sender, EventArgs e)
        {
            DatabaseTablesListform form = new DatabaseTablesListform(_databaseEngine, notificationForm, DatabasesList.SelectedItem as string);
            form.Show();
            form.Owner = this;
            this.Visible = false;
        }
    }
}
