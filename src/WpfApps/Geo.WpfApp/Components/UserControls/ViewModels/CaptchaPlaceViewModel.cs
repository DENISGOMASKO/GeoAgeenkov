using Geo.WpfApp.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Reflection;
namespace Geo.WpfApp.Components.UserControls.ViewModels
{
    internal class CaptchaPlaceViewModel : BaseViewModel
    {
        public CaptchaPlaceViewModel()
        {
            RefreshCaptchaImage();
            
        }

        private bool _isCaptchaFilled;
        public bool IsCaptchaFilled
        {
            get
            {
                return _isCaptchaFilled;
            }
            set
            {
                _isCaptchaFilled = value;
                OnPropertyChanged();
                Trace.WriteLine("in CPVM: " + IsCaptchaFilled.ToString());
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
