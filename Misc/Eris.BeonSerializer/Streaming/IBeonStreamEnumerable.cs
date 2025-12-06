using System;

namespace Eris.BeonSerializer.Streaming;

public interface IBeonStreamEnumerable
{
    bool MoveNextOrDonothing();

    IBeonSerializable? Current { get; }
    
    void Reset();
}
