using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace DataGridStyle.Views
{
    /// <summary>
    /// TestView.xaml 的交互逻辑
    /// </summary>
    public partial class TestView : Window
    {
        private bool IsMaximize = false;
        public TestView()
        {
            InitializeComponent();
         
        }

        
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 600;
                    this.Height = 1000;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }
        internal class MouseCapture
        {
            public Double VerticalOffset { get; set; }
            public Double HorticalOffset { get; set; }
            public Point Point { get; set; }
        }
        static Dictionary<object, MouseCapture> _captures = new Dictionary<object, MouseCapture>();
        private void ScrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;

            _captures[sender] = new MouseCapture
            {
                VerticalOffset = target.VerticalOffset,
                HorticalOffset = target.HorizontalOffset,
                Point = e.GetPosition(target),
            };
        }

        private void ScrollViewer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;
            target.ReleaseMouseCapture();
        }

        private void ScrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!_captures.ContainsKey(sender)) return;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                _captures.Remove(sender);
                return;
            }
            var target = sender as ScrollViewer;
            if (target == null) return;
            var capture = _captures[sender];
            var point = e.GetPosition(target);
            var dy = point.Y - capture.Point.Y;
            var dx = point.X - capture.Point.X;
            if (Math.Abs(dy) > 5)
            {
                target.CaptureMouse();
            }
            if (Math.Abs(dx) > 5)
            {
                target.CaptureMouse();
            }
            target.ScrollToVerticalOffset(capture.VerticalOffset - dy);
            target.ScrollToHorizontalOffset(0);
        

        }

        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            var target = sender as ScrollViewer;
            if (target == null) return;
        
            target.PreviewMouseLeftButtonDown += ScrollViewer_PreviewMouseLeftButtonDown; ;
            target.PreviewMouseMove += ScrollViewer_PreviewMouseMove; ;
            target.PreviewMouseLeftButtonUp += ScrollViewer_PreviewMouseLeftButtonUp; ;
        }
    }
}
