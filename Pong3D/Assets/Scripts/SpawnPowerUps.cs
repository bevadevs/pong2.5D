using System.Collections;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField] GameObject sizeUp;
    [SerializeField] GameObject sizeDown;
    [SerializeField] GameObject speedChange;
    [SerializeField] GameObject addBall;
    GameObject[] powerUps;
    GameObject instance;
    int spawningInterval = 10;

    void Start()
    {
        powerUps = new GameObject[] { sizeUp, sizeDown, speedChange, addBall };
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawningInterval);
            Destroy(instance);
            instance = Instantiate(powerUps[Random.Range(0,4)], new Vector3(Random.Range(-7, 7), Random.Range(-3.5f, 3.5f), 0), Quaternion.Euler(0, 0, -180));
        }
    }
}
