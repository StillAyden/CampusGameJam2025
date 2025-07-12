using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public void Died()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
