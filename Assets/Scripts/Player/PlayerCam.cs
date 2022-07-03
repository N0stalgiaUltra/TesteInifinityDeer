using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;

    public void SetCamera(Transform player)
    {
        cam.Follow = player;
        cam.LookAt = player;
    }
}
