using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public float bulletLife;


    public Transform tf;
    public TankData data;
    public float bulletSpeed = 10.0f;
    public int Score;
    

    

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        data = gameObject.GetComponent<TankData>();
        
    }

    private void Update()
    {
        //Always move forward
        tf.position += tf.forward * bulletSpeed * Time.deltaTime;

        bulletLife -= Time.deltaTime;
        if (bulletLife <= 0)
        {

            Destroy(this.gameObject);

        }



    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player2")
        {
            Score = PlayerPrefs.GetInt("Score") + 10;
            PlayerPrefs.SetInt("Score", Score);
            Destroy(this.gameObject);


        }

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
            Destroy(this.gameObject);


        }

        if (other.gameObject.tag == "Enemy")
        {

            Destroy(this.gameObject);


        }

        if (other.gameObject.tag == "Wall")
        {

            Destroy(this.gameObject);


        }

    }

}
