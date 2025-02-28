using Lagrange.Core.Internal.Packets.Message;

namespace Lagrange.Core.Message.Entities;

public class TextEntity(string text) : IMessageEntity
{
    public string Text { get; } = text;

    public TextEntity() : this(string.Empty) { }
    
    Task IMessageEntity.Preprocess(BotContext context, BotMessage message) => Task.CompletedTask;

    Task IMessageEntity.Postprocess(BotContext context, BotMessage message) => Task.CompletedTask;
    
    Elem[] IMessageEntity.Build()
    {
        throw new NotImplementedException();
    }
    
    IMessageEntity? IMessageEntity.Parse(Elem[] elements, Elem target)
    {
        throw new NotImplementedException();
    }
}