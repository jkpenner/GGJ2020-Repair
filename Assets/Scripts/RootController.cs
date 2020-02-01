using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RootController : MonoBehaviour
{
    public enum State { Active, Dead, Retreat }
    public State ActiveState { get; private set; }
    public bool IsInvincible { get; private set; }

    private new Rigidbody2D rigidbody;
    [SerializeField] float speed = 2f;
    [SerializeField] LineRenderer line;
    [SerializeField] float retreatSpeed = 0.5f;
    [SerializeField] float rotationSpeed = 10f;

    private Vector2 lastPosition;

    private RootManager rootManager;
    private RootVisual currentRoot;
    private int currentIndex;

    [SerializeField] float invicibleDuration = 0.5f;
    private Coroutine invicibleCoroutine;

    private float targetRotation;

    private void Awake()
    {
        rootManager = FindObjectOfType<RootManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        ActiveState = State.Active;
        this.IsInvincible = false;

        Vector2 start = new Vector2(0, 0);
        Vector2 target = Vector2.right;

        targetRotation = rigidbody.rotation;
    }

    private void Update()
    {
        switch (ActiveState)
        {
            case State.Active:
                OnActiveUpdate();
                break;
            case State.Dead:
                OnDeadUpdate();
                break;
            case State.Retreat:
                OnRetreatUpdate();
                break;
            default:
                ActiveState = State.Dead;
                break;
        }
    }

    private void OnActiveUpdate()
    {
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

        rigidbody.velocity = -transform.up * speed;


        Vector2 direction = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        ).normalized;

        var target = Quaternion.LookRotation(direction, Vector3.forward);
        var current = Quaternion.Euler(0f, 0f, rigidbody.rotation);
        rigidbody.SetRotation(Quaternion.Slerp(current, target, rotationSpeed * Time.deltaTime).eulerAngles.z);

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
            ActiveState = State.Dead;
            rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnDeadUpdate()
    {
        ActiveState = State.Retreat;
    }

    private void OnRetreatUpdate()
    {
        (RootVisual root, int index) = currentRoot.GetPreviousPoint(currentIndex);
        if (root != null)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, root.GetPosition(index), retreatSpeed * Time.deltaTime);
            if (newPosition == root.GetPosition(index))
            {
                currentIndex = index;
                currentRoot = root;
            }
            rigidbody.MovePosition(newPosition);
        }
        else
        {
            ExitRetreat();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitRetreat();
        }
    }

    private void ExitRetreat()
    {
        ActiveState = State.Active;
        rootManager.CreateNewVisual(currentRoot, currentIndex, transform.position);
        currentRoot = rootManager.GetCurrent();
        currentRoot.AddPoint(transform.position);
        currentRoot.AddPoint(transform.position);

        TriggerInvincible();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ActiveState = State.Dead;
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
}
