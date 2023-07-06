using MauiLib1;
using Mopups.Services;

namespace TestMopups;

public partial class MainPage : ContentPage
{
    //private readonly IPopupNavigation _popupNavigation = MopupService.Instance;

    public MainPage()
	{
		InitializeComponent();



#if ANDROID
		var platform = "Android";
#elif IOS
		var platform = "iOS";
#elif WINDOWS
		var platform = "Windows";
#else
        var platform = "No Platform???";
#endif

#if DEBUG
       var configuration = "Debug"; 
#elif RELEASE
        var configuration = "Release";
#else
		var configuration = "No Configuration??";
#endif

        MauiLabel.Text = $"Welcome to .NET Multi-platform App UI on {platform} {configuration}";
    }

	private async void OnPickList(object sender, EventArgs e)
	{
        try
        {
            await MopupService.Instance.PushAsync(new MyPopupPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
	}

	private async void OnWorkEvents(object sender, EventArgs e)
	{
        try
        {
            await MopupService.Instance.PushAsync(new WorkEventPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
	}

	private async void OnGetThing(object sender, EventArgs e)
	{
        try
        {
            var svcClass = ThingService.Instance;
            await DisplayAlert("What Kind of Thing?", svcClass.GetService(), "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
	}
}

