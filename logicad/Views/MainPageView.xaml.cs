using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace logicad.Views
{
    /// <summary>
    /// Interaction logic for MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Page
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        #region NoNeedForMVVM
        Point scrollMousePoint = new Point();
        double hOff = 1;
        double vOff = 1;

        private void CanvasMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            scrollMousePoint = e.GetPosition(null);
            hOff = scrollViewer.HorizontalOffset;
            vOff = scrollViewer.VerticalOffset;
            canvas.CaptureMouse();
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (canvas.IsMouseCaptured)
            {
                scrollViewer.ScrollToHorizontalOffset(hOff + (scrollMousePoint.X - e.GetPosition(null).X));
                scrollViewer.ScrollToVerticalOffset(vOff + (scrollMousePoint.Y - e.GetPosition(null).Y));
            }

            Point p = Mouse.GetPosition(canvas);
            MousePosTB.Text = $"{(int)p.X}:{(int)p.Y}";
        }

        private void CanvasMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (canvas.IsMouseCaptured)
            {
                canvas.ReleaseMouseCapture();
            }
        }
        #endregion
    }
}
