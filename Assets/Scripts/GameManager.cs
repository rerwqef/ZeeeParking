using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class GameManager : MonoBehaviour
{
    // Singleton instance
    private static GameManager _instance;
    public static  Action onGameStarted;
    public static  Action onGameFinished;
    public static  Action onGamePaused;
    public static  Action onGaMeOver;
   
    public static  Action LoadNewLevel;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    // Game variables
    public int level;
    public int carindex;
    public int fuel;
    public int coin;
    public int Buiedcars_num = 6;
    public String UserName=null;
    // Game objects and UI
/*    public string vr_enable="false";
    public int currentsterinngvalue=0;*/

    private UiManger uiManger;
 
  
  
   


    public bool pause;
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
       
        if (_instance == null)
        {
            _instance = this;
        
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Buiedcars_num = 6;
        // Load player data
        loadallldata();
    }
    private void OnEnable()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {
        // Log application data path
        uiManger = GameObject.FindGameObjectWithTag("uimg").GetComponent<UiManger>();
        onGamePaused += Pause;
        
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    // Load all player data from PlayerPrefs
    private void loadallldata()
    {
        carindex = PlayerPrefs.GetInt("carindex");
        coin = PlayerPrefs.GetInt("coin");
        level = PlayerPrefs.GetInt("level_index");
   /*     if (vr_enable != null)
        {
            vr_enable = PlayerPrefs.GetString("vr_enable");
        }
        if (currentsterinngvalue != 0)
        {
            currentsterinngvalue = PlayerPrefs.GetInt("currentsterinngvalue");
        }*/

    }
 /*   public void setcall(string m,int n)
    {
        PlayerPrefs.SetString("vr_enable",m);
       PlayerPrefs.SetInt("currentsterinngvalue", n);
    }*/
    // Save car index data to PlayerPrefs
    public void car_datasaving()
    {
        PlayerPrefs.SetInt("carindex", carindex);
    }

    // Save coin data to PlayerPrefs
    public void coin_dataSaving()
    {
        PlayerPrefs.SetInt("coin", coin);
    }

    // Save level data to PlayerPrefs
    public void level_datasaving()
    {
        PlayerPrefs.SetInt("level_index", level);
    }

    // Increase the level value
    public void level_value(int value)
    {
        level += value;
    }

    // Increase car index value
    public void carindexincreseer(int value)
    {
        carindex += value;
    }

    // Load a scene with a progress bar
    public void loadscene(int index)
    {
      
            if (pause)
            {
                Pause();
            } 
            StartCoroutine(loadscene_Coroutine(index));
        
    }

    // Coroutine to load a scene with a progress bar
    IEnumerator loadscene_Coroutine(int index)
    {
        uiManger.progressSlider.value = 0;
        uiManger.progress_pannel.SetActive(true);

        AsyncOperation asyncoperation = SceneManager.LoadSceneAsync(index);
        asyncoperation.allowSceneActivation = false;

        float progress = 0;
        while (!asyncoperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncoperation.progress, Time.deltaTime);
            uiManger.progressSlider.value = progress;

            if (uiManger.progressSlider.value >= 0.9f)
            {
                uiManger.progressSlider.value = 1;
                asyncoperation.allowSceneActivation = true;
            }

            yield return null;
        }
       
        uiManger = GameObject.FindGameObjectWithTag("uimg").GetComponent<UiManger>();       
    }

    // Restart the game by reloading the current scene
    public void RestartGame()
    {
        Pause();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Quit the game
    public void Quit()
    {
        Application.Quit();
    }

    // Game over logic
    public void gameover()
    {
        // Add game over logic here
    }

    // Load the next scene in the build order
    public void LoadNextScene(int index)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + index);
        uiManger = GameObject.FindGameObjectWithTag("uimg").GetComponent<UiManger>();
        Debug.Log("founded");
    }

    // Pause or resume the game
    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
        pause = !pause;

         
        if(uiManger == null)
        {
            uiManger = GameObject.FindGameObjectWithTag("uimg").GetComponent<UiManger>();
            Debug.Log("founded");
        }
        uiManger.Pause_pannel.SetActive(pause);

    }

    // Open settings logic
    public void OpenSettings()
    {
        // Add settings logic here
    }

    // Increase coin count
    public void coinincrese()
    {
        coin += 1000;
    }

    // Activate winning panel
    public void Activatewinningpannel()
    {
        int i = 0;
        if (i == 1)
        {
            Pause();
            i++;
        }
    //   uiManger.wimningpannel.SetActive(true);
    }

    // Activate failed panel
    public void failedingame()
    {
        Pause();
     //   uiManger.losepannel.SetActive(true);
    }
  
}