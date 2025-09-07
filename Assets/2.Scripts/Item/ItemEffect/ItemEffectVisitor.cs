using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemEffectVisitor : IVisitor
{
    private Controller controller;

    public ItemEffectVisitor(Controller controller)
    {
        this.controller = controller;
    }

    public void Visit<T>(T visitable) where T : IVisitable
    {
        if (visitable is Hp) HpEffect();
        if (visitable is Revival) RevivalEffect();
        if (visitable is AddTurn) AddTurnEffect();
    }

    private void HpEffect()
    {
        //Hp ���
        Debug.Log("use HP Item");
    }

    private void RevivalEffect()
    {
        //��Ȱ ������ ���
        Debug.Log("use Revival Item");
    }

    private void AddTurnEffect()
    {
        //�� �߰� ��ų ���
        Debug.Log("use AddTurn Item");
    }
}
