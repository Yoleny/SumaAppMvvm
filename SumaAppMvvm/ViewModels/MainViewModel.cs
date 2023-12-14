using System.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SumaAppMvvm
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private double value1;
        private double value2;
        private double result;
        private string resultMessage;

        public double Value1
        {
            get { return value1; }
            set
            {
                if (value1 != value)
                {
                    value1 = value;
                    OnPropertyChanged(nameof(Value1));
                }
            }
        }

        public double Value2
        {
            get { return value2; }
            set
            {
                if (value2 != value)
                {
                    value2 = value;
                    OnPropertyChanged(nameof(Value2));
                }
            }
        }

        public double Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public string ResultMessage
        {
            get { return resultMessage; }
            set
            {
                if (resultMessage != value)
                {
                    resultMessage = value;
                    OnPropertyChanged(nameof(ResultMessage));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SumValues()
        {
            if (Value1 == 0 || Value2 == 0)
            {
                ResultMessage = "Error: Ambos valores deben ser mayores a cero.";
                return;
            }

            Result = Value1 + Value2;
            ResultMessage = $"El resultado es: {Result}";
        }

        public void ClearFields()
        {
            Value1 = 0;
            Value2 = 0;
            Result = 0;
            ResultMessage = "";
        }
    }
}