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

    private GameObject revivePanel;

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
        NewGame();    
    }
    public void FindRevivePanel()
    {
        // RevivePanel adlı GameObject'i sahnede ara
        revivePanel = GameObject.FindWithTag("RevivePanel");

        // Eğer RevivePanel bulunamazsa hata mesajı yazdır
        if (revivePanel == null)
        {
            Debug.LogError("RevivePanel not found in the scene!");
        }
        revivePanel.SetActive(false);
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;
        score = 0;
    }
    public void LoadLevel(int world, int stage){
        this.world = world;
        this.stage = stage;
        
        SceneManager.LoadScene($"{world}-{stage}");
        
        // Activate the scene loader panel for 3 seconds
        Invoke("FindRevivePanel", 0.02f);
        
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
        //GameOverLoad(1,0);
        //NewGame();
        revivePanel.SetActive(true);
    }
    public void AddlifeAddLevelLoader()
    {
        this.world = world;
        this.stage = stage;
        LoadLevel(world,stage);
    }

    public void GameOverLoad(int world, int stage){
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
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
}
