using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float directionSpeed;


    private float horizontalInput, verticalInput;

    private float direction;
    private float upDownMovement;
    private float turnMovement;
    private bool corotineisDone = true;
    void Update()
    {
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        if (corotineisDone == true)
        {
         horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direction += horizontalInput * directionSpeed * Time.deltaTime;
        upDownMovement = Mathf.Lerp(0,30,Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        turnMovement = Mathf.Lerp(0, 25, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);
            transform.localRotation = Quaternion.Euler(Vector3.up * direction + Vector3.right * upDownMovement + Vector3.forward * turnMovement);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(horizontalInput >= 0)
            {
                StartCoroutine(RotateObj(1f,-1));
            }
            else
            {
                StartCoroutine(RotateObj(1f, 1));
            }
        }

        IEnumerator RotateObj(float duration,int direction)
        {
            corotineisDone = false;
            Quaternion startRot = transform.rotation;
            Debug.Log(startRot);
            float t = 0.0f;
            while (t <= duration)
            {
                t += Time.deltaTime;
                transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f * direction, Vector3.forward); //or transform.right if you want it to be locally based
                yield return null;
            }
           corotineisDone = true;
            // transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }
}
