using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using UnityEngine.SceneManagement;


public class ApparatusAcceptor : ApparatusBase
{
    

    public override void triggerEnterBehavior(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player1"))
        {
            Debug.Log("e");
            SceneManager.LoadScene(1);
        }
            



    }
}