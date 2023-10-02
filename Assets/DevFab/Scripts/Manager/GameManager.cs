using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int _gema1 { get; set; }
    public int _gema2 { get; set; }
    public int _gema3 { get; set; }
    public int _puntos { get; set; }
    public float _tiempo { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
          
        }
        else
        {
            Destroy(gameObject);         
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        UpdateUI.Instance.SetValuesUI(); 
    }
    public void AddGema(string name)
    {
        switch (name)
        {
            case "gema1":
                _gema1++;
                _puntos = _puntos + 10;
                UpdateUI.Instance.SetValuesUI();
                break;
            case "gema2":
                _gema2++;
                _puntos = _puntos + 5;
                UpdateUI.Instance.SetValuesUI();
                break;
            case "gema3":
                _gema3++;
                _puntos = _puntos + 1;
                UpdateUI.Instance.SetValuesUI();
                break;
            default:
                break;
        }
    }
    public void AddScore()
    {
        _puntos +=1;
        UpdateUI.Instance.SetValuesUI();

    }
}
