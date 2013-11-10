using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace TheDelegate.TheButler.Win
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (var application = new ButlerWinApplication
            {
                ConnectionString = connectionString,
                ApplicationName = "TheButler",
            })
            {
                application.CreateCustomObjectSpaceProvider += (s, e) =>
                {
                    e.ObjectSpaceProvider = new XPObjectSpaceProvider(new ConnectionStringDataStoreProvider(e.ConnectionString));
                };

                application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateOldDatabase;
                application.DatabaseVersionMismatch += (s, e) =>
                {
                    if (Debugger.IsAttached)
                    {
                        e.Updater.Update();
                        e.Handled = true;
                    }
                };


                application.Setup();
                application.Start();
            }
        }
    }
}
