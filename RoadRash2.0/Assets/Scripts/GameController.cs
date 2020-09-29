using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayeController playeController;
    public GameObject controllers;
    public GameObject countDown;
    public Material light;
    public float distancePassed;


    
    
   
    void Start()
    {
  
        StartCoroutine(CountDown());
    }

    private void Update()
    {
        
    }

    IEnumerator CountDown()
    {
        light.color = Color.red;
        yield return new WaitForSeconds(1f);
        light.color = Color.yellow;
        yield return new WaitForSeconds(1f);
        light.color = Color.green;
        yield return new WaitForSeconds(1f);

        playeController.gameStart = true;
        controllers.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(countDown);


    }
}
