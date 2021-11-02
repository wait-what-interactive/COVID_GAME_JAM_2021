using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform pointMoveToBottom = null;
    public Transform pointMoveToTop = null;

    public Transform GetPointMoveTo(float v_axis)
    {
        return v_axis > 0 ? pointMoveToTop : pointMoveToBottom;
    }
}
