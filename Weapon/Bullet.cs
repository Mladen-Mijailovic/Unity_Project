using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float destroyDelay;
    private void OnCollisionEnter(Collision objectHit)
    {
        if (objectHit.gameObject.CompareTag("Enemy")) 
        {
            print("hit " + objectHit.gameObject.name);
            CreateBulletImpactEffect(objectHit);
            Destroy(gameObject);
        }
        if (objectHit.gameObject.CompareTag("Wall"))
        {
            print("hit a wall");
            CreateBulletImpactEffect(objectHit);
            Destroy(gameObject);
        }
    }

    void CreateBulletImpactEffect(Collision objectHit)
    {
        ContactPoint contact = objectHit.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );

        //Dodavanje fade eff
        hole.AddComponent<FadeOutEffect>().fadeDuration = destroyDelay;

        hole.transform.SetParent(objectHit.gameObject.transform);
        hole.transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        
        Destroy(hole, destroyDelay); //Osiguravanje da se unisti objekat nakon efekta
    }
}
