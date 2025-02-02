using UnityEngine;
using UnityEngine.Pool;
public class RangeWeapon : Weapon
{
    [Header("Settings")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;

    [Header("Pooling")]
    private ObjectPool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(CreateFunction, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    private void Update()
    {
        AutoAim();
    }

    private Bullet CreateFunction()
    {
        Bullet bulletInstance = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        bulletInstance.Configure(this);

        return bulletInstance;
    }

    private void ActionOnGet(Bullet bullet)
    {
        bullet.Reload();
        bullet.transform.position = shootingPoint.position;
        bullet.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    public void ReleaseBullet(Bullet bulllet)
    {
        bulletPool.Release(bulllet);
    }

    private void AutoAim()
    {
        Enemy closestEnemy = GetClosestEnemy();
        Vector2 targetUpVector = Vector3.up;

        if (closestEnemy != null)
        {
            targetUpVector = (closestEnemy.transform.position - transform.position).normalized;
            transform.up = targetUpVector;

            
            ManageShooting();
            return;
        }

        transform.up = Vector3.Lerp(transform.up, targetUpVector, Time.deltaTime * aimLerp);
    }

    private void ManageShooting()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDelay)
        {
            attackTimer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        int damage = GetDamage(out bool isCriticalHit);

        Bullet bulletInstance = bulletPool.Get();
        bulletInstance.Shoot(damage, transform.up);
    }
}
