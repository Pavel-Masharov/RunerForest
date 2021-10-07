using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject lostMenuGame;

    private SpawnManager spawnManager;

    private AudioSource gameAudio;

    public static int monets;
    public static bool isGameOver { get; private set; } = true;
    public static int score { get; private set; }
    public static int scoreRecord { get; private set; }
    public static float speedEnemy { get; private set; } = 4;

    private float interval = 15;

    public bool isScoreMore = false;

    private void Awake()
    {
        gameAudio = GetComponent<AudioSource>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Load();
    }
    private void Start()
    {
        lostMenuGame.SetActive(false);
    }

    void Update()
    {
        SaveRecordScore();
        Debug.Log(score);
    }

    public void StartGame()
    {
        score = 0;
        isGameOver = false;
        StartCoroutine(GameTimer());
        StartCoroutine(GameOperation());
        spawnManager.StartSpawnEnemy();
        gameAudio.Play();
    }

    IEnumerator GameTimer()
    {
        while(isGameOver == false)
        {
            yield return new WaitForSeconds(ScoreMore());
            score++;
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        lostMenuGame.SetActive(true);
        Save();
        Debug.Log("ÈÃÐÀ ÎÊÎÍ×ÅÍÀ");
    }


    IEnumerator GameOperation()
    {
        while (isGameOver == false)
        {
            yield return new WaitForSeconds(interval);
            speedEnemy++;
        }
    }

    private void SaveRecordScore()
    {
        if(score > scoreRecord)
        {
            scoreRecord = score;
        }
    }
    private float ScoreMore()
    {
        float secondScore;
        if(isScoreMore)
        {
            secondScore = 0.3f;
        }
        else
        {
            secondScore = 1.0f;
        }
        return secondScore;
    }

    [System.Serializable]
    class SaveData
    {
        public int Record;
        public int Dollars;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.Record = scoreRecord;
        data.Dollars = monets;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            scoreRecord = data.Record;
            monets = data.Dollars;
        }
    }
}
