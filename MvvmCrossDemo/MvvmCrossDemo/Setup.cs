using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCrossDemo.Core.Interfaces;
using MvvmCrossDemo.Droid.Database;
using MvvmCrossDemo.Droid.Services;
using MvvmCrossDemo.Core.Database;
using MvvmCrossDemo.Droid.Maps;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Shared.Presenter;
using Android.App;

namespace MvvmCrossDemo.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();

            Mvx.LazyConstructAndRegisterSingleton<ILocationsDatabase, LocationDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IGeoCoder, GeoCoder>();
            //uncomment the below if you only want to use local storage
            //Mvx.LazyConstructAndRegisterSingleton<ILocationsDatabase, LocationsDatabase>();
            base.InitializeFirstChance();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }
    }
}
