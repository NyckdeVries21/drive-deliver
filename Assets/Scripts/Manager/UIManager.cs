using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("InfoField")]
    [SerializeField] public TextMeshProUGUI playerMoneyAmount;
    [SerializeField] private TextMeshProUGUI dayTime;
    [SerializeField] private TextMeshProUGUI pLevel;

    [Header("Clock Data")]
    private float timer;
    private int minutes = 00;
    private int hours = 8;
    private List<string> dayNames;
    private int week;

    [Header("Settings Tabs")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject saveDataMenu;
    [SerializeField] private GameObject dataSettingsMenu;

    [Header("Game Active?")]
    [SerializeField] private GameObject inGameUI;

    [Header("Out Game UI")]
    [SerializeField] private GameObject questMenu;
    [SerializeField] private GameObject completedTask;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject pInvStatsList;

    [Header("Menu Texts")]
    [SerializeField] private TextMeshProUGUI geldTxt;
    [SerializeField] private TextMeshProUGUI currentCarTxt;
    [SerializeField] private TextMeshProUGUI timeTxt;

    private void Update()
    {
        timer += Time.deltaTime;
        dayTime.text = hours +  ":0"+ minutes;
        if (minutes >= 10)
        {
            dayTime.text = hours + ":" + minutes;
        }
        CalculateClock();
        PlayerMoneyUpdate();
        ShowLevel();

        if ( GameManager.instance.questActive == false)
        {
            inGameUI.SetActive(false);
            startMenu.SetActive(true);
            UpdateMenuTexts();
            Time.timeScale = 0f;
        }
        else
        {
            inGameUI.SetActive(true);
            startMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void CalculateClock()
    {
        if (timer >= 5)
        {
            minutes++;
            timer = 0;
            if (minutes > 60)
            {
                hours++;
                minutes = 0;
                if (hours > 24)
                {
                    // dag erbij
                }
            }
        }
    }

    private void PlayerMoneyUpdate()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();

        playerMoneyAmount.text = "Cash: " + playerStats.moneyAmount;
    }

    private void ShowLevel()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
        pLevel.text = "" + playerStats.experienceLevel;
    }

    public void SettingTabOpenClose()
    {
        if (!settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(true);
        }
        else { settingsMenu.SetActive(false); }
    }

    public void SaveDataTabOpenClose() // save data tab
    {
        if (GameManager.instance.questActive == true)
        {
            if (!saveDataMenu.activeSelf)
            {
                saveDataMenu.SetActive(true);
            }
            else { saveDataMenu.SetActive(false); }
        }
        else
        {
            if (!dataSettingsMenu.activeSelf)
            {
                dataSettingsMenu.SetActive(true);
            }
            else
            {
                dataSettingsMenu.SetActive(false);
            }
        }
    }

    public void OpenTaskList()
    {
        if (!questMenu.activeSelf)
        {
            questMenu.SetActive(true);
        }
        else { questMenu.SetActive(false); }
    }

    public void GoToShop()
    {
        if (!shop.activeSelf)
        {
            shop.SetActive(true);
        } else {  shop.SetActive(false); }
    }

    public void ShowPlayerInvStats()
    {
        if (!pInvStatsList.activeSelf)
        {
            pInvStatsList.SetActive(true);
        }
        else { pInvStatsList.SetActive(false); }
    }

    public void GoToMenu()
    {
        if (!startMenu.activeSelf)
        {
            questMenu.SetActive(false);
            startMenu.SetActive(true);
            GameManager.instance.questActive = false;
        }
        else
        {
            startMenu.SetActive(false);
        }
    }

    private void UpdateMenuTexts()
    {
        PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
        Player player = FindAnyObjectByType<Player>();

        geldTxt.text = playerStats.moneyAmount.ToString();
        currentCarTxt.text = player.currentCar.name;
        timeTxt.text = dayTime.text;
    }
}
