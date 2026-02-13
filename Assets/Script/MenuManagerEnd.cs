using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerEnd : MonoBehaviour
{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetry()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
