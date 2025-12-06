using Eris.Utilities.Data;

namespace Eris.Component.Root;

public static class DelegateFactories
{
    public static readonly SerializableDelegate.Node<Action>.Factory Increment = SerializableDelegate.New<Action>(
        [Desc("返回两个函数，前者用于序列化，后者用于执行逻辑")]
        () =>
        {
            var i = 0;
            return (s => s.Process(ref i), () => Console.WriteLine(i++));
        });
}
