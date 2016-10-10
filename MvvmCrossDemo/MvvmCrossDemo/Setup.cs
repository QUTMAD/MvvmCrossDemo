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
using ZXing.Mobile;

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
            Mvx.LazyConstructAndRegisterSingleton<IMobileBarcodeScanner, MobileBarcodeScanner>();
            Mvx.LazyConstructAndRegisterSingleton<IToast, ToastService>();
            //uncomment the below if you only want to use local storage
            //Mvx.LazyConstructAndRegisterSingleton<ILocationsDatabase, LocationsDatabase>();
            base.InitializeFirstChance();
        }
    }
}
