using System;
using System.IO;
using Microsoft.Win32;

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

namespace Homework_Nanotec
{
    public partial class MainWindow : Window
    {

        string input = "";
        string targetFile = "";
        string fileExtension = "";

        public MainWindow()
        {
            InitializeComponent();
            /*
                OnLoad
            */
            input = textBox.Text;
        }

        private void menu_new(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";

            input = "";
            targetFile = "";
            fileExtension = "";

            textBox.Focus();
        }

        private void menu_open(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.ShowDialog();
            targetFile = fileDialog.FileName;

            if(targetFile != "")
            {
                string[] fileNameArray = targetFile.Split('.');
                fileExtension = fileNameArray.Last();

                if((fileExtension == "xml" || fileExtension == "xaml") && fileNameArray.Length >= 2)
                {
                    textBox.Text = File.ReadAllText(targetFile);

                    textBox.Focus();
                }
                else
                {
                    MessageBox.Show("Only XML/XAML Files Are Allowed!");
                }
            }
        }

        private void menu_saveAs(object sender, RoutedEventArgs e)
        {
	        SaveFileDialog saveAs = new SaveFileDialog();

            saveAs.Filter = "XML Files (*.xml)|*.xml";
            saveAs.ShowDialog();

            targetFile = saveAs.FileName;

            string[] fileNameArray = targetFile.Split('.');
            fileExtension = fileNameArray.Last();

            if((fileExtension == "xml" || fileExtension == "xaml") && fileNameArray.Length >= 2)
            {
                File.WriteAllText(targetFile, textBox.Text);

                textBox.Focus();
            }
            else
            {
                MessageBox.Show("Only XML/XAML Files Are Allowed!");
            }
        }

        private void menu_save(object sender, RoutedEventArgs e)
        {
            if(targetFile != "")
            {
                string[] fileNameArray = targetFile.Split('.');
                fileExtension = fileNameArray.Last();

                if((fileExtension == "xml" || fileExtension == "xaml") && fileNameArray.Length >= 2)
                {
                    File.WriteAllText(targetFile, textBox.Text);

                    textBox.Focus();
                }
                else
                {
                    MessageBox.Show("Only XML/XAML Files Are Allowed!");
                }

            }else{
                menu_saveAs(sender, e);
            }
        }

        private void menu_exit(object sender, RoutedEventArgs e)
        {
	        Application.Current.Shutdown();
        }

    }

}
