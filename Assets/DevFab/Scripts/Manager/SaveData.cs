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
     * descripcion atributo: Variable que almacena un objeto de texto (TMP_Text) utilizado para mostrar el nombre del jugador en la interfaz.
     * </summary>
     */
    public TMP_Text _nameTMP;
    /*
     * <summary>
     * descripcion atributo:
     * _showGema1, _showGema2, _showGema3: 
     * Variables que almacenan objetos de texto (TMP_Text) utilizados para mostrar la cantidad de gemas
     * de diferentes tipos en la interfaz.
     * _showTiempo:
     * Variable que almacena un objeto de texto (TMP_Text) utilizado para mostrar el tiempo transcurrido en la interfaz.
       _showScore:
    Variable que almacena un objeto de texto (TMP_Text) utilizado para mostrar la puntuación en la interfaz.
       _showNameTMP: Variable que almacena un objeto de texto (TMP_Text) utilizado para mostrar el nombre del jugador en la interfaz.
     * </summary>
     */
    public TMP_Text _showGema1, _showGema2, _showGema3,_showTiempo,_showScore, _showNameTMP;
    /*
    * <summary>
    * descripcion atributo:  Ruta del archivo JSON donde se guardan los datos del juego.
    * </summary>
    */
    private string dataFilePath = "Assets/DevFab/JSONs/DataJSON.json";
    /*
    * <summary>
    * descripcion del metodo: Guarda los datos del juego (gemas, puntuación, tiempo y nombre del jugador) 
    * en formato JSON y muestra los datos guardados en la interfaz.
    * </summary>
    */
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
    /*
    * <summary>
    * descripcion del metodo:  Muestra los datos guardados (gemas, tiempo, puntuación y nombre del jugador) en la interfaz de usuario.
    * </summary>
    */
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
    /*
    * <summary>
    * descripcion del metodo: Carga los datos del juego desde un 
    * archivo JSON y muestra esos datos en la interfaz, o muestra un mensaje si no se encuentra el archivo.
    * </summary>
    */
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
