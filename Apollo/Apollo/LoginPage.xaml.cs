namespace Apollo;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        
        if (username == "user" && password == "admin")
        {
           
            Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            DisplayAlert("Login Failed", "Invalid username or password", "OK");
        }
    }

}