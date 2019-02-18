using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Util;
using Xama.JTPorts.ExplosionView.components;
using Xama.JTPorts.ExplosionView.utils;

namespace Xama.JTPorts.ExplosionView
{
    public class ExplosionView : View
    {
        private JavaList<ExplosionAnimator> mExplosions = new JavaList<ExplosionAnimator>();
        private readonly int[] mExpandInset = new int[2];

        public ExplosionView(Context context, ViewGroup customExplosionBounds) : base(context)
        {
            Arrays.Fill(mExpandInset, Utils.Dp2Px(32));
            customExplosionBounds.AddView(this, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
        }

        public ExplosionView(Context context) : base(context)
        {
            Init(context);
        }

        public ExplosionView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public ExplosionView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        private void Init(Context activity)
        {
            Arrays.Fill(mExpandInset, Utils.Dp2Px(32));
            InternalAddToWindow((Activity)activity);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            foreach (ExplosionAnimator explosion in mExplosions)
            {
                explosion.Draw(canvas);
            }
        }

        public void ExpandExplosionBound(int dx, int dy)
        {
            mExpandInset[0] = dx;
            mExpandInset[1] = dy;
        }

        public void Explode(Bitmap bitmap, Rect bound, long startDelay, long duration)
        {
            ExplosionAnimator explosion = new ExplosionAnimator(this, bitmap, bound);

            explosion.AnimationEnd += (s,e) =>
            {
                if (mExplosions.Count != 0)
                {
                    mExplosions.Remove(s);
                }
            };

            explosion.StartDelay = startDelay;
            explosion.SetDuration(duration);
            mExplosions.Add(explosion);
            explosion.Start();
        }

        public void Explode(View view)
        {
            Rect r = new Rect();
            view.GetGlobalVisibleRect(r);
            int[] location = new int[2];
            GetLocationOnScreen(location);
            r.Offset(-location[0], -location[1]);
            r.Inset(-mExpandInset[0], -mExpandInset[1]);
            int startDelay = 100;
            ValueAnimator animator = ValueAnimator.OfFloat(0f, 1f);
            animator.SetDuration(150);
            animator.Update += (s, e) =>
            {
                Random random = new Random();
                view.TranslationX = (random.NextFloat() - 0.5f) * view.Width * 0.05f;
                view.TranslationY = (random.NextFloat() - 0.5f) * view.Height * 0.05f;
            };

            animator.Start();
            view.Animate().SetDuration(150).SetStartDelay(startDelay).ScaleX(0f).ScaleY(0f).Alpha(0f).Start();
            Explode(Utils.CreateBitmapFromView(view), r, startDelay, ExplosionAnimator.DEFAULT_DURATION);
        }

        public void Clear()
        {
            mExplosions.Clear();
            Invalidate();
        }

        /// <summary>
        /// Static builder
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static ExplosionView AttachToWindow(Activity activity)
        {
            var rootView = (ViewGroup)activity.FindViewById(Window.IdAndroidContent);
            var explosionField = new ExplosionView(activity);
            rootView.AddView(explosionField, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            return explosionField;
        }

        /// <summary>
        /// used to add the explosion view to the primary window
        /// </summary>
        /// <param name="activity"></param>
        private void InternalAddToWindow(Activity activity)
        {
            var rootView = (ViewGroup)activity.FindViewById(Window.IdAndroidContent);
            rootView.AddView(this, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
        }
    }
}
