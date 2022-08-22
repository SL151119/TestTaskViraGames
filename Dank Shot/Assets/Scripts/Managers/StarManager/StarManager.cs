using UnityEngine;
using TMPro;

public class StarManager : MonoBehaviour
{
    [Header("Star Text")]
    [SerializeField] private TextMeshProUGUI starText;

    [HideInInspector]
    public int starValue;

    void Start()
    {
        starValue = PlayerPrefs.GetInt("Star");
        UpdateStarUI();
    }

    public void AddStar(int value)
    {
        starValue += value;
        UpdateStarUI();
    }

    public void MinusStar(int value)
    {
        starValue -= value;
        UpdateStarUI();
    }

    public bool IsEnoughMoney(int PriceValue)
    {
        if (starValue >= PriceValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateStarUI()
    {
        starText.text = starValue.ToString();
        PlayerPrefs.SetInt("Star", starValue);
    }
}
