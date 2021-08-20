
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
/// Projectile script
/// Attached to the "Projectile" GameObject
/// </summary>
public class Projectile : MonoBehaviour
{
    #region PRIVATE_VARIABLES
    private Vector3 shootDirection;
    #endregion
    #region PUBLIC_VARIABLES
    public float speed;
    public int damage;
    #endregion
    #region MONOBEHAVIOUR_METHODS
    #region MONOBEHAVIOUR_METHODS_PRIVATE
    //Example Method and comment
    private void FixedUpdate()
    {
        this.transform.Translate(shootDirection * speed, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
        if(enemy)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
    #endregion
    #region PMONOBEHAVIOUR_METHODS_PUBLIC

    #endregion
    #endregion
    #region NON_MONOBEHAVIOUR_METHODS
    #region NON_MONOBEHAVIOUR_METHODS_PRIVATE
    private void RotateInShootDirection()
    {
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, shootDirection, 0.01f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }
    #endregion
    #region NON_MONOBEHAVIOUR_METHODS_PUBLIC
    public void FireProjectile(Ray shootRay)
    {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
        RotateInShootDirection();
    }
    #endregion
    #endregion
}
