using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 15f;       

    [Header("Rotation")]
    public float yawSpeed = 70f;           
    public float pitchSpeed = 50f;         

    void FixedUpdate()
    {
       
        float forwardInput = 0f;
        if (Input.GetKey(KeyCode.W)) forwardInput += 1f;
        if (Input.GetKey(KeyCode.S)) forwardInput -= 1f;
       
            transform.Translate(Vector3.forward * (moveSpeed ) * Time.deltaTime, Space.Self);

        
        float yawInput = 0f;
        if (Input.GetKey(KeyCode.A)) yawInput -= 1f;   
        if (Input.GetKey(KeyCode.D)) yawInput += 1f;   
        if (yawInput != 0f)
            transform.Rotate(Vector3.up * (yawSpeed * yawInput) * Time.deltaTime, Space.Self);

       
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.right * (pitchSpeed) * Time.deltaTime, Space.Self);      
        else if (Input.GetKey(KeyCode.F))
            transform.Rotate(-Vector3.right * (pitchSpeed) * Time.deltaTime, Space.Self);     
    }
}
