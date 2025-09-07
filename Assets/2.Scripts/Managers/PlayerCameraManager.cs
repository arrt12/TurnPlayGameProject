using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : Singleton<PlayerCameraManager>
{
    private bool isIncombatCameraPosition = false;
    [SerializeField] private float cameraSpeed = 5f;
    public float CameraRotationAngle;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private Transform target;
    private PlayerController player;

    public void SetTarget(Transform target) => this.target = target;

    public void SetCombatCameraState(bool isIncombatCameraPosition) => this.isIncombatCameraPosition = isIncombatCameraPosition;

    private void Start()
    {
        Vector3 initialRotation = transform.localEulerAngles;
        xRotation = initialRotation.x;
        yRotation = initialRotation.y;
    }

    private void Update()
    {
        RotationAngleUpdate();

        if (isIncombatCameraPosition)
        {
            MoveToCombatCameraPosition();           // ���콺�� ȸ�� ����
            LerpToTargetPosition_PositionOnly();    // ��ġ�� ����
        }
        else
            LerpToTargetPosition();                 // ���� ��ġ + ȸ�� ����
    }


    private void RotationAngleUpdate()
    {
        CameraRotationAngle = transform.eulerAngles.y;
    }

    private void LerpToTargetPosition()
    {
        if (target == null)
            return;

        transform.SetPositionAndRotation(
            Vector3.Lerp(transform.position, target.position, Time.deltaTime * cameraSpeed),
            Quaternion.Lerp(transform.localRotation, target.localRotation, Time.deltaTime * cameraSpeed)
            );
    }

    private void LerpToTargetPosition_PositionOnly()
    {
        if (target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * cameraSpeed);
    }


    private void MoveToCombatCameraPosition()
    {
        if (target == null || !isIncombatCameraPosition)
            return;

        PlayerInputHandler inputHandler = GameManager.Instance.PlayerInputHandler;

        float mouseX = inputHandler.MouseX;
        float mouseY = inputHandler.MouseY;

        float sensitivity = 2f; // �ʿ信 ���� ����

        xRotation -= mouseY * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX * sensitivity;

        // �� �� ȸ���� �ջ��� ����
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    public bool GetIsIncombatCameraPosition()
    {
        return isIncombatCameraPosition; 
    }
}
