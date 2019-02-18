using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;

namespace Xama.JTPorts.ExplosionView.utils
{
    class Utils
    {
        private static readonly float DENSITY = Resources.System.DisplayMetrics.Density;
        private static readonly Canvas sCanvas = new Canvas();

        public static int Dp2Px(int dp)
        {
            return Java.Lang.Math.Round(dp * DENSITY);
        }

        private static object _locker = new object();

        public static Bitmap CreateBitmapFromView(View view)
        {
            if (view is ImageView)
            {
                Drawable drawable = ((ImageView)view).Drawable;
                if (drawable != null && drawable is BitmapDrawable)
                {
                    return ((BitmapDrawable)drawable).Bitmap;
                }
            }
            view.ClearFocus();
            Bitmap bitmap = CreateBitmapSafely(view.Width, view.Height, Bitmap.Config.Argb8888, 1);
            if (bitmap != null)
            {
                lock (_locker)
                {
                    Canvas canvas = sCanvas;
                    canvas.SetBitmap(bitmap);
                    view.Draw(canvas);
                    canvas.SetBitmap(null);
                }
            }
            return bitmap;
        }

        public static Bitmap CreateBitmapSafely(int width, int height, Bitmap.Config config, int retryCount)
        {
            try
            {
                return Bitmap.CreateBitmap(width, height, config);
            }
            catch (OutOfMemoryError e)
            {
                e.PrintStackTrace();
                if (retryCount > 0)
                {
                    GC.Collect();
                    return CreateBitmapSafely(width, height, config, retryCount - 1);
                }
                return null;
            }
        }
    }
}