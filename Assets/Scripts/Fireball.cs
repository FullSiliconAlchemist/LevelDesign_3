using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Vector3 minScale;
    MeshRenderer mesh;
    ParticleSystem particles;
    public LayerMask groundLayer;
    public Vector3 maxScale;
    public bool repeatable;
    public float speed = 2f;
    public float duration = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);

        if (collision.gameObject.layer == 6)
        {
            collision.rigidbody.useGravity = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            SphereCollider sc = GetComponent<SphereCollider>();
            particles = GetComponentInChildren<ParticleSystem>();
            rb.isKinematic = true;
            sc.enabled = false;
            StartCoroutine(StartExplosion());
        }
    }

    IEnumerator StartExplosion()
    {
        mesh = GetComponent<MeshRenderer>();
        minScale = mesh.transform.localScale;
        //while (repeatable)
        //{
        yield return RepeatLerp(minScale, maxScale, duration);
        yield return RepeatLerp(maxScale, minScale, duration * 2);
        //}
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            Vector3 lerp = Vector3.Lerp(a, b, i);
            mesh.transform.localScale = lerp;
            particles.startSize = lerp.magnitude;
            yield return null;
        }
    }
}
