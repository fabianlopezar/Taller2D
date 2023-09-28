using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int _gema1 { get; set; }
    public int _gema2 { get; set; }
    public int _gema3 { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }
    public void AddGema(string gemaName)
    {
        switch (gemaName)
        {

        }
    }
}
