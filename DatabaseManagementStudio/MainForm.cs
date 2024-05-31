namespace DatabaseManagementStudio
{
    public partial class MainForm : Form
    {
        private readonly DatabaseManagementSystemDatabaseEngine.DatabaseEngine _databaseEngine;
        private readonly NotificationForm _notificationForm;
        public MainForm()
        {
            InitializeComponent();
            _databaseEngine = new DatabaseManagementSystemDatabaseEngine.DatabaseEngine();
            _notificationForm = new NotificationForm();
        }


        private void NewDatabaseButton_Click(object sender, EventArgs e)
        {
            var createDatabaseForm = new CreateDatabaseForm(_databaseEngine, _notificationForm);
            createDatabaseForm.Show();
            createDatabaseForm.Owner = this;
            this.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            var reviewForm = new DatabasesListForm(_databaseEngine, _notificationForm);
            reviewForm.Show();
            reviewForm.Owner = this;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectFolderDialog = new FolderBrowserDialog();
            
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                var validationResult = new DatabaseManagementSystemDatabaseEngine.ValidationResult();
                _databaseEngine.LoadDatabase(selectFolderDialog.SelectedPath, validationResult);
                _notificationForm.Notify(validationResult.Message);
            }           
        }
    }
}