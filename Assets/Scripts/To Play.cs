using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlay : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
