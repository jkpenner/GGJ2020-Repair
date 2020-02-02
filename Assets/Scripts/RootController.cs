using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class RootController : MonoBehaviour
{
    public bool IsInvincible { get; private set; }

    private new Rigidbody2D rigidbody;
    [SerializeField] float speed = 2f;
    [SerializeField] LineRenderer line;
    [SerializeField] float retreatSpeed = 0.5f;
    [SerializeField] float rotationSpeed = 10f;

    private Vector2 lastPosition;

    private GameManager gameManager;
    private ResourceManager resourceManager;
    private RootManager rootManager;
    private RootVisual currentRoot;
    private int currentIndex;

    [SerializeField] float invicibleDuration = 0.5f;
    [SerializeField] float gravityScale;
    private Coroutine invicibleCoroutine;

    private Vector2 targetDirection = Vector2.down;
    private float targetRotation;

    private PlayerInput input;
    private Vector2 movementInput;

    [SerializeField] GameObject impact;
    [SerializeField] GameObject visual;

    private void Awake()
    {
        rootManager = FindObjectOfType<RootManager>();
        resourceManager = FindObjectOfType<ResourceManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        this.IsInvincible = false;

        gameManager = GameManager.GetInstance();
        gameManager.SetState(GameState.Active);

        Vector2 start = new Vector2(0, 0);
        Vector2 target = Vector2.right;

        targetRotation = rigidbody.rotation;

        if (currentRoot == null)
        {
            currentRoot = rootManager.GetCurrent();
            if (currentRoot == null)
            {
                rootManager.CreateNewVisual(transform.position);
                currentRoot = rootManager.GetCurrent();
                // Create a second point that will be move to the player's location
                currentRoot.AddPoint(transform.position);
                currentIndex = currentRoot.GetPointCount();
                lastPosition = transform.position;
            }
        }

        input = new PlayerInput();
        input.SeedControls.Movement.performed += (ctx) => movementInput = ctx.ReadValue<Vector2>();

        input.SeedControls.Kill.performed += (ctx) =>
        {
            if (gameManager.ActiveState == GameState.Active)
                gameManager.SetState(GameState.Dead);
        };

        input.SeedControls.Select.performed += (ctx) =>
        {
            if (gameManager.ActiveState == GameState.Retreat)
            {
                if (resourceManager.IsWaterDrained == false)
                {
                    gameManager.SetState(GameState.Aim);
                }
            }
            else if (gameManager.ActiveState == GameState.Aim)
                ExitRetreat();
        };

        input.SeedControls.Cancel.performed += (ctx) =>
        {
            if (gameManager.ActiveState == GameState.Aim)
                gameManager.SetState(GameState.Retreat);
        };
    }

    private void OnEnable()
    {
        input.Enable();
        resourceManager.OnWaterDrained += OnWaterDrained;
    }

    private void OnDisable()
    {
        resourceManager.OnWaterDrained -= OnWaterDrained;
        input.Disable();
    }

    private void OnWaterDrained()
    {
        if (gameManager.ActiveState != GameState.Retreat && gameManager.ActiveState != GameState.Aim)
            SpawnImpact();
    }

    private void Update()
    {
        visual.SetActive(gameManager.ActiveState == GameState.Active || gameManager.ActiveState == GameState.Aim);

        if (gameManager.ActiveState == GameState.Exit || gameManager.ActiveState == GameState.Intro)
            return;

        if (resourceManager.IsWaterDrained)
        {
            gameManager.SetState(GameState.Retreat);
        }

        switch (gameManager.ActiveState)
        {
            case GameState.Active:
                OnActiveUpdate();
                break;
            case GameState.Dead:
                OnDeadUpdate();
                break;
            case GameState.Retreat:
            case GameState.WinRetreat:
                OnRetreatUpdate();
                break;
            case GameState.Aim:
                OnAimUpdate();
                break;
            default:
                gameManager.SetState(GameState.Dead);
                break;
        }
    }

    private void OnActiveUpdate()
    {
        rigidbody.gravityScale = gravityScale;
        rigidbody.velocity = -transform.up * speed;


        Vector2 direction = movementInput.normalized;

        if (direction.sqrMagnitude > 0.4)
        {
            targetDirection = direction;
        }


        var target = Quaternion.LookRotation(targetDirection, Vector3.forward);
        var current = Quaternion.Euler(0f, 0f, rigidbody.rotation);
        var amount = rotationSpeed * Time.deltaTime / Quaternion.Angle(target, current);
        rigidbody.SetRotation(Quaternion.Slerp(current, target, amount).eulerAngles.z);

        //rigidbody.SetRotation(rigidbody.rotation + input * 90f * Time.deltaTime);


        currentRoot.UpdateLastPosition(transform.position);

        if (Vector2.Distance(lastPosition, transform.position) > 0.5f)
        {
            currentRoot.AddPoint(transform.position);
            currentIndex = currentRoot.GetPointCount();
            lastPosition = transform.position;
        }


        if (IsInvincible == false && this.rootManager.CheckForCollision(transform.position, 0.5f))
        {
            gameManager.SetState(GameState.Dead);
            rigidbody.velocity = Vector2.zero;
            SpawnImpact();
        }
    }

    private void OnDeadUpdate()
    {
        gameManager.SetState(GameState.Retreat);
    }

    private void OnRetreatUpdate()
    {
        rigidbody.gravityScale = 0;
        float distLeft = currentRoot.GetDistanceToStart(currentIndex);
        float modifier = 1f;
        if (gameManager.ActiveState == GameState.WinRetreat)
            modifier = Mathf.Lerp(1f, 4f, Mathf.Clamp01(distLeft / 60f));

        float moveDistance = modifier * retreatSpeed * Time.deltaTime;
        while (moveDistance >= 0.001f)
        {
            (RootVisual root, int index) = currentRoot.GetPreviousPoint(currentIndex);
            if (root != null)
            {
                Vector2 target = root.GetPosition(index);
                Vector2 newPosition = Vector2.MoveTowards(transform.position, target, moveDistance);

                float distTraveled = Vector2.Distance(newPosition, transform.position);

                if (newPosition == target || distTraveled == 0)
                {
                    currentIndex = index;
                    currentRoot = root;
                }
                transform.position = newPosition;

                moveDistance -= distTraveled;
            }
            else
            {
                gameManager.SetState(GameState.Exit);
                return;
            }
        }
    }

    private void ExitRetreat()
    {
        gameManager.SetState(GameState.Active);
        rootManager.CreateNewVisual(currentRoot, currentIndex, transform.position);
        currentRoot = rootManager.GetCurrent();
        currentRoot.AddPoint(transform.position);
        currentRoot.AddPoint(transform.position);
        SpawnImpact();

        TriggerInvincible();
    }

    private void OnAimUpdate()
    {
        Vector2 position = currentRoot.GetPosition(currentIndex);
        Vector2 toPlayer = (Vector2)transform.position - position;

        Vector2 perp = Vector2.Perpendicular(toPlayer);
        Debug.DrawRay(transform.position, perp * 10f, Color.red);
        Vector2 direction = movementInput.normalized;

        if (direction.magnitude > 0.4f)
        {
            if (Vector2.Dot(perp, direction) > 0f)
                targetDirection = perp;
            else
                targetDirection = -perp;
        }
        //Debug.DrawRay(transform.position, targetDirection * 4f, Color.yellow);


        rigidbody.MovePosition(transform.position);
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;

        //Debug.Log(Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg + 90f);

        rigidbody.SetRotation(Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg + 90f);
        //rigidbody.SetRotation(Quaternion.LookRotation(targetDirection, Vector3.forward).eulerAngles.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        SpawnImpact();
        if (other.gameObject.tag == "Water")
        {
            resourceManager.HitWaterResource();
            gameManager.SetState(GameState.Retreat);
        }
        else if (other.gameObject.tag == "VictoryWater")
        {
            Debug.Log("Victory");
            gameManager.SetState(GameState.WinRetreat);
        }
        else
        {
            gameManager.SetState(GameState.Dead);
        }
    }

    private void TriggerInvincible()
    {
        if (invicibleCoroutine != null)
            StopCoroutine(invicibleCoroutine);

        invicibleCoroutine = StartCoroutine(StartInvincible());
    }

    private IEnumerator StartInvincible()
    {
        this.IsInvincible = true;
        yield return new WaitForSeconds(invicibleDuration);
        this.IsInvincible = false;
    }

    private void SpawnImpact()
    {
        var impact = Instantiate(this.impact);
        impact.transform.position = transform.position;
        impact.transform.rotation = transform.rotation;
    }
}
