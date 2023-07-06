using Microsoft.Maui.Controls.Internals;

namespace TestMopups;

public partial class MyPopupPage
{
    public MyPopupPage()
	{
        BackgroundColor = Color.FromArgb("#80000000");

        var vm = new MyPopupPageViewModel();
        vm.VisibilityChanged += VmOnVisibilityChanged;
        BindingContext = vm;

		InitializeComponent();
	}

    private void VmOnVisibilityChanged(object sender, EventArgs e)
    {
        InvalidateMeasureNonVirtual(InvalidationTrigger.SizeRequestChanged);
    }
}