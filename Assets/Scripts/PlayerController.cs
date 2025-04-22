using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isMoving = false;
    [SerializeField] private LayerMask blockLayer;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gridMoveDistance = 2f;

    void Update()
    {
        if(isMoving) return;
        var movementVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movementVector = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementVector = Vector3.back;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementVector = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementVector = Vector3.right;
        }
        
        if(movementVector != Vector3.zero)
        {
            TryToMove(movementVector);
        }
    }

    private void TryToMove(Vector3 direction)
    {
        Vector3 normalizedDirection = direction.normalized;
        Vector3 scaledDirection = normalizedDirection * gridMoveDistance;
        Vector3 targetPosition = transform.position + scaledDirection;

        if(!Physics.Raycast(transform.position, direction, out RaycastHit hit, gridMoveDistance + 0.1f, blockLayer))
        {
            StartCoroutine(MoveToTarget(targetPosition));
        }
        else if(hit.collider.CompareTag("Box"))
        {
            var box = hit.collider.GetComponent<BoxController>();
            if(box != null && box.TryToPushBox(direction, moveSpeed))
            {
                StartCoroutine(MoveToTarget(targetPosition));
            }
        }
    }
    
    private IEnumerator MoveToTarget(Vector3 target)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
            yield return null;
        }
        transform.position = target;
        
        isMoving = false;
    }
}
