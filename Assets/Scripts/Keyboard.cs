using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public GameObject keyPrefab;
    public TextMeshPro Screen;

    const float xStart = 2;
    const float zStart = -3.1f;
    const float keySize = 0.5f;
    const int keyRows = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string keyChars = "QWERTYUIOPASDFGHJKL;ZXCVBNM,.?";
        GameObject o;
        for (int i = 0; i < keyChars.Length; i++) {
            o = Instantiate(keyPrefab, new Vector3(xStart - (i%10)*keySize, 0.8f, zStart+(i/10)*keySize), Quaternion.identity);
            o.GetComponent<Key>().Char = keyChars[i];
            o.GetComponent<Key>().Screen = Screen;
        }
        
        o = Instantiate(keyPrefab, new Vector3(xStart - (4.5f*keySize), 0.8f, zStart+(3*keySize)), Quaternion.identity);
        o.GetComponent<Key>().Char = ' ';
        o.GetComponent<Key>().LabelText = "Space";
        o.GetComponent<Key>().Screen = Screen;
        o.GetComponent<Key>().Width = keySize * 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
