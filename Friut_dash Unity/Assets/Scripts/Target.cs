using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 13;
    private float maxtorque = 5;
    private float xRange = 4;
    private float ySpawnPos = -1;
    public int pointValue = 100;
    public ParticleSystem explosionParticle;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }
    Vector3 RandomForce (){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque(){
        return Random.Range(-maxtorque, maxtorque);
    }
}
