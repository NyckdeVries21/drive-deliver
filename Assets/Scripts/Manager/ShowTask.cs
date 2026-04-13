using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTask : MonoBehaviour
{
    [Header("Delivery Data")]
    [SerializeField] private TextMeshProUGUI aDeliveryCompany;
    [SerializeField] private TextMeshProUGUI bDeliveryCompany;
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI productName;
    [SerializeField] private TextMeshProUGUI productAmount;
    [SerializeField] private TextMeshProUGUI rewards;

    [SerializeField] private List<Challenge> challenges;
    private Challenge currentChallenge;

    [SerializeField] private GameObject map;

    public TaskManager taskManager;

    private void Start()
    {
        taskManager = FindAnyObjectByType<TaskManager>();

        currentChallenge = challenges[Random.Range(0, challenges.Count)];

        ShowChallenge(currentChallenge);
    }

    private void ShowChallenge(Challenge challenge)
    {
        aDeliveryCompany.text = "Start: " + challenge.ACompanyname;
        bDeliveryCompany.text = "Deliver at: " + challenge.BCompanyname;
        distance.text = challenge.Distance + "km";
        productName.text = challenge.ProductName;
        productAmount.text = "Amount: " + challenge.ProductAmount;
        rewards.text = "Receive: " + challenge.Money + '\n' + "XP: " + challenge.XP;
    }
    public void SelectThisTask()
    {
        taskManager.SelectedTask(currentChallenge);
        GameManager.instance.questActive = true;
    }


}
