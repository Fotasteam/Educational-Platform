using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Educational_Platform
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);

            this.InitializeComponent();

            if (DesktopAcrylicController.IsSupported())
                SystemBackdrop = new DesktopAcrylicBackdrop();
            NavViewMain.SelectedItem = NavItemDefault;
        }

        private void NavViewMain_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            FrameNavigationOptions navoptions = new FrameNavigationOptions();
            navoptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            string tagReplaced;
            if (item.Tag.ToString().Contains("TESTS"))
            {
                tagReplaced = item.Tag.ToString().Replace("TESTS", "");
                contentFrame.NavigateToType(Type.GetType("Educational_Platform.Windows.Tests." + tagReplaced), null, navoptions);
            }
            else if (item.Tag.ToString().Contains("LEARN"))
            {
                tagReplaced = item.Tag.ToString().Replace("LEARN", "");
                contentFrame.NavigateToType(Type.GetType("Educational_Platform.Windows.Learn." + tagReplaced), null, navoptions);
            }
            else contentFrame.NavigateToType(Type.GetType("Educational_Platform.Windows.Misc." + item.Tag.ToString()), null, navoptions);
        }
    }
}
