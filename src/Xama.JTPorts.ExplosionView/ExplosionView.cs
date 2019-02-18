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
        private int[] mExpandInset = new int[2];

        public ExplosionView(Context context) : base(context)
        {
            init();
        }

        public ExplosionView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            init();
        }

        public ExplosionView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            init();
        }

        private void init()
        {
            Arrays.Fill(mExpandInset, Utils.dp2Px(32));
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            foreach (ExplosionAnimator explosion in mExplosions)
            {
                explosion.draw(canvas);
            }
        }

        public void expandExplosionBound(int dx, int dy)
        {
            mExpandInset[0] = dx;
            mExpandInset[1] = dy;
        }

        public void explode(Bitmap bitmap, Rect bound, long startDelay, long duration)
        {
            ExplosionAnimator explosion = new ExplosionAnimator(this, bitmap, bound);
            explosion.Update += (s, e) =>
            {
                mExplosions.Remove(e.Animation);
            };

            explosion.StartDelay = startDelay;
            explosion.SetDuration(duration);
            mExplosions.Add(explosion);
            explosion.Start();
        }

        public void explode(View view)
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
            explode(Utils.createBitmapFromView(view), r, startDelay, ExplosionAnimator.DEFAULT_DURATION);
        }

        public void clear()
        {
            mExplosions.Clear();
            Invalidate();
        }

        public static ExplosionView attach2Window(Activity activity)
        {
            ViewGroup rootView = (ViewGroup)activity.FindViewById(Window.IdAndroidContent);
            ExplosionView explosionField = new ExplosionView(activity);
            rootView.AddView(explosionField, new ViewGroup.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            return explosionField;
        }
    }
}
