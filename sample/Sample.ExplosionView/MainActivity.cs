using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Xama.JTPorts.ExplosionView;

namespace Sample.ExplosionView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            var button1 = FindViewById<ImageView>(Resource.Id.ivtwitter);
            var button2 = FindViewById<ImageView>(Resource.Id.ivfacebook);
            var button3 = FindViewById<ImageView>(Resource.Id.ivinstagram);
            var button4 = FindViewById<ImageView>(Resource.Id.ivlinkedin);
            var button5 = FindViewById<ImageView>(Resource.Id.ivreddit);
            var button6 = FindViewById<ImageView>(Resource.Id.ivsnapchat);

            // This creates the explosion view used to display the particals at the root of the content display.
            // This is expecting an activity ideally, so this would be a little different if used inside of a fragment, so bear that in mind.
            Xama.JTPorts.ExplosionView.ExplosionView explosionField = new Xama.JTPorts.ExplosionView.ExplosionView(this);

            // Could be hooked up to an on click event of your control if you wish.
            button1.Click += (s, e) =>
            {
                explosionField.Explode(button1);
            };
            button2.Click += (s, e) =>
            {
                explosionField.Explode(button2);
            };
            button3.Click += (s, e) =>
            {
                explosionField.Explode(button3);
            };
            button4.Click += (s, e) =>
            {
                explosionField.Explode(button4);
            };
            button5.Click += (s, e) =>
            {
                explosionField.Explode(button5);
            };
            button6.Click += (s, e) =>
            {
                explosionField.Explode(button6);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

