using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void QuitApplication()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();

        // If you're in the editor, this will stop the play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
