namespace sampletitle
{
    public partial class App : Application
    {
        public SampleTitleWindow OurWindow { get; }
        public App(SampleTitleWindow ourWindow)
        {
            InitializeComponent();
            OurWindow = ourWindow;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            OurWindow.Page = new AppShell();
            
            return OurWindow;
        }
    }
}