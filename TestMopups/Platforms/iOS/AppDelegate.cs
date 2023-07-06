using Foundation;
using TestMopups.Services;

namespace TestMopups;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    private static readonly ExternalStoragePath ExternalStoragePath = new();
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public AppDelegate()
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledException;

        // For iOS and Mac Catalyst
        // Exceptions will flow through AppDomain.CurrentDomain.UnhandledException,
        // but we need to set UnwindNativeCode to get it to work correctly. 
        // 
        // See: https://github.com/xamarin/xamarin-macios/issues/15252

        ObjCRuntime.Runtime.MarshalManagedException += (_, args) =>
        {
            args.ExceptionMode = ObjCRuntime.MarshalManagedExceptionMode.UnwindNativeCode;
        };
    }

    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        try
        {
            var newExc = new Exception("Current_UnhandledException", e.ExceptionObject as Exception);
            LogUnhandledException(newExc);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    internal static void LogUnhandledException(Exception exception)
    {
        try
        {
            const string errorFileName = "Unhandled.log";

            var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //ExternalStoragePath.ApplicationData;
            var errorFilePath = Path.Combine(libraryPath, errorFileName);
            var errorMessage = $"Time: {DateTime.Now}\r\nError: Unhandled Exception\r\n{exception}";
            File.WriteAllText(errorFilePath, errorMessage);
        }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
        catch
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
        {
            // just suppress any error logging exceptions
        }
    }
}
