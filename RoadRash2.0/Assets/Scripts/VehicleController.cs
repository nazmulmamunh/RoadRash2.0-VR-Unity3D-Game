using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Transform Player;
    public PlayeController playeController;
    public float vehicaleSpeed = 1f;
   
    // Start is called before the first frame update

    void Start()
    {
        GameObject p = GameObject.Find("Player");
        Player = p.GetComponent<Transform>();
        playeController = p.GetComponent<PlayeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playeController.gameOver && playeController.gameStart)
        {
            if (Player.position.z - 100f > transform.position.z)
            {
                Destroy(gameObject);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * vehicaleSpeed));

            
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstracal")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 40f);
        }
    }
}
