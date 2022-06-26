
namespace WindowsMAUI.Common
{
    public static class WinUtils
    {
        public static void ResizeWindow(int width, int heigth)
        {
            IntPtr windowHandle = WinApi.GetActiveWindow();
            WinApi.RECT rect;
            WinApi.GetWindowRect(windowHandle, out rect);
            var ScreenX = WinApi.GetSystemMetrics(WinApi.SystemMetric.SM_CXSCREEN);
            var ScreenY = WinApi.GetSystemMetrics(WinApi.SystemMetric.SM_CYSCREEN);

            rect.right = rect.left + width;
            rect.bottom = rect.top + heigth;

            var x = ScreenX / 2 - width;
            var y = ScreenY / 2 - (rect.bottom - rect.top) / 2;

            var cx = rect.right - rect.left;
            var cy = rect.bottom - rect.top;

            WinApi.SetWindowPos(windowHandle, (int)WinApi.SpecialWindowHandles.HWND_TOP, x, y, cx, cy, (int)WinApi.SetWindowPosFlags.SWP_NOMOVE);
        }

        public static void CentreWindow()
        {
            IntPtr windowHandle = WinApi.GetActiveWindow();
            WinApi.RECT rect;
            WinApi.GetWindowRect(windowHandle, out rect);
            var ScreenX = WinApi.GetSystemMetrics(WinApi.SystemMetric.SM_CXSCREEN);
            var ScreenY = WinApi.GetSystemMetrics(WinApi.SystemMetric.SM_CYSCREEN);

            var x = (ScreenX / 2) - ((rect.right - rect.left) / 2);
            var y = (ScreenY / 2) - ((rect.bottom - rect.top) / 2);

            var cx = rect.right - rect.left;
            var cy = rect.bottom - rect.top;

            WinApi.MoveWindow(windowHandle, x, y, cx, cy, false);
        }

        public static void SetAlwaysOnTop()
        {
            IntPtr windowHandle = WinApi.GetActiveWindow();
            WinApi.SetWindowPos(windowHandle, (int)WinApi.SpecialWindowHandles.HWND_TOPMOST, 0, 0, 0, 0, (int)WinApi.SetWindowPosFlags.SWP_NOMOVE | (int)WinApi.SetWindowPosFlags.SWP_NOSIZE);
        }

        public static WinApi.RECT GetWindowsRect()
        {
            WinApi.RECT rect;
            WinApi.GetWindowRect(WinApi.GetActiveWindow(), out rect);

            return rect;
        }

        public static void SetWindowsLocation(int x, int y)
        {
            IntPtr windowHandle = WinApi.GetActiveWindow();
            WinApi.RECT rect;
            WinApi.GetWindowRect(windowHandle, out rect);
            var ScreenX = WinApi.GetSystemMetrics(WinApi.SystemMetric.SM_CXSCREEN);
            var ScreenY = WinApi.GetSystemMetrics(WinApi.SystemMetric.SM_CYSCREEN);

            var cx = rect.right - rect.left;
            var cy = rect.bottom - rect.top;

            WinApi.MoveWindow(windowHandle, x, y, cx, cy, false);
        }
    }
}
