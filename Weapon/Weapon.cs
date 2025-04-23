using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [Header("Shooting stats")]
    public bool isShooting, readyToShoot;
    bool allowsReset = true;
    public float shootingDelay = 2f;

    //Burst
    public int bulletPerBurst = 3;
    public int burstBulletsLeft;

    //Spread
    public float spreadIntesinty;

    [Header("Bullet stats")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;


    public enum ShootingMode 
    {
        Single,
        Burst,
        Auto
    }

    public ShootingMode currentShootingMode;

    private void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletPerBurst;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentShootingMode == ShootingMode.Auto)
        {
            //holding lmouse btn
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else if (currentShootingMode == ShootingMode.Single || currentShootingMode == ShootingMode.Burst) 
        { 
            //click lmouse btn
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if(readyToShoot && isShooting)
        {
            burstBulletsLeft = bulletPerBurst;
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        readyToShoot = false;

        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;

        //instancira objekat
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        bullet.transform.forward = shootingDirection;

        //ispaljuje metak
        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);


        //del bullet
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

        //proverava da li je zavrseno pusanje
        if (allowsReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowsReset = false;
        }

        //Burst mode
        if (currentShootingMode == ShootingMode.Burst && burstBulletsLeft > 1) 
        {
            burstBulletsLeft--;
            Invoke("FireWeapon", shootingDelay);
        }


    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowsReset = true;
    }
    public Vector3 CalculateDirectionAndSpread()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            //ako pogodi nesto
            targetPoint = hit.point;
        }
        else 
        { 
            //shooting at the air
            targetPoint = ray.GetPoint(100);
        }

        Vector3 directio = targetPoint - bulletSpawn.position;

        float x = UnityEngine.Random.Range(-spreadIntesinty, spreadIntesinty);
        float y = UnityEngine.Random.Range(-spreadIntesinty, spreadIntesinty);

        return directio + new Vector3(x, y, 0);
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float bulletPrefabLifeTime)
    {
        yield return new WaitForSeconds(bulletPrefabLifeTime);
        Destroy(bullet);
    }
}
