using AxGrid.Base;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviourExt
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool hasTarget = false;

    [OnAwake]
    private void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        if (!hasTarget)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            return;
        }
        
        Vector3 direction = (targetPosition - transform.position);
        direction.y = 0f; 
        float distance = direction.magnitude;

        if (distance > 0.5f)
        {
            Vector3 moveVelocity = direction.normalized * moveSpeed;
            Vector3 velocity = rb.velocity;
            velocity.x = moveVelocity.x;
            velocity.z = moveVelocity.z;
            rb.velocity = velocity;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            ClearTarget();
        }
    }

    public void CantMove(bool canMove) => rb.isKinematic = canMove;
    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        hasTarget = true;
    }

    public void ClearTarget()
    {
        hasTarget = false;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}