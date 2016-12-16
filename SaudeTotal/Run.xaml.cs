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
        public Run()
        {
            this.InitializeComponent();
        }

        private void abbBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Chart));
        }

        private void abbDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void abbAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RunManage));
        }

        private void abbUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void abbDown_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
