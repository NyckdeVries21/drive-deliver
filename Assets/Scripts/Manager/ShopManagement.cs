using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class ShopManagement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private PlayerStats playerStats;

    [Header("Pickup")]
    [SerializeField] private TextMeshProUGUI pickupCostsTxt;
    [SerializeField] private GameObject pickup;

    [Header("LVL2: Roadcar")]
    [SerializeField] private TextMeshProUGUI l2CostsTxt;
    [SerializeField] private GameObject roadcar;
    [SerializeField] private GameObject l2LockIcon;

    [Header("LVL4: Van")]
    [SerializeField] private TextMeshProUGUI l4CostsTxt;
    [SerializeField] private GameObject van;
    [SerializeField] private GameObject l4LockIcon;

    [Header("LVL6: Towtruck")]
    [SerializeField] private TextMeshProUGUI l6CostsTxt;
    [SerializeField] private GameObject towtruck;
    [SerializeField] private GameObject l6LockIcon;

    [Header("LVL8: Truck")]
    [SerializeField] private TextMeshProUGUI l8CostsTxt;
    [SerializeField] private GameObject truck;
    [SerializeField] private GameObject l8LockIcon;

    [Header("LVL10: Van XL")]
    [SerializeField] private TextMeshProUGUI l10CostsTxt;
    [SerializeField] private GameObject vanXL;
    [SerializeField] private GameObject l10LockIcon;

    void Start()
    {
    }

    public void RemoveLockIcons()
    {
        int level = playerStats.experienceLevel;

        l2LockIcon.SetActive(level <= 2);
        l4LockIcon.SetActive(level <= 4);
        l6LockIcon.SetActive(level <= 6);
        l8LockIcon.SetActive(level <= 8);
        l10LockIcon.SetActive(level <= 10);
    }
    public void RoadcarBuy()
    {
        if (playerInventory.ownedCars.Contains(roadcar)) return;

        playerInventory.ownedCars.Add(roadcar);
        l2CostsTxt.text = "Owned";
        l2CostsTxt.color = Color.green;
    }

    public void VanBuy()
    {
        if (playerInventory.ownedCars.Contains(van)) return;

        playerInventory.ownedCars.Add(van);
        l4CostsTxt.text = "Owned";
        l4CostsTxt.color = Color.green;
    }

    public void TowTruckBuy()
    {
        if (playerInventory.ownedCars.Contains(towtruck)) return;

        playerInventory.ownedCars.Add(towtruck);
        l6CostsTxt.text = "Owned";
        l6CostsTxt.color = Color.green;
    }

    public void TruckBuy()
    {
        if (playerInventory.ownedCars.Contains(truck)) return;

        playerInventory.ownedCars.Add(truck);
        l8CostsTxt.text = "Owned";
        l8CostsTxt.color = Color.green;
    }

    public void VanXLBuy()
    {
        if (playerInventory.ownedCars.Contains(vanXL)) return;

        playerInventory.ownedCars.Add(vanXL);
        l10CostsTxt.text = "Owned";
        l10CostsTxt.color = Color.green;
    }
}
