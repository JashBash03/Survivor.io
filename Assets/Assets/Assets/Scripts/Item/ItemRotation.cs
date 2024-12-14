using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    [SerializeField] float itemSpeed;

    void Update()
    {
        transform.Rotate(0f, 0f, itemSpeed);
    }
}