using Eris.Extension.Core.Generic;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Extension.Core.Style;

public class StyleManager
{
    public static readonly StyleManager Instance = new StyleManager();

    public bool TryCreate(TechnoExt owner, GameObject manager, StyleType type, HouseExt? house = null, WarheadTypeExt? warhead = null,
        Pointer<ObjectClass> pSource = default)
    {
        var style = new StyleInstance();
        if (style.TryAttach(owner, type, house, warhead, pSource))
        {
            manager.AttachComponent(style);
            style.Enable();
            return true;
        }
        return false;
    }

    public void Remove(GameObject manager, StyleInstance style)
    {
        manager.ReleaseComponent(style);
    }

    public void OnUpdate(GameObject manager)
    {
        manager.ForEach(c =>
        {
            if(c is StyleInstance style && style.UpdateActive())
                style.OnUpdate();
        });
    }
}