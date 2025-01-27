using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position;
        targetPosition.z = -10;

        transform.position = targetPosition;
    }
}
