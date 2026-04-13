using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Objects")]
    [SerializeField] public GameObject completeTaskUI;

    [Header("Game Activity")]
    public bool questActive = false;

    [Header("ChallengeObjects")]
    public Transform[] spawnLocations;
    public GameObject[] deliverObjects;
    public GameObject[] canvases;



    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        
    }

    public Transform GetLocation(int index)
    {
        return spawnLocations[index];
    }

    public GameObject GetDeliverObject(int index)
    {
        return deliverObjects[index];
    }

    public GameObject GetCanvas(int index)
    {
        return canvases[index];
    }

}
