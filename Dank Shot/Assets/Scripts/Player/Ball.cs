using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private StarManager starManager;
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;

    private int basketCounter = 0;

    [HideInInspector]
    public Vector2 playerPos
    { get { return transform.position; } }

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    public void Push(Vector2 _force)
    {
        rb.AddForce(_force, ForceMode2D.Impulse);
        AudioManager.Instance.PlayAudio(AudioManager.Instance._shootSound);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net")
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance._netSound);
            gameManager.isShoot = false;
            scoreController.AddScore(1);
            GameObject basket = SpawnManager.Instance.GetPooledObject();
            if (basket != null)
            {
                switch (basketCounter)
                {
                    case 0:
                        basket.transform.position = 
                            new Vector2(Random.Range(-3f,-4f), transform.position.y + Random.Range(3f, 5f));
                        basket.SetActive(true);
                        basketCounter++;
                        break;
                    case 1:
                        basket.transform.position = 
                            new Vector2(Random.Range(3,4f), transform.position.y + Random.Range(3f, 5f));
                        basket.SetActive(true);
                        basketCounter = 0;

                        break;
                }
            }
            Destroy(collision);
        }


        if (collision.gameObject.tag == "Star")
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance._starSound);
            starManager.AddStar(5);
            collision.gameObject.SetActive(false);
            Destroy(collision);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ColliderNet")
        {
            gameManager.isShoot = false;
        }

        if (collision.gameObject.tag == "Ground")
        {
            scoreController.UpdateBestScore();
            gameManager.LoseGame();
            gameObject.SetActive(false);
        }
    }
}
