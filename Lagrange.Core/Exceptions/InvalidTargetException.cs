using Lagrange.Core.Common.Entity;

namespace Lagrange.Core.Exceptions;

/// <summary>
/// When specified target <see cref="BotContact"/> is not found or invalid, this exception will be thrown.
/// </summary>
public class InvalidTargetException : LagrangeException
{
    public long? TargetUin { get; }
    
    public long? GroupUin { get; }
    
    public InvalidTargetException(long targetUin) : 
        base($"Target {targetUin} is invalid or not found.")
    {
        TargetUin = targetUin;
    }
    
    public InvalidTargetException(long? targetUin, long groupUin) : 
        base($"Target {targetUin} is invalid in group {groupUin} or not found.")
    {
        TargetUin = targetUin;
        GroupUin = groupUin;
    }
}