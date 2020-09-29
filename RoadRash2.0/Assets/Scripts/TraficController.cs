
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficController : MonoBehaviour
{
    [SerializeField] GameObject[] Vehicles;
    public Transform player;
    public PlayeController playeController;
    public float spawnDistance = 700f;
    public int[] vehiclePositions = new int[] { -66, -23, 23, 66 };
    public int[] vehicleSpeeds = new int[] {50 , 60, 80, 100 };
    public bool trafic = false;
    public float spawnTime = 5f;
    public float gameTime = 0f;
    public bool constValue = false;
    public bool easyMode = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartTrafic", 20f);
    }

    void Update()
    {
        if (!playeController.gameOver)
        {
            if (trafic)
            {

                int indexVehicle = UnityEngine.Random.Range(0, Vehicles.Length);
                int indexPosition = UnityEngine.Random.Range(0, vehiclePositions.Length);
                Vector3 newPosition = new Vector3(transform.position.x + vehiclePositions[indexPosition], transform.position.y, player.position.z + spawnDistance);
                GameObject spawnVehicle = Instantiate(Vehicles[indexVehicle], newPosition, transform.rotation);
                spawnVehicle.GetComponent<VehicleController>().vehicaleSpeed = vehicleSpeeds[indexPosition];
                trafic = false;
                Invoke("StartTrafic", spawnTime);
            }

            if (easyMode)
            {
                gameTime += Time.deltaTime;

                if (gameTime > 10f)
                {
                    easyMode = false;
                    gameTime = 0f;
                    constValue = false;
                    spawnTime = 1.5f;

                }
            }

            if (!constValue)
            {

                gameTime += Time.deltaTime;
                if (playeController.speed > 5.9f && spawnTime < .9f)
                {
                    spawnTime = .7f;

                    constValue = true;
                    gameTime = 0;
                    easyMode = true;
                }
                else if (playeController.speed > 4f && spawnTime < 3f)
                {
                    spawnDistance = 1200f;
                    //Camera.main.farClipPlane = 1190;

                }

                if (gameTime > 10f)
                {
                    DecreaseSpawnTime(.3f);
                    gameTime = 0f;
                }
            }
        }    
    }

    void StartTrafic()
    {

        trafic = true;
    }

    public void DecreaseSpawnTime(float decreaseValue)
    {
        spawnTime = spawnTime - decreaseValue;
    }
}
