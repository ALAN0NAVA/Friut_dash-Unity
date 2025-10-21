using UnityEngine;

public class Cutter : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    private Vector3 initPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && gameManager.gameActive)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            // Mover el cuchillo a esa posición
            transform.position = worldPos;
            Instantiate(explosionParticle, worldPos, explosionParticle.transform.rotation);
            explosionParticle.Play();
        } else transform.position = initPos;
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Bad")) gameManager.GameOver();
        if (other.gameObject.CompareTag("Fruit") && gameManager.gameActive)
        {   
            gameManager.UpdateScore(100);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
}
