using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.VisualTree;

namespace Semi.Avalonia.Demo
{
    public partial class MainWindow : Window
    {
        private readonly WindowNotificationManager _manager;
        public MainWindow()
        {
            InitializeComponent();
            _manager = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.TopLeft,
                MaxItems = 3
            };
        }

        internal void Notify(NotificationType t)
        {
            _manager.Show(new Notification(t.ToString(), "This is a notification message", t));
        }
    }
}