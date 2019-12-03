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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Comandos_y_Menús
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListBoxItem guardado;

        public MainWindow()
        {
            CentralListBox = new ListBox();
            guardado = new ListBoxItem();
            InitializeComponent();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {            
            ListBoxItem list = new ListBoxItem();
            TextBlock  texto = new TextBlock();
            texto.Text = "Item añadido" ;
            list.Content = texto;

            CentralListBox.Items.Add(list);
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CentralListBox.Items.Count < 10) 
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {                       
            TextBlock textoBlock = new TextBlock();
            textoBlock.Text = CentralListBox.SelectedItem.ToString();
            guardado.Content = textoBlock;
        }

        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CentralListBox.SelectedItem == null )
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CentralListBox.Items.Add(guardado);
            guardado.Content = null;
        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (guardado.Content != null && CentralListBox.Items.Count != 10)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        
    }
}
