using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coinCount {get; private set;} = 0;
    public int lifeCount {get; private set;} = 3;

    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(lifeCount <= 0)
        {
            GameOver();
        }
    }
    public void AddCoin()
    {
        coinCount++;
    }
    public bool UseCoin(int amount)
    {
        if(coinCount >= amount)
        {
            coinCount -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void LoseLife(int amount = 1)
    {
        lifeCount -= amount;
    }
    void GameOver()
    {
        //게임 오버 처리
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //reset player stats
        coinCount = 0;
        lifeCount = 3;
    }
}
