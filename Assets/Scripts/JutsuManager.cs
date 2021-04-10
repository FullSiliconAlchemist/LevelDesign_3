using UnityEngine;
using UnityEngine.UI;

public class JutsuManager : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 20f;

    public GameObject hitMarker;
    public GameObject fireball;
    public GameObject fireballInst;

    public TimeManager focusMode;
    public Text jutsuUI;

    public string jutsuCode = "";

    // Update is called once per frame
    void Update()
    {
        if (focusMode.bulletTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FindObjectOfType<AudioManager>().PlaySound("FireballJutsu");

                jutsuCode += "1";
                jutsuUI.text = "Jutsu: 1";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FindObjectOfType<AudioManager>().PlaySound("FireballJutsu");

                jutsuCode += "2";
                jutsuUI.text += "2";
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                FindObjectOfType<AudioManager>().PlaySound("FireballJutsu");

                jutsuCode += "3";
                jutsuUI.text += "3";
            }
        }
        else if (jutsuCode != "123")
        {
            jutsuCode = "";
            jutsuUI.text = "Jutsu:";
        }
        else if (jutsuCode == "123")
        {
            Shoot();
            jutsuCode = "";
            jutsuUI.text = "Jutsu:";
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            TargetDummy target = hit.transform.GetComponent<TargetDummy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impact = Instantiate(hitMarker, hit.transform.position, Quaternion.LookRotation(-hit.normal));

            Destroy(impact, 0.6f);
        }

        GameObject effect = Instantiate(fireball, fireballInst.transform.position, Quaternion.LookRotation(-hit.normal));

        Rigidbody fireballBody = effect.GetComponent<Rigidbody>();
        fireballBody.AddForce(transform.forward * impactForce, ForceMode.VelocityChange);
        Destroy(effect, 1f);
    }
}
