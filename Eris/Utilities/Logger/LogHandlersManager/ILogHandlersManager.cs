using Eris.Utilities.Logger.LogHandle;

namespace Eris.Utilities.Logger.LogHandlersManager;

public interface ILogHandlersManager<TMessage>
{
    public void AddLogHandler(ILogHandle<TMessage> message);
    public void RemoveLogHandler(ILogHandle<TMessage> message);
    
    public IReadOnlyList<ILogHandle<TMessage>> Handles { get; }
}