using UnityEngine;

public class HandController : MonoBehaviour
{
    public SceneNode selectedObject;

    private float rotationSpeed = 90f;
    void Start()
    {
        
    }

    void Update()
    {
        float yaw = 0f;
        float pitch = 0f;
        float yAxisRot = 0f;

        if (Input.GetKey(KeyCode.A))
            yaw -= rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            yaw += rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            pitch -= rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            pitch += rotationSpeed * Time.deltaTime;

        //for rotating the hand itself in case the person messes it up bad
        if (selectedObject.name == "hand")
        {
            if (Input.GetKey(KeyCode.Q))
                yAxisRot -= rotationSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.E))
                yAxisRot += rotationSpeed * Time.deltaTime;
        }


        // apply rotation
        selectedObject.transform.Rotate(pitch, yAxisRot, yaw, Space.Self);
    }
}
