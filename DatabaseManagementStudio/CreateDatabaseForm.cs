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
    public partial class CreateDatabaseForm : Form
    {
        private readonly DatabaseManagementSystemDatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm notificationForm;
        public CreateDatabaseForm(DatabaseManagementSystemDatabaseEngine.DatabaseEngine engine, NotificationForm form)
        {
            InitializeComponent();
            _databaseEngine = engine;
            notificationForm = form;
        }

        private void CreateDatabaseButton_Click(object sender, EventArgs e)
        {
            var validation = new ValidationResult();
            _databaseEngine.CreateDatabase(DatabaseNameTextBox.Text, validation);
            notificationForm.Notify(validation.Message);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            this.Close();
        }
    }
}
