using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private Transform goTo;

    private PlayerAnimator playerAnimator;
    private PlayerMove playerMove;

    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerMove = GetComponent<PlayerMove>();
    }

    public void MovePlayer()
    {
        transform.position = goTo.position;
        playerAnimator.SetClimbing(false);
        playerMove.SetCanMove(true);
        playerAnimator.SetCanTurn(true);
        playerAnimator.ResetTurn();
    }
}
