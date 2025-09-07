/// 특정 IVisitable 객체를 방문하여 작업을 수행
public interface IVisitor
{
    void Visit<T>(T visitable) where T : IVisitable;
}
 
/// 방문자가 이 객체를 방문할 수 있도록 Accept 메서드를 제공
public interface IVisitable
{
    void Accept(IVisitor visitor);
}