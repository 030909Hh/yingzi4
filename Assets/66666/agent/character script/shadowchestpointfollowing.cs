using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloInteractive.XR.HoloKit;

public class shadowchestpointfollowing : MonoBehaviour
{
    [SerializeField] private LightSourcePlayerRaycaster raycaster;

    [SerializeField] private float chestRatio = 0.2f;

    [SerializeField] private Transform shadowChestPointVisualizer;

    private Transform centerEyePose;

    public Vector3 ShadowTopPoint => shadowTopPoint;

    [SerializeField] private Transform lightSource;

    private Vector3 shadowTopPoint;

    private GameObject lastHitFloorCube;

    public float smooth = 0.5f;

    [SerializeField] private Transform character;

    private bool isFollow = false;

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
        transform.position = new Vector3(centerEyePose.position.x, shadowTopPoint.y, centerEyePose.position.z);
        // Set shadow direction
        Vector3 shadowBottomToTop = shadowTopPoint - transform.position;
        transform.forward = shadowBottomToTop.normalized;
        // Set shadow scale
        //float shadowScale = shadowBottomToTop.magnitude;
        //transform.localScale = new Vector3(shadowScale, shadowScale, shadowScale);

        // Calculate shadow chest point
        Vector3 shadowChestPoint = shadowTopPoint - transform.forward * (1 * chestRatio);



        var playerFootPosition = new Vector3(centerEyePose.position.x, 0, centerEyePose.position.z);
        if (Vector3.Distance(playerFootPosition, character.transform.position) < 1f && !isFollow)
        {
            isFollow = true;
        }

        if (isFollow)
        {
            //character.position = shadowChestPoint;
            character.LookAt(centerEyePose);
            character.position = Vector3.Lerp(character.position, shadowChestPoint, smooth * Time.deltaTime);
        }
        else
        {

        }



    }
}
