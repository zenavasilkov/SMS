using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace UniversityApp.WPF.Helpers
{
    public static class TextBoxHelper
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(TextBoxHelper),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public static string GetPlaceholder(TextBox textBox) =>
            (string)textBox.GetValue(PlaceholderProperty);

        public static void SetPlaceholder(TextBox textBox, string value) =>
            textBox.SetValue(PlaceholderProperty, value);

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not TextBox textBox)
                return;

            textBox.Loaded += (s, ev) => ShowOrHidePlaceholder(textBox);
            textBox.TextChanged += (s, ev) => ShowOrHidePlaceholder(textBox);
        }

        private static void ShowOrHidePlaceholder(TextBox textBox)
        {
            var layer = AdornerLayer.GetAdornerLayer(textBox);
            if (layer == null) return;

            var adorners = layer.GetAdorners(textBox);
            var placeholderText = GetPlaceholder(textBox);
             
            if (adorners != null)
            {
                foreach (var adorner in adorners)
                {
                    if (adorner is PlaceholderAdorner)
                        layer.Remove(adorner);
                }
            }
             
            if (string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(placeholderText))
            {
                var placeholderAdorner = new PlaceholderAdorner(textBox, placeholderText);
                layer.Add(placeholderAdorner);
            }
        }
    }
}
