namespace Phoneword;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private string translatedNumber;

    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(translatedNumber))
        {
            // TODO
        }
        else
        {
            // TODO   
        }
    }
}