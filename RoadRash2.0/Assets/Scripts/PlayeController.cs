using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
public class PlayeController : MonoBehaviour
{

    
    public float maxSpeed = 15;
    public float speed = 0f;
    public float speedPerFrame = .5f;
    public float sideMovePerFrame = .5f;
    public TraficController traficController;
    public bool gameOver = false;
    public bool gameStart = false;

    public GameObject bike;
    public bool accecident = false;
    public TMP_Text scoreBoard;

    public GameObject HighScoreCanv;
    public TMP_Text highScore;
    public TMP_Text gameScore;
    public Transform cameraTransfrom;
    public Transform handle;
    void Start()
    {
        
        cameraTransfrom = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = "Distance: " + Convert.ToInt32(transform.position.z / 10f) + " m";
        if (!gameOver && gameStart)
        {
            if (speed <= maxSpeed)
            {
                speed += Time.deltaTime * speedPerFrame;
            }

            if (cameraTransfrom.rotation.y > .1f)
            {
                if (transform.position.x < 85f)
                {
                    transform.position = new Vector3(transform.position.x + sideMovePerFrame, transform.position.y, transform.position.z + speed);
                    handle.localRotation = Quaternion.Euler(new Vector3(handle.rotation.x, 25f, handle.rotation.z));
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
                    handle.localRotation = Quaternion.Euler(new Vector3(handle.rotation.x, 0, handle.rotation.z));
                }

            }
            else if (cameraTransfrom.rotation.y < -0.1f)
            {
                //frontRotate = Quaternion. (handle.rotation.x, 25f, handle.rotation.z);
                if (transform.position.x > -85f)
                {
                    transform.position = new Vector3(transform.position.x - sideMovePerFrame, transform.position.y, transform.position.z + speed);
                    handle.localRotation = Quaternion.Euler(new Vector3(handle.rotation.x, -25f, handle.rotation.z));
                    //handle.rotation = Quaternion.Lerp(handle.rotation, (handle.rotation.x f, 25f, handle.rotation.z f), Time.deltaTime * 2);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
                    handle.localRotation = Quaternion.Euler(new Vector3(handle.rotation.x, 0, handle.rotation.z));
                }

            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
                handle.localRotation = Quaternion.Euler(new Vector3(handle.rotation.x, 0, handle.rotation.z));
            }

            if (speed > 5f)
            {
                sideMovePerFrame = .5f;
            }

        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        scoreBoard.gameObject.SetActive(false);
        if(collision.collider.tag == "Obstracal")
        {
            Debug.Log(collision.collider.name);
            gameOver = true;

            gameObject.GetComponent<BoxCollider>().enabled = false;
           // bike.GetComponent<CapsuleCollider>().enabled = true;
            Rigidbody accecident = bike.AddComponent<Rigidbody>();
            //accecident.isKinematic = true;
            accecident.AddForce(0, 0 , speed * 30f, ForceMode.Impulse);

            if (!PlayerPrefs.HasKey("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", 0);
            }

            int prevScore = PlayerPrefs.GetInt("HighScore");

            int score = Convert.ToInt32(transform.position.z /10f);

            if(prevScore < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            highScore.text = highScore.text + PlayerPrefs.GetInt("HighScore");
            gameScore.text = gameScore.text + score;
            HighScoreCanv.SetActive(true);
        }
    }
}
