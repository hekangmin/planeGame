using UnityEngine;
using System.Collections;

public class enemyBulletController : MonoBehaviour {
    public Rigidbody enemyBulletRd;
    public float EnemyBulletSpeed = -40.0f;
    // Use this for initialization
    void Start () {
        enemyBulletRd = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        enemyBulletRd.velocity = new Vector3(0, 0, EnemyBulletSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(other.gameObject);
        }
    }
}
