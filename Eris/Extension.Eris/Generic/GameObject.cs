using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Eris.Scripts;
using Eris.Serializer;
using Eris.Utilities.Helpers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Generic;

/// <summary>
/// <see cref="Component">元件</see>附着的对象，可序列化
/// </summary>
public sealed class GameObject : INaegleriaSerializable
{
    /// <summary>
    /// 创建游戏对象，区别于序列化使用的无参构造函数
    /// </summary>
    public static GameObject Create()
    {
        return new GameObject();
    }

    /// <summary>
    /// 左右缓冲状态
    /// </summary>
    private enum State : byte
    {
        Left, Right
    }
    
    private const int DefaultCapacity = 4;

    /// <summary>
    /// 左缓冲，用于遍历
    /// </summary>
    private Component[]? _leftBuffer;
    private int _leftBufferSize;
    /// <summary>
    /// <see cref="_leftBuffer">左缓冲</see>是否存在<see cref="Component.Expired">过期原件</see>
    /// </summary>
    private bool _leftDirt;
    
    private State _state = State.Left;

    /// <summary>
    /// 右缓冲，用于<see cref="_leftBuffer">左缓冲</see>占用时增删元件
    /// </summary>
    private Component[]? _rightBuffer;
    private int _rightBufferSize;
    /// <summary>
    /// <see cref="_leftBuffer">左缓冲</see>遍历时的锁
    /// </summary>
    private int _enumeratorLock;

    public bool EnumeratorLock
    {
        get => _enumeratorLock > 0;
        set => _enumeratorLock += value ? 1 : -1;
    }
    
    private bool _expired;
    public bool Expired => _expired;
    
    public void Serialize(INaegleriaStream stream)
    {
        stream.Process(ref _expired);
    }

    void INaegleriaSerializable.OnSave(NaegleriaSerializeStream stream)
    {
        if (_expired) return;
        if (_state == State.Left)
        {
            if (_leftBuffer == null)
            {
                stream.Buffer.WriteInt32(-1);
            }
            else
            {
                stream.Buffer.WriteInt32(_leftBufferSize);

                for (var i = 0; i < _leftBufferSize; i++)
                {
                    INaegleriaSerializable? temp = _leftBuffer[i];
                    stream.ProcessObject(ref temp);
                }
            }
        }
        else
        {
            if (_rightBuffer == null)
            {
                stream.Buffer.WriteInt32(-1);
            }
            else
            {
                stream.Buffer.WriteInt32(_rightBufferSize);

                for (var i = 0; i < _rightBufferSize; i++)
                {
                    INaegleriaSerializable? temp = _rightBuffer[i];
                    stream.ProcessObject(ref temp);
                }
            }
        }

    }

    void INaegleriaSerializable.OnLoad(NaegleriaDeserializeStream stream)
    {            
        if (_expired) return;
        var length = stream.Buffer.ReadInt32();
        if (length < 0)
        {
            _leftBuffer = null;
            _leftBufferSize = 0;
        }
        else
        {
            _leftBufferSize = length;
            _leftBuffer = new Component[length];
            for (var i = 0; i < _leftBufferSize; i++)
            {
                INaegleriaSerializable? temp = null;
                stream.ProcessObject(ref temp);
                _leftBuffer[i] = (Component)temp!;
            }
        }
            
        _state = State.Left;

    }
    
    /// <summary>
    /// 将<see cref="_rightBuffer">右缓冲</see>复制到<see cref="_leftBuffer">左缓冲</see>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ReflashLeftBuffer()
    {
        ReflashBuffer(ref _leftBuffer, ref _leftBufferSize, ref _rightBuffer, ref _rightBufferSize);
    }

    /// <summary>
    /// 清理<see cref="_leftBuffer">左缓冲</see>中的<see cref="Component.Expired">过期原件</see>
    /// </summary>
    private void ClearExpiredLeftBuffer()
    {
        if (_leftBuffer == null) return;
        
        var activeCount = 0;
        for (var i = 0; i < _leftBufferSize; i++)
        {
            if (_leftBuffer[i] is not { Expired: false } component) continue;
            
            _leftBuffer[activeCount] = component;
            activeCount++;
        }
        
        if (_leftBufferSize > activeCount)
        {
            Array.Clear(_leftBuffer, activeCount, _leftBufferSize - activeCount);
        }

        _leftBufferSize = activeCount;
        
        _leftDirt = false;
    }
    
    /// <summary>
    /// 将<see cref="_leftBuffer">左缓冲</see>复制到<see cref="_rightBuffer">右缓冲</see>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ReflashRightBuffer()
    {
        ReflashBuffer(ref _rightBuffer, ref _rightBufferSize, ref _leftBuffer, ref _leftBufferSize);
    }

    /// <summary>
    /// 获取最近更新的缓冲，由<see cref="_state">状态</see>决定
    /// </summary>
    private Component[]? GetCurrentBuffer() =>
        _state switch
        {
            State.Left => _leftBuffer,
            State.Right => _rightBuffer,
            _ => null
        };

