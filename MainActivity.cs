using Android.Graphics;
using System.Text;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Initialize();
        }

        private void Initialize()
        {
            var asm = typeof(MainActivity).Assembly;
            var customAttrs = asm.GetCustomAttributes(false);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Babel Tag:");
            foreach (var attr in customAttrs) {
                var fullName = attr.ToString();
                if (fullName!.StartsWith("Babel"))
                    sb.AppendLine(fullName);
            }

            sb.AppendLine("Types:");
            foreach (var type in asm.GetTypes())
            {
                sb.AppendLine(type.FullName);
            }
            
            var tv = FindViewById<TextView>(Resource.Id.TextView);
            tv?.SetText(sb.ToString(), TextView.BufferType.Normal);
            tv?.SetTypeface(tv?.Typeface, TypefaceStyle.Bold);
        }
    }
}