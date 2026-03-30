using TMPro;
using UnityEngine;

public class UIPlayerINfo : MonoBehaviour
{
    [Header("Script Links")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Player player;

    [Header("Show Car Buttons")]
    [SerializeField] private GameObject l2CarButton;
    [SerializeField] private GameObject l4CarButton;
    [SerializeField] private GameObject l6CarButton;
    [SerializeField] private GameObject l8CarButton;
    [SerializeField] private GameObject l10CarButton;

    [Header("Read/Show PlayerStats")]
    [SerializeField] private TextMeshProUGUI showPlayerStatsTxt;


    private void Start()
    {
        showPlayerStatsTxt.text =
            "Money Amount: " + playerStats.moneyAmount + '\n' +
            "XP Level: " + playerStats.experienceLevel + '\n' +
            "XP: " + playerStats.experience + '\n' +
            "Tasks completed: " + playerStats.tasksCompleted + '\n';

    }

    void Update()
    {

    }
    public void UpdateCarButtons()
    {
        int count = inventory.ownedCars.Count;

        l2CarButton.SetActive(count >= 2);
        l4CarButton.SetActive(count >= 3);
        l6CarButton.SetActive(count >= 4);
        l8CarButton.SetActive(count >= 5);
        l10CarButton.SetActive(count >= 6);
    }


    public void SelectPickup()
    {
        if (inventory.ownedCars.Count > 0)
        {
            player.SetCar(inventory.ownedCars[0]);
        }
    }

    public void SelectRoadcar()
    {
        if (inventory.ownedCars.Count > 1)
        {
            player.SetCar(inventory.ownedCars[1]);
        }
    }

    public void SelectVan()
    {
        if (inventory.ownedCars.Count > 2)
        {
            player.SetCar(inventory.ownedCars[2]);
        }
    }

    public void SelectTowtruck()
    {
        if (inventory.ownedCars.Count > 3)
        {
            player.SetCar(inventory.ownedCars[3]);
        }
    }

    public void SelectTruck()
    {
        if (inventory.ownedCars.Count > 4)
        {
            player.SetCar(inventory.ownedCars[4]);
        }
    }

    public void SelectVanXL()
    {
        if (inventory.ownedCars.Count >= 5)
        {
            player.SetCar(inventory.ownedCars[5]);
        }
    }

}
