using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePrimitive : MonoBehaviour
{
    public Color MyColor = new Color(0.1f, 0.1f, 0.2f, 1.0f);
    public Vector3 Pivot;

    private Matrix4x4 worldMatrix = Matrix4x4.identity;

    public Texture texture;

    // Use this for initialization @
    void Start()
    {
    }

    void Update()
    {
    }


    public void LoadShaderMatrix(Matrix4x4 nodeMatrix)
    {
        Matrix4x4 p = Matrix4x4.TRS(Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 invp = Matrix4x4.TRS(-Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 trs = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);
        Matrix4x4 m = nodeMatrix * p * trs * invp;
        worldMatrix = m;
        GetComponent<Renderer>().sharedMaterial.SetMatrix("MyXformMat", m);
    }

    public Matrix4x4 GetWorldMatrix()
    {
        return worldMatrix;
    }
}
