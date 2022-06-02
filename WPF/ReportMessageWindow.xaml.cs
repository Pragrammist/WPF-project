using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для ReportMessageWindow.xaml
    /// </summary>
    public partial class ReportMessageWindow : Window
    {
        
        public ReportMessageWindow(string message)
        {
            InitializeComponent();
            ReportMessageTextBlock.Text = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.Owner).CloseMWinow();
        }
    }
}
