using MauiLib1.Contracts;

namespace MauiLib1.Platforms.Windows
{
    // All the code in this file is only included on Windows.
    public class PlatformClass1 : IServiceThing
    {
        public string ServiceName => "Windows Service Thing";
    }
}