using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1
    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }
    // 2
    public void Quit()
    {
        Application.Quit();
    }


}
