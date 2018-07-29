﻿using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientLight.Views
{
    using System;

    using Windows.UI.Xaml.Navigation;

    using ClientLight.ViewModel;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PilotsPage : Page
    {
        private PilotsViewModel ViewModel => DataContext as PilotsViewModel;

        public PilotsPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                await ViewModel.LoadDataAsync(WindowStates.CurrentState);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                //                throw;
            }
        }
    }
}
