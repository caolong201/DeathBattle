﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OncoliisionController : MonoBehaviour
{
   

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        //Debug.Log( this.name +" -- va cham --" + collision.gameObject.name);





    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} ** kích hoạt ** {other.gameObject.name}");
    }





}
