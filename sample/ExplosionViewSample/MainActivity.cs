using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Xama.JTPorts.ExplosionView;

namespace ExplosionViewSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ImageView ivFB;
        private ImageView ivReddit;
        private ImageView ivTwitter;
        private ImageView ivInsta;
        private ImageView ivSnap;
        private ImageView ivLinkedIn;

        private RelativeLayout mainView;
        private LinearLayout centerView;
        private ExplosionView explosionView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            mainView = FindViewById<RelativeLayout>(Resource.Id.cvLayout);
            centerView = FindViewById<LinearLayout>(Resource.Id.llMainView);

            ivFB = FindViewById<ImageView>(Resource.Id.ivfacebook);
            ivReddit = FindViewById<ImageView>(Resource.Id.ivreddit);
            ivTwitter = FindViewById<ImageView>(Resource.Id.ivtwitter);
            ivInsta = FindViewById<ImageView>(Resource.Id.ivinstagram);
            ivSnap = FindViewById<ImageView>(Resource.Id.ivsnapchat);
            ivLinkedIn = FindViewById<ImageView>(Resource.Id.ivlinkedin);
            
            explosionView =  new ExplosionView(this);

            ivFB.Click += (s,e) => {
                explosionView.Explode(ivFB);
            };
            ivReddit.Click += (s, e) => {
                explosionView.Explode(ivReddit);
            };
            ivTwitter.Click += (s, e) => {
                explosionView.Explode(ivTwitter);
            };
            ivInsta.Click += (s, e) => {
                explosionView.Explode(ivInsta);
            };
            ivSnap.Click += (s, e) => {
                explosionView.Explode(ivSnap);
            };
            ivLinkedIn.Click += (s, e) => {
                explosionView.Explode(ivLinkedIn);
            };
            
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
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
	}
}

