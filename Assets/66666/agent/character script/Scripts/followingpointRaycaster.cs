using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloInteractive.XR.HoloKit;

// 从光源到玩家发出一条虚拟射线，射线打到地板上，得出射线和地板的交点。
public class followingpointRaycaster : MonoBehaviour
{
    //public Vector3 ShadowTopPoint => shadowTopPoint;

    //[SerializeField] private Transform lightSource;

    //private Transform followingpoint;

    //private Transform centerEyePose;

    //private Transform pointX;

    //private Vector3 shadowTopPoint;

    //private GameObject lastHitFloorCube;

    //private void Start()
    //{
    //    var holokitCameraManager = FindObjectOfType<HoloKitCameraManager>();
    //    followingpoint = holokitCameraManager.center;
    //    pointX = holokitCameraManager.CenterEyePose;
    //}

    //private void Update()
    //{
    //    transform.position = new Vector3(centerEyePose.position.x, shadowTopPoint.y, centerEyePose.position.z);
    //    Vector3 rayDirection = (followingpoint.position - lightSource.position).normalized;
    //    Ray ray = new Ray(followingpoint.position, rayDirection);
    //    if (Physics.Raycast(ray, out var hitInfo))
    //    {
    //        if (hitInfo.transform.CompareTag("Floor"))
    //        {
    //            if (lastHitFloorCube != null)
    //                lastHitFloorCube.GetComponent<MeshRenderer>().material.color = Color.gray;

    //            hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.green;
    //            lastHitFloorCube = hitInfo.transform.gameObject;

    //            Debug.Log($"name: {hitInfo.transform.gameObject.name}, position: {hitInfo.point}");

    //            shadowTopPoint = hitInfo.point;
    //        }
    //    }
    //}
}

