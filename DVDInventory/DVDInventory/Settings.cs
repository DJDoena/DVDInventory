using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.DVDInventory
{
    [Serializable()]
    public class Settings
    {
        public SizableForm MainForm;

        public String CurrentVersion;
    }

    [Serializable()]
    public class BaseForm
    {
        public Int32 Top = 50;

        public Int32 Left = 50;
    }

    [Serializable()]
    public class SizableForm : BaseForm
    {
        public Int32 Height = 500;

        public Int32 Width = 900;

        public FormWindowState WindowState = FormWindowState.Normal;

        public Rectangle RestoreBounds;
    }
}