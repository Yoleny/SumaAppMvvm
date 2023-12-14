using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SumaAppMvvm
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private double resultado;
        public double Resultado
        {
            get { return resultado; }
            set { resultado = value; NotifyPropertyChanged(); }
        }

        public Command SumarCommand { get; }
        public Command LimpiarCommand { get; }

        public MainPage()
        {
            InitializeComponent();

            SumarCommand = new Command(Sumar, ValidarCampos);
            LimpiarCommand = new Command(Limpiar);

            BindingContext = this;
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(valor1Entry.Text) && !string.IsNullOrWhiteSpace(valor2Entry.Text);
        }

        private void Sumar()
        {
            double valor1 = Convert.ToDouble(valor1Entry.Text);
            double valor2 = Convert.ToDouble(valor2Entry.Text);
            Resultado = valor1 + valor2;

            resultadoLabel.Text = Resultado.ToString();
        }

        private void Limpiar()
        {
            valor1Entry.Text = string.Empty;
            valor2Entry.Text = string.Empty;
            resultadoLabel.Text = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}