namespace sampletitle;

public partial class SampleTitleWindow : Window
{
	public SampleTitleWindow()
	{
		InitializeComponent();
		
	}

	int count = 0;
    private void Button_Clicked(object sender, EventArgs e)
    {
		count++;
		CustomButton.Text = "Clicked " + count;
    }
}