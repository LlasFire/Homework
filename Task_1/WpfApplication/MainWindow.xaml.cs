// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApplication
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Send_Name(object sender, RoutedEventArgs e)
        {
            this.OutputLabel.Visibility = Visibility.Visible;

            if (string.IsNullOrEmpty(this.NameBox.Text))
            {
                this.OutputLabel.Content = "«Hello, unknown user!»";
            }
            else
            {
                this.OutputLabel.Content = $"«Hello, {this.NameBox.Text}!»";
            }
        }
    }
}
