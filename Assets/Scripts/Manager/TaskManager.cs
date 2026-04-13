using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("Linked Objects")]
    public GameObject player;
    private PlayerStats playerStats;
    [SerializeField] public JSONManager jsonManager;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject questionList;

    [Header("Delivery Data")]
    [SerializeField] private TextMeshProUGUI deliveryCompany;
    [SerializeField] private TextMeshProUGUI rewards;

    public Challenge selectedChallenge;

    [Header("Teleport")]
    [SerializeField] private Transform teleportALoc;

    [Header("Complete Task UI")]
    [SerializeField] private TextMeshProUGUI geldTxt;
    [SerializeField] private TextMeshProUGUI dLocTxt; // deliver location
    [SerializeField] private TextMeshProUGUI timeTxt;

    [SerializeField] private TextMeshProUGUI pXPLevel;
    [SerializeField] private TextMeshProUGUI pExperience;


    [Header("Whole Map Texts")]
    [SerializeField] private TextMeshProUGUI aLoc;
    [SerializeField] private TextMeshProUGUI bLoc;
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI productName;
    [SerializeField] private TextMeshProUGUI amount;
    [SerializeField] private TextMeshProUGUI reward;

    [Header("Whole Map - Player")]
    [SerializeField] private TextMeshProUGUI pMoney;
    [SerializeField] private TextMeshProUGUI pXP;
    [SerializeField] private TextMeshProUGUI gameTime;

    [Header("Checks")]
    private bool collectedRewards;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();

        if (selectedChallenge != null)
        {
            deliveryCompany.text = "To: " + selectedChallenge.BCompanyname;
            rewards.text = "Receive: " + selectedChallenge.Money + "    XP: " + selectedChallenge.XP;
        }
    }

    private void Update()
    {
        if (GameManager.instance.completeTaskUI.activeSelf)
        {
            CompletedTaskInfo();
            jsonManager.SaveData();
        }

    }

    public void SelectedTask(Challenge challenge)
    {
        questionList.SetActive(false);
        Time.timeScale = 1f;

        selectedChallenge = challenge;

        teleportALoc = GameManager.instance.GetLocation(challenge.locationIndex);

        GameObject deliver = GameManager.instance.GetDeliverObject(challenge.deliverIndex);
        GameObject canvas = GameManager.instance.GetCanvas(challenge.canvasIndex);

        deliver.SetActive(true);
        canvas.SetActive(true);
        UpdateTaskUI();

        if (player != null && teleportALoc != null)
        {
            player.transform.position = teleportALoc.transform.position;
        }
    }

    private void UpdateTaskUI()
    {
        deliveryCompany.text = "To: " + selectedChallenge.BCompanyname;
        rewards.text = "Receive: " + selectedChallenge.Money + '\n' + "XP: " + selectedChallenge.XP;
    }
    
    private void CompletedTaskInfo()
    {
        if (selectedChallenge == null) return;
        GameObject deliver = GameManager.instance.GetDeliverObject(selectedChallenge.deliverIndex);
        GameObject canvas = GameManager.instance.GetCanvas(selectedChallenge.canvasIndex);

        deliver.SetActive(false);
        canvas.SetActive(false);

        if ( collectedRewards == false)
        {
            playerStats.experience += selectedChallenge.XP;
            playerStats.moneyAmount += selectedChallenge.Money;
            collectedRewards = true;
        }
        

        playerStats.LevelUpSystem();
        geldTxt.text = "" + selectedChallenge.Money;
        dLocTxt.text = selectedChallenge.BCompanyname;
        // timeTxt.text = uiManager.deliverDuration;

        pXPLevel.text = "" + playerStats.experienceLevel;
        pExperience.text = playerStats.experience + "/" + playerStats.xpToLevelUp;

        selectedChallenge = null;
    }

    public void CloseContinueOn() // nadat je de challenge heb complete
    {
        GameManager.instance.completeTaskUI.SetActive(false);
        GameManager.instance.questActive = true;
        questionList.SetActive(true);
        collectedRewards = false;
    }

    public void UpdateWholeMapTexts()
    {
        aLoc.text = selectedChallenge.ACompanyname;
        bLoc.text = selectedChallenge.BCompanyname;
        distance.text = selectedChallenge.Distance;
        productName.text = selectedChallenge.ProductName;
        amount.text = "" + selectedChallenge.ProductAmount;
        reward.text = "Cash | XP: " + selectedChallenge.Money + "|" + selectedChallenge.XP;
        pMoney.text = playerStats.moneyAmount + "";
        pExperience.text = playerStats.experience + "";
        gameTime.text = timeTxt.text;

    }
}
