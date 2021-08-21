
/// ----SARASABER---2021-----
/// This is a template Script for MonoBehaviors Scripts suggested for editing
/// Please check out the naming convention Manuals Here: https://1drv.ms/w/s!AgDnFacvwTrJgaQlvHY2xl-0eH2pVg?e=REYund
/// Editable version Here: https://1drv.ms/w/s!AgDnFacvwTrJgaQlvHY2xl-0eH2pVg?e=REYund
/// Please duplicate the scripts ligns bellow in the "TemplatesScriptsMonoBehaviour.c" or script and leave it empty, you can duplicate this into a script newly made by you in the editor, 
/// or set up this template as a default unity emplate Script each time you generate a new empty script with replacing this file: https://1drv.ms/t/s!AgDnFacvwTrJgaQ2RrAA6EKnFilrAA?e=TJsnDj :)



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// This is the Game controller scrpt (Game manager S)ss)
/// </summary>
public class GameController : MonoBehaviour
{
    #region PRIVATE_VARIABLES
    private SoundManager soundManager;
    #endregion
    #region PUBLIC_VARIABLES
    public EnemyProducer enemyProducer;
    public GameObject playerPrefab;
    public Text winText;
    public Text looseText;
    public Text countText;
    public Text healthText;
    public int enemyDeaths;
    public Canvas menuGameCanvas;
    public Canvas inGameCanvas;
    public Canvas winGameCanvas;
    public Canvas looseGameCanvas;
    
    
    #endregion
    #region MONOBEHAVIOUR_METHODS
    #region MONOBEHAVIOUR_METHODS_PRIVATE
    //Example Method and comment
    private void Start()
    {
        Time.timeScale = 0;
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.play("BG_MainGame");
        InitializeUI();
        enemyDeaths = 0;

        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onPlayerDeath += OnPlayerDeath;

        countText.text = GetKillCountText();
    }
    #endregion
    #region PMONOBEHAVIOUR_METHODS_PUBLIC

    #endregion
    #endregion
    #region NON_MONOBEHAVIOUR_METHODS
    #region NON_MONOBEHAVIOUR_METHODS_PRIVATE
    private void OnPlayerDeath(Player player)
    {
        enemyProducer.SpawnEnemies(false);
        Destroy(player.gameObject);
        looseText.text = "You Lose, Restarting game...";
        soundManager.continuePlayWithVolume("BG_MainGame", 0.6f);
        soundManager.play("SFX_LooseGame");
        looseGameCanvas.enabled = true; //Show the panel for the game etc ?
        inGameCanvas.enabled = false; //Show the panel for the game etc ?
        Invoke("RestartGame", 3);
        
    }


    private void InitializeUI()
    {
        winText.text = "";
        looseText.text = "";
        countText.text = "Kill count: 0";

        
        looseGameCanvas.enabled = false;
        winGameCanvas.enabled = false;
        inGameCanvas.enabled = false;
    }
   

    private void RestartGame()
    {
        soundManager.continuePlayWithVolume("BG_MainGame", 0.3f);
        enemyDeaths = 0;
        /*winText.text = "";
        countText.text = "";*/
        //Replaced by InitializeUI()
        InitializeUI();
        menuGameCanvas.enabled = false;
        looseGameCanvas.enabled = false;
        winGameCanvas.enabled = false;
        inGameCanvas.enabled = true;
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var enemy in enemies)
        {
            Destroy(enemy);
        }

        var playerObject = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0),
        Quaternion.identity) as GameObject;
        var cameraRig = Camera.main.GetComponent<CameraRig>();
        cameraRig.target = playerObject;
        enemyProducer.SpawnEnemies(true);
        playerObject.GetComponent<Player>().onPlayerDeath += OnPlayerDeath;
    }


    private void StopEnemies()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var enemy in enemies)
        {
            Destroy(enemy);
        }

        var enemyProducer = GameObject.Find("EnemyProducer");
        Destroy(enemyProducer);
    }

    private void StopEnemiesForRestartGame()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
    }



        private String GetKillCountText()
    {
        return "Kill count: " + enemyDeaths;
    }


    #endregion
    #region NON_MONOBEHAVIOUR_METHODS_PUBLIC
    public void OnEnemyDeath()
    {
        enemyDeaths++;
        countText.text = GetKillCountText();
        soundManager.play("SFX_Count");

        if (enemyDeaths >= 5)
        {
            winText.text = "Sara WINS!";
            soundManager.continuePlayWithVolume("BG_MainGame", 0.6f);
            soundManager.play("SFX_WinGame");
            StopEnemies();
        winGameCanvas.enabled = true; //Show the panel for the game etc ?
            Invoke("ReloadGameScene", 3);
                   }
    }

    public void ReloadGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    public void OnClickStartGame()
    {
        soundManager.continuePlayWithVolume("BG_MainGame", 0.3f);
        menuGameCanvas.enabled = false;
        looseGameCanvas.enabled = false;
        winGameCanvas.enabled = false;
        inGameCanvas.enabled = true;
        Time.timeScale = 1;
    }
    public void OnClickRestartGame()
    {
        CancelInvoke();
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyProducer.SpawnEnemies(false);
        Destroy(player.gameObject);
        //We want to have the player disapear then the enemies then restart the game into an empty scene
        Invoke("StopEnemiesForRestartGame", 1);
        //Play some effects ?
        Invoke("RestartGame", 2);
    }
    
    
    public void OnClickQuitGame()
    {
        Application.Quit();
    }
    //Not used
    public void SetUI(string winText, string looseText, string countText)
    {
        this.winText.text = winText;
        this.looseText.text = looseText;
        this.countText.text = countText;
    }
    #endregion
    #endregion
}
