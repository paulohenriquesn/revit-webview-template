using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Autodesk.Revit.UI;
using CefSharp.Wpf;

namespace Addin;

public partial class WebView : Page, IDockablePaneProvider
{
    ChromiumWebBrowser browser = new ChromiumWebBrowser();

    public WebView()
    {
        this.InitializeComponent();

        browser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
        browser.KeyDown += OnKeyDownHandler;
        BorderWeb.Child = browser;

        browser.IsBrowserInitializedChanged += delegate (object sender, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
            {
                browser.Load("https://github.com/paulohenriquesn/revit-webview-template");
            }
        };
    }

    private void OnKeyDownHandler(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F12)
        {
            browser.GetBrowser().GetHost().ShowDevTools();
        }
    }

    public void SetupDockablePane(DockablePaneProviderData data)
    {
        data.FrameworkElement = this;
        data.InitialState = new DockablePaneState
        {
            DockPosition = DockPosition.Right
        };
    }
}
