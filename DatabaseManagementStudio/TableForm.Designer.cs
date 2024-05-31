namespace DatabaseManagementStudio
{
    partial class TableForm
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
            label1 = new Label();
            TableNameTextBox = new TextBox();
            TableDataGrid = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            ColumnNameTextBox = new TextBox();
            ColumnTypeComboBox = new ComboBox();
            AddColumnButton = new Button();
            IsPrimaryCheckBox = new CheckBox();
            CreateTableButton = new Button();
            CancelButton = new Button();
            RemoveColumnButton = new Button();
            ((System.ComponentModel.ISupportInitialize)TableDataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "Table name";
            // 
            // TableNameTextBox
            // 
            TableNameTextBox.BackColor = Color.LightGray;
            TableNameTextBox.Location = new Point(12, 32);
            TableNameTextBox.Name = "TableNameTextBox";
            TableNameTextBox.Size = new Size(454, 27);
            TableNameTextBox.TabIndex = 1;
            // 
            // TableDataGrid
            // 
            TableDataGrid.BackgroundColor = Color.LightGray;
            TableDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TableDataGrid.Location = new Point(506, 9);
            TableDataGrid.Name = "TableDataGrid";
            TableDataGrid.RowHeadersWidth = 51;
            TableDataGrid.RowTemplate.Height = 29;
            TableDataGrid.Size = new Size(744, 579);
            TableDataGrid.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 3;
            label2.Text = "Column name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 4;
            label3.Text = "Column type";
            // 
            // ColumnNameTextBox
            // 
            ColumnNameTextBox.BackColor = Color.LightGray;
            ColumnNameTextBox.Location = new Point(12, 85);
            ColumnNameTextBox.Name = "ColumnNameTextBox";
            ColumnNameTextBox.Size = new Size(454, 27);
            ColumnNameTextBox.TabIndex = 5;
            // 
            // ColumnTypeComboBox
            // 
            ColumnTypeComboBox.BackColor = Color.LightGray;
            ColumnTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ColumnTypeComboBox.FormattingEnabled = true;
            ColumnTypeComboBox.Location = new Point(13, 138);
            ColumnTypeComboBox.Name = "ColumnTypeComboBox";
            ColumnTypeComboBox.Size = new Size(453, 28);
            ColumnTypeComboBox.TabIndex = 6;
            // 
            // AddColumnButton
            // 
            AddColumnButton.BackColor = Color.LightGray;
            AddColumnButton.Location = new Point(13, 202);
            AddColumnButton.Name = "AddColumnButton";
            AddColumnButton.Size = new Size(100, 32);
            AddColumnButton.TabIndex = 7;
            AddColumnButton.Text = "Add column";
            AddColumnButton.UseVisualStyleBackColor = false;
            AddColumnButton.Click += AddColumnButton_Click;
            // 
            // IsPrimaryCheckBox
            // 
            IsPrimaryCheckBox.AutoSize = true;
            IsPrimaryCheckBox.Location = new Point(13, 172);
            IsPrimaryCheckBox.Name = "IsPrimaryCheckBox";
            IsPrimaryCheckBox.Size = new Size(122, 24);
            IsPrimaryCheckBox.TabIndex = 8;
            IsPrimaryCheckBox.Text = "Is primary key";
            IsPrimaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // CreateTableButton
            // 
            CreateTableButton.BackColor = Color.LightGray;
            CreateTableButton.Location = new Point(13, 611);
            CreateTableButton.Name = "CreateTableButton";
            CreateTableButton.Size = new Size(200, 50);
            CreateTableButton.TabIndex = 9;
            CreateTableButton.Text = "Create";
            CreateTableButton.UseVisualStyleBackColor = false;
            CreateTableButton.Click += CreateTableButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.LightGray;
            CancelButton.Location = new Point(219, 611);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(200, 50);
            CancelButton.TabIndex = 10;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // RemoveColumnButton
            // 
            RemoveColumnButton.BackColor = Color.LightGray;
            RemoveColumnButton.Location = new Point(314, 202);
            RemoveColumnButton.Name = "RemoveColumnButton";
            RemoveColumnButton.Size = new Size(152, 32);
            RemoveColumnButton.TabIndex = 11;
            RemoveColumnButton.Text = "Remove last column";
            RemoveColumnButton.UseVisualStyleBackColor = false;
            RemoveColumnButton.Click += RemoveColumnButton_Click;
            // 
            // CreateTableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(RemoveColumnButton);
            Controls.Add(CancelButton);
            Controls.Add(CreateTableButton);
            Controls.Add(IsPrimaryCheckBox);
            Controls.Add(AddColumnButton);
            Controls.Add(ColumnTypeComboBox);
            Controls.Add(ColumnNameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TableDataGrid);
            Controls.Add(TableNameTextBox);
            Controls.Add(label1);
            Name = "CreateTableForm";
            Text = "CreateTableForm";
            ((System.ComponentModel.ISupportInitialize)TableDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TableNameTextBox;
        private DataGridView TableDataGrid;
        private Label label2;
        private Label label3;
        private TextBox ColumnNameTextBox;
        private ComboBox ColumnTypeComboBox;
        private Button AddColumnButton;
        private CheckBox IsPrimaryCheckBox;
        private Button CreateTableButton;
        private Button CancelButton;
        private Button RemoveColumnButton;
    }
}