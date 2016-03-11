using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;

    //Esses atributos ficam como público pq preciso deles na UI do player dentro do unity...
    public Text countText;
    public Text winText;

    //Essa vaíável é publica porque queremos que ela apareça no "inspector" 
    // como uma propriedade editável no Unity
    public float Speed = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        CalculatePts();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        //move na horizontal
        //(move o objeto que representa o jogador no eixo X do plano carteziano).
        float moveHorizontal = Input.GetAxis("Horizontal");

        //move na vertical
        //(move o objeto que representa o jogador no eixo Z do plano cartesiano)
        float moveVertical = Input.GetAxis("Vertical");

        //Determina a direção da força que iremos aplicar sobre a nossa bola (x,y,z)
        //'Y' terá o valor 0 porque não queremos que a bola se mova para cima.
        //moveHorizontal fará com que a bola se mova para direita ou esquerda.
        // análogamente moveVertical fará com que a bola vá para frente ou para trás.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            CalculatePts();
        }
    }

    #region Helpers

    private void CalculatePts()
    {
        countText.text = "Points: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You win !";
        }
            
    }

    #endregion
}
