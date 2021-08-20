
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


/// <summary>
/// This is the Game controller scrpt (Game manager S)ss)
/// </summary>
public class GameController : MonoBehaviour
{
    #region PRIVATE_VARIABLES
    #endregion
    #region PUBLIC_VARIABLES
    public EnemyProducer enemyProducer;
    public GameObject playerPrefab;
    public Text winText;
    public Text countText;
    public int enemyDeaths;
    #endregion
    #region MONOBEHAVIOUR_METHODS
    #region MONOBEHAVIOUR_METHODS_PRIVATE
    //Example Method and comment
    private void Start()
    {
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

        Invoke("RestartGame", 3);
    }


    private void RestartGame()
    {
        enemyDeaths = 0;
        winText.text = "";
        countText.text = "";
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

        if (enemyDeaths >= 5)
        {
            winText.text = "Sara WINS!";
            StopEnemies();
        }
    }
    #endregion
    #endregion
}