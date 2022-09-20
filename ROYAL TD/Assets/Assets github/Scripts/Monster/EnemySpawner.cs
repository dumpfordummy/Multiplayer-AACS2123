using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawner : MonoBehaviour
{
    public float firstBuildingTime;
    public float firstEnemyWaveTime;
    public int firstEnemyCount;

    public float secondBuildingTime;
    public float secondEnemyWaveTime;
    public int secondEnemyCount;

    public float thirdBuildingTime;
    public float thirdEnemyWaveTime;
    public int thirdEnemyCount;

    public float fourthBuildingTime;
    public float fourthEnemyWaveTime;
    public int fourthEnemyCount;

    public float fifthBuildingTime;
    public float fifthEnemyWaveTime;
    public int fifthEnemyCount;

    public float sixthBuildingTime;
    public float sixthEnemyWaveTime;
    public int sixthEnemyCount;

    private int spawnRegion;
    private float spawnCooldown;
    public float spawnCooldownDuration;
    private Timer timer;

    public GameObject[] bats;
    public GameObject[] crabs;
    public GameObject[] golem1;
    public GameObject[] golem2;
    public GameObject[] rat;
    public GameObject[] spikedSlime;

    // Update is called once per frame
    void Update()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        if (firstBuildingTime > 0)
        {
            firstBuildingTime -= Time.deltaTime;
            timer.DisplayTime(firstBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if (firstEnemyWaveTime > 0)
        {
            if (firstEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else if (spawnCooldown <= 0)
                {
                    spawnEnemy(1);
                    firstEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            firstEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(firstEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (secondBuildingTime > 0)
        {
            secondBuildingTime -= Time.deltaTime;
            timer.DisplayTime(secondBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if (secondEnemyWaveTime > 0)
        {
            if (secondEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(2);
                    secondEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            secondEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(secondEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (thirdBuildingTime > 0)
        {
            thirdBuildingTime -= Time.deltaTime;
            timer.DisplayTime(thirdBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if (thirdEnemyWaveTime > 0)
        {
            if (thirdEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(3);
                    thirdEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            thirdEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(thirdEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (fourthBuildingTime > 0)
        {
            fourthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(fourthBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if (fourthEnemyWaveTime > 0)
        {
            if (fourthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(4);
                    fourthEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            fourthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(fourthEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (fifthBuildingTime > 0)
        {
            fifthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(fifthBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if (fifthEnemyWaveTime > 0)
        {
            if (fifthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(5);
                    fifthEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            fifthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(fifthEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (sixthBuildingTime > 0)
        {
            sixthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(sixthBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        else if (sixthEnemyWaveTime > 0)
        {
            if (sixthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(6);
                    sixthEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            sixthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(sixthEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    void spawnEnemy(int n)
    {
        GameObject enemy = FindEnemy(n);
        enemy.SetActive(true);

        spawnRegion = Random.Range(0, 4);

        if (spawnRegion == 0)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(-50, -40) + 0.5f, Random.Range(-15, 25) - 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(-50, -40) + 0.5f, Random.Range(-15, 25) - 0.5f);
        }
        else if (spawnRegion == 1)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(-50, 40) + 0.5f, Random.Range(-25, -15) + 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(-50, 40) + 0.5f, Random.Range(-25, -15) + 0.5f);
        }
        else if (spawnRegion == 2)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(40, 50) - 0.5f, Random.Range(-25, 15) + 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(40, 50) - 0.5f, Random.Range(-25, 15) + 0.5f);
        }
        else if (spawnRegion == 3)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(-40, 50) - 0.5f, Random.Range(15, 25) - 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(-40, 50) - 0.5f, Random.Range(15, 25) - 0.5f);
        }
    }

    private GameObject FindEnemy(int n)
    {
        switch (n)
        {
            case 1:
                for (int i = 0; i < bats.Length; i++)
                {
                    if (!bats[i].activeInHierarchy)
                        return bats[i];
                }
                break;
            case 2:
                for (int i = 0; i < crabs.Length; i++)
                {
                    if (!crabs[i].activeInHierarchy)
                        return crabs[i];
                }
                break;
            case 3:
                for (int i = 0; i < golem1.Length; i++)
                {
                    if (!golem1[i].activeInHierarchy)
                        return golem1[i];
                }
                break;
            case 4:
                for (int i = 0; i < golem2.Length; i++)
                {
                    if (!golem2[i].activeInHierarchy)
                        return golem2[i];
                }
                break;
            case 5:
                for (int i = 0; i < rat.Length; i++)
                {
                    if (!rat[i].activeInHierarchy)
                        return rat[i];
                }
                break;
            case 6:
                for (int i = 0; i < spikedSlime.Length; i++)
                {
                    if (!spikedSlime[i].activeInHierarchy)
                        return spikedSlime[i];
                }
                break;
        }
        return null;
    }
}
