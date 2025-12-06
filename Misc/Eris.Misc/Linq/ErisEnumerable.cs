using ZLinq;

namespace Eris.Misc.Linq;

public static partial class ErisEnumerable
{
    extension<TEnumerator, T>(ValueEnumerable<TEnumerator, T> source) where TEnumerator : struct, IValueEnumerator<T>, allows ref struct
    {
        public void Iter(Action<T> action)
        {
            ArgumentNullException.ThrowIfNull(action, "Action");
            using var enumerator = source.Enumerator;
            if(enumerator.TryGetSpan(out var span))
                for(var i = 0; i < span.Length; i++)
                    action(span[i]);
            else
                while(enumerator.TryGetNext(out var current))
                    action(current);
        }    

        public TState Fold<TState>(Func<TState, T, TState> func, TState state)
        {
            ArgumentNullException.ThrowIfNull(func, "Func");
            using var enumerator = source.Enumerator;
            if(enumerator.TryGetSpan(out var span))
                for(var i = 0; i < span.Length; i++)
                    state = func(state, span[i]);
            else
                while(enumerator.TryGetNext(out var current))
                    state = func(state, current);

            return state;
        }
    }
}
