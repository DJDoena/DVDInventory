namespace DoenaSoft.DVDProfiler.DVDInventory
{
    partial class MainForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.UPCTabPage = new System.Windows.Forms.TabPage();
            this.RemoveSelectedUpcRowButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RemoveProfileButton = new System.Windows.Forms.Button();
            this.UPCTextBox = new System.Windows.Forms.TextBox();
            this.UPCDataGridView = new System.Windows.Forms.DataGridView();
            this.MassUpcInputTabPage = new System.Windows.Forms.TabPage();
            this.ProcessListButton = new System.Windows.Forms.Button();
            this.MassUpcTextBox = new System.Windows.Forms.TextBox();
            this.ManualDiscIdTabPage = new System.Windows.Forms.TabPage();
            this.RemoveSelectedManualRowButton = new System.Windows.Forms.Button();
            this.ManualDiscIdDataGridView = new System.Windows.Forms.DataGridView();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.LogTextbox = new System.Windows.Forms.TextBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCollectionXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInventoryXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveInventoryXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFlagSetListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFlagSetListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDiscIdListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDVDInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl.SuspendLayout();
            this.UPCTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UPCDataGridView)).BeginInit();
            this.MassUpcInputTabPage.SuspendLayout();
            this.ManualDiscIdTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualDiscIdDataGridView)).BeginInit();
            this.LogTab.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.UPCTabPage);
            this.TabControl.Controls.Add(this.MassUpcInputTabPage);
            this.TabControl.Controls.Add(this.ManualDiscIdTabPage);
            this.TabControl.Controls.Add(this.LogTab);
            this.TabControl.Location = new System.Drawing.Point(12, 27);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(628, 427);
            this.TabControl.TabIndex = 2;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.OnTabControlSelectedIndexChanged);
            // 
            // UPCTabPage
            // 
            this.UPCTabPage.Controls.Add(this.RemoveSelectedUpcRowButton);
            this.UPCTabPage.Controls.Add(this.label1);
            this.UPCTabPage.Controls.Add(this.RemoveProfileButton);
            this.UPCTabPage.Controls.Add(this.UPCTextBox);
            this.UPCTabPage.Controls.Add(this.UPCDataGridView);
            this.UPCTabPage.Location = new System.Drawing.Point(4, 22);
            this.UPCTabPage.Name = "UPCTabPage";
            this.UPCTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UPCTabPage.Size = new System.Drawing.Size(620, 401);
            this.UPCTabPage.TabIndex = 0;
            this.UPCTabPage.Text = "UPC/EAN Profiles";
            this.UPCTabPage.UseVisualStyleBackColor = true;
            // 
            // RemoveSelectedUpcRowButton
            // 
            this.RemoveSelectedUpcRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveSelectedUpcRowButton.Location = new System.Drawing.Point(446, 6);
            this.RemoveSelectedUpcRowButton.Name = "RemoveSelectedUpcRowButton";
            this.RemoveSelectedUpcRowButton.Size = new System.Drawing.Size(168, 23);
            this.RemoveSelectedUpcRowButton.TabIndex = 4;
            this.RemoveSelectedUpcRowButton.Text = "Remove Selected Row Profile ";
            this.RemoveSelectedUpcRowButton.UseVisualStyleBackColor = true;
            this.RemoveSelectedUpcRowButton.Click += new System.EventHandler(this.OnRemoveSelectedUpcRowProfileButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "UPC / EAN:";
            // 
            // RemoveProfileButton
            // 
            this.RemoveProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveProfileButton.Location = new System.Drawing.Point(305, 6);
            this.RemoveProfileButton.Name = "RemoveProfileButton";
            this.RemoveProfileButton.Size = new System.Drawing.Size(135, 23);
            this.RemoveProfileButton.TabIndex = 2;
            this.RemoveProfileButton.Text = "Remove Profile by UPC";
            this.RemoveProfileButton.UseVisualStyleBackColor = true;
            this.RemoveProfileButton.Click += new System.EventHandler(this.OnRemoveProfileByUpcButtonClick);
            // 
            // UPCTextBox
            // 
            this.UPCTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UPCTextBox.Location = new System.Drawing.Point(77, 8);
            this.UPCTextBox.MaxLength = 13;
            this.UPCTextBox.Name = "UPCTextBox";
            this.UPCTextBox.Size = new System.Drawing.Size(222, 20);
            this.UPCTextBox.TabIndex = 1;
            this.UPCTextBox.TextChanged += new System.EventHandler(this.OnUPCTextBoxTextChanged);
            // 
            // UPCDataGridView
            // 
            this.UPCDataGridView.AllowUserToAddRows = false;
            this.UPCDataGridView.AllowUserToOrderColumns = true;
            this.UPCDataGridView.AllowUserToResizeRows = false;
            this.UPCDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UPCDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.UPCDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UPCDataGridView.Location = new System.Drawing.Point(9, 35);
            this.UPCDataGridView.MultiSelect = false;
            this.UPCDataGridView.Name = "UPCDataGridView";
            this.UPCDataGridView.ReadOnly = true;
            this.UPCDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UPCDataGridView.Size = new System.Drawing.Size(605, 360);
            this.UPCDataGridView.TabIndex = 0;
            this.UPCDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.OnUPCDataGridViewUserDeletingRow);
            // 
            // MassUpcInputTabPage
            // 
            this.MassUpcInputTabPage.Controls.Add(this.ProcessListButton);
            this.MassUpcInputTabPage.Controls.Add(this.MassUpcTextBox);
            this.MassUpcInputTabPage.Location = new System.Drawing.Point(4, 22);
            this.MassUpcInputTabPage.Name = "MassUpcInputTabPage";
            this.MassUpcInputTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MassUpcInputTabPage.Size = new System.Drawing.Size(620, 401);
            this.MassUpcInputTabPage.TabIndex = 3;
            this.MassUpcInputTabPage.Text = "Mass UPC / EAN Input";
            this.MassUpcInputTabPage.UseVisualStyleBackColor = true;
            // 
            // ProcessListButton
            // 
            this.ProcessListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessListButton.Location = new System.Drawing.Point(531, 372);
            this.ProcessListButton.Name = "ProcessListButton";
            this.ProcessListButton.Size = new System.Drawing.Size(83, 23);
            this.ProcessListButton.TabIndex = 1;
            this.ProcessListButton.Text = "Process List";
            this.ProcessListButton.UseVisualStyleBackColor = true;
            this.ProcessListButton.Click += new System.EventHandler(this.OnProcessListButtonClick);
            // 
            // MassUpcTextBox
            // 
            this.MassUpcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MassUpcTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MassUpcTextBox.Location = new System.Drawing.Point(6, 6);
            this.MassUpcTextBox.Multiline = true;
            this.MassUpcTextBox.Name = "MassUpcTextBox";
            this.MassUpcTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MassUpcTextBox.Size = new System.Drawing.Size(608, 360);
            this.MassUpcTextBox.TabIndex = 0;
            // 
            // ManualDiscIdTabPage
            // 
            this.ManualDiscIdTabPage.Controls.Add(this.RemoveSelectedManualRowButton);
            this.ManualDiscIdTabPage.Controls.Add(this.ManualDiscIdDataGridView);
            this.ManualDiscIdTabPage.Location = new System.Drawing.Point(4, 22);
            this.ManualDiscIdTabPage.Name = "ManualDiscIdTabPage";
            this.ManualDiscIdTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ManualDiscIdTabPage.Size = new System.Drawing.Size(620, 401);
            this.ManualDiscIdTabPage.TabIndex = 1;
            this.ManualDiscIdTabPage.Text = "Manual / DiscId Profiles";
            this.ManualDiscIdTabPage.UseVisualStyleBackColor = true;
            // 
            // RemoveSelectedManualRowButton
            // 
            this.RemoveSelectedManualRowButton.Location = new System.Drawing.Point(6, 6);
            this.RemoveSelectedManualRowButton.Name = "RemoveSelectedManualRowButton";
            this.RemoveSelectedManualRowButton.Size = new System.Drawing.Size(168, 23);
            this.RemoveSelectedManualRowButton.TabIndex = 5;
            this.RemoveSelectedManualRowButton.Text = "Remove Selected Row Profile ";
            this.RemoveSelectedManualRowButton.UseVisualStyleBackColor = true;
            this.RemoveSelectedManualRowButton.Click += new System.EventHandler(this.OnRemoveSelectedManualRowButtonClick);
            // 
            // ManualDiscIdDataGridView
            // 
            this.ManualDiscIdDataGridView.AllowUserToAddRows = false;
            this.ManualDiscIdDataGridView.AllowUserToOrderColumns = true;
            this.ManualDiscIdDataGridView.AllowUserToResizeRows = false;
            this.ManualDiscIdDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManualDiscIdDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ManualDiscIdDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManualDiscIdDataGridView.Location = new System.Drawing.Point(8, 35);
            this.ManualDiscIdDataGridView.MultiSelect = false;
            this.ManualDiscIdDataGridView.Name = "ManualDiscIdDataGridView";
            this.ManualDiscIdDataGridView.ReadOnly = true;
            this.ManualDiscIdDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ManualDiscIdDataGridView.Size = new System.Drawing.Size(606, 360);
            this.ManualDiscIdDataGridView.TabIndex = 1;
            this.ManualDiscIdDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.OnManualDiscIdDataGridViewUserDeletingRow);
            // 
            // LogTab
            // 
            this.LogTab.Controls.Add(this.LogTextbox);
            this.LogTab.Location = new System.Drawing.Point(4, 22);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogTab.Size = new System.Drawing.Size(620, 401);
            this.LogTab.TabIndex = 2;
            this.LogTab.Text = "Log";
            this.LogTab.UseVisualStyleBackColor = true;
            // 
            // LogTextbox
            // 
            this.LogTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextbox.Location = new System.Drawing.Point(6, 6);
            this.LogTextbox.Multiline = true;
            this.LogTextbox.Name = "LogTextbox";
            this.LogTextbox.ReadOnly = true;
            this.LogTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextbox.Size = new System.Drawing.Size(608, 389);
            this.LogTextbox.TabIndex = 1;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(652, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCollectionXMLToolStripMenuItem,
            this.openInventoryXMLToolStripMenuItem,
            this.saveInventoryXMLToolStripMenuItem,
            this.exportFlagSetListToolStripMenuItem,
            this.importFlagSetListToolStripMenuItem,
            this.importDiscIdListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openCollectionXMLToolStripMenuItem
            // 
            this.openCollectionXMLToolStripMenuItem.Name = "openCollectionXMLToolStripMenuItem";
            this.openCollectionXMLToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openCollectionXMLToolStripMenuItem.Text = "Open &Collection XML";
            this.openCollectionXMLToolStripMenuItem.Click += new System.EventHandler(this.OnOpenCollectionXMLToolStripMenuItemClick);
            // 
            // openInventoryXMLToolStripMenuItem
            // 
            this.openInventoryXMLToolStripMenuItem.Name = "openInventoryXMLToolStripMenuItem";
            this.openInventoryXMLToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openInventoryXMLToolStripMenuItem.Text = "Open &Inventory XML";
            this.openInventoryXMLToolStripMenuItem.Click += new System.EventHandler(this.OnOpenInventoryXMLToolStripMenuItemClick);
            // 
            // saveInventoryXMLToolStripMenuItem
            // 
            this.saveInventoryXMLToolStripMenuItem.Name = "saveInventoryXMLToolStripMenuItem";
            this.saveInventoryXMLToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveInventoryXMLToolStripMenuItem.Text = "&Save Inventory XML";
            this.saveInventoryXMLToolStripMenuItem.Click += new System.EventHandler(this.OnSaveInventoryXMLToolStripMenuItemClick);
            // 
            // exportFlagSetListToolStripMenuItem
            // 
            this.exportFlagSetListToolStripMenuItem.Name = "exportFlagSetListToolStripMenuItem";
            this.exportFlagSetListToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exportFlagSetListToolStripMenuItem.Text = "&Export Flag Set List";
            this.exportFlagSetListToolStripMenuItem.Click += new System.EventHandler(this.OnExportFlagSetListToolStripMenuItemClick);
            // 
            // importFlagSetListToolStripMenuItem
            // 
            this.importFlagSetListToolStripMenuItem.Name = "importFlagSetListToolStripMenuItem";
            this.importFlagSetListToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.importFlagSetListToolStripMenuItem.Text = "Import &UPC/EAN List";
            this.importFlagSetListToolStripMenuItem.Click += new System.EventHandler(this.OnImportUPCListToolStripMenuItemClick);
            // 
            // importDiscIdListToolStripMenuItem
            // 
            this.importDiscIdListToolStripMenuItem.Name = "importDiscIdListToolStripMenuItem";
            this.importDiscIdListToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.importDiscIdListToolStripMenuItem.Text = "Import &DiscId List";
            this.importDiscIdListToolStripMenuItem.Click += new System.EventHandler(this.OnImportDiscIdListToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readMeToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.aboutDVDInventoryToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // readMeToolStripMenuItem
            // 
            this.readMeToolStripMenuItem.Name = "readMeToolStripMenuItem";
            this.readMeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.readMeToolStripMenuItem.Text = "&Read Me";
            this.readMeToolStripMenuItem.Click += new System.EventHandler(this.OnReadMeToolStripMenuItemClick);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.checkForUpdateToolStripMenuItem.Text = "&Check for Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.OnCheckForUpdateToolStripMenuItemClick);
            // 
            // aboutDVDInventoryToolStripMenuItem
            // 
            this.aboutDVDInventoryToolStripMenuItem.Name = "aboutDVDInventoryToolStripMenuItem";
            this.aboutDVDInventoryToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.aboutDVDInventoryToolStripMenuItem.Text = "&About";
            this.aboutDVDInventoryToolStripMenuItem.Click += new System.EventHandler(this.OnAboutDVDInventoryToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 466);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "DVD Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormClosing);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.TabControl.ResumeLayout(false);
            this.UPCTabPage.ResumeLayout(false);
            this.UPCTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UPCDataGridView)).EndInit();
            this.MassUpcInputTabPage.ResumeLayout(false);
            this.MassUpcInputTabPage.PerformLayout();
            this.ManualDiscIdTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ManualDiscIdDataGridView)).EndInit();
            this.LogTab.ResumeLayout(false);
            this.LogTab.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage UPCTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemoveProfileButton;
        private System.Windows.Forms.TextBox UPCTextBox;
        private System.Windows.Forms.DataGridView UPCDataGridView;
        private System.Windows.Forms.TabPage ManualDiscIdTabPage;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCollectionXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInventoryXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveInventoryXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutDVDInventoryToolStripMenuItem;
        private System.Windows.Forms.DataGridView ManualDiscIdDataGridView;
        private System.Windows.Forms.Button RemoveSelectedUpcRowButton;
        private System.Windows.Forms.ToolStripMenuItem exportFlagSetListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFlagSetListToolStripMenuItem;
        private System.Windows.Forms.TabPage LogTab;
        private System.Windows.Forms.TextBox LogTextbox;
        private System.Windows.Forms.ToolStripMenuItem importDiscIdListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.TabPage MassUpcInputTabPage;
        private System.Windows.Forms.Button ProcessListButton;
        private System.Windows.Forms.TextBox MassUpcTextBox;
        private System.Windows.Forms.Button RemoveSelectedManualRowButton;

    }
}