using System.Linq;
using System.Windows;
using System.Windows.Forms;
using GloomyMon.Helpers;

namespace GloomyMon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var screenCount = Screen.AllScreens.Count(s => !s.Primary);

            if (screenCount < 0) Current.Shutdown();

            if (screenCount > 0)
                GetMonitors();
        }

        private static void GetMonitors()
        {
            var count = -1;
            var screens = Screen.AllScreens;

            foreach (var screen in screens.Where(s => !s.Primary))
            {
                count++;

                var screenDimensions = ScreenInformation.GetDimensions(screen.WorkingArea);

                var window = new MainWindow
                {
                    Name = "screen_" + count,
                    Title = "screen_" + count,
                    Width = screenDimensions.Width,
                    Height = screenDimensions.Height,
                    Top = screenDimensions.Top,
                    Left = screenDimensions.Left
                };

                window.Show();
            }
        }

        
    }
}
