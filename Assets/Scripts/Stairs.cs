using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform pointMoveToBottom;
    public Transform pointMoveToTop;

    public Transform GetPointMoveTo(float v_axis)
    {
        return v_axis > 0 ? pointMoveToTop : pointMoveToBottom;
    }
}
