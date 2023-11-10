namespace DatabaseManagementStudio
{
    partial class DatabasesListForm
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
            DatabasesList = new ListBox();
            CloseButton = new Button();
            RemoveDatabaseButton = new Button();
            RenameDatabaseButton = new Button();
            CancelRenamingButton = new Button();
            label1 = new Label();
            DatabaseNameTextBox = new TextBox();
            ApplyButton = new Button();
            SuspendLayout();
            // 
            // DatabasesList
            // 
            DatabasesList.BackColor = Color.LightGray;
            DatabasesList.FormattingEnabled = true;
            DatabasesList.ItemHeight = 20;
            DatabasesList.Location = new Point(12, 12);
            DatabasesList.Name = "DatabasesList";
            DatabasesList.Size = new Size(1238, 584);
            DatabasesList.TabIndex = 0;
            DatabasesList.DoubleClick += DatabasesList_DoubleClick;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.LightGray;
            CloseButton.Location = new Point(424, 611);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(200, 50);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Cancel";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // RemoveDatabaseButton
            // 
            RemoveDatabaseButton.BackColor = Color.LightGray;
            RemoveDatabaseButton.Location = new Point(12, 611);
            RemoveDatabaseButton.Name = "RemoveDatabaseButton";
            RemoveDatabaseButton.Size = new Size(200, 50);
            RemoveDatabaseButton.TabIndex = 2;
            RemoveDatabaseButton.Text = "Remove selected database";
            RemoveDatabaseButton.UseVisualStyleBackColor = false;
            RemoveDatabaseButton.Click += RemoveDatabaseButton_Click;
            // 
            // RenameDatabaseButton
            // 
            RenameDatabaseButton.BackColor = Color.LightGray;
            RenameDatabaseButton.Location = new Point(218, 611);
            RenameDatabaseButton.Name = "RenameDatabaseButton";
            RenameDatabaseButton.Size = new Size(200, 50);
            RenameDatabaseButton.TabIndex = 3;
            RenameDatabaseButton.Text = "Rename selected database";
            RenameDatabaseButton.UseVisualStyleBackColor = false;
            RenameDatabaseButton.Click += RenameDatabaseButton_Click;
            // 
            // CancelRenamingButton
            // 
            CancelRenamingButton.BackColor = Color.LightGray;
            CancelRenamingButton.Location = new Point(1050, 611);
            CancelRenamingButton.Name = "CancelRenamingButton";
            CancelRenamingButton.Size = new Size(200, 50);
            CancelRenamingButton.TabIndex = 4;
            CancelRenamingButton.Text = "Cancel renaming";
            CancelRenamingButton.UseVisualStyleBackColor = false;
            CancelRenamingButton.Visible = false;
            CancelRenamingButton.Click += CancelRenamingButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(630, 611);
            label1.Name = "label1";
            label1.Size = new Size(180, 20);
            label1.TabIndex = 5;
            label1.Text = "Enter new database name";
            label1.Visible = false;
            // 
            // DatabaseNameTextBox
            // 
            DatabaseNameTextBox.Location = new Point(630, 634);
            DatabaseNameTextBox.Name = "DatabaseNameTextBox";
            DatabaseNameTextBox.Size = new Size(208, 27);
            DatabaseNameTextBox.TabIndex = 6;
            DatabaseNameTextBox.Visible = false;
            // 
            // ApplyButton
            // 
            ApplyButton.BackColor = Color.LightGray;
            ApplyButton.Location = new Point(844, 611);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(200, 50);
            ApplyButton.TabIndex = 7;
            ApplyButton.Text = "Confirm";
            ApplyButton.UseVisualStyleBackColor = false;
            ApplyButton.Visible = false;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // DatabasesListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(ApplyButton);
            Controls.Add(DatabaseNameTextBox);
            Controls.Add(label1);
            Controls.Add(CancelRenamingButton);
            Controls.Add(RenameDatabaseButton);
            Controls.Add(RemoveDatabaseButton);
            Controls.Add(CloseButton);
            Controls.Add(DatabasesList);
            Name = "DatabasesListForm";
            Text = "DatabasesListForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox DatabasesList;
        private Button CloseButton;
        private Button RemoveDatabaseButton;
        private Button RenameDatabaseButton;
        private Button CancelRenamingButton;
        private Label label1;
        private TextBox DatabaseNameTextBox;
        private Button ApplyButton;
    }
}