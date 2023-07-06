using MauiLib1.Contracts;

namespace MauiLib1
{
    // All the code in this file is included in all platforms.
    public class Class1 : IClass
    {
        public string GetService()
        {
            var implementation = GenerateServiceThing();
            return implementation.ServiceName;
        }

        internal IServiceThing GenerateServiceThing()
        {
#if ANDROID
            return new MauiLib1.Platforms.Android.PlatformClass1();
#elif IOS
            return new MauiLib1.Platforms.iOS.PlatformClass1();
#elif WINDOWS
            return new MauiLib1.Platforms.Windows.PlatformClass1();
#endif
            throw new NotImplementedException("there is no thing to return!");
        }
    }
}