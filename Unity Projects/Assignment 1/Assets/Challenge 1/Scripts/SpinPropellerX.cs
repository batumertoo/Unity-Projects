using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float spinSpeed = 1000f; 

    void Update()
    {
      
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
