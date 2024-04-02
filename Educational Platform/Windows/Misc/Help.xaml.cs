using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Educational_Platform.Windows.Misc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Help : Page
    {
        public Help()
        {
            this.InitializeComponent();

            ApplicationDataContainer dataContainer = ApplicationData.Current.LocalSettings;
            if (dataContainer.Values["onLaunched_Misc_Help_FirstTimeLaunched"].ToString() == "false")
            {
                ContentDialog noWifiDialog = new ContentDialog()
                {
                    XamlRoot = this.XamlRoot,
                    Title = "No wifi connection",
                    Content = "Check connection and try again.",
                    CloseButtonText = "Ok"
                };

                var dialog = noWifiDialog.ShowAsync();

                dataContainer.Values["onLaunched_Misc_Help_FirstTimeLaunched"] = "true";
            }
        }
    }
}
