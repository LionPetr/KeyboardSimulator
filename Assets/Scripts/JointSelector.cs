using System.Collections.Generic;
using UnityEngine;

public class JointSelector : MonoBehaviour
{
    public SceneNode[] sceneNodes;
    public HandController controller;

    Dictionary<KeyCode, int> keyMap;

    private int selectedIndex;
    void Start()
    {
        keyMap = new Dictionary<KeyCode, int>()
        {
            {KeyCode.Y, 0},
            { KeyCode.U, 1 },
            { KeyCode.I, 2 },
            { KeyCode.O, 3 },
            { KeyCode.P, 4 },

            { KeyCode.G, 5 },
            { KeyCode.H, 6 },
            { KeyCode.J, 7 },
            { KeyCode.K, 8 },
            { KeyCode.L, 9 },

            { KeyCode.V, 10 },
            { KeyCode.B, 11 },
            { KeyCode.N, 12 },
            { KeyCode.M, 13 },
            { KeyCode.Space, 14 },
            { KeyCode.T, 15 },
        };
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var pair in keyMap)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                SelectJoint(pair.Value);
            }
        }
    }

    void SelectJoint(int index)
    {
        controller.selectedObject = sceneNodes[index];
    }
}
