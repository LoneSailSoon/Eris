namespace Eris.Utilities.Data;
#pragma warning disable CS9113 // 参数未读。

[AttributeUsage(AttributeTargets.All)]
public class DescAttribute(string? _ = null) : Attribute;

[AttributeUsage(AttributeTargets.All)]
public class WipAttribute(string? _ = null) : Attribute;

[AttributeUsage(AttributeTargets.All)]
public class UnsyncAttribute(string? _ = null) : Attribute;

[AttributeUsage(AttributeTargets.All)]
public class SyncAttribute(string? _ = null) : Attribute;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class HookAttribute(uint address, uint size) : Attribute;

#pragma warning restore CS9113 // 参数未读。
