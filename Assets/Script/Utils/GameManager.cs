using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int world{ get; private set;}
    public int stage {get; private set;}
    public int lives {get; private set;}
    public int coins {get; private set;}
    public int score {get; private set;}

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this){
            Instance = null;
        }
    }

    private void Start(){
        Application.targetFrameRate = 60;
        //NewGame();    
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;
        score = 0;
        LoadLevel(1, 1);
    }
    public void LoadLevel(int world, int stage){
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        //  if(world == 1 && stage == 10){
        //  Loadlevel(world +1 , 1);
        // }
        //use it when you impelement other world
        //
        LoadLevel(world, stage + 1 );

    }
    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }
    public void ResetLevel()
    {
        lives--;

        if(lives > 0){
            LoadLevel(world,stage);
        }else {
            GameOver();
        }
    }
    private void GameOver()
    {
        //change it when you done with the game
        Invoke(nameof(NewGame), 3f);
    }

    public void AddCoin()
    {
        AddScore(200);
        coins++;
        if(coins == 100)
        {
            AddLife();
            coins = 0;
        }
    }

    public void AddLife(){
        lives++;
    }

     public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void ChangeTimeScale(float newTimeScale)
    {
        Time.timeScale = newTimeScale;

        // delete it if you dont use it
    }  

}
