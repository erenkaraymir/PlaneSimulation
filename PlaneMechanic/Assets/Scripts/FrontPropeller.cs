using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontPropeller : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.right * rotateSpeed);       
    }
}
