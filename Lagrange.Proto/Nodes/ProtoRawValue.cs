using System.Runtime.InteropServices;
using Lagrange.Proto.Serialization;

namespace Lagrange.Proto.Nodes;

/// <summary>
/// The Raw value extracted from the proto source without scheme.
/// </summary>
[StructLayout(LayoutKind.Auto)]
internal class ProtoRawValue(WireType wireType, long value)
{
    public readonly WireType WireType = wireType;

    public readonly long Value = value;
    
    public ReadOnlyMemory<byte> Bytes = ReadOnlyMemory<byte>.Empty;
}