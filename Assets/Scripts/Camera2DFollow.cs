using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = Player.position + offset;
    }
}
