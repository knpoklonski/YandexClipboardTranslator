namespace YandexClipboardTranslator.Impl
{
    using System.Drawing;
    using System.Windows.Forms;

    public class TrayService : ITrayService
    {
        public void Show(string title, string message)
        {
            //this.WindowState = FormWindowState.Minimized;
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