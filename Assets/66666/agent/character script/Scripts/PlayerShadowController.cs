using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloInteractive.XR.HoloKit;

public class PlayerShadowController : MonoBehaviour
{
    [SerializeField] private LightSourcePlayerRaycaster raycaster;

    [SerializeField] private float chestRatio = 0.2f;

    [SerializeField] private Transform shadowChestPointVisualizer;

    private Transform centerEyePose;

    private void Start()
    {
        var holokitCameraManager = FindObjectOfType<HoloKitCameraManager>();
        centerEyePose = holokitCameraManager.CenterEyePose;
    }

    private void Update()
    {
        // Shadow top point position
        Vector3 shadowTopPoint = raycaster.ShadowTopPoint;
        // Set shadow position (shadow botton)
        //transform.position = new Vector3(centerEyePose.position.x, shadowTopPoint.y, centerEyePose.position.z);
        // Set shadow direction
        Vector3 shadowBottomToTop = shadowTopPoint - transform.position;
        //transform.forward = shadowBottomToTop.normalized;
        // Set shadow scale
        float shadowScale = shadowBottomToTop.magnitude;
        //transform.localScale = new Vector3(shadowScale, shadowScale, shadowScale);

        // Calculate shadow chest point
        Vector3 shadowChestPoint = shadowTopPoint - transform.forward * (shadowScale * chestRatio);
        shadowChestPointVisualizer.position = shadowChestPoint;
    }
}
