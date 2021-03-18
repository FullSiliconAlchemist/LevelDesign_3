using UnityEngine;

public class JutsuManager : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 20f;

    public GameObject hitMarker;
    public GameObject fireball;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            TargetDummy target = hit.transform.GetComponent<TargetDummy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject effect = Instantiate(fireball, transform.position + (transform.forward * 2), Quaternion.LookRotation(-hit.normal));
            GameObject impact = Instantiate(hitMarker, hit.transform.position, Quaternion.LookRotation(-hit.normal));

            Rigidbody fireballBody = effect.GetComponent<Rigidbody>();
            fireballBody.AddForce(transform.forward * impactForce);
            Destroy(impact, 0.6f);
            Destroy(effect, 1f);
        }
    }
}
