using Java.Lang;

namespace Xama.JTPorts.ExplosionView.components
{
    internal class Particle
    {
        public float alpha;
        public int color;
        public float cx;
        public float cy;
        public float radius;
        public float baseCx;
        public float baseCy;
        public float baseRadius;
        public float top;
        public float bottom;
        public float mag;
        public float neg;
        public float life;
        public float overflow;

        public void advance(float factor)
        {
            float f = 0f;
            float normalization = factor / ExplosionAnimator.END_VALUE;
            if (normalization < life || normalization > 1f - overflow)
            {
                alpha = 0f;
                return;
            }
            normalization = (normalization - life) / (1f - life - overflow);
            float f2 = normalization * ExplosionAnimator.END_VALUE;
            if (normalization >= 0.7f)
            {
                f = (normalization - 0.7f) / 0.3f;
            }
            alpha = 1f - f;
            f = bottom * f2;
            cx = baseCx + f;
            cy = (float)(baseCy - this.neg * Math.Pow(f, 2.0)) - f * mag;
            radius = ExplosionAnimator.V + (baseRadius - ExplosionAnimator.V) * f2;
        }
    }
}