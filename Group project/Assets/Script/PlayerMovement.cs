using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float Speed;

    private CharacterController characterController;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMove();
    }


    private void PlayerMove()
    {
        float horizontalInput = Input.GetAxis(horizontalInputName) * Speed;
        float verticleInput = Input.GetAxis(verticalInputName) * Speed;

        Vector3 MoveX = transform.forward * verticleInput;  //forward and back
        Vector3 MoveY = transform.right * horizontalInput;  // left and right

        characterController.SimpleMove(MoveX + MoveY);
    }
}
