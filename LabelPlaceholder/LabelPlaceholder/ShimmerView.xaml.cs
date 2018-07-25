using LabelPlaceholder.CustomRenderers;
using LabelPlaceholder.Model;
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
            ObterGradient();
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

                    int recuo = ObterRecuo();

                    await TranslateBox.TranslateTo(WidthShimmer - recuo, 0, VelocityShimmer);

                    await RetonarGradientParaOInicio();

                    await Task.Delay(1000);

                    TranslateBox.IsVisible = true;
                }
            });
        }

        private static int ObterRecuo()
        {
            if (Device.RuntimePlatform == Device.iOS)
                return 55;
            else
                return 60;
        }

        private async Task RetonarGradientParaOInicio()
        {
            TranslateBox.IsVisible = false;

            await TranslateBox.TranslateTo(-50, 0, 1);
        }

        private void ObterGradient()
        {
            Color[] gradientColors = new Color[] { Color.FromHex("#eeeeee"), Color.FromHex("#dddddd"), Color.FromHex("#eeeeee") };

            if (Device.RuntimePlatform == Device.Android)
                ObterGradienteAndroid(gradientColors);
            else if (Device.RuntimePlatform == Device.iOS)
                ObterGradienteiOS(gradientColors);
        }

        private void ObterGradienteAndroid(Color[] gradientColors) => TranslateBox.GradientColors = gradientColors;

        private void ObterGradienteiOS(Color[] gradientColors)
        {
            GradientModel g = new GradientModel()
            {
                GradientColors = gradientColors,
                ViewWidth = WidthShimmer,
                ViewHeight = HeightShimmer,
                RoundCorners = false,
                CornerRadius = 0,
                LeftToRight = true
            };

            TranslateBox.SetBinding(GradientViewRender.GradientColorsProperty, "GradientColors");
            TranslateBox.SetBinding(GradientViewRender.CornerRadiusProperty, "CornerRadius");
            TranslateBox.SetBinding(GradientViewRender.ViewWidthProperty, "ViewWidth");
            TranslateBox.SetBinding(GradientViewRender.ViewHeightProperty, "ViewHeight");
            TranslateBox.SetBinding(GradientViewRender.RoundCornersProperty, "RoundCorners");
            TranslateBox.SetBinding(GradientViewRender.LeftToRightProperty, "LeftToRight");

            TranslateBox.BindingContext = g;
        }

    }
}