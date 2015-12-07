using UnityEngine;
using System.Collections;
//挂载在一个空物体上;
public class SpawnEnemy : MonoBehaviour {
    public GameObject enemy;
    private float myTime;
    public GameObject enemyBullet;
    private Rigidbody enemyBulletRd;
    public static bool isOn = false;//判断敌军是否生成
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        myTime += Time.deltaTime;
        if (myTime > 1.5f&&enemyController.gameOver==false) {
            enemy.transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 0, 30);
            GameObject.Instantiate(enemy, enemy.transform.position, Quaternion.identity);
            myTime = 0;
        }
        if (Input.GetButton("Fire2")&&enemyController.gameOver==true) {
            Application.LoadLevel("main");
            enemyController.gameOver = false;
        }
	}
}