    /// <summary>
    /// 复制缓冲
    /// </summary>
    private void ReflashBuffer(ref Component[]? destBuffer, ref int destBufferSize, ref Component[]? srcBuffer, ref int srcBufferSize)
    {
        if (srcBuffer == null) return;
        if (destBuffer == null || destBuffer.Length < srcBufferSize)
        {
            destBuffer = new Component[srcBuffer.Length];
            var activeCount = 0;
            for (var i = 0; i < srcBufferSize; i++)
            {
                if (srcBuffer[i] is not { Expired: false } component) continue;
                
                destBuffer[activeCount] = component;
                activeCount++;
            }
            destBufferSize = activeCount;
        }
        else
        {
            var activeCount = 0;
            for (var i = 0; i < srcBufferSize; i++)
            {
                if (srcBuffer[i] is not { Expired: false } component) continue;
                
                destBuffer[activeCount] = component;
                activeCount++;
            }

            if (destBufferSize > activeCount)
            {
                Array.Clear(destBuffer, activeCount, destBufferSize - activeCount);
            }
            destBufferSize = activeCount;
        }
    }
    
    /// <summary>
    /// 获取新的缓冲容量
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int GetNewCapacity(int oldCapacity, int capacity)
    {

        var newCapacity = oldCapacity == 0 ? DefaultCapacity : 2 * oldCapacity;
        
        if ((uint)newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;
        
        if (newCapacity < capacity) newCapacity = capacity;

        return newCapacity;
    }
    
    /// <summary>
    /// 增长指定缓冲容量
    /// </summary>
    private void Grow(ref Component[] buffer, int count, int capacity)
    {
        var newCapacity = GetNewCapacity(buffer.Length, capacity); 
        Component[] newItems = new Component[newCapacity];
        if (count > 0)
        {
            Array.Copy(buffer, newItems, count);
        }
        buffer = newItems;
    }
    
    private void Add(Component component, ref Component[]? buffer, ref int count)
    {
        if (buffer == null)
        {
            buffer = new Component[DefaultCapacity];
            var index = count;
            count++;
            buffer[index] = component;
        }
        else if(count < buffer.Length)
        {
            var index = count;
            count++;
            buffer[index] = component;
        }
        else
        {
            var index = count;
            Grow(ref buffer, count, count + 1);
            count ++;
            buffer[index] = component;
        }
    }
    
    private void RemoveAt(int index, ref Component[]? buffer, ref int count)
    {
        if (buffer == null) return;
        
        count--;
        if (index < count)
        {
            Array.Copy(buffer, index + 1, buffer, index, count - index);
        }
        buffer[count] = null!;
    }
    
    private void Remove(Component item, ref Component[]? buffer, ref int count)
    {
        if (buffer == null) return;

        var index = FindIndex(buffer, count, item);
        count--;
        if (index < count)
        {
            Array.Copy(buffer, index + 1, buffer, index, count - index);
        }
        buffer[count] = null!;

    }
    
    private int FindIndex(Component[] buffer, int count, Component item) => Array.IndexOf(buffer, item, 0, count);

    /// <summary>
    /// 遍历<see cref="_leftBuffer">左缓冲</see>的元件，遍历过程中增加一层<see cref="_enumeratorLock">锁</see>
    /// </summary>
    public void ForEach(Action<Component> action)
    {
        if (_expired) return;

        if (_enumeratorLock <= 0)
        {
            if (_state != State.Left)
            {
                ReflashLeftBuffer();
                _state = State.Left;
                _leftDirt = false;
            }
            else if (_leftDirt)
            {
                ClearExpiredLeftBuffer();
            }
        }

        if (_leftBuffer == null || _leftBufferSize == 0) return;

        try
        {
            _enumeratorLock++;
            
            for (var i = 0; i < _leftBufferSize; i++)
            {
                var component = _leftBuffer[i];

                if (component.Expired)
                {
                    _leftDirt = true;
                    continue;
                }

                action(component);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _enumeratorLock--;
        }
    }

    public delegate void ForEachDelegate<T>(Component component, in T data);

    /// <summary>
    /// 遍历<see cref="_leftBuffer">左缓冲</see>的元件并执行有额外参数的事件，遍历过程中增加一层<see cref="_enumeratorLock">锁</see>
    /// </summary>
    public void ForEach<T>(in T args, ForEachDelegate<T> action)
    {
        if (_expired) return;
        
        if (_enumeratorLock <= 0)
        {
            if (_state != State.Left)
            {
                ReflashLeftBuffer();
                _state = State.Left;
                _leftDirt = false;
            }
            else if (_leftDirt)
            {
                ClearExpiredLeftBuffer();
            }
        }
        
        if(_leftBuffer == null || _leftBufferSize == 0) return;

        try
        {
            _enumeratorLock++;

            for (var i = 0; i < _leftBufferSize; i++)
            {
                var component = _leftBuffer[i];
            
                if (component.Expired)
                {
                    _leftDirt = true;
                    continue;
                }
            
                action(component, args);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _enumeratorLock--;
        }
    }

    /// <summary>
    /// 移除<see cref="Component">元件</see>
    /// </summary>
    public void ReleaseComponent(Component component)
    {
        if (_expired)
        {
            if(!component.Expired)
                component.Expire();
            return;
        }
        
        if (_state == State.Right)
        {
            Remove(component, ref _rightBuffer, ref _rightBufferSize);
            component.Expire();
            return;
        }
        if (_enumeratorLock <= 0)
        {
            ReflashRightBuffer();
            _state = State.Right;
            
            Remove(component, ref _rightBuffer, ref _rightBufferSize);
            component.Expire();
            return;
        }
        Remove(component, ref _leftBuffer, ref _leftBufferSize);
        component.Expire();
    }

    public void ReleaseComponentAt(int index)
    {
        if (_expired) return;
        
        if (_state == State.Right)
        {
            if (_rightBuffer == null || index < 0 || index >= _rightBufferSize) return;
            
            var component = _rightBuffer[index];
            RemoveAt(index, ref _rightBuffer, ref _rightBufferSize);
            component.Expire();

            return;
        }
        if (_enumeratorLock <= 0)
        {
            ReflashRightBuffer();
            _state = State.Right;

            if (_rightBuffer == null || index < 0 || index >= _rightBufferSize) return;
            
            var component = _rightBuffer[index];
            RemoveAt(index, ref _rightBuffer, ref _rightBufferSize);
            component.Expire();
            return;
        }

        if (_leftBuffer == null || index < 0 || index >= _leftBufferSize) return;
        
        {
            var component = _leftBuffer[index];
            RemoveAt(index, ref _leftBuffer, ref _leftBufferSize);
            component.Expire();
        }
    }

    public void AttachComponent(Component component)
    {
        if (_expired)
        {
            if(!component.Expired)
                component.Expire();
            return;
        }

        if (_state == State.Right)
        {
            Add(component, ref _rightBuffer, ref _rightBufferSize);
            component.Awake();
            return;
        }
        if (_enumeratorLock <= 0)
        {
            ReflashRightBuffer();
            _state = State.Right;
            
            Add(component, ref _rightBuffer, ref _rightBufferSize);
            component.Awake();
            return;
        }
        Add(component, ref _leftBuffer, ref _leftBufferSize);
        component.Awake();
    }

    // public void ReleaseComponentAt(int index)
    // {
    //     if (_expired) return;
    //
    //     if (EnumeratorLock)
    //     {
    //         QueueComponents.Add((this,false, null, new(index)));
    //         _queueComponentCount++;
    //     }
    //     else
    //     {
    //         _children.RemoveAt(index);
    //     }
    // }
    //
    // public void InsertComponent(int index, Component component)
    // {
    //     if (_expired)
    //     {
    //         if(!component.Expired)
    //             component.Expire();
    //         return;
    //     }
    //     if (EnumeratorLock)
    //     {
    //         QueueComponents.Add((this,true, component, new(index)));
    //         _queueComponentCount++;
    //     }
    //     else
    //     {
    //         _children.Insert(index, component);
    //     }
    // }
    //
    // public void ReleaseComponentAt(Func<int> index)
    // {
    //     if (_expired) return;
    //
    //     if (EnumeratorLock)
    //     {
    //         QueueComponents.Add((this, false, null, new(index)));
    //         _queueComponentCount++;
    //     }
    //     else
    //     {
    //         _children.RemoveAt(index());
    //     }
    // }
    //
    // public void InsertComponent(Func<int> index, Component component)
    // {
    //     if (_expired)
    //     {
    //         if(!component.Expired)
    //             component.Expire();
    //         return;
    //     }
    //     if (EnumeratorLock)
    //     {
    //         QueueComponents.Add((this,true, component, new(index)));
    //         _queueComponentCount++;
    //     }
    //     else
    //     {
    //         _children.Insert(index(), component);
    //     }
    // }
    //
    public void Destroy()
    {
        _expired = true;
        if (GetCurrentBuffer() is { } buffer)
        {
            foreach (var component in buffer)
            {
                if (component is { Expired: false })
                    component.Expire();
            }
        }
        
        _leftBuffer = null;
        _rightBuffer = null;
        _leftBufferSize = 0;
        _rightBufferSize = 0;
        
    
    }

    public ReadOnlySpan<Component> GetBuffer()
    {
        if(_expired) return ReadOnlySpan<Component>.Empty;
        
        int length;
        Component[]? buffer;
        
        if (_enumeratorLock <= 0)
        {
            length = _leftBufferSize;
            buffer = _leftBuffer;
        }
        else
        {
            length = _state == State.Right ? _rightBufferSize : _leftBufferSize;
            buffer = _state == State.Right ? _rightBuffer : _leftBuffer;
        }
            
        if(buffer is null || length == 0) return ReadOnlySpan<Component>.Empty;
        return buffer.AsSpan(0, length);
    }

    public int SerializeType => SerializeRegister.GameObjectType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();
}