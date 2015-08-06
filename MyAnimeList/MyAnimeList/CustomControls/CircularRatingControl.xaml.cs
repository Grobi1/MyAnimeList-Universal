using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MyAnimeList.CustomControls
{
    public sealed partial class CircularRatingControl : UserControl
    {
        public CircularRatingControl()
        {
            InitializeComponent();
            Angle = (150 * 360) / 100;
            RenderArc();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = Percentage;
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            CubicEase easingFunction = new CubicEase();
            easingFunction.EasingMode = EasingMode.EaseOut;
            animation.EasingFunction = easingFunction;
            animation.AutoReverse = false;

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            animation.EnableDependentAnimation = true;
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, "Percentage");
            storyboard.Begin();
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public Brush SegmentBrush
        {
            get { return (Brush)GetValue(SegmentBrushProperty); }
            set { SetValue(SegmentBrushProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public int MaxPercentage
        {
            get { return (int)GetValue(MaxPercentageProperty); }
            set { SetValue(MaxPercentageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxPercentage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxPercentageProperty =
            DependencyProperty.Register("MaxPercentage", typeof(int), typeof(CircularRatingControl), new PropertyMetadata(100, OnPercentageChanged));

        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register("Percentage", typeof(double), typeof(CircularRatingControl), new PropertyMetadata(5d, OnPercentageChanged));

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CircularRatingControl), new PropertyMetadata(5d));

        public static readonly DependencyProperty SegmentBrushProperty =
            DependencyProperty.Register("SegmentBrush", typeof(Brush), typeof(CircularRatingControl), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(CircularRatingControl), new PropertyMetadata(50d, OnPropertyChanged));

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CircularRatingControl), new PropertyMetadata(120d, OnPropertyChanged));

        private static void OnPercentageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var circle = (CircularRatingControl)sender;
            circle.Angle = (circle.Percentage * 360) / circle.MaxPercentage;
        }

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var circle = (CircularRatingControl)sender;
            circle.RenderArc();
        }

        public void RenderArc()
        {
            var backgroundEndpoint = ComputeCartesianCoordinate(360, Radius);
            backgroundEndpoint.X -= 0.001;
            var startPoint = new Point(Radius, 0);
            var endPoint = ComputeCartesianCoordinate(Angle, Radius);
            endPoint.X += Radius;
            endPoint.Y += Radius;
            backgroundEndpoint.X += Radius;
            backgroundEndpoint.Y += Radius;

            pathRoot.Width = Radius * 2 + StrokeThickness;
            pathRoot.Height = Radius * 2 + StrokeThickness;
            pathRoot.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);
            backgroundPathRoot.Width = Radius * 2 + StrokeThickness;
            backgroundPathRoot.Height = Radius * 2 + StrokeThickness;
            backgroundPathRoot.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);

            var largeArc = Angle > 180.0;

            var outerArcSize = new Size(Radius, Radius);

            pathFigure.StartPoint = startPoint;
            backgroundPathFigure.StartPoint = startPoint;

            if (Math.Abs(startPoint.X - Math.Round(endPoint.X)) < .1 && Math.Abs(startPoint.Y - Math.Round(endPoint.Y)) < .1)
                endPoint.X -= 0.01;

            arcSegment.Point = endPoint;
            arcSegment.Size = outerArcSize;
            arcSegment.IsLargeArc = largeArc;
            backgroundArcSegment.Size = outerArcSize;
            backgroundArcSegment.IsLargeArc = true;
            backgroundArcSegment.Point = backgroundEndpoint;
        }

        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            var angleRad = (Math.PI / 180.0) * (angle - 90);

            var x = radius * Math.Cos(angleRad);
            var y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }
    }
}
