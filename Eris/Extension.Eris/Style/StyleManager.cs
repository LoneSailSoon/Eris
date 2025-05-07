using Eris.Extension.Eris.Generic;
using Eris.Extension.Generic;

namespace Eris.Extension.Eris.Style;

public class StyleManager
{
    public static readonly StyleManager Instance = new StyleManager();

    public bool TryCreate(TechnoExt owner, GameObject manager, StyleType type)
    {
        var style = new StyleInstance();
        if (style.TryAttach(owner, type))
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