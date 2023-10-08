/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andr�s Garz�n Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicol�s Ram�rez Arango 2195824
 */
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*<summary>
 * descripcion clase: Este c�digo define un cron�metro que registra el tiempo transcurrido en una escena del juego. El cron�metro se muestra en un objeto de texto (TMP_Text) y se puede iniciar, detener y reiniciar. Adem�s, se asegura de que el cron�metro persista entre las escenas del juego y ajusta el objeto de texto seg�n la escena cargada.
 </summary>
 */
public class chronometer : MonoBehaviour
{/*
  * <summary>
  * descripcion atributo: lo que permite acceder a esta instancia desde cualquier lugar del c�digo.
  * </summary>
  */
    public static chronometer Instance { get; private set; }
    /*
  * <summary>
  * descripcion atributo: una variable de tipo TMP_Text que representa el objeto de texto que muestra el cron�metro en la interfaz del juego.
  * </summary>
  */
    public TMP_Text _cronometroTMP;
    /*
  * <summary>
  * descripcion atributo:  un valor flotante que almacena el tiempo transcurrido en segundos.
  * </summary>
  */
    public float tiempoTranscurrido = 0f;
    /*
  * <summary>
  * descripcion atributo:  una variable booleana que indica si el cron�metro est� activo o detenido.
  * </summary>
  */
    private bool _cronometroActivo = true;

    void Awake()
    {
        FindObjectName();
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

    void Update()
    {
        if (_cronometroActivo)
        {
            tiempoTranscurrido += Time.deltaTime;
            _cronometroTMP.text = tiempoTranscurrido.ToString("F2");
        }
    }

    public void IniciarCronometro()
    {
        _cronometroActivo = true;
    }

    public void DetenerCronometro()
    {
        GameManager.Instance._tiempo = tiempoTranscurrido;
        _cronometroActivo = false;
    }

    public void ReiniciarCronometro()
    {
        tiempoTranscurrido = 0f;
        _cronometroTMP.text = "Tiempo: 0";
    }
    private void FindObjectName()
    {string name= "cronometroTMP";
            // Intenta encontrar el GameObject por su nombre
            GameObject objetoEncontrado = GameObject.Find(name);

            // Verifica si se encontr� el GameObject
            if (objetoEncontrado != null)
            {
            _cronometroTMP = objetoEncontrado.GetComponent<TMP_Text>();//Le asigno el valor a la variable encontrada.
        }
        else
        {
            Debug.Log("crhonometer: Deberia existir un TMP en pantalla.");
        }
        
    }
    private void OnEnable()
    {
        // Suscribirse al evento de escena cargada
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    private void OnDisable()
    {
        // Aseg�rate de desuscribirte cuando el objeto se desactive o sea destruido
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    // Este m�todo se ejecutar� cada vez que se cargue una nueva escena
    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {    //   Cambio de escena detectado. 
        // Puedes agregar aqu� el c�digo que deseas ejecutar cuando cambie de escena
        FindObjectName();
    }
}
