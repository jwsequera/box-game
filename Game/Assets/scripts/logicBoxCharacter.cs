using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class logicBoxCharacter : MonoBehaviour
{

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public bool isAnimating;
    public string trigger;
    private Socket socket;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        // Crea un socket TCP
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Conecta al servidor
        socket.Connect("localhost", 5000);

        // Suscribe un observador a la conexión
        socket.Observable.Subscribe(
            data => {
                // Procesa los datos
                string current_action = data.ToString();

                // Ejecuta la animación correspondiente
                if (current_action != "None" && !isAnimating){
                    Animating(current_action);
                }
            },
            error => {
                // Maneja los errores
                Debug.Log("Error: " + error);
            },
            () => {
                // Se desconectó del servidor
                Debug.Log("Desconectado");
            }
        );
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }

    private void Animating(string trigger){
        if (trigger == "JabCross"){
            anim.SetTrigger(trigger);
            Debug.Log("Ejecutando " + trigger);
            isAnimating = true;
        } else
        {
            isAnimating = false;
            
        }
    }

    private void notAnimating(){ //se ejecuta al casi finalizar la animacion de JabCross
        isAnimating = false;
    }
}