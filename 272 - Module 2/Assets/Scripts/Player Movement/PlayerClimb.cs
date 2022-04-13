using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private Transform goTo;

    private PlayerAnimator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void MovePlayer()
    {
        transform.position = goTo.position;
        playerAnimator.SetClimbing(false);
    }
}
