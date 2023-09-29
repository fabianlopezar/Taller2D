using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    /*public void SceneToChange()
    {
        SceneManager.LoadScene(sceneName);
    }*/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(sceneName); // Carga la nueva escena cuando se presiona la tecla "C"
        }
    }
}
