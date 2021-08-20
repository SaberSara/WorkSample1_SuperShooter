
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
/// Shooting Script for the player
/// Attached to the "Player" gameObject
/// </summary>
public class PlayerShooting : MonoBehaviour
{
    #region PRIVATE_VARIABLES
    #endregion
    #region PUBLIC_VARIABLES
    public Projectile projectilePrefab;
    public LayerMask mask;
    #endregion
    #region MONOBEHAVIOUR_METHODS
    #region MONOBEHAVIOUR_METHODS_PRIVATE
    //Example Method and comment
    private void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if(mouseButtonDown)
        {
            RaycastOnMouseClick();
        }
    }
    #endregion
    #region PMONOBEHAVIOUR_METHODS_PUBLIC
    #endregion
    #endregion
    #region NON_MONOBEHAVIOUR_METHODS
    #region NON_MONOBEHAVIOUR_METHODS_PRIVATE
    private void Shoot(RaycastHit hit)
    {
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        var pointAbobeFloor = hit.point + new Vector3(0, this.transform.position.y, 0);
        var direction = pointAbobeFloor - transform.position;
        var shootRay = new Ray(this.transform.position, direction);
        //Uncomment if you want to debug the ray shoots
        //Debug.DrawRay(shootRay.origin, shootRay.direction * 100.0f, Color.green, 2f);
        
        Physics.IgnoreCollision(GetComponent<Collider>(),
            projectile.GetComponent<Collider>());
        projectile.FireProjectile(shootRay);
    }

    private void RaycastOnMouseClick()
    {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Uncomment if you want to debug the ray shoots
        //Debug.DrawRay(rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2f);

        if(Physics.Raycast(rayToFloor,out hit,100.0f,mask,
            QueryTriggerInteraction.Collide))
        {
            Shoot(hit);
        }
    }
    #endregion
    #region NON_MONOBEHAVIOUR_METHODS_PUBLIC
    #endregion
    #endregion
}
