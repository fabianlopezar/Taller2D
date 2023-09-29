using TMPro;
using UnityEngine;
public class UpdateUI : MonoBehaviour
{
    public static UpdateUI Instance { get; set; }

    public TMP_Text gem1TMP;
    public TMP_Text gem2TMP;
    public TMP_Text gem3TMP;
    public TMP_Text scoreTMP;
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
    public void Start()
    {
        SetValuesUI();
    }
    public void SetValuesUI()
    {
        gem1TMP.text = ""+GameManager.Instance._gema1;
        gem2TMP.text = "" + GameManager.Instance._gema2;
        gem3TMP.text = ""+ GameManager.Instance._gema3;
        scoreTMP.text = ""+ GameManager.Instance._puntos;
    }

}
