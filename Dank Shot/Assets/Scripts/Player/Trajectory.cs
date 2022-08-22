using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [Header("Dots")]
    [SerializeField] int dotsNumber;
    [SerializeField] float dotSpacing;

    [Header("DotsPrefab")]
    [SerializeField] GameObject DotsParent;
    [SerializeField] GameObject DotsPrefab;

    [Header("Range")]
    [SerializeField][Range(0.01f, 0.8f)] float dotMinScale;
    [SerializeField][Range(0f, 1.2f)] float dotMaxScale;

    private Transform[] dotsList;
    private Vector2 pos;
    private float TimeStamp;

    private void Start()
    {
        Hide();
        PrepareDots();
    }


    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        DotsPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scalefactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(DotsPrefab, null).transform;
            dotsList[i].parent = DotsParent.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
            {
                scale -= scalefactor;
            }
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        TimeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * TimeStamp);
            pos.y = (ballPos.y + forceApplied.y * TimeStamp) - (Physics2D.gravity.magnitude * TimeStamp * TimeStamp) / 2f;

            dotsList[i].position = pos;
            TimeStamp += dotSpacing;
        }
    }


    public void Show()
    {
        DotsParent.SetActive(true);
    }
    public void Hide()
    {
        DotsParent.SetActive(false);
    }
}
