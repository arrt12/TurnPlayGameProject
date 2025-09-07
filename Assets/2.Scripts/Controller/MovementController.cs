using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool IsMove = false;
    public bool IsArrivalTriggered = false;
    [SerializeField] private Rigidbody rb;
    [SerializeField] Transform root;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float arrivalDistance;
    [SerializeField] private GameObject runEffect;

    private bool IsArrival;

    private event Action onArrival;
    private Transform target;

    private void Start() => RunEffectSetActive(false);

    public void MoveStart(Transform target)
    {
        SetTarget(target);
        SetIsMove(true);
    }

    public void Arrivalsubscribe(Action action) => onArrival = action;
    public void SetTarget(Transform target) => this.target = target;
    public void SetIsMove(bool isMove) => this.IsMove = isMove;

    public void RunEffectSetActive(bool isSetActive) => runEffect.SetActive(isSetActive);

    private void Update()
    {
        if (!IsMove)
            return;
        CheckArrival();
    }

    private void FixedUpdate()
    {
        if (!IsMove)
            return;
        Move();
        TargetSlerp();
    }

    private void CheckArrival()
    {
        IsArrival = IsAtTarget();
        if (IsArrival && !IsArrivalTriggered)
        {
            onArrival?.Invoke();
            IsArrivalTriggered = true;
        }
    }

    private void Move()
    {
        if (IsArrival)
            return;
        Vector3 current = rb.position;
        Vector3 dir = (target.position - current).normalized;
        Vector3 moveDelta = dir * moveSpeed;
        rb.MovePosition(current + moveDelta);
    }

    private void TargetSlerp()
    {
        if (IsArrival)
            return;
        root.rotation = Quaternion.Slerp(root.transform.rotation, target.rotation, -rotationSpeed * Time.deltaTime);
    }

    private bool IsAtTarget()
    {
        return Vector3.Distance(rb.transform.position, target.transform.position) <= arrivalDistance;
    }
}
