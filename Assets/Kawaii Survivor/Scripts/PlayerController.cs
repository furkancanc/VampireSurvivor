using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private MobileJoystick playerJoystick;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = Vector2.right;
    }

    private void FixedUpdate()
    {
        rig.linearVelocity = playerJoystick.GetMoveVector() * moveSpeed * Time.deltaTime;
    }
}
