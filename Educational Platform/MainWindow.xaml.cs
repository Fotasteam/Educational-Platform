using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using Educational_Platform.Scripts;
using System.Collections.Generic;
using Windows.UI;

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

            Microsoft.UI.Xaml.Media.MicaBackdrop micaBackdrop = new Microsoft.UI.Xaml.Media.MicaBackdrop();
            micaBackdrop.Kind = MicaKind.Base;
            this.SystemBackdrop = micaBackdrop;

            NavViewMain.SelectedItem = NavItemDefault;

            //InitializeNavViewMainItems(NavViewItemsReader.downloadedItems());
        }

        //public void InitializeNavViewMainItems(List<NavViewItem> listOfAllItems)
        //{
        //    foreach (NavViewItem element in listOfAllItems)
        //    {
        //        var itemToAdd = new NavigationViewItem() { Content = element.Name, Tag = element.Tag };

        //        FontIcon icon = new FontIcon();
        //        icon.Glyph = element.Icon;
        //        itemToAdd.Icon = icon;
        //        bool firstTimeCategory2 = false;
        //        switch (element.Category)
        //        {
        //            case 0:
        //                NavViewMain.MenuItems.Add(itemToAdd);
        //                break;
        //            case 1:
        //                NavViewMain.FooterMenuItems.Add(itemToAdd);
        //                break;
        //            case 2:
        //                if (!firstTimeCategory2) {  firstTimeCategory2 = true; }
        //                NavViewMain.MenuItems.Add(itemToAdd);
        //                break;
        //        }
        //    }
        //}

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
