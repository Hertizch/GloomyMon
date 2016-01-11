using System.Drawing;
using System.Windows;

namespace GloomyMon.Helpers
{
    public class ScreenInformation
    {
        public static Rect GetDimensions(Rectangle value)
        {
            return new Rect
            {
                X = value.X,
                Y = value.Y,
                Width = value.Width,
                Height = value.Height
            };
        }
    }
}
