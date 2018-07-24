using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabelPlaceholder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShimmerView : ContentView
	{
        public ShimmerView()
        {
            InitializeComponent();
            ObterGradiente();
            IniciarAnimacao();
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

        public static readonly BindableProperty VelocityShimmerProperty =
          BindableProperty.Create(nameof(VelocityShimmer), typeof(uint), typeof(ShimmerView), Convert.ToUInt32(400));

        public uint VelocityShimmer
        {
            get => (uint)GetValue(VelocityShimmerProperty);
            set => SetValue(VelocityShimmerProperty, value);
        }

        private void IniciarAnimacao()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                while (true)
                {
                    await RetonarGradientParaOInicio();

                    TranslateBox.IsVisible = true;

                    await TranslateBox.TranslateTo(WidthShimmer - 60, 0, VelocityShimmer);

                    await RetonarGradientParaOInicio();

                    await Task.Delay(800);

                    TranslateBox.IsVisible = true;
                }
            });
        }

        private async Task RetonarGradientParaOInicio()
        {
            TranslateBox.IsVisible = false;

            await TranslateBox.TranslateTo(-50, 0, 1);
        }

        private void ObterGradiente()
        {
            Color[] gradientColors = new Color[] { Color.FromHex("#eeeeee"), Color.FromHex("#dddddd"), Color.FromHex("#eeeeee") };
            TranslateBox.GradientColors = gradientColors;
        }

    }
}