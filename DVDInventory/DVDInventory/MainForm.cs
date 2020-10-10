using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.DVDInventory
{
    public partial class MainForm : Form
    {
        private Boolean SkipVersionCheck;

        private Dictionary<String, List<String>> CollectionList;

        private Dictionary<String, Boolean> RemovedIds;

        public MainForm(Boolean skipVersionCheck)
        {
            SkipVersionCheck = skipVersionCheck;
            CollectionList = new Dictionary<String, List<String>>();
            RemovedIds = new Dictionary<String, Boolean>();
            InitializeComponent();
        }

        private void OnOpenCollectionXMLToolStripMenuItemClick(Object sender, EventArgs e)
        {
            OpenXmlFile("Collection");
        }

        private void OpenXmlFile(String fileName
            , String initialFolder = null)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Filter = fileName + ".xml|*.xml";
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.FileName = fileName + ".xml";
                if (String.IsNullOrEmpty(initialFolder) == false)
                {
                    ofd.InitialDirectory = initialFolder;
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Boolean onlyParents;

                    if (MessageBox.Show(MessageBoxTexts.ImportOnlyParents, String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        onlyParents = true;
                    }
                    else
                    {
                        onlyParents = false;
                    }

                    Cursor = Cursors.WaitCursor;
                    UPCDataGridView.SuspendLayout();
                    ManualDiscIdDataGridView.SuspendLayout();
                    SuspendLayout();
                    UPCTextBox.Text = String.Empty;
                    UPCDataGridView.Rows.Clear();
                    ManualDiscIdDataGridView.Rows.Clear();
                    CollectionList = new Dictionary<String, List<String>>();
                    try
                    {
                        Collection collection;

                        collection = DVDProfilerSerializer<Collection>.Deserialize(ofd.FileName);
                        if ((collection != null) && (collection.DVDList != null) && (collection.DVDList.Length > 0))
                        {
                            List<DataGridViewRow> upcRows;
                            List<DataGridViewRow> manualDiscIdRows;

                            upcRows = new List<DataGridViewRow>();
                            manualDiscIdRows = new List<DataGridViewRow>();
                            foreach (DVD dvd in collection.DVDList)
                            {
                                DataGridViewRow row;

                                if ((onlyParents) && (HasParent(dvd)))
                                {
                                    continue;
                                }

                                row = CreateRow();
                                if (CollectionList.ContainsKey(dvd.ID_Base) == false)
                                {
                                    CollectionList.Add(dvd.ID_Base, new List<String>(1));
                                }
                                CollectionList[dvd.ID_Base].Add(GetProfileId(dvd));
                                if (dvd.ID_Type != DVDID_Type.UPCEAN)
                                {
                                    manualDiscIdRows.Add(row);
                                }
                                else
                                {
                                    upcRows.Add(row);
                                }
                                row.Tag = dvd;
                                row.Cells[0].Value = dvd.UPC;
                                row.Cells[1].Value = dvd.Title;
                                row.Cells[2].Value = dvd.Edition;
                                row.Cells[3].Value = dvd.OriginalTitle;
                                row.Cells[4].Value = dvd.SortTitle;
                                row.Cells[5].Value = dvd.ID_LocalityDesc;
                                row.Cells[6].Value = dvd.ID_LocalityID;
                                if (dvd.ID_VariantNum > 0)
                                {
                                    row.Cells[7].Value = dvd.ID_VariantNum;
                                }
                                else
                                {
                                    row.Cells[7].Value = String.Empty;
                                }
                            }
                            UPCDataGridView.Rows.AddRange(upcRows.ToArray());
                            ManualDiscIdDataGridView.Rows.AddRange(manualDiscIdRows.ToArray());
                        }
                        UPCDataGridView.Sort(UPCDataGridView.Columns["SortTitle"]
                            , ListSortDirection.Ascending);
                        ManualDiscIdDataGridView.Sort(ManualDiscIdDataGridView.Columns["SortTitle"]
                            , ListSortDirection.Ascending);
                        UPCTextBox.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, ofd.FileName, ex.Message)
                            , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        UPCDataGridView.ResumeLayout();
                        ManualDiscIdDataGridView.ResumeLayout();
                        ResumeLayout();
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private static string GetProfileId(DVD dvd)
        {
            var profileId = dvd.UPC;
            var locality = dvd.ID_LocalityDesc;
            var variant = dvd.ID_VariantNum > 0 ? dvd.ID_VariantNum.ToString() : null;
            var edition = dvd.Edition;
            var title = dvd.Title;

            GetProfileId(ref profileId, locality, variant, title, edition);

            return profileId;
        }

        private string GetProfileId(DataGridViewRow row)
        {
            var profileId = row.Cells["UPC"].Value.ToString();
            var locality = row.Cells["Locality"].Value.ToString();
            var variant = row.Cells["Variant"].Value.ToString();
            var edition = row.Cells["Edition"].Value.ToString();
            var title = row.Cells["Title"].Value.ToString();

            GetProfileId(ref profileId, locality, variant, title, edition);

            return profileId;
        }

        private static void GetProfileId(ref string profileId, string locality, string variant, string title, string edition)
        {
            if (string.IsNullOrEmpty(locality) == false)
            {
                profileId += " (" + locality + ")";
            }

            if (string.IsNullOrEmpty(variant) == false)
            {
                profileId += " #" + variant;
            }

            profileId += " \"" + title + "\"";

            if (string.IsNullOrEmpty(edition) == false)
            {
                profileId += " (" + edition + ")";
            }
        }

        private static Boolean HasParent(DVD dvd)
        {
            Boolean hasParent;

            hasParent = ((dvd.BoxSet != null) && (String.IsNullOrEmpty(dvd.BoxSet.Parent) == false));

            return (hasParent);
        }

        private static DataGridViewRow CreateRow()
        {
            DataGridViewRow row;
            DataGridViewTextBoxCell upcCell;
            DataGridViewTextBoxCell titleCell;
            DataGridViewTextBoxCell editionCell;
            DataGridViewTextBoxCell originalTitleCell;
            DataGridViewTextBoxCell sortTitleCell;
            DataGridViewTextBoxCell localityCell;
            DataGridViewTextBoxCell localityIdCell;
            DataGridViewTextBoxCell variantCell;

            upcCell = new DataGridViewTextBoxCell();
            titleCell = new DataGridViewTextBoxCell();
            editionCell = new DataGridViewTextBoxCell();
            originalTitleCell = new DataGridViewTextBoxCell();
            sortTitleCell = new DataGridViewTextBoxCell();
            localityCell = new DataGridViewTextBoxCell();
            localityIdCell = new DataGridViewTextBoxCell();
            variantCell = new DataGridViewTextBoxCell();

            row = new DataGridViewRow();

            row.Cells.AddRange(new System.Windows.Forms.DataGridViewCell[] { upcCell, titleCell
                , editionCell, originalTitleCell, sortTitleCell ,localityCell, localityIdCell, variantCell  });
            return (row);
        }

        private void OnOpenInventoryXMLToolStripMenuItemClick(Object sender, EventArgs e)
        {
            String initialFolder;

            initialFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + @"\DVD Inventory";
            if (Directory.Exists(initialFolder))
            {
                OpenXmlFile("Inventory", initialFolder);
            }
            else
            {
                OpenXmlFile("Inventory");
            }
        }

        private void OnSaveInventoryXMLToolStripMenuItemClick(Object sender, EventArgs e)
        {
            SaveInventoryXml();
        }

        private DialogResult SaveInventoryXml()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                DialogResult result;

                try
                {
                    String initialFolder;

                    initialFolder = GetDocumentsFolder();
                    sfd.InitialDirectory = initialFolder;
                }
                catch
                {
                }
                sfd.FileName = "Inventory.xml";
                sfd.Filter = "Inventory.xml|*.xml";
                sfd.OverwritePrompt = true;
                sfd.RestoreDirectory = true;
                sfd.ValidateNames = true;
                result = sfd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    result = SaveInventoryXml(sfd.FileName, true);
                }
                return (result);
            }
        }

        private DialogResult SaveInventoryXml(String fileName
            , Boolean withErrorMessage)
        {
            DialogResult result;
            Collection collection;
            List<DVD> dvds;

            dvds = new List<DVD>(UPCDataGridView.Rows.Count
                + ManualDiscIdDataGridView.Rows.Count);
            CreateInventoryRows(dvds, UPCDataGridView);
            CreateInventoryRows(dvds, ManualDiscIdDataGridView);
            collection = new Collection();
            collection.DVDList = dvds.ToArray();
            try
            {
                collection.Serialize(fileName);
                result = DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (withErrorMessage)
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, fileName, ex.Message)
                        , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                result = DialogResult.Abort;
            }

            return result;
        }

        private static string GetDocumentsFolder()
        {
            String initialFolder;
            initialFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + @"\DVD Inventory";
            if (Directory.Exists(initialFolder) == false)
            {
                Directory.CreateDirectory(initialFolder);
            }
            return initialFolder;
        }

        private static void CreateInventoryRows(List<DVD> dvds, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DVD dvd;

                dvd = (DVD)(row.Tag);
                dvd.AudioList = null;
                dvd.CastList = null;
                dvd.CrewList = null;
                dvd.DiscList = null;
                dvd.EventList = null;
                dvd.Features = null;
                dvd.Format = null;
                dvd.GenreList = null;
                dvd.LoanInfo = null;
                dvd.Locks = null;
                dvd.MediaCompanyList = null;
                dvd.MyLinks = null;
                dvd.Notes = null;
                dvd.Overview = null;
                dvd.PluginCustomData = null;
                dvd.PurchaseInfo = null;
                dvd.RegionList = null;
                dvd.StudioList = null;
                dvd.SubtitleList = null;
                dvd.TagList = null;
                dvd.Exclusions = null;
                dvd.MediaBanners = null;

                dvd.OpenElements = null;

                dvds.Add(dvd);
            }
        }

        private void OnReadMeToolStripMenuItemClick(Object sender, EventArgs e)
        {
            OpenReadme();
        }

        private void OnAboutDVDInventoryToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox(GetType().Assembly))
            {
                aboutBox.ShowDialog();
            }
        }

        private void OnMainFormLoad(Object sender, EventArgs e)
        {
            SuspendLayout();
            LayoutForm();
            AddColumns(UPCDataGridView);
            AddColumns(ManualDiscIdDataGridView);
            ResumeLayout();
            if (Program.Settings.CurrentVersion != Assembly.GetExecutingAssembly().GetName().Version.ToString())
            {
                OpenReadme();
                Program.Settings.CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private static void AddColumns(DataGridView dataGridView)
        {
            DataGridViewTextBoxColumn upcColumn;
            DataGridViewTextBoxColumn titleColumn;
            DataGridViewTextBoxColumn editionColumn;
            DataGridViewTextBoxColumn originalTitleColumn;
            DataGridViewTextBoxColumn sortTitleColumn;
            DataGridViewTextBoxColumn localityColumn;
            DataGridViewTextBoxColumn localityIdColumn;
            DataGridViewTextBoxColumn variantColumn;

            upcColumn = new DataGridViewTextBoxColumn();
            titleColumn = new DataGridViewTextBoxColumn();
            editionColumn = new DataGridViewTextBoxColumn();
            originalTitleColumn = new DataGridViewTextBoxColumn();
            sortTitleColumn = new DataGridViewTextBoxColumn();
            localityColumn = new DataGridViewTextBoxColumn();
            localityIdColumn = new DataGridViewTextBoxColumn();
            variantColumn = new DataGridViewTextBoxColumn();

            upcColumn.HeaderText = "UPC / EAN";
            upcColumn.Name = "UPC";

            titleColumn.HeaderText = "Title";
            titleColumn.Name = "Title";

            editionColumn.HeaderText = "Edition";
            editionColumn.Name = "Edition";
            originalTitleColumn.HeaderText = "Original Title";
            originalTitleColumn.Name = "OriginalTitle";

            sortTitleColumn.HeaderText = "Sort Title";
            sortTitleColumn.Name = "SortTitle";

            localityColumn.HeaderText = "Locality";
            localityColumn.Name = "Locality";

            localityIdColumn.HeaderText = "LocalityId";
            localityIdColumn.Name = "LocalityId";
            localityIdColumn.Visible = false;


            variantColumn.HeaderText = "Variant";
            variantColumn.Name = "Variant";

            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { upcColumn, titleColumn
                , editionColumn, originalTitleColumn, sortTitleColumn ,localityColumn, localityIdColumn, variantColumn });
        }

        private void CheckForNewVersion(Boolean skipVersionCheck)
        {
            if (skipVersionCheck == false)
            {
                OnlineAccess.Init("Doena Soft.", "DVDInventory");
                OnlineAccess.CheckForNewVersion("http://doena-soft.de/dvdprofiler/3.9.0/versions.xml", this, "DVDInventory", GetType().Assembly);
            }
        }

        private void LayoutForm()
        {
            if (Program.Settings.MainForm.WindowState == FormWindowState.Normal)
            {
                Left = Program.Settings.MainForm.Left;
                Top = Program.Settings.MainForm.Top;
                if (Program.Settings.MainForm.Width > MinimumSize.Width)
                {
                    Width = Program.Settings.MainForm.Width;
                }
                else
                {
                    Width = MinimumSize.Width;
                }
                if (Program.Settings.MainForm.Height > MinimumSize.Height)
                {
                    Height = Program.Settings.MainForm.Height;
                }
                else
                {
                    Height = MinimumSize.Height;
                }
            }
            else
            {
                Left = Program.Settings.MainForm.RestoreBounds.X;
                Top = Program.Settings.MainForm.RestoreBounds.Y;
                if (Program.Settings.MainForm.RestoreBounds.Width > MinimumSize.Width)
                {
                    Width = Program.Settings.MainForm.RestoreBounds.Width;
                }
                else
                {
                    Width = MinimumSize.Width;
                }
                if (Program.Settings.MainForm.RestoreBounds.Height > MinimumSize.Height)
                {
                    Height = Program.Settings.MainForm.RestoreBounds.Height;
                }
                else
                {
                    Height = MinimumSize.Height;
                }
            }
            if (Program.Settings.MainForm.WindowState != FormWindowState.Minimized)
            {
                WindowState = Program.Settings.MainForm.WindowState;
            }
        }

        private void OpenReadme()
        {
            if (File.Exists(Application.StartupPath + @"\Readme\readme.html"))
            {
                using (HelpForm helpForm = new HelpForm())
                {
                    helpForm.Text = "Read Me";
                    helpForm.ShowDialog(this);
                }
            }
        }

        private void OnRemoveProfileByUpcButtonClick(Object sender, EventArgs e)
        {
            RemoveUPC(true);
        }

        private void RemoveUPC(Boolean withErrorMessage)
        {

            RemoveById(withErrorMessage, UPCTextBox.Text, false, out bool temp, out temp);
        }

        private void RemoveById(Boolean withErrorMessage, String id, Boolean autoInput, out Boolean success, out Boolean cancel)
        {
            String alternateUpc;
            String errorText;

            success = true;
            cancel = false;
            if (CollectionList.ContainsKey(id))
            {
                success = RemoveUPC(id, autoInput);
                return;
            }
            if ((id.StartsWith("I") == false) && (id.StartsWith("M") == false))
            {
                alternateUpc = "0" + id;
                if ((id.Length == 12) && (CollectionList.ContainsKey(alternateUpc)))
                {
                    success = RemoveUPC(alternateUpc, autoInput);
                    return;
                }
            }
            else
            {
                alternateUpc = String.Empty;
            }
            if (withErrorMessage)
            {
                errorText = String.Format("{0} {1} could not be found in List!", DetermineIdType(id), id);
                if ((RemovedIds.ContainsKey(id) == false) && (RemovedIds.ContainsKey(alternateUpc) == false))
                {
                    AddLog(errorText);
                    RemovedIds.Add(id, false);
                }
                else
                {
                    if ((RemovedIds.ContainsKey(id)) && (RemovedIds[id] == true))
                    {
                        errorText = String.Format("{0} {1} has been removed already!", DetermineIdType(id), id);
                        AddLog(errorText);
                    }
                    else if ((RemovedIds.ContainsKey(alternateUpc)) && (RemovedIds[alternateUpc] == true))
                    {
                        errorText = String.Format("{0} {1} has been removed already!", DetermineIdType(id), id); ;
                        AddLog(errorText);
                    }
                }
                if (autoInput)
                {
                    success = false;
                    if (MessageBox.Show(errorText, MessageBoxTexts.WarningHeader
                          , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        cancel = true;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(errorText, MessageBoxTexts.WarningHeader
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    success = false;
                    return;
                }
                if (autoInput == false)
                {
                    UPCTextBox.SelectAll();
                    UPCTextBox.Focus();
                }
            }
            else
            {
                if ((RemovedIds.ContainsKey(id)) && (RemovedIds[id] == true))
                {
                    errorText = String.Format("{0} {1} has been removed already!", DetermineIdType(id), id); ;
                    AddLog(errorText);
                    if (autoInput == false)
                    {
                        UPCTextBox.SelectAll();
                        UPCTextBox.Focus();
                    }
                }
                else if ((RemovedIds.ContainsKey(alternateUpc)) && (RemovedIds[alternateUpc] == true))
                {
                    errorText = String.Format("{0} {1} has been removed already!", DetermineIdType(id), id); ;
                    AddLog(errorText);
                    if (autoInput == false)
                    {
                        UPCTextBox.SelectAll();
                        UPCTextBox.Focus();
                    }
                }
            }
        }

        private void AddLog(String text)
        {
            String fileName;

            text += Environment.NewLine + Environment.NewLine;
            LogTextbox.Text += text;

            fileName = GetLogFileName();

            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                sw.Write(text);
            }
        }

        private String GetLogFileName()
        {
            String fileName;
            String path;
            DateTime today;

            path = GetDocumentsFolder();

            today = DateTime.Now;

            fileName = "Log_" + today.ToString("yyyy_MM_dd") + ".log";

            fileName = Path.Combine(path, fileName);

            return (fileName);
        }

        private static String DetermineIdType(String id)
        {
            switch (id[0])
            {
                case ('I'):
                    {
                        return ("Disc ID");
                    }
                case ('M'):
                    {
                        return ("Manual Profile");
                    }
                case ('_'):
                    {
                        return ("Plugin-specific ID");
                    }
                default:
                    {
                        return ("UPC / EAN");
                    }
            }
        }

        private Boolean RemoveUPC(String upc, Boolean autoInput)
        {
            DataGridView dataGrid;

            if ((upc.StartsWith("I")) || (upc.StartsWith("M")))
            {
                dataGrid = ManualDiscIdDataGridView;
            }
            else
            {
                dataGrid = UPCDataGridView;
            }
            for (Int32 i = dataGrid.Rows.Count - 1; i >= 0; i--)
            {
                DVD dvd;
                DataGridViewRow row;

                row = dataGrid.Rows[i];
                dvd = (DVD)(row.Tag);
                if (dvd.ID_Base == upc)
                {

                    if (CollectionList[upc].Count == 1)
                    {
                        dataGrid.Rows.RemoveAt(i);
                        RemoveIdFromCollectionList(dvd);
                        if (autoInput == false)
                        {
                            UPCTextBox.Text = String.Empty;
                            System.Media.SystemSounds.Asterisk.Play();
                        }
                        return (true);
                    }
                    else
                    {
                        String variant;

                        variant = row.Cells["Variant"].Value.ToString();
                        if (String.IsNullOrEmpty(variant) == false)
                        {
                            variant = ", Variant: " + variant;
                        }
                        if (MessageBox.Show(String.Format("There are multiple entries with {0} {1} .\nRemove \"{2}\" , Locality: {3}{4}?"
                            , DetermineIdType(row.Cells["UPC"].Value.ToString()), row.Cells["UPC"].Value, row.Cells["Title"].Value, row.Cells["Locality"].Value, variant)
                            , "Remove Profile?", MessageBoxButtons.YesNo
                            , MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            String extId;

                            extId = GetProfileId(row);
                            dataGrid.Rows.RemoveAt(i);
                            CollectionList[upc].Remove(extId);
                            AddLog(String.Format("Successfully removed {0}", extId));
                            SaveTempFile();
                            if (autoInput == false)
                            {
                                UPCTextBox.Text = String.Empty;
                            }
                            return (true);
                        }
                    }
                }
            }
            if (autoInput == false)
            {
                UPCTextBox.SelectAll();
                UPCTextBox.Focus();
            }
            return (true);
        }

        private void RemoveIdFromCollectionList(DVD dvd)
        {
            CollectionList.Remove(dvd.ID_Base);
            AddLog(String.Format("Successfully removed {0}", GetProfileId(dvd)));
            if (RemovedIds.ContainsKey(dvd.ID_Base) == false)
            {
                RemovedIds.Add(dvd.ID_Base, true);
            }
            SaveTempFile();
        }

        private void SaveTempFile()
        {
            String fileName;

            fileName = GetTempFileName();

            SaveInventoryXml(fileName, false);
        }

        private String GetTempFileName()
        {
            String fileName;
            String path;

            path = GetDocumentsFolder();

            fileName = "Inventory.tmp.xml";

            fileName = Path.Combine(path, fileName);

            return (fileName);
        }

        private void OnUPCTextBoxTextChanged(Object sender, EventArgs e)
        {
            if (UPCTextBox.Text.Length == 12)
            {
                RemoveUPC(false);
            }
            else if (UPCTextBox.Text.Length == 13)
            {
                RemoveUPC(true);
            }
        }

        private void OnMainFormClosing(Object sender, FormClosingEventArgs e)
        {
            if ((UPCDataGridView.RowCount > 0) || (ManualDiscIdDataGridView.RowCount > 0))
            {
                if (MessageBox.Show("Save Inventory XML?", "Save XML?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if (SaveInventoryXml() != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            Program.Settings.MainForm.Left = Left;
            Program.Settings.MainForm.Top = Top;
            Program.Settings.MainForm.Width = Width;
            Program.Settings.MainForm.Height = Height;
            Program.Settings.MainForm.WindowState = WindowState;
            Program.Settings.MainForm.RestoreBounds = RestoreBounds;
        }

        private void OnUPCDataGridViewUserDeletingRow(Object sender, DataGridViewRowCancelEventArgs e)
        {
            RemoveRow(e.Row);
        }

        private void RemoveRow(DataGridViewRow row)
        {
            DVD dvd;

            dvd = (DVD)(row.Tag);
            if (CollectionList[dvd.ID_Base].Count > 1)
            {
                String extId;

                extId = GetProfileId(row);
                CollectionList[dvd.ID_Base].Remove(extId);
                AddLog(String.Format("Successfully removed {0}", extId));
                SaveTempFile();
            }
            else
            {
                RemoveIdFromCollectionList(dvd);
            }
        }

        private void OnRemoveSelectedUpcRowProfileButtonClick(Object sender, EventArgs e)
        {
            RemoveSelectedRow(UPCDataGridView);
        }

        private void RemoveSelectedRow(DataGridView dataGrid)
        {
            DataGridViewSelectedRowCollection rows;

            rows = dataGrid.SelectedRows;

            if (rows.Count > 0)
            {
                RemoveRow(rows[0]);
                dataGrid.Rows.RemoveAt(rows[0].Index);
            }
        }

        private void OnExportFlagSetListToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "";
                sfd.Filter = "Flag Set List (*.lst)|*.lst";
                sfd.OverwritePrompt = true;
                sfd.RestoreDirectory = true;
                sfd.ValidateNames = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    List<String> ids;

                    ids = new List<String>(UPCDataGridView.Rows.Count + ManualDiscIdDataGridView.Rows.Count);
                    foreach (DataGridViewRow row in UPCDataGridView.Rows)
                    {
                        DVD dvd;

                        dvd = (DVD)(row.Tag);
                        ids.Add(dvd.ID);
                    }
                    foreach (DataGridViewRow row in ManualDiscIdDataGridView.Rows)
                    {
                        DVD dvd;

                        dvd = (DVD)(row.Tag);
                        ids.Add(dvd.ID);
                    }
                    try
                    {
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write
                            , FileShare.None))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1252)))
                            {
                                foreach (String id in ids)
                                {
                                    sw.WriteLine(id);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, sfd.FileName, ex.Message)
                            , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OnImportUPCListToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text File (*.txt)|*.txt|Any File (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                while (sr.EndOfStream == false)
                                {
                                    String line;

                                    line = sr.ReadLine().Trim();
                                    if (String.IsNullOrEmpty(line) == false)
                                    {

                                        RemoveById(true, line, true, out bool success, out bool temp);
                                        if (success == false)
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, ofd.FileName, ex.Message)
                            , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OnManualDiscIdDataGridViewUserDeletingRow(Object sender, DataGridViewRowCancelEventArgs e)
        {
            RemoveRow(e.Row);
        }

        private void OnImportDiscIdListToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text File (*.txt)|*.txt|Any File (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                while (sr.EndOfStream == false)
                                {
                                    String discId;

                                    discId = sr.ReadLine().Trim();
                                    if (discId.StartsWith("I") == false)
                                    {
                                        discId = "I" + discId;
                                    }
                                    RemoveById(true, discId, true, out bool success, out bool temp);
                                    if (success == false)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, ofd.FileName, ex.Message)
                            , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OnCheckForUpdateToolStripMenuItemClick(Object sender, EventArgs e)
        {
            CheckForNewVersion(false);
        }

        private void OnProcessListButtonClick(Object sender, EventArgs e)
        {
            List<String> ids;
            String[] split;
            StringBuilder temp;

            Cursor = Cursors.WaitCursor;
            ids = new List<String>(50);
            split = MassUpcTextBox.Text.Split('\n');
            for (Int32 i = split.Length - 1; i >= 0; i--)
            {
                String line;

                line = split[i].Trim();
                if (String.IsNullOrEmpty(line) == false)
                {
                    ids.Add(line);
                }
            }
            for (Int32 i = ids.Count - 1; i >= 0; i--)
            {

                RemoveById(true, ids[i], true, out bool success, out bool cancel);
                if (cancel)
                {
                    break;
                }
                if (success)
                {
                    ids.RemoveAt(i);
                }
            }
            temp = new StringBuilder();
            for (Int32 i = ids.Count - 1; i >= 0; i--)
            {
                temp.AppendLine(ids[i]);
            }
            MassUpcTextBox.Text = temp.ToString();
            Cursor = Cursors.Default;
            MassUpcTextBox.Focus();
        }

        private void OnTabControlSelectedIndexChanged(Object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                UPCTextBox.Focus();
            }
            else if (TabControl.SelectedIndex == 1)
            {
                MassUpcTextBox.Focus();
            }
        }

        private void OnRemoveSelectedManualRowButtonClick(Object sender, EventArgs e)
        {
            RemoveSelectedRow(ManualDiscIdDataGridView);
        }
    }
}