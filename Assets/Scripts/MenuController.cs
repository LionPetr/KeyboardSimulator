using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject TutorialScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TutorialScreen.SetActive(!TutorialScreen.activeSelf);
        }
    }
}
