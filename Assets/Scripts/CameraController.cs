using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //Referência ao objeto que representa o jogador (bolinha)
    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	
	}


	void LateUpdate () {

        //"the camera is moving into a new position align to the player project..."
        transform.position = player.transform.position + offset;
	}
}
