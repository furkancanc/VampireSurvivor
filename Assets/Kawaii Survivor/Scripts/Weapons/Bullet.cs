using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [Header("Elements")]
    private Rigidbody2D rig;
    private Collider2D collider;
    private RangeWeapon rangeWeapon;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask enemyMask;
    private int damage;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        //LeanTween.delayedCall(gameObject, 5, () => rangeEnemyAttack.ReleaseBullet(this));
        //StartCoroutine(ReleaseCoroutine());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Configure(RangeWeapon rangeWeapon)
    {
        this.rangeWeapon = rangeWeapon;
    }

    public void Shoot(int damage, Vector2 direction)
    {
        Invoke("Release", 1);

        this.damage = damage;

        transform.right = direction;
        rig.linearVelocity = direction * moveSpeed;
    }

    public void Reload()
    {
        rig.linearVelocity = Vector2.zero;
        collider.enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsInLayerMask(collider.gameObject.layer, enemyMask))
        {
            CancelInvoke();

            Attack(collider.GetComponent<Enemy>());
            Release();
        }
    }

    private void Release()
    {
        if (!gameObject.activeSelf) 
            return;
        rangeWeapon.ReleaseBullet(this);
    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }

    private bool IsInLayerMask(int layer, LayerMask layerMask)
    {
        return (layerMask.value & (1 << layer)) != 0;
    }

  
}
