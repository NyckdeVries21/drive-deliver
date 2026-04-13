using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "Scriptable Objects/Challenge")]
public class Challenge : ScriptableObject
{
    public string ACompanyname;
    public string BCompanyname;
    public string Distance;
    public string ProductName;

    public int ProductAmount;
    public int Money;
    public int XP;

    [Header("IDs")]
    public int locationIndex;
    public int deliverIndex;
    public int canvasIndex;
}