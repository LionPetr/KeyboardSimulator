using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public char Char;
    public string LabelText;
    public TextMeshPro LabelObj;
    public TextMeshPro Screen;
    public GameObject Cube;
    public float Width = 0.4f;
    
    bool colliding = false;
    Vector3 StartPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (LabelText == "") {
          LabelText = "" + Char;
        }
        LabelObj.text = LabelText;
        StartPos = gameObject.transform.localPosition;
        Cube.transform.localScale = new Vector3(Width, 0.4f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitCols = Physics.OverlapBox(StartPos, Vector3.one * 0.2f);
        if (hitCols.Length > 0 && hitCols[0].name != "Key(Clone)") {
            if (colliding == false) {
                gameObject.transform.localPosition = StartPos + new Vector3(0f, -0.1f, 0f);
                Screen.text += Char;
                colliding = true;
            }
        }
        else {
            gameObject.transform.localPosition = StartPos;
            colliding = false;
        }
    }
    
}
