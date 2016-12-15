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
            LoadChartContents();
        }

        private void LoadChartContents()
        {
            List<Test> list = new List<Test>();
            list.Add(new Test() { Name = "A1", Amount = 70 });
            list.Add(new Test() { Name = "A2", Amount = 20 });
            list.Add(new Test() { Name = "A3", Amount = 10 });
            (PieChart.Series[0] as PieSeries).ItemsSource = list;
            (PieChart.Series[1] as PieSeries).ItemsSource = list;
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

    public class Test
    {
       public string Name { get; set; }
       public int Amount { get; set; }
    }
}
