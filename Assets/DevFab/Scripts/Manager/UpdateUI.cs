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
    /*<summary>
Descripcion del metodo: Inicializa la instancia única de la clase UpdateUI, garantizando que solo
    haya una instancia en el juego, y busca objetos de texto en la interfaz de usuario.
</summary>
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
        FindObjectName();
    }
    /*<summary>
Descripcion del metodo:  Llama al método "SetValuesUI()" para configurar los valores en la interfaz de
    usuario al inicio del juego y llama a "InicializarValores()" para asignar nombres de objetos de texto.
</summary>
*/
    public void Start()
    {
        SetValuesUI();
        InicializarValores();
    }
    /*<summary>
Descripcion del metodo:  Asigna nombres de objetos de texto a las variables "gem1", "gem2", "gem3" y "score".
</summary>
*/
    private void InicializarValores()
    {
        gem1 = "gema1TMP";
        gem2 = "gema2TMP";
        gem3 = "gema3TMP";
        score = "scoreTMP";
    }
    /*<summary>
Descripcion del metodo: Actualiza los valores
de los objetos de texto en la interfaz con los valores actuales de gemas y puntaje del GameManager.
</summary>
*/
    public void SetValuesUI()
    {
        _textosTMP[0].text = ""+GameManager.Instance._gema1;
        _textosTMP[1].text = "" + GameManager.Instance._gema2;
        _textosTMP[2].text = ""+ GameManager.Instance._gema3;
        _textosTMP[3].text = ""+ GameManager.Instance._puntos;
    }
    /*<summary>
Descripcion del metodo: Encuentra objetos de texto en la interfaz por sus nombres y asigna
las referencias a las variables "_textosTMP".
</summary>
*/
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
    /*<summary>
Descripcion del metodo: Crea y llena una lista de nombres de objetos de texto.
</summary>
*/
    private static List<string> LlenarLista()
    {
        List<string> lista = new List<string>();
        lista.Add("gema1TMP");
        lista.Add("gema2TMP");
        lista.Add("gema3TMP");
        lista.Add("scoreTMP");
        return lista;
    }
    /*<summary>
Descripcion del metodo: Suscribe el método "HandleSceneLoaded" al evento de escena cargada para detectar cambios de escena.
</summary>
*/
    private void OnEnable()
    {
        // Suscribirse al evento de escena cargada
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }
    /*<summary>
Descripcion del metodo:Desuscribe el método "HandleSceneLoaded" del evento de
escena cargada para evitar problemas cuando el objeto se desactive o destruya.
</summary>
*/
    private void OnDisable()
    {
        // Asegúrate de desuscribirte cuando el objeto se desactive o sea destruido
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    /*<summary>
     * Descripcion del metodo:Este método se ejecuta cada vez que se carga una nueva escena y se utiliza para buscar 
     * nuevamente los objetos de texto en la escena recién cargada y actualizar la interfaz.
    </summary>
*/
    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Puedes agregar aquí el código que deseas ejecutar cuando cambie de escena
        FindObjectName();
        SetValuesUI();
  //      Debug.Log("Cambio de escena detectado. Se cargó la escena: " + scene.name);
    }
}
