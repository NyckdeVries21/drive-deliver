using UnityEngine;

public class ClickOnMap : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private TaskManager taskManager;

    public void ShowMinimap()
    {
        map.SetActive(false);
    }

    public void ShowMap()
    {
        map.SetActive(true);
        taskManager.UpdateWholeMapTexts();
    }
}
