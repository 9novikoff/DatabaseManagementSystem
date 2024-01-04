namespace DatabaseManagementStudio
{
    partial class TableJoinForm
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
            firstTableComboBox = new ComboBox();
            secondTableComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            JoinButton = new Button();
            cancelButton = new Button();
            resultTableDataGrid = new DataGridView();
            firstTableColumnComboBox = new ComboBox();
            label3 = new Label();
            secondTableColumnComboBox = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)resultTableDataGrid).BeginInit();
            SuspendLayout();
            // 
            // firstTableComboBox
            // 
            firstTableComboBox.FormattingEnabled = true;
            firstTableComboBox.Location = new Point(12, 32);
            firstTableComboBox.Name = "firstTableComboBox";
            firstTableComboBox.Size = new Size(460, 28);
            firstTableComboBox.TabIndex = 0;
            firstTableComboBox.SelectedValueChanged += firstTableComboBox_SelectedValueChanged;
            // 
            // secondTableComboBox
            // 
            secondTableComboBox.FormattingEnabled = true;
            secondTableComboBox.Location = new Point(12, 140);
            secondTableComboBox.Name = "secondTableComboBox";
            secondTableComboBox.Size = new Size(460, 28);
            secondTableComboBox.TabIndex = 1;
            secondTableComboBox.SelectedValueChanged += secondTableComboBox_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 2;
            label1.Text = "Select first table to join";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 117);
            label2.Name = "label2";
            label2.Size = new Size(185, 20);
            label2.TabIndex = 3;
            label2.Text = "Select second table to join";
            // 
            // JoinButton
            // 
            JoinButton.BackColor = Color.LightGray;
            JoinButton.Location = new Point(12, 241);
            JoinButton.Name = "JoinButton";
            JoinButton.Size = new Size(200, 50);
            JoinButton.TabIndex = 4;
            JoinButton.Text = "Join";
            JoinButton.UseVisualStyleBackColor = false;
            JoinButton.Click += JoinButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(12, 611);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(200, 50);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // resultTableDataGrid
            // 
            resultTableDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultTableDataGrid.Location = new Point(487, 9);
            resultTableDataGrid.Name = "resultTableDataGrid";
            resultTableDataGrid.RowHeadersWidth = 51;
            resultTableDataGrid.RowTemplate.Height = 29;
            resultTableDataGrid.Size = new Size(763, 588);
            resultTableDataGrid.TabIndex = 6;
            // 
            // firstTableColumnComboBox
            // 
            firstTableColumnComboBox.FormattingEnabled = true;
            firstTableColumnComboBox.Location = new Point(12, 86);
            firstTableColumnComboBox.Name = "firstTableColumnComboBox";
            firstTableColumnComboBox.Size = new Size(460, 28);
            firstTableColumnComboBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(169, 20);
            label3.TabIndex = 8;
            label3.Text = "Select first table column";
            // 
            // secondTableColumnComboBox
            // 
            secondTableColumnComboBox.FormattingEnabled = true;
            secondTableColumnComboBox.Location = new Point(12, 194);
            secondTableColumnComboBox.Name = "secondTableColumnComboBox";
            secondTableColumnComboBox.Size = new Size(460, 28);
            secondTableColumnComboBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 171);
            label4.Name = "label4";
            label4.Size = new Size(191, 20);
            label4.TabIndex = 10;
            label4.Text = "Select second table column";
            // 
            // TableJoinForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(label4);
            Controls.Add(secondTableColumnComboBox);
            Controls.Add(label3);
            Controls.Add(firstTableColumnComboBox);
            Controls.Add(resultTableDataGrid);
            Controls.Add(cancelButton);
            Controls.Add(JoinButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(secondTableComboBox);
            Controls.Add(firstTableComboBox);
            Name = "TableJoinForm";
            Text = "TableJoinForm";
            ((System.ComponentModel.ISupportInitialize)resultTableDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox firstTableComboBox;
        private ComboBox secondTableComboBox;
        private Label label1;
        private Label label2;
        private Button JoinButton;
        private Button cancelButton;
        private DataGridView resultTableDataGrid;
        private ComboBox firstTableColumnComboBox;
        private Label label3;
        private ComboBox secondTableColumnComboBox;
        private Label label4;
    }
}