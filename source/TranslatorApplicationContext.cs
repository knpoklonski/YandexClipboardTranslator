namespace YandexClipboardTranslator
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Impl;

    public class TranslatorApplicationContext : ApplicationContext
    {
        private static readonly IYandexApiTranslator Translator = new YandexApiTranslator();
        private static readonly ITrayService TrayService = new TrayService();
        public TranslatorApplicationContext()
        {
            HotKeyManager.RegisterHotKey(Keys.T, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += HotKeyPressedHandle;
           
            while (true)
            {
            }
        }

        static void HotKeyPressedHandle(object sender, HotKeyEventArgs e)
        {
            string idat = null;
            Exception threadEx = null;
            var staThread = new Thread(
                () =>
                {
                    try
                    {
                        idat = Clipboard.GetText(TextDataFormat.Text);
                    }

                    catch (Exception ex)
                    {
                        threadEx = ex;
                    }
                });

            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();

            TrayService.Show("Перевод", Translator.Translate(idat));
        }
    }
}