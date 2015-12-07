using UnityEngine;
using System.Collections;
//enemy预设体上，预设体存在刚体
public class enemyController : MonoBehaviour {

    public Rigidbody enemyRd;//预设体上的刚体;
    private float MaxRange = -100.0f;//边界最大值
    private float enemySpeed = -30.0f;
    GameObject GameOverText;
    public GameObject enemyBullet;
    public static bool gameOver = false;

    public float time = 0.0f;

    
    void Start () {
        enemyRd = GetComponent<Rigidbody>();
        GameOverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
       
        enemyRd.velocity = new Vector3(0, 0, enemySpeed);//敌方飞机运动;
        if (transform.position.z < MaxRange) {//超出边界即销毁;
            Destroy(gameObject);
        }

        if (gameOver == true)//游戏结束
        {
            GameOverText.GetComponent<TextMesh>().text = "GameOver!";
          
        }

        time += Time.deltaTime;
        if (time > 1.5f) {
            GameObject.Instantiate(enemyBullet, transform.position, Quaternion.identity);
            time = 0.0f;
        }

    }

    void OnTriggerEnter(Collider other)//碰撞检测;
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("player"))
        {
            gameOver = true;
            Destroy(other.gameObject);
        }
    }

    public void OnClickRestart()
    {
        gameOver = false;
        PlayerBulletController.count = 0;
        Application.LoadLevel("main");
    }
}
