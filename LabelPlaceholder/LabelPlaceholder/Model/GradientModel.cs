using System;
using System.Collections.Generic;
using System.Text;

namespace LabelPlaceholder.Model
{
    public class GradientModel
    {
        public Xamarin.Forms.Color[] GradientColors { get; set; }
        public double ViewWidth { get; set; }
        public double ViewHeight { get; set; }
        public bool RoundCorners { get; set; }
        public double CornerRadius { get; set; }
        public bool LeftToRight { get; set; }
    }
}
