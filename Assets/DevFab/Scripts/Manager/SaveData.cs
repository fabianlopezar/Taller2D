using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class Data
{
    public int _gema1;
    public int _gema2;
    public int _gema3;
    public int _score;

    public string _name;
    public float _time;
}
public class SaveData : MonoBehaviour
{
    public TMP_Text _nameTMP; //Este es el texto que recibo y guardo(_name).

    public TMP_Text _showGema1, _showGema2, _showGema3,_showTiempo,_showScore, _showNameTMP;//Este texto muestra las monedas guardadas.
    private string dataFilePath = "Assets/DevFab/JSONs/DataJSON.json"; //Creo un string con el nombre del archivo que quiero crear.

    
    public void Awake()
    {
     //   LoadDataFromJson();
    }
    public void SaveDataToJson()
    {
        Data data = new Data();
        data._gema1 = GameManager.Instance._gema1;
        data._gema2 = GameManager.Instance._gema2;
        data._gema3 = GameManager.Instance._gema3;
        data._score = GameManager.Instance._puntos;
        data._name = _nameTMP.text;
        data._time = chronometer.Instance.tiempoTranscurrido;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(dataFilePath, jsonData);
        MostrarDatosGuardados();
    }
    public void MostrarDatosGuardados()
    {
        //_showGema1, _showGema2, _showGema3,_showTiempo,_showScore, _showNameTMP
        _showGema1.text =""+ GameManager.Instance._gema1;
        _showGema2.text =""+ GameManager.Instance._gema2;
        _showGema3.text =""+ GameManager.Instance._gema3;
        _showTiempo.text =""+ chronometer.Instance.tiempoTranscurrido;
        _showScore.text = "" + GameManager.Instance._puntos;
        _showNameTMP.text = ""+_nameTMP.text ;

    }
    public void LoadDataFrom()
    {
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            Data data = JsonUtility.FromJson<Data>(jsonData);

            _showGema1.text = "" + data._gema1;
            _showGema2.text = "" + data._gema2;
            _showGema3.text = "" + data._gema3;
            _showTiempo.text = "" + data._time;
            _showScore.text = "" + data._score;
            _showNameTMP.text = "" + data._name;
        }
        else
        {
            _showNameTMP.text = "No se encontro :3";
        }
    }

}
