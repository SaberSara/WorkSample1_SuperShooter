
/// ----SARASABER---2021-----
/// This is a template Script for MonoBehaviors Scripts suggested for editing
/// Please check out the naming convention Manuals Here: https://1drv.ms/w/s!AgDnFacvwTrJgaQlvHY2xl-0eH2pVg?e=REYund
/// Editable version Here: https://1drv.ms/w/s!AgDnFacvwTrJgaQlvHY2xl-0eH2pVg?e=REYund
/// Please duplicate the scripts ligns bellow in the "TemplatesScriptsMonoBehaviour.c" or script and leave it empty, you can duplicate this into a script newly made by you in the editor, 
/// or set up this template as a default unity emplate Script each time you generate a new empty script with replacing this file: https://1drv.ms/t/s!AgDnFacvwTrJgaQ2RrAA6EKnFilrAA?e=TJsnDj :)



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script to generate Enemy
/// Attached to the "EnemyProducer" GameObject
/// </summary>
public class EnemyProducer : MonoBehaviour
{
    #region PRIVATE_VARIABLES


    private Bounds spawnArea;
    private GameObject player;
    #endregion
    #region PUBLIC_VARIABLES
    public bool shouldSpawn;
    public Enemy[] enemyPrefabs;
    public float[] moveSpeedRange;
    public int[] healthRange;

    #endregion
    #region MONOBEHAVIOUR_METHODS
    #region MONOBEHAVIOUR_METHODS_PRIVATE
    //Example Method and comment
    private void Start()
    {
        spawnArea = this.GetComponent<BoxCollider>().bounds;
        SpawnEnemies(shouldSpawn);
        InvokeRepeating("SpawnEnemy", 0.5f, 1.0f);
    }
    #endregion
    #region PMONOBEHAVIOUR_METHODS_PUBLIC
    #endregion
    #endregion
    #region NON_MONOBEHAVIOUR_METHODS
    #region NON_MONOBEHAVIOUR_METHODS_PRIVATE

    private Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float z = Random.Range(spawnArea.min.z, spawnArea.max.z);
        float y = 0.5f;

        return new Vector3(x, y, z);
    }

    private void SpawnEnemy()
    {
        if(shouldSpawn==false || player == null)
        {
            return;
        }

        int index = Random.Range(0, enemyPrefabs.Length);
        var newEnemy = Instantiate(enemyPrefabs[index], RandomSpawnPosition(),
            Quaternion.identity) as Enemy;
        newEnemy.Initialize(player.transform,
            Random.Range(moveSpeedRange[0], moveSpeedRange[1]),
            Random.Range(healthRange[0], healthRange[1]));
    }    
    #endregion
    #region NON_MONOBEHAVIOUR_METHODS_PUBLIC
    public void SpawnEnemies(bool shouldSpawn)
    {
        if (shouldSpawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        this.shouldSpawn = shouldSpawn;
    }
    #endregion
    #endregion
}
