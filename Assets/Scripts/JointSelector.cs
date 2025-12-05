using System.Collections.Generic;
using UnityEngine;

public class JointSelector : MonoBehaviour
{
    public SceneNode[] sceneNodes;
    public FingerColliderController[] fingerColliders;

    public HandController controller;
    public FingerCameraController fingerCameraController;

    Dictionary<KeyCode, (int fingerColliderIndex, int joinIndex)> keyMap;

    private int selectedIndex;
    void Start()
    {
        keyMap = new Dictionary<KeyCode, (int fingerColliderIndex, int joinIndex)>()
        {
            {KeyCode.Y, (0, 0)},
            { KeyCode.U, (1, 1) },
            { KeyCode.I, (2, 2) },
            { KeyCode.O, (3, 3) },
            { KeyCode.P, (4, 4) },

            { KeyCode.G, (0, 5) },
            { KeyCode.H, (1, 6) },
            { KeyCode.J, (2, 7) },
            { KeyCode.K, (3, 8) },
            { KeyCode.L, (4, 9) },

            { KeyCode.V, (0, 10) },
            { KeyCode.B, (1, 11) },
            { KeyCode.N, (2, 12) },
            { KeyCode.M, (3, 13) },
            { KeyCode.Space, (-1, 14) }, //hand
            { KeyCode.T, (-1, 15) }, //arm
        };
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var pair in keyMap)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                SelectJoint(pair.Value.joinIndex);
                SelectFinger(pair.Value.fingerColliderIndex);
            }
        }
    }

    void SelectJoint(int index)
    {
        controller.selectedObject = sceneNodes[index];
    }

    void SelectFinger(int index)
    {
        if (index == -1)
        {
            return;
        }
        else
        { 
            fingerCameraController.selectedFingerCollider = fingerColliders[index];
        }
    }
}
