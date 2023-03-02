using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField]
    private float _destroyTime;

    void Start()
    {
        Invoke(nameof(Destroy), _destroyTime);
    }

    private void Destroy() => Destroy(gameObject);
}
