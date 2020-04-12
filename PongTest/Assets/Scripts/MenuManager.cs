using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Load2PlayerGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Load1PlayerGame()
    {
        SceneManager.LoadScene(2);
    }
    

}
