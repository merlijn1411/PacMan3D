using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool teleported = false;

    public Respawn destination;





    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            if (!teleported)
            {


                StartCoroutine(Teleport(c.gameObject));


            }
        }
    }

    IEnumerator Teleport(GameObject go)
    {
        yield return new WaitForSeconds(0.05f);
        destination.teleported = true;
        go.transform.position = destination.gameObject.transform.position;
    }

    void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Player")|| c.CompareTag("Ghost"))
        {
            teleported = false;

        }
    }

}