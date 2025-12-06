using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSEDataReader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(My_ErrorHandler);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs args)
        {
            Exception e = (Exception)args.Exception;
            MessageBox.Show("Error Message : " + e.Message
                + (e.StackTrace != null ? Environment.NewLine + "Stack Trace" + e.StackTrace : "")
                + (e.InnerException != null ? Environment.NewLine + "Inner Exception" + e.InnerException.Message : "")
                , "Error Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void My_ErrorHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show("Error Message : " + e.Message
                + (e.StackTrace != null? Environment.NewLine + "Stack Trace" + e.StackTrace: "")
                + (e.InnerException != null ? Environment.NewLine + "Inner Exception" + e.InnerException.Message : "")
                , "Error Occur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
