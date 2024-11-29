using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed = 0.5f;
    public ParticleSystem onCollectEffect;
    public ParticleSystem onCollectLastEffect;

    Type collectibleType;

    void Update()
    {
        collectibleType = Type.GetType("Collectible");
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool isLast = UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length == 1;
            Destroy(gameObject);
            if (!isLast)
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(onCollectLastEffect, transform.position, transform.rotation);
            }
        }
    }
}
