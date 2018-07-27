using Xamarin.Forms;

namespace LabelPlaceholder.Model
{
    public class GradientModel
    {
		private GradientModel(Color[] gradientColors, int widthShimmer, int heightShimmer, bool roundCorners, int cornerRadius, bool leftToRight)
        {
            GradientColors = gradientColors;
            ViewWidth = widthShimmer;
            ViewHeight = heightShimmer;
            RoundCorners = roundCorners;
            CornerRadius = cornerRadius;
            LeftToRight = leftToRight;
        }

        public Color[] GradientColors { get; set; }
        public double ViewWidth { get; set; }
        public double ViewHeight { get; set; }
        public bool RoundCorners { get; set; }
        public double CornerRadius { get; set; }
        public bool LeftToRight { get; set; }

		internal static GradientModel Create(Color[] gradientColors, int widthShimmer, int heightShimmer, bool roundCorners, int cornerRadius, bool leftToRight)
            => new GradientModel(gradientColors, widthShimmer, heightShimmer, roundCorners, cornerRadius, leftToRight);
    }
}
