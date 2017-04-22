using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;

namespace DoenaSoft.DVDProfiler.DVDInventory
{
    public static class Program
    {
        internal static Settings Settings;

        private static readonly XmlSerializer XmlSerializerSettings;

        private static readonly String SettingsFile;

        private static readonly String ErrorFile;

        private static readonly String ApplicationPath;

        private static WindowHandle WindowHandle;

        static Program()
        {
            WindowHandle = new WindowHandle();
            XmlSerializerSettings = new XmlSerializer(typeof(Settings));
            ApplicationPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Doena Soft\DVD Inventory\";
            SettingsFile = ApplicationPath + "DVDInventorySettings.xml";
            ErrorFile = Environment.GetEnvironmentVariable("TEMP") + @"\DVDInventorySettingsCrash.xml";
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread()]
        static void Main(String[] args)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("de-DE");
            //if((args != null) && (args.Length > 0))
            //{
            //    for(Int32 i = 0; i < args.Length; i++)
            //    {
            //        if(args[i] == "/lang=de")
            //        {
            //            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de");
            //            break;
            //        }
            //        else if(args[i] == "/lang=en")
            //        {
            //            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            //            break;
            //        }
            //    }
            //}
            try
            {
                MainForm mainForm;

                if(Directory.Exists(ApplicationPath) == false)
                {
                    Directory.CreateDirectory(ApplicationPath);
                }
                if(File.Exists(SettingsFile))
                {
                    try
                    {
                        using(FileStream fs = new FileStream(SettingsFile, FileMode.Open, FileAccess.Read
                            , FileShare.Read))
                        {
                            Settings = (Settings)(XmlSerializerSettings.Deserialize(fs));
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(WindowHandle, String.Format(MessageBoxTexts.FileCantBeRead, SettingsFile, ex.Message)
                            , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                CreateSettings();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if((args != null) && (args.Length > 0))
                {
                    Boolean found;                  

                    found = false;
                    for(Int32 i = 0; i < args.Length; i++)
                    {
                        if(args[i] == "/skipversioncheck")
                        {
                            break;
                        }
                    }
                    if(found)
                    {
                        mainForm = new MainForm(true);
                        Application.Run(mainForm);
                    }
                    else
                    {
                        mainForm = new MainForm(false);
                        Application.Run(mainForm);
                    }
                }
                else
                {
                    mainForm = new MainForm(false);
                    Application.Run(mainForm);
                }
                try
                {
                    using(FileStream fs = new FileStream(SettingsFile, FileMode.Create, FileAccess.Write
                           , FileShare.None))
                    {
                        XmlSerializerSettings.Serialize(fs, Settings);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(WindowHandle, String.Format(MessageBoxTexts.FileCantBeWritten, SettingsFile, ex.Message)
                        , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                try
                {
                    ExceptionXml exceptionXml;

                    MessageBox.Show(WindowHandle, String.Format(MessageBoxTexts.CriticalError, ex.Message, ErrorFile)
                        , MessageBoxTexts.CriticalErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if(File.Exists(ErrorFile))
                    {
                        File.Delete(ErrorFile);
                    }
                    exceptionXml = new ExceptionXml(ex);
                    Serializer<ExceptionXml>.Serialize(ErrorFile, exceptionXml);
                }
                catch(Exception inEx)
                {
                    MessageBox.Show(WindowHandle, String.Format(MessageBoxTexts.FileCantBeWritten, ErrorFile, inEx.Message), MessageBoxTexts.ErrorHeader
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void CreateSettings()
        {
            if(Settings == null)
            {
                Settings = new Settings();
            }
            if(Settings.MainForm == null)
            {
                Settings.MainForm = new SizableForm();
            }
        }
    }
}