using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//我方子弹，playerBullet预设体，预设体上存在刚体;
public class PlayerBulletController : MonoBehaviour
{

    public Rigidbody playerBulletRd;//playerBullet上的刚体;


    public float PlayerBulletSpeed = 100.0f;


    private float MaxRange = 100.0f;

    public static int count = 0;//计算子弹与敌方碰撞次数;
    void Start()
    {
        playerBulletRd = GetComponent<Rigidbody>();
    }


    void Update()
    {

        playerBulletRd.velocity = new Vector3(0, 0, PlayerBulletSpeed);
        if (transform.position.z > MaxRange)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            count++;
            Destroy(other.gameObject);
        }

    }
}
