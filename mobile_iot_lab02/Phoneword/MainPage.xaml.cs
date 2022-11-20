namespace Phoneword;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private string _translatedNumber;

    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        _translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(_translatedNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + _translatedNumber;

        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";   
        }
    }


    async void OnCall(object sender, System.EventArgs e)
    {
        if (await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call " + _translatedNumber + "?",
                "Yes",
                "No"))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(_translatedNumber);
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch(Exception)
            {
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }
            
        }
    }
}