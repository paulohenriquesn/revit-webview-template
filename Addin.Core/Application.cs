using System.Reflection;
using Autodesk.Revit.UI;

namespace Addin;

public class Application : IExternalApplication
{
    public Result OnStartup(UIControlledApplication application)
    {
        WebView WebView = new WebView();
        DockablePaneId id = new DockablePaneId(new Guid("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}")); 
        application.RegisterDockablePane(id, "Addin", WebView);
        
        string assemblyPath = Assembly.GetExecutingAssembly().Location;
        PushButton? obj = application.CreateRibbonPanel(Tab.AddIns, "AddinWebView").AddItem(new PushButtonData("AddinWebView", "AddinWebView", assemblyPath, "Addin.Show")) as PushButton;
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }

}
