namespace YandexClipboardTranslator.Impl
{
    using System.Drawing;
    using System.Windows.Forms;

    public class TrayService : ITrayService
    {
        public void Show(string title, string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            var notifyIcon = new NotifyIcon
            {
                Icon = new Icon(SystemIcons.Application, 40, 40),
                Visible = true,
                BalloonTipText = message,
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipTitle = title
            };

            notifyIcon.ShowBalloonTip(500);
        }
    }
}