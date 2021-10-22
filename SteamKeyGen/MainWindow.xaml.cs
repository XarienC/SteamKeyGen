using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Diagnostics;

namespace SteamKeyGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            NoteMSG.Content = "Note for users:\nThis does not generate working Steam keys.\n\nThis tool generates keys in the Steam key format\nthat can be used for checking.\n\nExample: P2R4S-TVR2S-30YR1\n\n\n\n\n\nMade by cracked.to/Matt101";
        }

        private void SelectOutPutLocation_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = "Choose output location:";
            dialog.ShowDialog();
            LocationOutput.Text = dialog.SelectedPath;
        }

        private void GenKeysButton_Click(object sender, RoutedEventArgs e)
        {
            KeyGen key = new KeyGen();
            key.KeyLetters_ = "ABCDEFGHIJKLMNOPQRSTUVWYZ";
            key.KeyNumbers_ = "0123456789";
            key.KeyChars_ = 5;
            int num = Conversions.ToInteger(KeyAmount.Text);
            string folderpath = LocationOutput.Text;
            FileStream stream = new FileStream(folderpath + "\\" + Conversions.ToString(num) + " Steam Keys.txt", FileMode.Create);
            TextWriter @out = Console.Out;
            StreamWriter streamWriter = new StreamWriter(stream);
            Console.SetOut(streamWriter);
            int num2 = num;
            checked
            {
                for (int i = 1; i <= num2; i++)
                {
                    string text = key.GenerateKey();
                    Console.WriteLine(string.Concat(new string[]
                    {
                        key.GenerateKey(),
                        "-",
                        key.GenerateKey(),
                        "-",
                        key.GenerateKey()
                    }));
                }
                Console.SetOut(@out);
                streamWriter.Close();
                System.Windows.MessageBox.Show("Generated " + Conversions.ToString(num) + " keys");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MattEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://cracked.to/Matt101");
        }
    }
}
