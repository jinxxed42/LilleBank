namespace LilleBank
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("da-DK");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            ApplicationConfiguration.Initialize();
            Application.Run(new BankForm());
        }
    }
}