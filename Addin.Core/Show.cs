using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Addin;

[Transaction(TransactionMode.Manual)]
public class Show : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        DockablePaneId id = new DockablePaneId(new Guid("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"));
        commandData.Application.GetDockablePane(id).Show();
        return Result.Succeeded;
    }
}

