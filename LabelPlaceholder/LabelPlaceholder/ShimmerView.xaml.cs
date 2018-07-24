using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabelPlaceholder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShimmerView : ContentView
	{
		public ShimmerView ()
		{
			InitializeComponent ();
            animate();
        }

        public static readonly BindableProperty WidthShimmerProperty =
            BindableProperty.Create(nameof(WidthShimmer), typeof(int), typeof(ShimmerView), 200);

        public int WidthShimmer
        {
            get => (int)GetValue(WidthShimmerProperty);
            set => SetValue(WidthShimmerProperty, value);
        }

        public static readonly BindableProperty HeightShimmerProperty =
           BindableProperty.Create(nameof(HeightShimmer), typeof(int), typeof(ShimmerView), 30);

        public int HeightShimmer
        {
            get => (int)GetValue(HeightShimmerProperty);
            set => SetValue(HeightShimmerProperty, value);
        }

        private void animate()
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                while (true)
                {
                    TranslateBox.IsVisible = false;

                    await TranslateBox.TranslateTo(-30, 0, 1);

                    TranslateBox.IsVisible = true;

                    await TranslateBox.TranslateTo((WidthShimmer - 75), 0, 400);

                    TranslateBox.IsVisible = false;

                    await TranslateBox.TranslateTo(-30, 0, 1);

                    await Task.Delay(800);

                    TranslateBox.IsVisible = true;

                }
            });

        }
    }
}