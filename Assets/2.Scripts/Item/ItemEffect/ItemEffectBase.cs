public class ItemEffectBase :  IVisitable
{
    public virtual void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
