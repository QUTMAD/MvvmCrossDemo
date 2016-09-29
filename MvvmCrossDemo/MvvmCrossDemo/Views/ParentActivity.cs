using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCrossDemo.Core.ViewModels;
using Android.Support.V4.Widget;
using MvvmCross.Droid.FullFragging.Fragments;

namespace MvvmCrossDemo.Droid.Views
{
    [Activity(Label = "ParentActivity")]
    public class ParentActivity : MvxCachingFragmentCompatActivity<ParentViewModel>
    {
        MvxFragment[] fragments = { new ForecastView(), new WeatherMapView() };
        string[] titles = { "Forecast", "Weather Map" };
        ActionBarDrawerToggle drawerToggle;

        ListView drawerListView;

        DrawerLayout drawerLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ParentLayout);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);
            drawerListView.ItemClick += (s, e) => ShowFragmentAt(e.Position);
            drawerListView.Adapter = new ArrayAdapter<string>(
                this,
                Android.Resource.Layout.SimpleListItem1,
                titles);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            drawerToggle = new ActionBarDrawerToggle(
                this,
                drawerLayout,
                Resource.String.OpenDrawerString,
                Resource.String.CloseDrawerString);

            drawerLayout.AddDrawerListener(drawerToggle);
            var tm = FragmentManager.BeginTransaction();
            foreach (var item in fragments)
            {
                tm.Add(item, item.ToString());
            }
            ShowFragmentAt(0);
            // Create your application here
        }

        void ShowFragmentAt (int position)
        {
            FragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.frameLayout, fragments[position])
                .Commit();

            Title = titles[position];
            drawerLayout.CloseDrawer(drawerListView);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (drawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}