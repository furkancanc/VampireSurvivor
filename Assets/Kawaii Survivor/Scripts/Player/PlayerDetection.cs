using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Candy candy))
        {
            Destroy(candy.gameObject);

        }
    }
}
