using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _explosionRadius;

    [SerializeField]
    private GameObject _explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        var collidersHit = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach (var collider in collidersHit)
        {
            if (collider.CompareTag("Destroyable"))
            {
                Destroy(collider.gameObject);
            }
        }

        Destroy(gameObject);
    }
}
