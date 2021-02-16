using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Debug.LogError("Попытка создания второго GameManager!");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Game");
    }
    
    
}
