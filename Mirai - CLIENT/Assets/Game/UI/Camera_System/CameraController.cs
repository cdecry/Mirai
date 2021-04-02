using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Follows a GameObject in a Smooth way and with various settings
/// Author: Manuel Otheo (@Lootheo) with guidance from Hasan Bayat (EmpireWorld)
/// 
/// https://www.reddit.com/r/Unity3D/comments/6iskah/movetowards_vs_lerp_vs_slerp_vs_smoothdamp/
/// How to use: Attach it to a GameObject and then assign the target to follow and the variables like offset and speed
/// If it's not moving check the speed
/// 
/// TODO: Make more efficient usage of the vector3 to vector2;
/// </summary>
/// 
public class CameraController : MonoSingleton<CameraController>
{
    protected override void Init()
    {
        base.Init();
    }

        

    #region Fields

    public Transform target;
    public Vector3 speed;
    public Vector3 time;
    public Vector3 acceleration;
    public Vector3 offset;
    public bool bounds;
    public Vector3 lowerBounds;
    public Vector3 higherBounds;
    public GameObject UserInterface;
    #endregion

    #region Variables

    public Vector3 velocity;
    public Vector3 step;
    public Vector3 localSpeed;

    #endregion

    #region MonoBehaviour Messages

    void Awake()
    {
        UserInterface = GameObject.Find("UI_Panel");
    }

    protected virtual void Update()
    {

        // Exit if the target object not specified
        /*if (target == null)
        {
            return;
        }

        switch (followType)
        {
            case FollowType.MoveTowards:
                MoveTowards();
                break;
            case FollowType.Lerp:
                Lerp();
                break;
            case FollowType.Slerp:
                Slerp();
                break;
            case FollowType.SmoothDamp:
                SmoothDamp();
                break;
            case FollowType.Acceleration:
                Acceleration();
                break;
        }*/
    }

    #endregion

    #region Methods

    protected virtual void MoveTowards()
    {
        //step = speed * Time.deltaTime;
        //transform.position = new Vector2(Vector2.MoveTowards(transform.position, (Vector2)target.position + offset, step.x).x, Vector2.MoveTowards(transform.position, (Vector2)target.position + offset, step.x).y);
        //transform.position = new Vector2(Vector2.MoveTowards(transform.position, new Vector2(5, 0), step.x).x, Vector2.MoveTowards(transform.position, new Vector2(0, 5), step.x).y);
    }

    // should only move fixed amount ? (perhaps depending on location)
    public static void CameraRight()
    {
        Instance.step = Instance.speed * Time.deltaTime;
        Instance.transform.position = new Vector3(Vector3.MoveTowards(Instance.transform.position, new Vector3(200, 0, 0), Instance.step.x).x, Vector3.MoveTowards(Instance.transform.position, new Vector3(0, 0, 0), Instance.step.x).y, Vector3.MoveTowards(Instance.transform.position, new Vector3(0,0,-50), Instance.step.z).z);
        Instance.UserInterface.transform.position = new Vector3(Vector3.MoveTowards(Instance.UserInterface.transform.position, new Vector3(200, 0, 0), Instance.step.x).x, Vector3.MoveTowards(Instance.UserInterface.transform.position, new Vector3(0, 0, 0), Instance.step.x).y, Vector3.MoveTowards(Instance.UserInterface.transform.position, new Vector3(0, 0, 0), Instance.step.z).z);
    }

    public static void CameraLeft()
    {
        Instance.step = Instance.speed * Time.deltaTime;
        Instance.transform.position = new Vector3(Vector3.MoveTowards(Instance.transform.position, new Vector3(-200, 0, 0), Instance.step.x).x, Vector3.MoveTowards(Instance.transform.position, new Vector3(0, 0, 0), Instance.step.x).y, Vector3.MoveTowards(Instance.transform.position, new Vector3(0, 0, -50), Instance.step.z).z);
        Instance.UserInterface.transform.position = new Vector3(Vector3.MoveTowards(Instance.UserInterface.transform.position, new Vector3(-200, 0, 0), Instance.step.x).x, Vector3.MoveTowards(Instance.UserInterface.transform.position, new Vector3(0, 0, 0), Instance.step.x).y, Vector3.MoveTowards(Instance.UserInterface.transform.position, new Vector3(0, 0, 0), Instance.step.z).z);
    }

    #endregion

}