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
    public partial class ObligatoryPasswordField : UserControl
    {
        private Brush _wrongBrush = Brushes.Red;
        private Brush _correctBrush = Brushes.Green;
        public ObligatoryPasswordField()
        {
            InitializeComponent();
            CorrectBorderBrush();
        }
        private void CorrectBorderBrush()
        {
            if (string.IsNullOrEmpty(Password))
            {
                Border.BorderBrush = _wrongBrush;
            }
            else
            {
                Border.BorderBrush = _correctBrush;
            }
        }

        private bool _isPasswordChanging;

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(
                name: "Password",
                propertyType: typeof(string),
                ownerType: typeof(ObligatoryPasswordField),
                typeMetadata: new FrameworkPropertyMetadata(
                        defaultValue: string.Empty,
                        flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        propertyChangedCallback: PasswordPropertyChanged,
                        coerceValueCallback: null,
                        isAnimationProhibited: false,
                        defaultUpdateSourceTrigger: UpdateSourceTrigger.PropertyChanged
                        ));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ObligatoryPasswordField obligatoryField)
            {
                obligatoryField.UpdatePassword();
            }
        }

        private void UpdatePassword()
        {
            if (!_isPasswordChanging)
            {
                passwordBox.Password = Password;
            }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging = true;
            Password = passwordBox.Password;
            _isPasswordChanging = false;
            CorrectBorderBrush();
        }
    }
}
