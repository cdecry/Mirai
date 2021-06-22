using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScroll : MonoSingleton<cameraScroll>
{
    protected override void Init()
    {
        base.Init();
    }

    public Vector3 targetPos;

    private float smoothSpeed = 1f;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        targetPos = Instance.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(targetPos.x, targetPos.y, -50);
        Instance.transform.position = Vector3.SmoothDamp(Instance.transform.position, desiredPosition, ref Instance.velocity, Instance.smoothSpeed);
    }

}
