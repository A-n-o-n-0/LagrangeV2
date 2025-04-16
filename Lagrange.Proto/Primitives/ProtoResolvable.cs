using System.Runtime.CompilerServices;
using Lagrange.Proto.Serialization;
using Lagrange.Proto.Serialization.Metadata;

namespace Lagrange.Proto.Primitives;

public static class ProtoResolvableExtension
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EncodeResolvable<T>(this ProtoWriter writer, int field, WireType wireType, T value)
    {
        var converter = ProtoTypeResolver.GetConverter<T>();
        converter.Write(field, wireType, writer, value);
    }
}

public static class ProtoResolvableUtility
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Measure<T>(int field, WireType wireType, T value)
    {
        var converter = ProtoTypeResolver.GetConverter<T>();
        return converter.Measure(field, wireType, value);
    }
}