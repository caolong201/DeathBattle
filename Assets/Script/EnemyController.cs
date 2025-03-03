using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
     void OnParticleCollision(GameObject other)                                 // Được gọi tự động khi một hạt từ Particle System va chạm với GameObject này.
    {
        // phá hủy gameObject
        Debug.Log($"{name}  cham {other.gameObject.name}");
        Destroy(gameObject);
    }
}
