﻿using System;
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
    public sealed partial class WeightManage : Page
    {
        public WeightManage()
        {
            this.InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Weight));
        }

        private async void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Peso peso = new Peso()
            {
                Pessoa = Sessao.pessoa.PessoaId,
                Data = pkrData.Date.ToString(),
                Valor = sldPeso.Value
            };

            string message;
            try
            {
                Dados.Save(peso);
                message = "A operação foi realizada com sucesso.";
                Frame.Navigate(typeof(Weight));
            }
            catch (Exception)
            {
                message = "A operação falhou.";
            }

            ContentDialog dlgMessage = new ContentDialog()
            {
                Title = "Peso",
                Content = message,
                PrimaryButtonText = "Ok"
            };
            await dlgMessage.ShowAsync();
        }
    }
}
