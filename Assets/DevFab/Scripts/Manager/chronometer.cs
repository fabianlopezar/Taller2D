using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class chronometer : MonoBehaviour
{
    public static chronometer Instance { get; private set; }
    public TMP_Text _cronometroTMP;
    public float tiempoTranscurrido = 0f;
    private bool _cronometroActivo = true;

    void Awake()
    {
       // _cronometroTMP.text = "Tiempo: 0";
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

            // Verifica si se encontró el GameObject
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
        // Asegúrate de desuscribirte cuando el objeto se desactive o sea destruido
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    // Este método se ejecutará cada vez que se cargue una nueva escena
    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {    //   Cambio de escena detectado. 
        // Puedes agregar aquí el código que deseas ejecutar cuando cambie de escena
        FindObjectName();
    }
}
