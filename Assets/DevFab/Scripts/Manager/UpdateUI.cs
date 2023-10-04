/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/*
<summary>
descripcion clase:actualizar y mostrar información en la interfaz de usuario (UI) utilizando TextMeshPro. También gestiona la persistencia y actualización de la UI a través de cambios de escena.
</summary>
*/
  
public class UpdateUI : MonoBehaviour
{/*
<summary>
Descripcion atributo: Se utiliza para implementar el patrón Singleton, garantizando que solo haya una instancia de la clase en el juego.
</summary>
*/
  public static UpdateUI Instance { get; set; }

    [Header("TMP")]
/*<summary>
Descripcion atributo:Estas variables almacenan los nombres de los objetos de texto en la interfaz de usuario (UI) correspondientes a las gemas y el puntaje del juego.
</summary>
*/
    private string gem1, gem2, gem3, score;    
    //      0          1          2          3
    // _gem1TMP;   _gem2TMP;  _gem3TMP;  _scoreTMP;
/*<summary>
Descripcion atributo: Es un arreglo de objetos TMP_Text que almacenan referencias a los componentes de texto en la UI utilizados para mostrar información como las gemas y el puntaje.
</summary>
*/
    public TMP_Text[] _textosTMP;

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
        FindObjectName();
    }
    public void Start()
    {
        SetValuesUI();
        InicializarValores();
    }

    private void InicializarValores()
    {
        gem1 = "gema1TMP";
        gem2 = "gema2TMP";
        gem3 = "gema3TMP";
        score = "scoreTMP";
    }

    public void SetValuesUI()
    {
        _textosTMP[0].text = ""+GameManager.Instance._gema1;
        _textosTMP[1].text = "" + GameManager.Instance._gema2;
        _textosTMP[2].text = ""+ GameManager.Instance._gema3;
        _textosTMP[3].text = ""+ GameManager.Instance._puntos;
    }
    public void FindObjectName()
    {
        //bucle for recorriendo una lista.
        List<string> lista = LlenarLista();
        for (int i = 0; i < lista.Count; i++)
        {
            //pregunta si existe.
            //si existe asignar valor a la variable.

            // Intenta encontrar el GameObject por su nombre
            GameObject objetoEncontrado = GameObject.Find(lista[i]);

            // Verifica si se encontró el GameObject
            if (objetoEncontrado != null)
            {
                _textosTMP[i] = objetoEncontrado.GetComponent<TMP_Text>();//Le asigno el valor a la variable encontrada.
            }
        }
    }

    private static List<string> LlenarLista()
    {
        List<string> lista = new List<string>();
        lista.Add("gema1TMP");
        lista.Add("gema2TMP");
        lista.Add("gema3TMP");
        lista.Add("scoreTMP");
        return lista;
    }
    private void OnEnable()
    {
        // Suscribirse al evento de escena cargada
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    private void OnDisable()
    {
        // Asegúrate de desuscribirte cuando el objeto se desactive o sea destruido
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    // Este método se ejecutará cada vez que se cargue una nueva escena
    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Puedes agregar aquí el código que deseas ejecutar cuando cambie de escena
        FindObjectName();
        SetValuesUI();
  //      Debug.Log("Cambio de escena detectado. Se cargó la escena: " + scene.name);
    }
}
