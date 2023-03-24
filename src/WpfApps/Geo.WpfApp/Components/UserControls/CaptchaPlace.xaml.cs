using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using Geo.WpfApp.Components.UserControls.ViewModels;
using Geo.WpfApp.Core;

namespace Geo.WpfApp.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CaptchaPlace.xaml
    /// </summary>
    public partial class CaptchaPlace : UserControl
    {
        
        public CaptchaPlace()
        {
            InitializeComponent();
            RefreshCaptchaImage();
        }

        private void RefreshCaptchaImage()
        {
            if (IsCaptchaFilled) return;
            field.Text = string.Empty;
            _captchaCode = CaptchaGen.CaptchaCodeFactory.GenerateCaptchaCode(6).ToLower();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = CaptchaGen.ImageFactory.GenerateImage(_captchaCode);
            image.EndInit();
            captchaImage.Source = image;
        }

        private string _captchaCode;

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            RefreshCaptchaImage();
        }

        private void Field_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsCaptchaFilled = string.Equals(field.Text, _captchaCode);
        }

        public bool IsCaptchaFilled
        {
            get
            {
                return (bool)GetValue(IsCaptchaFilledProperty);
            }
            set
            {
                SetValue(IsCaptchaFilledProperty, value);
                if (value)
                {
                    //field. //TODO: ReadOnly
                }
            }
        }

        public static readonly DependencyProperty IsCaptchaFilledProperty =
             DependencyProperty.Register(
                 name: "IsCaptchaFilled",
                 propertyType: typeof(bool),
                 ownerType: typeof(CaptchaPlace),
                 typeMetadata: new FrameworkPropertyMetadata(
                        defaultValue: false,
                        flags: FrameworkPropertyMetadataOptions.None,
                        propertyChangedCallback: null,
                        coerceValueCallback: null,
                        isAnimationProhibited: false,
                        defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged
                        ));
    }
}
