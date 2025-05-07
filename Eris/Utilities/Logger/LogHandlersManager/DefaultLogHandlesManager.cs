using Eris.Utilities.Logger.LogHandle;

namespace Eris.Utilities.Logger.LogHandlersManager;

public class DefaultLogHandlesManager(params ReadOnlySpan<ILogHandle<LogMessage>> handles) : ILogHandlersManager<LogMessage>
{
    private readonly List<ILogHandle<LogMessage>> _logHandles = [..handles];
    
    public void AddLogHandler(ILogHandle<LogMessage> message)
    {
        _logHandles.Add(message);
    }

    public void RemoveLogHandler(ILogHandle<LogMessage> message)
    {
        _logHandles.Remove(message);
    }

    public IReadOnlyList<ILogHandle<LogMessage>> Handles => _logHandles;
}