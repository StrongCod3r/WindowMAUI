namespace WindowsMAUI.Common
{
    public enum PropNames
    {
        PosX, PosY, Width, Height
    }

    public static class GlobalConfig
    {
        private static string pathFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        private static string fileConfig = "config.ini";
        private static Properties config;
        private static readonly object lockObj = new object();

        public static void Init()
        {
            config = new Properties(pathFolder, fileConfig);

            LoadProperties();
        }

        public static void LoadProperties()
        {
            WinUtils.SetAlwaysOnTop();

            // Load config
            int posX = Convert.ToInt32(config.get(PropNames.PosX.ToString(), "-1"));
            int posY = Convert.ToInt32(config.get(PropNames.PosY.ToString(), "-1"));
            int width = Convert.ToInt32(config.get(PropNames.Width.ToString(), "-1"));
            int height = Convert.ToInt32(config.get(PropNames.Height.ToString(), "-1"));

            if (width != -1 && height != -1)
            {
                WinUtils.ResizeWindow(width, height);
            }

            if (posX == -1 || posY == -1)
            {
                WinUtils.CentreWindow();
            }
            else
            {
                WinUtils.SetWindowsLocation(posX, posY);
            } 
        }

        public static void SaveWindowLocation()
        {
            var rect = WinUtils.GetWindowsRect();

            Properties config = new Properties(pathFolder, fileConfig);

            // Save config
            config.set(PropNames.PosX.ToString(), rect.left.ToString());
            config.set(PropNames.PosY.ToString(), rect.top.ToString());
            config.Save();
        }

        public static void SaveWindowSize()
        {
            var rect = WinUtils.GetWindowsRect();

            Properties config = new Properties(pathFolder, fileConfig);

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            // Save config
            config.set(PropNames.Width.ToString(), width.ToString());
            config.set(PropNames.Height.ToString(), height.ToString());
            config.Save();
        }
    }
}
