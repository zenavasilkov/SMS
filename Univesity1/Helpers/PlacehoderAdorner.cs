using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Controls;

namespace UniversityApp.WPF.Helpers
{
    public class PlaceholderAdorner : Adorner
    {
        private readonly TextBlock _placeholderTextBlock;

        public PlaceholderAdorner(UIElement adornedElement, string placeholderText)
            : base(adornedElement)
        {
            IsHitTestVisible = false;

            _placeholderTextBlock = new TextBlock
            {
                Text = placeholderText,
                Foreground = Brushes.Gray,
                Margin = new Thickness(4, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            AddVisualChild(_placeholderTextBlock);
        }

        protected override int VisualChildrenCount => 1;
        protected override Visual GetVisualChild(int index) => _placeholderTextBlock;

        protected override Size ArrangeOverride(Size finalSize)
        {
            _placeholderTextBlock.Arrange(new Rect(finalSize));
            return finalSize;
        }
    }
}
