namespace DatabaseManagementStudio
{
    partial class DatabaseTablesListform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CancelButton = new Button();
            CreateTableButton = new Button();
            TablesList = new ListBox();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(227, 611);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(200, 50);
            CancelButton.TabIndex = 0;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // CreateTableButton
            // 
            CreateTableButton.Location = new Point(12, 611);
            CreateTableButton.Name = "CreateTableButton";
            CreateTableButton.Size = new Size(200, 50);
            CreateTableButton.TabIndex = 1;
            CreateTableButton.Text = "Create new table";
            CreateTableButton.UseVisualStyleBackColor = true;
            CreateTableButton.Click += CreateTableButton_Click;
            // 
            // TablesList
            // 
            TablesList.BackColor = Color.LightGray;
            TablesList.ForeColor = SystemColors.ControlText;
            TablesList.FormattingEnabled = true;
            TablesList.ItemHeight = 20;
            TablesList.Location = new Point(12, 12);
            TablesList.Name = "TablesList";
            TablesList.Size = new Size(1238, 584);
            TablesList.TabIndex = 2;
            TablesList.DoubleClick += TablesList_DoubleClick;
            // 
            // DatabaseTablesListform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(TablesList);
            Controls.Add(CreateTableButton);
            Controls.Add(CancelButton);
            Name = "DatabaseTablesListform";
            Text = "DatabaseTablesListform";
            ResumeLayout(false);
        }

        #endregion

        private Button CancelButton;
        private Button CreateTableButton;
        private ListBox TablesList;
    }
}