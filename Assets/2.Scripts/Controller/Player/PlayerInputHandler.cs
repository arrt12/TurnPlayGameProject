using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public bool IsInAttackMode { get; private set; }
    public bool IsAttackPressed { get; private set; }

    public float MouseX { get; private set; }
    public float MouseY { get; private set; }

    [SerializeField] private float mouseSensitivity = 100f;

    private void Update()
    {
        IsInAttackMode = Input.GetKeyDown(KeyCode.D);
        IsAttackPressed = Input.GetKeyDown(KeyCode.Mouse0);

        MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
}
