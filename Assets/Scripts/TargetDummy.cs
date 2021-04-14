using System.Collections;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    public float health = 10f;
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            StartCoroutine(Ded());
        }
    }

    private IEnumerator Ded()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
