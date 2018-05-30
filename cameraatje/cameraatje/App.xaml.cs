using Prism;
using Prism.Ioc;
using cameraatje.ViewModels;
using cameraatje.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using cameraatje.Contracts;
using cameraatje.Data;
using cameraatje.Repositories;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace cameraatje
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.RegisterForNavigation<OverviewToddler>();
            containerRegistry.RegisterForNavigation<OverviewCorner>();
            containerRegistry.RegisterForNavigation<OverviewPicture>();
            containerRegistry.RegisterForNavigation<ChecklistToddler>();
            containerRegistry.RegisterForNavigation<Choice>();
            containerRegistry.RegisterForNavigation<OverviewPersonalToddler>();
            containerRegistry.RegisterInstance<IDbContext>(new CameraatjeDbContext("Data Source=sashavdv.database.windows.net;Initial Catalog=cameraatje;Persist Security Info=True;User ID=sashavdv;Password=Heyhey123123"));
            containerRegistry.Register<IRepository, CameraatjeRepository>();
        }
    }
}
