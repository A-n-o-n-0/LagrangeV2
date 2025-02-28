using Lagrange.Core.Internal.Services;
using Lagrange.Core.Utility.Binary;
using Lagrange.Core.Utility.Cryptography;

namespace Lagrange.Core.Internal.Packets.Struct;

internal class ServicePacker(BotContext context) : StructBase(context)
{
    private static readonly ReadOnlyMemory<byte> EmptyD2Key = new byte[16];
    
    public ReadOnlyMemory<byte> BuildProtocol12(ref BinaryPacket sso, ServiceOptions options)
    {
        var cipher = options.EncryptType switch
        {
            EncryptType.NoEncrypt => sso.CreateReadOnlySpan(),
            EncryptType.EncryptEmpty => TeaProvider.Encrypt(sso.CreateReadOnlySpan(), EmptyD2Key.Span),
            EncryptType.EncryptD2Key => TeaProvider.Encrypt(sso.CreateReadOnlySpan(), Keystore.WLoginSigs.D2Key),
            _ => throw new ArgumentOutOfRangeException(nameof(options.EncryptType), options.EncryptType, null)
        };
        sso.Dispose(); // may allocate on the heap, ensure to return it to the ArrayPool after encryption
        
        var writer = new BinaryPacket(0x200); // TODO: Implement the packet size
        
        writer.EnterLengthBarrier<int>();
        
        writer.Write(12);
        writer.Write((byte)options.EncryptType);
        if (options.EncryptType == EncryptType.EncryptD2Key) writer.Write(Keystore.WLoginSigs.D2, Prefix.Int32 | Prefix.WithPrefix);
        else writer.Write(4);
        writer.Write((byte)0);
        writer.Write(Keystore.Uin.ToString(), Prefix.Int32 | Prefix.WithPrefix);
        writer.Write(cipher, Prefix.Int32 | Prefix.WithPrefix);
        
        writer.ExitLengthBarrier<int>(true);
        
        return writer.ToArray();
    }

    public ReadOnlyMemory<byte> BuildProtocol13(ref SsoPacket sso, ref BinaryPacket payload, ServiceOptions options)
    {
        var cipher = options.EncryptType switch
        {
            EncryptType.NoEncrypt => payload.CreateReadOnlySpan(),
            EncryptType.EncryptEmpty => TeaProvider.Encrypt(payload.CreateReadOnlySpan(), EmptyD2Key.Span),
            EncryptType.EncryptD2Key => TeaProvider.Encrypt(payload.CreateReadOnlySpan(), Keystore.WLoginSigs.D2Key),
            _ => throw new ArgumentOutOfRangeException(nameof(options.EncryptType), options.EncryptType, null)
        }; // the payload would always be allocated on the stack for packetType 13
        
        var writer = new BinaryPacket(0x200);
        
        writer.EnterLengthBarrier<int>();
        
        writer.Write(13);
        writer.Write((byte)options.EncryptType);
        writer.Write(sso.Sequence);
        writer.Write((byte)0);
        writer.Write(Keystore.Uin.ToString(), Prefix.Int32 | Prefix.WithPrefix);
        writer.Write(cipher, Prefix.Int32 | Prefix.WithPrefix);
        
        writer.ExitLengthBarrier<int>(true);
        
        return writer.ToArray();
    }
}

internal enum EncryptType : byte
{
    EncryptD2Key = 0x02,
    EncryptEmpty = 0x01,
    NoEncrypt = 0x00,
}

internal enum RequestType
{
    D2Auth = 0x0C,
    Simple = 0x0D,
}