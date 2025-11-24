using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public char Char;
    public TextMeshPro Text;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Text.text = "" + Char; // convert to string
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
