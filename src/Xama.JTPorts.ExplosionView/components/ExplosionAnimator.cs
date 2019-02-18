using Android.Animation;
using Android.Graphics;
using Android.Views;
using Android.Views.Animations;
using Java.Util;
using Xama.JTPorts.ExplosionView.utils;

namespace Xama.JTPorts.ExplosionView.components
{
    class ExplosionAnimator : ValueAnimator
    {
        internal static long DEFAULT_DURATION = 0x400;
        internal static AccelerateInterpolator DEFAULT_INTERPOLATOR = new AccelerateInterpolator(0.6f);
        internal static float END_VALUE = 1.4f;
        internal static float X = Utils.Dp2Px(5);
        internal static float Y = Utils.Dp2Px(20);
        internal static float V = Utils.Dp2Px(2);
        internal static float W = Utils.Dp2Px(1);
        private readonly Paint mPaint;
        private readonly Particle[] mParticles;
        private readonly Rect mBound;
        private readonly View mContainer;

        public ExplosionAnimator(View container, Bitmap bitmap, Rect bound)
        {
            mPaint = new Paint();
            mBound = new Rect(bound);
            int partLen = 15;
            mParticles = new Particle[partLen * partLen];
            Random random = new Random(System.DateTime.Today.TimeOfDay.Milliseconds);
            int w = bitmap.Width / (partLen + 2);
            int h = bitmap.Height / (partLen + 2);
            for (int i = 0; i < partLen; i++)
            {
                for (int j = 0; j < partLen; j++)
                {
                    mParticles[(i * partLen) + j] = GenerateParticle(bitmap.GetPixel((j + 1) * w, (i + 1) * h), random);
                }
            }
            mContainer = container;
            SetFloatValues(0f, END_VALUE);
            SetInterpolator(DEFAULT_INTERPOLATOR);
            SetDuration(DEFAULT_DURATION);
        }

        public Particle GenerateParticle(int color, Random random)
        {
            Particle particle = new Particle
            {
                color = color,
                radius = V
            };

            if (random.NextFloat() < 0.2f)
            {
                particle.baseRadius = V + ((X - V) * random.NextFloat());
            }
            else
            {
                particle.baseRadius = W + ((V - W) * random.NextFloat());
            }

            float nextFloat = random.NextFloat();
            particle.top = mBound.Height() * ((0.18f * random.NextFloat()) + 0.2f);
            particle.top = nextFloat < 0.2f ? particle.top : particle.top + ((particle.top * 0.2f) * random.NextFloat());
            particle.bottom = (mBound.Height() * (random.NextFloat() - 0.5f)) * 1.8f;
            float f = nextFloat < 0.2f ? particle.bottom : nextFloat < 0.8f ? particle.bottom * 0.6f : particle.bottom * 0.3f;
            particle.bottom = f;
            particle.mag = 4.0f * particle.top / particle.bottom;
            particle.neg = (-particle.mag) / particle.bottom;
            f = mBound.CenterX() + (Y * (random.NextFloat() - 0.5f));
            particle.baseCx = f;
            particle.cx = f;
            f = mBound.CenterY() + (Y * (random.NextFloat() - 0.5f));
            particle.baseCy = f;
            particle.cy = f;
            particle.life = END_VALUE / 10 * random.NextFloat();
            particle.overflow = 0.4f * random.NextFloat();
            particle.alpha = 1f;
            return particle;
        }

        public bool Draw(Canvas canvas)
        {
            if (!IsStarted)
            {
                return false;
            }
            foreach (Particle particle in mParticles)
            {
                particle.advance((float)AnimatedValue);
                if (particle.alpha > 0f)
                {
                    mPaint.Color = new Color(particle.color);
                    mPaint.Alpha = (int)(Color.GetAlphaComponent(particle.color) * particle.alpha);
                    canvas.DrawCircle(particle.cx, particle.cy, particle.radius, mPaint);
                }
            }
            mContainer.Invalidate();
            return true;
        }

        public override void Start()
        {
            base.Start();
            mContainer.Invalidate(mBound);
        }
    }
}