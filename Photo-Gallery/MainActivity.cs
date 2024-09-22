using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Photo_Gallery
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button Gallery, Grid;
        EditText Amount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();
            AddClicks();
        }

        void AddClicks()
        {
            Gallery.Click += Gallery_Click;
            Grid.Click += Grid_Click;
        }

        private void Grid_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Grid));
            intent.PutExtra("amount", Amount.Text);
            StartActivity(intent);
        }

        private void Gallery_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Gallery));
            intent.PutExtra("amount", Amount.Text);
            StartActivity(intent);
        }

        void Init()
        {
            Gallery = FindViewById<Button>(Resource.Id.galleryBtn);
            Grid = FindViewById<Button>(Resource.Id.gridBtn);
            Amount = FindViewById<EditText>(Resource.Id.cardAmount);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
