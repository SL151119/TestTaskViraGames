using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("GameManager Script")]
    [SerializeField] private GameManager gameManagerScript;

    private void Update()
    {
        if (!gameManagerScript.isGameOver)
        {
            transform.position = new Vector3(transform.position.x,
                                               Mathf.Lerp(transform.position.y, player.transform.position.y + 4f, 0.02f),
                                               transform.position.z);
        }
    }
}
