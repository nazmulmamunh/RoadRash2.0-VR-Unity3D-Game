using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [SerializeField]
    Transform[] roads;
    [SerializeField]
    Transform player;

    [SerializeField]
    float roadShiftLength = 201;
    [SerializeField]
    float roadMoveLength = 1600;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform road in roads )
        {
            if(road.position.z < player.position.z - roadShiftLength)
            {
                road.position = new Vector3(road.position.x, road.position.y, road.position.z + roadMoveLength);
            }
        }
    }
}
