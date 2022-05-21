using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offSet;
    [SerializeField] private float lerpValue;
    [SerializeField] private GameObject targetObject;
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,targetObject.transform.position - offSet,lerpValue);
    }
}
