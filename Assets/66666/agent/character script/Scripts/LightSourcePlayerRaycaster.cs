using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloInteractive.XR.HoloKit;

// 从光源到玩家发出一条虚拟射线，射线打到地板上，得出射线和地板的交点。
public class LightSourcePlayerRaycaster : MonoBehaviour
{
    public Vector3 ShadowTopPoint => shadowTopPoint;

    [SerializeField] private Transform lightSource;

    private Transform centerEyePose;

    private Vector3 shadowTopPoint;

    private GameObject lastHitFloorCube;

    private void Start()
    {
        var holokitCameraManager = FindObjectOfType<HoloKitCameraManager>();
        centerEyePose = holokitCameraManager.CenterEyePose;
    }

    private void Update()
    {
        Vector3 rayDirection = (centerEyePose.position - lightSource.position).normalized;
        Ray ray = new Ray(centerEyePose.position, rayDirection);
        if (Physics.Raycast(ray, out var hitInfo))
        {
            if (hitInfo.transform.CompareTag("Floor"))
            {
                //if (lastHitFloorCube != null)
                //    lastHitFloorCube.GetComponent<MeshRenderer>().material.color = Color.gray;

                //hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.black;
                //lastHitFloorCube = hitInfo.transform.gameObject;

                Debug.Log($"name: {hitInfo.transform.gameObject.name}, position: {hitInfo.point}");

                shadowTopPoint = hitInfo.point;

                    }
        }
    }
}

