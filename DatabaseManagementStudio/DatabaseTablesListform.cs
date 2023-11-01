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
        private readonly DatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm notificationForm;
        public DatabaseTablesListform(DatabaseEngine.DatabaseEngine engine, NotificationForm form, string databaseName)
        {
            InitializeComponent();
            _databaseEngine = engine;
            notificationForm = form;
            TablesList.BeginUpdate();
            _databaseEngine.GetTableNames(databaseName).ForEach(name => TablesList.Items.Add(name));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            this.Close();
        }

        private void CreateTableButton_Click(object sender, EventArgs e)
        {

        }
    }
}
