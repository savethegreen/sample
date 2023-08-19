using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using static solution.Model.View;

namespace solution.Model
{
    internal class ViewModel : INotifyPropertyChanged
    {

        #region common
        private View _view;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModel(View view)
        {
            _view = view;
        }

        #endregion common

        #region ICommand

        public class RelayCommand : ICommand
        {
            private readonly Action _execute;

            public RelayCommand(Action execute)
            {
                _execute = execute;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object parameter) => true;

            public void Execute(object parameter) => _execute();
        }


        private ICommand _changeCommand_Mode;
        public ICommand ChangeCommand_Mode => _changeCommand_Mode ??= new RelayCommand(ChangeCommand_Mode_F);

        private ICommand _changeCommand_View;
        public ICommand ChangeCommand_View => _changeCommand_View ??= new RelayCommand(ChangeCommand_View_F);

        private ICommand _changeCommand_Recipe;
        public ICommand ChangeCommand_Recipe => _changeCommand_Recipe ??= new RelayCommand(ChangeCommand_Recipe_F);

        private ICommand _changeCommand_Setting;
        public ICommand ChangeCommand_Setting => _changeCommand_Setting ??= new RelayCommand(ChangeCommand_Setting_F);
        #endregion ICommand

        #region string

        #endregion string

        #region bool
        public bool Mode_B
        {
            get => _view.Bool;
            set
            {
                _view.Bool = value;
                OnPropertyChanged(nameof(Mode_B));
            }
        }
        #endregion bool

        #region Enum

        public WindowPage_E WindowPage
        {
            get => _view.WindowPage;
            set
            {
                _view.WindowPage = value;
                OnPropertyChanged(nameof(WindowPage));
            }
        }



        public ISeries[] Series
        {
            get => _view.Series;
            set
            {
                _view.Series = value;
                OnPropertyChanged(nameof(Series));
            }
        }
        #endregion Enum

        #region Function
        #region Button

        private void ChangeCommand_Mode_F()
        {
            Mode_B = !Mode_B;
        }

        private void ChangeCommand_View_F()
        {
            WindowPage =  WindowPage_E.View;

        }
        private void ChangeCommand_Recipe_F()
        {
            WindowPage = WindowPage_E.Recipe;
            double[] dd = new double[] { 5, 0, 5, 0, 5, 0 };
            Series = new ISeries[] {
                new LineSeries<double>
        {
            Values = dd,
            Fill = null,

            GeometrySize = 20,
            // use the line smoothness property to control the curve
            // it goes from 0 to 1
            // where 0 is a straight line and 1 the most curved
            LineSmoothness = 0,
            Stroke = new SolidColorPaint(SKColor.Parse("#FFEC9D3F")) { StrokeThickness = 6 },
            GeometryStroke = new SolidColorPaint(SKColors.GreenYellow) { StrokeThickness = 6 }

        },
        new LineSeries<double>
        {
            Values = new double[] { 7, 2, 7, 2, 7, 2 },
            Fill = null,
            GeometrySize = 0,
            LineSmoothness = 1
        }  };
        }
        private void ChangeCommand_Setting_F()
        {
            WindowPage = WindowPage_E.Setting;
        }
        #endregion Button
        #endregion Function
    }
}
