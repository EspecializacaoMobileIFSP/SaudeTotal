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
    public sealed partial class Run : Page
    {
        private List<Corrida> list;
        string direction;

        public Run()
        {
            this.InitializeComponent();
            this.InitializeList();
        }

        private void InitializeList()
        {
            direction = "DESC";
            list = Dados.ListCorrida(Sessao.pessoa, direction);
            lbxDados.DataContext = list;
        }

        private void abbBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Chart));
        }

        private async void abbDelete_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dlgMessage = new ContentDialog()
            {
                Title = "Corrida",
                Content = "Deseja deletar este registro?",
                PrimaryButtonText = "Deletar",
                SecondaryButtonText = "Cancelar"
            };
            ContentDialogResult result = await dlgMessage.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string message;
                try
                {
                    Dados.Delete(list[lbxDados.SelectedIndex]);
                    list = Dados.ListCorrida(Sessao.pessoa, direction);
                    lbxDados.DataContext = list;
                    message = "A operação foi realizada com sucesso.";
                }
                catch (Exception)
                {
                    message = "A operação falhou.";
                }

                dlgMessage = new ContentDialog()
                {
                    Title = "Corrida",
                    Content = message,
                    PrimaryButtonText = "Ok"
                };
                await dlgMessage.ShowAsync();
            }
        }

        private void abbAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RunManage));
        }

        private void abbUp_Click(object sender, RoutedEventArgs e)
        {
            direction = "ASC";
            list = Dados.ListCorrida(Sessao.pessoa, direction);
            lbxDados.DataContext = list;
        }

        private void abbDown_Click(object sender, RoutedEventArgs e)
        {
            direction = "DESC";
            list = Dados.ListCorrida(Sessao.pessoa, direction);
            lbxDados.DataContext = list;
        }

        private void lbxDados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            abbDelete.IsEnabled = lbxDados.SelectedIndex > -1;
        }
    }
}
