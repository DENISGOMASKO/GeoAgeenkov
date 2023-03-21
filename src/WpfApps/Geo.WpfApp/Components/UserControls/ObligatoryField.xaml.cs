using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Geo.WpfApp.Core;


namespace Geo.WpfApp.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ObligatoryField.xaml. Также является DataContext для ObligatoryField
    /// Реализован интерфейс INotifyPropertyChanged
    /// </summary>
    public partial class ObligatoryField : UserControl//, INotifyPropertyChanged
    {
        private Brush _wrongBrush = Brushes.Red;
        private Brush _correctBrush = Brushes.Green;
        public ObligatoryField()
        {
            InitializeComponent();
            CorrectBorderBrush();
        }

        private void CorrectBorderBrush()
        {
            if (string.IsNullOrEmpty(Text))
            {
                Border.BorderBrush = _wrongBrush;
            }
            else
            {
                Border.BorderBrush = _correctBrush;
            }
        }

        public event TextChangedEventHandler TextChanged;

        private bool _isTextChanging;

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                name: "Text",
                propertyType: typeof(string),
                ownerType: typeof(ObligatoryField),
                typeMetadata: new FrameworkPropertyMetadata(
                        defaultValue: string.Empty,
                        flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        propertyChangedCallback: TextPropertyChanged,
                        coerceValueCallback: null,
                        isAnimationProhibited: false,
                        defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged
                        ));

        private static void TextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ObligatoryField obligatoryField)
            {
                obligatoryField.UpdateText();
            }
        }

        private void UpdateText()
        {
            if (!_isTextChanging)
            {
                textBox.Text = Text;
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            _isTextChanging = true;
            Text = textBox.Text;
            _isTextChanging = false;
            CorrectBorderBrush();
            TextChanged?.Invoke(this, e);
        }             
    }
}
