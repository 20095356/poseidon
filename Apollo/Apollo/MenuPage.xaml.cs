namespace Apollo;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}
    private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
    {
        // Toggle between Light and Dark themes based on the switch state
        var appTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
        Application.Current.UserAppTheme = appTheme;
    }
    private void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        // Navigate back to the login page on logout
        Shell.Current.GoToAsync("//LoginPage");
    }
}
