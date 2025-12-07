using UnityEngine;

public class HandController : MonoBehaviour
{
    public SceneNode selectedObject;

    private float rotationSpeed = 90f;
    private float movementSpeed = 2f;

    Vector3 armMovement = Vector3.zero;
    
    void Start()
    {
        
    }

    void Update()
    {
        float yaw = 0f;
        float pitch = 0f;
        float yAxisRot = 0f;
        armMovement = Vector3.zero;

        if (!selectedObject.CompareTag("Arm"))
        {
            if (Input.GetKey(KeyCode.A))
                yaw -= rotationSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
                yaw += rotationSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
                pitch -= rotationSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.S))
                pitch += rotationSpeed * Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
                armMovement.x += movementSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
                armMovement.x -= movementSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
                armMovement.z -= movementSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.S))
                armMovement.z += movementSpeed * Time.deltaTime;

            selectedObject.transform.position += armMovement;
            
            Vector3 pos = selectedObject.transform.position;
            pos.x = Mathf.Clamp(pos.x, -3.0f, 3.0f);
            pos.z = Mathf.Clamp(pos.z, -1.0f, 1.0f);
            selectedObject.transform.position = pos;
        }


        //for rotating the hand itself in case the person messes it up bad
        if (selectedObject.name == "Hand")
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
