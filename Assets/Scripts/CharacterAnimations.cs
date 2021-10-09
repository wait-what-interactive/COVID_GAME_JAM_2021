using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Character _character;

    private void Start()
    {
        _character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    public void EndShootAnimation()
    {
        _character.EndShoot();
    }

    //public void EndJumpAnimation()
    //{
    //    _character.EndJump();
    //}
}
