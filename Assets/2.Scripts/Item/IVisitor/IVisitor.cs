/// Ư�� IVisitable ��ü�� �湮�Ͽ� �۾��� ����
public interface IVisitor
{
    void Visit<T>(T visitable) where T : IVisitable;
}
 
/// �湮�ڰ� �� ��ü�� �湮�� �� �ֵ��� Accept �޼��带 ����
public interface IVisitable
{
    void Accept(IVisitor visitor);
}