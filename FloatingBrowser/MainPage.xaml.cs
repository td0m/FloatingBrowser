using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FloatingBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            EnterViewMode(ApplicationViewMode.CompactOverlay);
        }

        public async void EnterViewMode(ApplicationViewMode mode)
        {
            bool switched = false;
            if (ApplicationView.GetForCurrentView().IsViewModeSupported(mode))
            {
                switched = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(mode);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            webView.Source = new Uri(urlBox.Text);
            webView.Visibility = Visibility.Visible;
            initialPanel.Visibility = Visibility.Collapsed;
        }
    }
}
