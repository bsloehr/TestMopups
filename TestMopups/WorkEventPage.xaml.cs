using Microsoft.Maui.Controls.Internals;

namespace TestMopups;

public partial class WorkEventPage
{
	public WorkEventPage()
	{
        BackgroundColor = Color.FromArgb("#80000000");

        var vm = new WorkEventPageViewModel();
        vm.VisibilityChanged += VmOnVisibilityChanged;
        BindingContext = vm;

		InitializeComponent();
	}

    private void VmOnVisibilityChanged(object sender, EventArgs e)
    {
        InvalidateMeasureNonVirtual(InvalidationTrigger.SizeRequestChanged);
    }
}