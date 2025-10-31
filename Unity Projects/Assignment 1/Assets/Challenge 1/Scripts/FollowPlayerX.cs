using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;

    [Header("Local-space Offsets")]
    public Vector3 sideOffset = new Vector3(6f, 1.5f, 0f);   
    public Vector3 rearOffset = new Vector3(0f, 1.5f, -8f);  

    [Header("Follow Settings")]
    public float followLerp = 8f;
    public float rotateLerp = 12f;

    void LateUpdate()
    {
        if (!plane) return;

        bool rearViewHeld = Input.GetKey(KeyCode.B);
        Vector3 desiredLocalOffset = rearViewHeld ? rearOffset : sideOffset;

        Vector3 targetPos = plane.transform.TransformPoint(desiredLocalOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, followLerp * Time.deltaTime);
        if (!rearViewHeld)
        {
            Vector3 lookDir = (plane.transform.position - transform.position).normalized;
            Quaternion targetRot = Quaternion.LookRotation(lookDir, plane.transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateLerp * Time.deltaTime);
        }
        else
        {
            Quaternion targetRot = Quaternion.LookRotation(plane.transform.forward, plane.transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateLerp * Time.deltaTime);
        }
    }
}
