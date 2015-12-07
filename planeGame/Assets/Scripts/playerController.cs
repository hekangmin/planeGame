using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public GameObject playerBullet;
    
    public float PlayerSpeed = 100.0f;
    GameObject ScoreText;
    private bool fire = false;
    
    void Start () {
        ScoreText = GameObject.Find("ScoreText");
    }

    void Update() {
        if (fire) {
            OnClickFire();
            fire = false;
        }
       
        ScoreText.GetComponent<TextMesh>().text = "Score:" + PlayerBulletController.count;
    }
	void FixedUpdate () {

        if (transform.position.x < -100.0f)
        {
            transform.position = new Vector3(-99.9f,transform.position.y,transform.position.z);//如果超出左边界，则停留在左边界;
        }
        if (transform.position.x > 100.0f)
        {
            transform.position = new Vector3(99.9f, transform.position.y, transform.position.z);//如果超出右边界，则停留在右边界;
        }

        if (transform.position.z< -95.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -95.0f);//如果超出左边界，则停留在左边界;
        }
        if (transform.position.z > 35.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 34.0f);//如果超出右边界，则停留在右边界;
        }
        /* 通过键盘控制player移动*/
        Vector3 newPosition = transform.position;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        newPosition.z += vertical*PlayerSpeed*0.5f;
        newPosition.x += horizontal * PlayerSpeed *0.5f;
        transform.position = newPosition;
       
       
    }

    /*void Fire() {
        if (Input.GetButtonDown("Fire1"))
        {
          GameObject.Instantiate(playerBullet, transform.position, Quaternion.identity);
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            Destroy(gameObject);
            enemyController.gameOver = true;
        }

    }

    public void OnClickUp() {
        float verticalDis = PlayerSpeed *2.5f;
        Vector3 newPosition = transform.position;
        newPosition.z += verticalDis;
        transform.position = newPosition;
    }
    public void OnClickDown()
    {
        float verticalDis = -1*PlayerSpeed *2.5f;
        Vector3 newPosition = transform.position;
        newPosition.z += verticalDis;
        transform.position = newPosition;
    }
    public void OnClickLeft()
    {
        float Horizontal = -1 * PlayerSpeed*2.5f;
        Vector3 newPosition = transform.position;
        newPosition.x += Horizontal;
        transform.position = newPosition;
    }
    public void OnClickRight()
    {
        float Horizontal =   PlayerSpeed*2.5f;
        Vector3 newPosition = transform.position;
        newPosition.x += Horizontal;
        transform.position = newPosition;
    }

    public void OnClickFire() {
        GameObject.Instantiate(playerBullet, transform.position, Quaternion.identity);
        fire = true;
    }

    
}
