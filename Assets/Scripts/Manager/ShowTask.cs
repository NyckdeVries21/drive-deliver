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

    [SerializeField] public Challenge challenge;

    [SerializeField] private GameObject map;

    private void Start()
    {
        aDeliveryCompany.text = "Start: " + challenge.ACompanyname;
        bDeliveryCompany.text = "Deliver at: " + challenge.BCompanyname;
        distance.text = challenge.Distance + "km";
        productName.text = challenge.ProductName;
        productAmount.text = "Amount: " + challenge.ProductAmount;
        rewards.text = "Receive: " + challenge.Money + '\n' + "XP: " + challenge.XP;
    }

    
}
