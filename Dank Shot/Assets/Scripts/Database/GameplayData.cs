using UnityEngine;

[CreateAssetMenu(menuName = "Database/Gameplay Data")]
public class GameplayData : ScriptableObject
{
    [Header("Prefabs Variant:")]
    [SerializeField] private GameObject[] _easyList;
    [SerializeField] private Transform[] _normalList;
    [SerializeField] private Transform[] _hardList;
    [SerializeField] private Transform[] _expertList;

    //public GameObject GetEasy => _easyList[Random.Range(0, _easyList.Length)];
    //public Transform GetNormal => _normalList[Random.Range(0, _normalList.Length)];
    //public Transform GetHard => _hardList[Random.Range(0, _hardList.Length)];
    //public Transform GetExpert => _expertList[Random.Range(0, _expertList.Length)];
}