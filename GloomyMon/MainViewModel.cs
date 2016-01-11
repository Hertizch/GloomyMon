using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace GloomyMon
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            SliderDimStrength = Properties.Settings.Default.DimStrengthSliderValue;
            Debug.WriteLine(Properties.Settings.Default.DimStrengthSliderValue);
        }

        // Fields
        private double _sliderDimStrength;
        private double _currentDimStrength;
        private ICommand _commandCloseApp;

        /// <summary>
        /// 
        /// </summary>
        public double SliderDimStrength
        {
            get { return _sliderDimStrength; }
            set
            {
                if (Math.Abs(value - _sliderDimStrength) < 0.001) return;
                _sliderDimStrength = value;

                // Convert
                var input = Convert.ToInt32(value);
                var output = (input / (double)100);
                CurrentDimStrength = output;

                // Save to settings
                Properties.Settings.Default.DimStrengthSliderValue = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double CurrentDimStrength
        {
            get { return _currentDimStrength; }
            set
            {
                if (Math.Abs(value - _currentDimStrength) < 0.001) return;
                _currentDimStrength = value;
                OnPropertyChanged();
            }
        }

        public ICommand CommandCloseApp
        {
            get
            {
                return _commandCloseApp ??
                       (_commandCloseApp =
                           new RelayCommand(Execute_CloseApp, p => true));
            }
        }

        private static void Execute_CloseApp(object obj)
        {
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        // Property changed event
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
