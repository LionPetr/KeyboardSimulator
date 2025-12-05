using UnityEngine;

public class FingerCameraController : MonoBehaviour
{
    public FingerColliderController selectedFingerCollider;

    Quaternion flipY = Quaternion.Euler(0f, 180f, 0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = selectedFingerCollider.transform.position;
        transform.rotation = selectedFingerCollider.tip.GetWorldMatrix().rotation * flipY;
    }
}
