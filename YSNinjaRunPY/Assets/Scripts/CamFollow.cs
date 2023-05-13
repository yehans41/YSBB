using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
  public GameObject player;

    void Update()
    {
        //follow the character with a y offset
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10.5f, player.transform.position.z);
    }
}
