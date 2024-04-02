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
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Diagnostics;
using System.Windows.Input;
using Educational_Platform.Scripts;
using Educational_Platform.Windows.Learn;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Educational_Platform.Windows.Misc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            List<MainPageCardTemplate> MainPageCards = new List<MainPageCardTemplate>()
            {
                new MainPageCardTemplate {ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c2/GitHub_Invertocat_Logo.svg/800px-GitHub_Invertocat_Logo.svg.png", Name = "GitHub", Description = "Check the source code of this App, written in C# using WinUI3.", LinkOnClick = "https://github.com/"},
                new MainPageCardTemplate {ImageLink = "https://www.microsoft.com/en-us/microsoft-365/blog/wp-content/uploads/sites/50/2022/06/cropped-microsoft_logo_element.png", Name = "Microsoft Learn", Description = "A great place to learn more about developing Apps for Windows and beyond.", LinkOnClick = "https://learn.microsoft.com/en-us/training/"},
                new MainPageCardTemplate {ImageLink = "https://cdn4.iconfinder.com/data/icons/logos-and-brands/512/160_Hackerrank_logo_logos-512.png", Name = "Hackerrank", Description = "An amazing platform to expand your knowledge and find employment.", LinkOnClick = "https://www.hackerrank.com/"},
                new MainPageCardTemplate {ImageLink = "https://avatars.githubusercontent.com/u/70107528?s=200&v=4", Name = "FreeCodeCamp", Description = "A non-profit education platform that also offers certification.", LinkOnClick = "https://www.freecodecamp.org/"},
                new MainPageCardTemplate {ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Windows_logo_-_2021.svg/1024px-Windows_logo_-_2021.svg.png", Name = "Dev Options", Description = "Get to know various ways of developing apps for Windows.", LinkOnClick = "https://learn.microsoft.com/en-us/windows/apps/get-started/?tabs=winappsdk-winui%2Cnet-maui"},
                new MainPageCardTemplate {ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Stack_Overflow_icon.svg/768px-Stack_Overflow_icon.svg.png", Name = "StackOverflow", Description = "A great way to find answers to your questions.", LinkOnClick = "https://stackoverflow.com/"},
                new MainPageCardTemplate {ImageLink = "https://projecteuler.net/images/clipart/euler_portrait.png", Name = "Project Euler", Description = "A series of mathematical and computer programming problems.", LinkOnClick = "https://projecteuler.net/"}
            };
            
            foreach (var card in MainPageCards)
                CardsGridView.Items.Add(card);
        }
    }

    public class MainPageCardTemplate
    {
        public string LinkOnClick { get; set; }
        public string ImageLink { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public MainPageCardTemplate()
        {

        }

        public ICommand WebsiteOpeningCommand
        {
            get
            {
                return new CommadEventHandler<object>((obj) => this.OpenWebsite(obj));
            }

        }

        private void OpenWebsite(object obj)
        {
            Debug.WriteLine("Website opened");
        }

        public class CommadEventHandler<T> : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public Action<T> action;
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this.action((T)parameter);
                Process.Start(new ProcessStartInfo { FileName = parameter.ToString(), UseShellExecute = true });
            }
            public CommadEventHandler(Action<T> action)
            {
                this.action = action;
            }
        }
    }
}
