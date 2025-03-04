using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public PlayerController playerScript;
    float Timeload = 5f;
    public float delayBeforeLoad = 2f;


     void OnTriggerEnter(Collider other)
    {
        
            Loadtime();
        
    }
        //Debug.Log( this.name +" -- va cham --" + collision.gameObject.name);
     
    void Loadtime ()
    {
        
            playerScript.enabled = false;
            GetComponent<PlayerController>().enabled = false;     // cách tắt script PlayerController dùng di chuyển và tắt di chuyển 
            //SceneManager.LoadScene("DeathBattle");
            Invoke("LoadScene" , delayBeforeLoad); //  Invoke()lệnh gọi phương thức sau một khoảng thời gian trễ, delayBeforeLoad thời gian trể.

        
    }
    void LoadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;     // SceneManager.GetActiveScene().buildIndex; lấy chỉ số index của Scene hiện tại
        SceneManager.LoadScene(currentSceneIndex);                           // load lại Scene hiện tại
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($"{this.name} ** kích hoạt ** {other.gameObject.name}");
    //}

   
}
