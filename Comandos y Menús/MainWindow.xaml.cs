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
        string guardado = "";

        public MainWindow()
        {
            CentralListBox = new ListBox();            
            InitializeComponent();            
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            TextBlock texto = new TextBlock
            {
                Text = "Item añadido"
            };

            CentralListBox.Items.Add(texto);
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
            
            guardado = CentralListBox.SelectedValue.ToString();
            
        }

        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CentralListBox.SelectedItem != null )
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock texto = new TextBlock
            {
                Text = guardado
            };
            CentralListBox.Items.Add(texto.Text);
            guardado = "";
        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (guardado != "" && CentralListBox.Items.Count != 10)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CentralListBox.Items.Clear();
        }

        private void DeleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CentralListBox.Items.Count > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
    }
}
