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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace SaudeTotal
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private async void btnLogar_Click(object sender, RoutedEventArgs e)
        {
            Pessoa pessoa = Dados.GetPessoa(tbxAcesso.Text, tbxSenha.Password);

            string message;
            if (pessoa != null)
            {
                message = string.Format("Seja bem vindo {0}", pessoa.Nome);
                Frame.Navigate(typeof(Chart), pessoa);
            }
            else
            {
                message = "A credencial utilizada é incorreta.";
            }

            ContentDialog dlgMessage = new ContentDialog()
            {
                Title = "Login",
                Content = message,
                PrimaryButtonText = "Ok"
            };
            await dlgMessage.ShowAsync();
        }
    }
}
