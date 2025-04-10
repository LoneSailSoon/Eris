using Eris.Extension.Generic;

namespace Eris.Extension.Eris.Style;

public class StyleManager
{
    public static readonly StyleManager Instance = new StyleManager();

    public bool TryCreate(TechnoExt owner, List<StyleInstance> styles, StyleType type)
    {
        var style = new StyleInstance();


        if (style.Attach(owner, type, null, null))
        {
            styles.Add(style);
            style.Awake();
            style.Enable();
            return true;
        }

        return false;
    }

    public void Remove(List<StyleInstance> styles, StyleInstance style)
    {
        styles.Remove(style);
        style.OnDestroy();
    }

    public void ForEach(List<StyleInstance> styles, Action<StyleInstance> action)
    {
        if (styles.Count > 0)
        {
            foreach (var style in styles.ToArray().Where(IsStyleActive))
            {
                action(style);
            }
        }

        static bool IsStyleActive(StyleInstance ae) => ae.IsActive() && !ae.IsExpired();
    }

    public void UpdateAll(List<StyleInstance> styles)
    {
        if (styles.Count > 0)
        {
            foreach (var style in styles.ToArray().Where(IsStyleActive))
            {
                style.OnUpdate();
            }
        }

        static bool IsStyleActive(StyleInstance ae) => ae.UpdateActive();
    }

    public void ClearExpired(List<StyleInstance> styles)
    {
        if (styles.Count > 0)
        {
            for (var i = styles.Count - 1; i >= 0; i--)
            {
                StyleInstance style = styles[i];
                if (style.IsExpired())
                {
                    Remove(styles, style);
                }
            }
        }
    }

    public void OnUpdate(GameToken token, List<StyleInstance> styles)
    {
        if (!token.Initialized) return;

        UpdateAll(styles);
        ClearExpired(styles);
    }

    public void OnDestroy(List<StyleInstance> styles)
    {
        foreach (var style in styles)
        {
            style.OnDestroy();
        }

        styles.Clear();
    }
}