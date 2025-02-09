﻿using App1.Entity;
using App1.Service;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private UserService service = new UserService();
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Handle_Login(object sender, RoutedEventArgs e)
        {
            var loginInformation = new LoginInformation()
            {
                email = email.Text,
                password = password.Password.ToString()
            };
            var credential = await service.Login(loginInformation);
            if (credential == null)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Login failed";
                contentDialog.Content = "Please try again later!";
                contentDialog.PrimaryButtonText = "Close";
                await contentDialog.ShowAsync();
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Login success";
                contentDialog.Content = "Welcome back";
                contentDialog.PrimaryButtonText = "Close";
                await contentDialog.ShowAsync();
                this.Frame.Navigate(typeof(Pages.Navigation));
            }
        }

        private void Handle_Register(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register.RegisterPage));
        }
    }
}
