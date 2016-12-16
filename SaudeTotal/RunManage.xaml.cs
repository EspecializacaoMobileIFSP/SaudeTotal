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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace SaudeTotal
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class RunManage : Page
    {
        public RunManage()
        {
            this.InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Run));
        }

        private async void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Corrida corrida = new Corrida() {
                Pessoa = Sessao.pessoa.PessoaId,
                Data = pkrData.Date.ToString(),
                Distancia = Double.Parse(tbxDistancia.Text),
                Tempo = pkrTempo.Time.TotalMinutes
            };

            string message;
            try
            {
                Dados.Save(corrida);
                message = "A operação foi realizada com sucesso.";
                Frame.Navigate(typeof(Run));
            }
            catch (Exception)
            {
                message = "A operação falhou.";
            }

            ContentDialog dlgMessage = new ContentDialog()
            {
                Title = "Corrida",
                Content = message,
                PrimaryButtonText = "Ok"
            };
            await dlgMessage.ShowAsync();
        }
    }
}
