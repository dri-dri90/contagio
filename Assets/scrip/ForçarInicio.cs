using UnityEngine;
using UnityEngine.SceneManagement;

public class ForcarMenu : MonoBehaviour
{
    void Awake()
    {
        // Se a cena atual não for a 0, ele força a ida para a 0
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}