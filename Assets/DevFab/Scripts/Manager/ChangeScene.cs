using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(sceneName); //Carga la nueva escena cuando se presiona la tecla "C".
        }
    }
    public void Scena1()
    {
        string nameScene = "1";
        SceneManager.LoadScene(nameScene);
    }
    public void Scena2()
    {
        string nameScene = "2";
        SceneManager.LoadScene(nameScene);
    }
    public void Scena3()
    {
        string nameScene = "3";
        SceneManager.LoadScene(nameScene);
    }
    
    public void Inicial()
    {
        string nameScene = "Inicio";
        SceneManager.LoadScene(nameScene);
    }
}
