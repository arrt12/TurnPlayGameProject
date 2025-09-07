using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    protected IJobUnit job; // 하나의 참조로 모든 기능 처리

    [SerializeField] protected JobType jobType;
    public JobConfig JobConfig;
    public string RaycastHitTagName = "Monster";

    [SerializeField] private bool isInActionMode = false;
    [SerializeField] private Transform PlayerRotationRoot;
    public RaycastHit Hit;
    
    [SerializeField] private PlayerInputHandler inputHandler;
    public Transform RTCActionCameraPosition;
    public Transform ActionCameraPosition;
    public Transform MagicCircleSpawnPos;

    private void Update()
    {
        PlayerInput();
        IsUnitInBasicActionMode();
    }

    protected override void Awake()
    {
        base.Awake();
        SetJobByType();
        job.SetPlayerController(this);
        RaycastHitTagName = JobConfig.UniversalRayCastTagName;
    }

    private void SetJobByType()
    {
        IJobUnit newJob = jobType switch
        {
            JobType.Gunman => new Gunman((GunmanConfig)JobConfig),
            JobType.Warrior => new Warrior((WarriorConfig)JobConfig),
            JobType.Healer => new Healer((HealerConfig)JobConfig),
            _ => throw new System.ArgumentOutOfRangeException(nameof(jobType), $"Invalid JobType: {jobType}")
        };

        SetJob(newJob);
    }


    public void SetJob(IJobUnit newJob)
    {
        job = newJob;
    }


    private void PlayerInput()
    {
        if (!isTurn) return;
            PlayerAttackInput();
    }
    
    private void IsUnitInBasicActionMode()//조건 바꿔야 할듯
    {
        if (!isInActionMode && ActionSelectionManager.Instance.CurrentAction != ActionSelect.ExecuteRTCombatAction) return;
            PlayerRotationRootUpdate();
    }

    private void PlayerAttackInput()//Input
    {
        if (inputHandler.IsAttackPressed && isInActionMode)
            CheckClickObject();
    }

    public override void StartTurn()
    {
        base.StartTurn();
        SetupTurnState();
        SetupUI();
        UnlockCursor();
    }

    public override void EndTurn()
    {
        base.EndTurn();
        job.EndTurn();
        PlayerCameraManager.Instance.SetCombatCameraState(false);
    }

    public void InActionMode()
    {
        GameManager.Instance.SetActionSelection(false);
        job.StartTurn();
    }

    private void CheckClickObject()
    {
        if (IsRaycastHitUnit(RaycastManager.Instance.GetRayByType()))
        {
            job.Act();
            //print(Hit.collider.gameObject.name);
        }
        else
            OnNoObjectClicked();
    }

    private void OnNoObjectClicked() => Debug.Log("NoClickObject");

    private void PlayerRotationRootUpdate()
    {
        Vector3 playerEulerAngles = new Vector3(transform.eulerAngles.x, PlayerCameraManager.Instance.CameraRotationAngle, transform.eulerAngles.z);
        PlayerRotationRoot.eulerAngles=  playerEulerAngles;
    }

    public override void Action()
    {
        SetActionMode(false);
        base.Action();
    }

    private void SetupTurnState()
    {
        ActionSelectionManager.Instance.SetPlayer(this);
        GameManager.Instance.SetActionSelection(true);
    }

    private void SetupUI()
    {
        PlayerHUDManager.Instance.ToggleMousePoint(false);
    }

    private void UnlockCursor()
    {
        ToggleCursorLock(CursorLockMode.None, true);
    }

    public void ToggleCursorLock(CursorLockMode lockMode, bool visible)
    {
        Cursor.lockState = lockMode;
        Cursor.visible = visible;
    }

    public void SetActionMode(bool isInActionMode)
    {
        this.isInActionMode = isInActionMode;
    }

    private bool IsRaycastHitUnit(Ray ray)
    {
        return Physics.Raycast(ray, out Hit) && Hit.collider.gameObject.CompareTag(RaycastHitTagName);
    }

    //private bool IsSameCombatPosition()
    //{
    //    Controller target = Hit.collider.GetComponent<Controller>();
    //    return CombatPosition == target.CombatPosition;
    //}

    public void PlayerSpawnBullet()
    {
        AttackEffectObject.GetComponent<HomingBullet>().Target = Hit.transform;
        SpawnGameEffect(AttackBoomEffectObject, AttackEffectObjectPos.position, Quaternion.identity);
        SpawnGameEffect(AttackEffectObject, AttackEffectObjectPos.position, Quaternion.identity);
    }
}
