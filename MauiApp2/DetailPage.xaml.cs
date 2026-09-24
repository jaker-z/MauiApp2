namespace MauiApp2;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel dvm)
	{
		InitializeComponent();
		BindingContext = dvm;
	}
}