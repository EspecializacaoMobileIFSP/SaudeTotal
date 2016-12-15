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
    public sealed partial class Person : Page
    {
        public Person()
        {
            this.InitializeComponent();
            this.LoadFields();
        }

        private void LoadFields()
        {
            tbxNome.Text = Sessao.pessoa.Nome;
            tbxAcesso.Text = Sessao.pessoa.Acesso;
            tbxSenha.Password = Sessao.pessoa.Senha;
            sldAltura.Value = Sessao.pessoa.Altura;
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Chart));
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Chart));
        }
    }
}
