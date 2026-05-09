using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    private BulletPattern bulletPattern;
    private Boss bossScript;
    [SerializeField] private BulletBossPool bulletBossPool;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private EnemyPool enemy1Pool;
    [SerializeField] private EnemyPool enemy2Pool;
    [SerializeField] private GameObject boss;
    float minX = -2.2f;
    float maxX = 2.2f;
    float posX;
    float posY = 5.4f;
    private int baseMaxEnemy = 20;
    private int currentEnemy = 0;
    [SerializeField] private TextMeshProUGUI waveText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(GameFlow());
    }
    IEnumerator GameFlow()
    {
        yield return StartCoroutine(Wave1());
        yield return StartCoroutine(WaitClear());

        yield return StartCoroutine(Wave2());
        yield return StartCoroutine(WaitClear());
        yield return StartCoroutine(Wave3());
    }
    IEnumerator WaitClear()
    {
        yield return new WaitUntil(() => currentEnemy <= 0);
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Wave1()
    {
        StartCoroutine(ShowWaveUI("WAVE 1"));
        int maxEnemy = baseMaxEnemy;       
        yield return new WaitForSeconds(1.5f);
        for(int i = 0; i < maxEnemy; i++)
        {
           Spawn(enemy1, maxEnemy);
           yield return new WaitForSeconds(0.5f);
        }
        
    }

    IEnumerator Wave2()
    {
        StartCoroutine(ShowWaveUI("WAVE 2"));
        int maxEnemy = baseMaxEnemy;

        yield return new WaitForSeconds(1.5f);
        for(int i = 0; i < maxEnemy; i++)
        {
            Spawn(enemy2, maxEnemy);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Wave3()
    {
        StartCoroutine(ShowWaveUI("WAVE 3"));
        yield return new WaitForSeconds(1.5f);
        SpawnBoss(boss);
        yield return new WaitForSeconds(1.7f);
        while (true)
        {
            bossScript.SetMove(false);
            for (int i = 0; i < 5; i++)
            {
                bulletPattern.ShootStraight();
                yield return new WaitForSeconds(0.4f);
            }
            yield return new WaitForSeconds(1f);
            bossScript.SetMove(true);
            yield return new WaitForSeconds(0.5f);
            bossScript.SetMove(false);
            for (int i = 0; i < 1; i++)
            {
                bulletPattern.ShootCircle();
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1f);
            bossScript.SetMove(true);
            yield return new WaitForSeconds(0.5f);
        }

    }

    void Spawn(GameObject enemy, int maxEnemy)
    {
        posX = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(posX, posY, 0);

        if (enemy == enemy1)
        {
            enemy1Pool.GetEnemy(pos);
        }
        else if (enemy == enemy2)
        {
            enemy2Pool.GetEnemy(pos);
        }

        currentEnemy++;
    }
    void SpawnBoss(GameObject boss)
    {
        Vector3 pos = new Vector3(0, 7.1f, 0);
        GameObject newBoss = Instantiate(boss,pos,Quaternion.identity);
        newBoss.transform.SetParent(transform,true);
        bulletPattern = newBoss.GetComponent<BulletPattern>();
        bulletPattern.Init(bulletBossPool);
        bossScript = newBoss.GetComponent<Boss>();
        uIManager.BossHPUI(newBoss);
    }

    public void EnemyDied()
    {
        currentEnemy--;
        if (currentEnemy < 0) currentEnemy = 0;
    }
    IEnumerator ShowWaveUI(string text)
    {
        waveText.gameObject.SetActive(true);
        waveText.text = text;
        yield return new WaitForSeconds(1.5f);
        waveText.gameObject.SetActive(false);
    }
}
