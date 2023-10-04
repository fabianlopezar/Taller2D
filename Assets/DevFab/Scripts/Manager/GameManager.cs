/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using UnityEngine;
/*
 * <summary>
 * Descripcion clase: El código representa un administrador de juego con variables para gemas, puntuación y tiempo. Permite agregar gemas y puntuación, además de gestionar la persistencia entre escenas.
 * </summary>
 */
public class GameManager : MonoBehaviour
{
    /*
 * <summary>
 * Descripcion atributo: una instancia estática de la clase GameManager, lo que permite acceder a esta instancia desde cualquier lugar del código.
 * </summary>
 */
    public static GameManager Instance { get; private set; }
    /*
* <summary>
* Descripcion atributo: : variables enteras que almacenan la cantidad de diferentes tipos de gemas recolectadas en el juego.
* </summary>
*/
    public int _gema1 { get; set; }
    /*
* <summary>
* Descripcion atributo: : variables enteras que almacenan la cantidad de diferentes tipos de gemas recolectadas en el juego.
* </summary>
*/
    public int _gema2 { get; set; }
    /*
* <summary>
* Descripcion atributo: : variables enteras que almacenan la cantidad de diferentes tipos de gemas recolectadas en el juego.
* </summary>
*/
    public int _gema3 { get; set; }
    /*
* <summary>
* Descripcion atributo: una variable entera que representa la puntuación total del juego.
* </summary>
*/
    public int _puntos { get; set; }
    /*
* <summary>
* Descripcion atributo: una variable flotante que almacena el tiempo transcurrido en el juego.
* </summary>
*/
    public float _tiempo { get; set; }
    /*
* <summary>
* Descripcion del metodo:  Inicializa la instancia única de la clase GameManager y asegura que el objeto persista entre las escenas del juego.
* </summary>
*/
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
    /*
* <summary>
* Descripcion del metodo:Llama al método "SetValuesUI()" de la clase "UpdateUI" para configurar
* los valores en la interfaz de usuario al inicio del juego.
* </summary>
*/
    private void Start()
    {
        UpdateUI.Instance.SetValuesUI(); 
    }
    /*
* <summary>
* Descripcion del metodo:Agrega gemas al jugador según su tipo (gema1, gema2 o gema3), actualiza la puntuación y actualiza la interfaz de usuario.
* </summary>
*/
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
    /*
* <summary>
* Descripcion del metodo:Aumenta la puntuación del jugador en 1 punto y actualiza la interfaz de usuario.
* </summary>
*/
    public void AddScore()
    {
        _puntos +=1;
        UpdateUI.Instance.SetValuesUI();

    }
}
