using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject currentCar;

    public void SetCar(GameObject carPrefab)
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;

        if (currentCar != null)
        {
            spawnPosition = currentCar.transform.position;
            spawnRotation = currentCar.transform.rotation;

            Destroy(currentCar);
        }
        else
        {
            spawnPosition = transform.position;
            spawnRotation = transform.rotation;
        }

        currentCar = Instantiate(carPrefab, spawnPosition, spawnRotation);
    }
}
