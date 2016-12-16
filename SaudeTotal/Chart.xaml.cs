using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace SaudeTotal
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Chart : Page
    {
        public Chart()
        {
            this.InitializeComponent();
        }

        private void InitializeScreen()
        {
            List<ValueChart> listPeso = new List<ValueChart>();
            List<ValueChart> listDistancia = new List<ValueChart>();
            List<ValueChart> listTempo = new List<ValueChart>();

            List<Peso> pesos = Dados.ListPeso(Sessao.pessoa, "ASC");
            List<Corrida> corridas = Dados.ListCorrida(Sessao.pessoa, "ASC");

            int count = 0;
            foreach (Peso peso in pesos)
            {
                listPeso.Add(new ValueChart()
                {
                    Count = count++,
                    Value = peso.Valor
                });
            };

            count = 0;
            foreach (Corrida corrida in corridas)
            {
                listDistancia.Add(new ValueChart()
                {
                    Count = count++,
                    Value = corrida.Distancia
                });
            };

            count = 0;
            foreach (Corrida corrida in corridas)
            {
                listTempo.Add(new ValueChart()
                {
                    Count = count++,
                    Value = corrida.Tempo
                });
            };

            (chtPeso.Series[0] as LineSeries).ItemsSource = listPeso;
            (chtDistancia.Series[0] as LineSeries).ItemsSource = listDistancia;
            (chtTempo.Series[0] as LineSeries).ItemsSource = listTempo;

            txtAtividades.Text = "Atividades";
            if (pesos.Count > 0)
            {
                Peso peso = pesos[pesos.Count - 1];
                txtAtividades.Text += string.Format("\nIMC: {0:0.00}", (peso.Valor / Math.Pow(Sessao.pessoa.Altura / 100, 2.0)));
            }

            if (corridas.Count > 0) {
                Corrida corrida = corridas[corridas.Count -1];
                txtAtividades.Text += string.Format("\nÚtima atividade \n{0} metros em \n{1} minutos", corrida.Distancia, corrida.Tempo);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Pessoa)
            {
                Sessao.pessoa = (Pessoa) e.Parameter;
            }
            base.OnNavigatedTo(e);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeScreen();
        }

        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Person));
        }

        private void btnPeso_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Weight));
        }

        private void btnCorrida_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Run));
        }
    }

    public class ValueChart
    {
       public int Count { get; set; }
       public double Value { get; set; }
    }
}
