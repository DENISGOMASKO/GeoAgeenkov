using Geo.WpfApp.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;

namespace Geo.WpfApp.Components.UserControls.ViewModels
{
    internal class CaptchaPlaceViewModel : BaseViewModel
    {
        public CaptchaPlaceViewModel()
        {
            RefreshCaptchaImage();
        }

        public static readonly DependencyProperty IsCaptchaFilledProperty =
             DependencyProperty.Register(
                 name: "IsCaptchaFilled",
                 propertyType: typeof(bool),
                 ownerType: typeof(CaptchaPlace),
                 typeMetadata: new FrameworkPropertyMetadata(
                         defaultValue: false,
                         flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                         propertyChangedCallback: null,
                         coerceValueCallback: null,
                         isAnimationProhibited: false,
                         defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged
                         ));

        public bool IsCaptchaFilled
        {
            get
            {
                return (bool)GetValue(IsCaptchaFilledProperty);
            }
            set
            {
                SetValue(IsCaptchaFilledProperty, value);
                //OnPropertyChanged();
            }
        }

        private string _captchaCode;

        private byte[] _captchaImage;
        public byte[] CaptchaImage
        {
            get
            {
                return _captchaImage;
            }
            set
            {
                _captchaImage = value;
                OnPropertyChanged();
            }
        }

        private string _enteredCaptchaCode;

        

        public string EnteredCaptchaCode
        {
            get
            {
                return _enteredCaptchaCode;
            }
            set
            {
                _enteredCaptchaCode = value;
                IsCaptchaFilled = string.Equals(_captchaCode, _enteredCaptchaCode);
                OnPropertyChanged();
            }
        }

        private void RefreshCaptchaImage()
        {
            EnteredCaptchaCode = string.Empty;
            _captchaCode = CaptchaGen.CaptchaCodeFactory.GenerateCaptchaCode(6).ToLower();
            CaptchaImage = CaptchaGen.ImageFactory.GenerateImage(_captchaCode).ToArray();
        }



        public ICommand RefreshCommand
        {
            get
            {
                return new ActionCommand(RefreshCaptchaImage);
            }
        }
    }
}
