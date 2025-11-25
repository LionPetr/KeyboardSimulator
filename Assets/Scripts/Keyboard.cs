using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public GameObject keyPrefab;
    public TextMeshPro Screen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string keyChars = "QWERTYUIOPASDFGHJKL;ZXCVBNM,.?";
        GameObject o;
        for (int i = 0; i < keyChars.Length; i++) {
            o = Instantiate(keyPrefab, new Vector3(2.5f - (i%10)*0.4f, 0, -4.1f+(i/10)*0.4f), Quaternion.identity);
            o.GetComponent<Key>().Char = keyChars[i];
            o.GetComponent<Key>().Screen = Screen;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
