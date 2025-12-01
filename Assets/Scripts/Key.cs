using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public char Char;
    public TextMeshPro Text;
    public TextMeshPro Screen;
    
    bool colliding = false;
    Vector3 StartPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Text.text = "" + Char; // convert to string
        StartPos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitCols = Physics.OverlapBox(StartPos, gameObject.transform.localScale/4);
        if (Char == 'G') {
          Debug.Log(hitCols[0]);
        }
        if (colliding || (hitCols[0].name != "Key(Clone)")) {
            gameObject.transform.localPosition = StartPos + new Vector3(0f, -0.2f, 0f);
            Screen.text += Char;
        }
        else {
            gameObject.transform.localPosition = StartPos;
        }
    }
    
    void OnTriggerEnter(Collider col) {
        colliding = true;
        Screen.text += Char;
    }
    void OnTriggerExit(Collider col) {
        colliding = false;
    }

    void OnCollisionEnter(Collision col) {
      colliding = true;
      Screen.text += Char;
    }
    void OnCollisionExit(Collision col) {
      colliding = false;
    }
}
