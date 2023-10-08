/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
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
/*
 * <summary>
 *Descripcion clase: El código define un script que gestiona la carga y guardado de datos del juego en formato JSON, además de mostrar esos datos en texto en la interfaz del juego. Utiliza la información de gemas, puntuación, tiempo y nombre del jugador.
 * </summary>
 */

public class SaveData : MonoBehaviour
{
    /*
     * <summary>
     * dscripcion atributo
     * </summary>
     */
    public TMP_Text _nameTMP;  
    /*
     * <summary>
     * dscripcion atributo
     * </summary>
     */
    public TMP_Text _showGema1, _showGema2, _showGema3,_showTiempo,_showScore, _showNameTMP;
    /*
    * <summary>
    * dscripcion atributo
    * </summary>
    */
    private string dataFilePath = "Assets/DevFab/JSONs/DataJSON.json";

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
