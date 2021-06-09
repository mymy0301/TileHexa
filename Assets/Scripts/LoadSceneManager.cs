using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    private void Awake()
    {
        instance = this;
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init();
            Debug.Log("FBInit is called with appID:" + FB.AppId);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Config.GetSound();
        Config.GetMusic();
        Config.currCoin = Config.GetCoin();
        Config.GetCurrLevel();
        Config.currPiggyBankCoin = Config.GetPiggyBank();
        Config.GetLevelStar();
        if (Config.isMusic)
        {
            MusicManager.instance.PlayMusicBG();
        }
        // Config.SetChestCountStar(15);
        StartCoroutine(LoadMenuScene_IEnumerator());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator LoadMenuScene_IEnumerator() {
        yield return new WaitForSeconds(2f);
        LoadMenuScene();
    }
    bool isLoadMenu = false;
    public void LoadMenuScene() {
        if (!isLoadMenu)
        {
            isLoadMenu = true;
            // if (Config.currLevel == 1)
            // {
            //     SceneManager.LoadSceneAsync("Play");
            //
            // }
            // else
            // {
            //     SceneManager.LoadSceneAsync("Menu");
            // }
            
            SceneManager.LoadSceneAsync("Menu");
        }
    }
}
