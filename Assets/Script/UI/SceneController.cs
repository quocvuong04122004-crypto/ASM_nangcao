using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Nút PLAY
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Nút MENU
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Nút Trangchu
    public void GoToTrangchu()
    {
        SceneManager.LoadScene("Main");
    }
}