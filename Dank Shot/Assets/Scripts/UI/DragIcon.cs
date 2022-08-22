using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DragIcon : MonoBehaviour
{
    [Header("GameManager Script")]
    [SerializeField] private GameManager gameManagerScript;
   
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!gameManagerScript.gameIsStart)
        {
            StartCoroutine(DragItAnimation());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator DragItAnimation()
    {
        yield return new WaitForSecondsRealtime(0.9f);
        anim.SetBool("IsDrag", true);
    }
    
}
