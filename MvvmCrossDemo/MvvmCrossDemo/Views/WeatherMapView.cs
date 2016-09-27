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
using MvvmCross.Droid.Views;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MvvmCrossDemo.Core.ViewModels;
using MvvmCrossDemo.Core.Models;

namespace MvvmCrossDemo.Droid.Views
{
    [Activity(Label = "WeatherMapView")]
    public class WeatherMapView : MvxActivity, IOnMapReadyCallback
    {
        private delegate IOnMapReadyCallback OnMapReadyCallback();
        private GoogleMap map;
        WeatherMapViewModel vm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WeatherMap);
            vm = ViewModel as WeatherMapViewModel;
            var mapFragment = FragmentManager.FindFragmentById(Resource.Id.weathermap) as MapFragment;
            mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            vm.OnMapSetup(MoveToLocation, AddWeatherPin);
            map = googleMap;
            map.MyLocationEnabled = true;
            map.MyLocationChange += Map_MyLocationChange;
            map.MapLongClick += Map_MapClick;
        }

        private void Map_MapClick(object sender, GoogleMap.MapLongClickEventArgs e)
        {
            vm.MapTapped(new GeoLocation(e.Point.Latitude, e.Point.Longitude));
        }

        private void Map_MyLocationChange(object sender, GoogleMap.MyLocationChangeEventArgs e)
        {
            map.MyLocationChange -= Map_MyLocationChange;
            var location = new GeoLocation(e.Location.Latitude, e.Location.Longitude, e.Location.Altitude);
            MoveToLocation(location);
            vm.OnMyLocationChanged(location);
        }

        private void MoveToLocation(GeoLocation geoLocation, float zoom = 18)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(geoLocation.Latitude, geoLocation.Longitude));
            builder.Zoom(zoom);
            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);
        }
        private void AddWeatherPin(GeoLocation location, Forecast forecast)
        {
            var markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(location.Latitude, location.Longitude));
            var min = forecast.DailyForecasts.FirstOrDefault().Temperature.Minimum;
            var max = forecast.DailyForecasts.FirstOrDefault().Temperature.Maximum;
            markerOptions.SetSnippet(string.Format("Min {0}{1}, Max {2}{3}", min.Value, min.Unit, max.Value, max.Unit));
            markerOptions.SetTitle(location.Locality);
            map.AddMarker(markerOptions);
        }
    }
}