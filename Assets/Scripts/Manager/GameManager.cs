using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    private void ShowDeliveryStats()
    {
        // laat de stats/info zien v/d opdracht in de UI
    }
}
