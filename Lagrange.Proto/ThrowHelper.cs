using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Lagrange.Proto.Serialization;

namespace Lagrange.Proto;

[StackTraceHidden]
internal static class ThrowHelper
{
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_NeedLargerSpan() => throw new InvalidOperationException("Need larger span");
    
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_InvalidNumberHandling(Type type) => throw new InvalidOperationException($"Invalid number handling for the type {type.Name}");
    
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_FailedDetermineConverter<T>() => throw new InvalidOperationException($"Unable to determine the type of the object to serialize for {typeof(T).Name}");
    
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidDataException_MalformedMessage() => throw new InvalidDataException("Malformed proto message while decoding");

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowObjectDisposedException_ProtoWriter() => throw new ObjectDisposedException("ProtoWriter", "The ProtoWriter has been disposed. Please ensure that the ProtoWriter is not used after it has been disposed.");
    
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowArgumentOutOfRangeException_NoEnoughSpace(string type, int size, int available) => throw new ArgumentOutOfRangeException(type, $"The {type} size is {size}, but only {available} bytes are available.");

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_DuplicateField(Type type, int fieldInfoField) => throw new InvalidOperationException($"The type {type.Name} has duplicate field {fieldInfoField}. Please ensure that the field numbers are unique.");

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_CanNotCreateObject(Type type) => throw new InvalidOperationException($"Cannot create an instance of {type.Name}. Ensure that the type has a parameterless constructor or is a value type.");
    
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_NodeWrongType(params ReadOnlySpan<string> supportedTypeNames)
    {
        Debug.Assert(supportedTypeNames.Length > 0);
        string concatenatedNames = supportedTypeNames.Length == 1 ? supportedTypeNames[0] : string.Join(", ", supportedTypeNames.ToArray());
        throw new InvalidOperationException($"The node is not of the expected type. Supported types are: {concatenatedNames}.");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_NodeCycleDetected() => throw new InvalidOperationException("Node cycle detected");

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_NodeAlreadyHasParent() => throw new InvalidOperationException("Node already has a parent");
    
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException_InvalidWireType(WireType wireType) => throw new InvalidOperationException($"Invalid wire type {wireType} for the node.");
}