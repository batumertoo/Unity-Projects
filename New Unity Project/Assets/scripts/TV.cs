using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject player;
    private Vector3 offset = new Vector3(20, 10, 50);
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
