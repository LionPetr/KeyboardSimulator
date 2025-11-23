using UnityEngine;


[ExecuteInEditMode]
public class FingerColliderController : MonoBehaviour
{
    public NodePrimitive tip;

    public Vector3 offset = Vector3.zero;

    void Update()
    {
        Matrix4x4 worldPosition = tip.GetWorldMatrix();

        Vector3 finalPos = worldPosition.MultiplyPoint3x4(offset);

        transform.position = finalPos;
    }
}
