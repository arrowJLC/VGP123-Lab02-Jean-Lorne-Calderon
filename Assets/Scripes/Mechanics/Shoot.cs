using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;

    public Vector2 initialShotVelocity = Vector2.zero;
    //public Vector2 initialShotVelocity2 = Vector2.zero;


    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public Projectile  ProjectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (initialShotVelocity == Vector2.zero)
        {
            initialShotVelocity.x = 10.0f;
        }
        //if (initialShotVelocity2 == Vector2.zero)
        //{
        //    initialShotVelocity2.x = 10.0f;
        //}

        if (!spawnPointRight || !spawnPointLeft || !ProjectilePrefab)
            Debug.Log($"for {gameObject.name}");
    }

   public void Fire()
    {
        if (sr.flipX)
        {
            Projectile curProjectile = Instantiate(ProjectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.SetVelocity(-initialShotVelocity);
        }
        else
        {
            Projectile curProjectile = Instantiate(ProjectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.SetVelocity(initialShotVelocity);
        }

   }
}
