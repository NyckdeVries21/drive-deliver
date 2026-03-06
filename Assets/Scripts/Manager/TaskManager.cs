using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("Linked Objects")]
    public GameObject player;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject questionList;

    [Header("Delivery Data")]
    [SerializeField] private TextMeshProUGUI deliveryCompany;
    [SerializeField] private TextMeshProUGUI rewards;

    private Challenge selectedChallenge;

    [Header("Teleport")]
    [SerializeField] private Transform teleportALoc;
    private void Start()
    {
        player = GameObject.Find("Player");
        deliveryCompany.text = "To: " + selectedChallenge.BCompanyname;
        rewards.text = "Receive: " + selectedChallenge.Money;
    }

    private void Update()
    {
    }

    public void SelectedTask()
    {
        questionList.SetActive(false);
        Time.timeScale = 1f;
        GetAndFillChallenge();
        UpdateTaskUI();
        player.transform.position = teleportALoc.transform.position;
    }

    private void GetAndFillChallenge()
    {
        ShowTask showTask = FindAnyObjectByType<ShowTask>();
        selectedChallenge = showTask.challenge;
    }

    private void UpdateTaskUI()
    {
        deliveryCompany.text = "To: " + selectedChallenge.BCompanyname;
        rewards.text = "Receive: " + selectedChallenge.Money + '\n' + "XP: " + selectedChallenge.XP;
    }
    

}
