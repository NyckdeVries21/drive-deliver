using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Objects")]
    [SerializeField] public GameObject completeTaskUI;

    [Header("Game Activity")]
    public bool questActive = false;

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

}
