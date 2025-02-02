using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] private CircleCollider2D daveCollider;

    //private void FixedUpdate()
    //{
    //    Collider2D[] candyColliders = Physics2D.OverlapCircleAll(
    //        (Vector2)transform.position + daveCollider.offset, 
    //        daveCollider.radius);

    //    foreach (Collider2D collider in candyColliders)
    //    {
    //        if (collider.TryGetComponent(out Candy candy))
    //        {
    //            Destroy(candy);
    //        }
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Candy candy))
        {
            if (!collider.IsTouching(daveCollider))
            {
                return;
            }

            Destroy(candy);
        }
    }
}
