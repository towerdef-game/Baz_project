using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public static int BulletDamage;
    public int damage = 1;
   // public GameObject bulleteffect;
    [Header("only set if missle")]
    public float explosionrange = 0f;

    public void Start()
    {
        BulletDamage = damage;
    }
    public void aim(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
      //  GameObject blast = (GameObject)Instantiate(bulleteffect, transform.position, transform.rotation);
      //  Destroy(blast, 2f);

        if(explosionrange > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

     //  Damage(target);
       Destroy(gameObject);
       
    }
    void Explode()
    {
      Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionrange);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
      enemy_Ai bear =  enemy.GetComponent<enemy_Ai>();
      
       if(bear != null)
        {
            bear.damagetaken(damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionrange);

    }
}
