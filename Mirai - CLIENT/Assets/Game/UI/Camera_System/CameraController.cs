using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoSingleton<CameraController>
{
    protected override void Init()
    {
        base.Init();
    }


    private Func<Vector3> GetCameraFollowPositionFunc;

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    void Update()
    {
        /*Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;
        transform.position = cameraFollowPosition;*/
    }

    public void cameraRight()
    {
        transform.position = new Vector3(1, 0, transform.position.z);
    }


}
