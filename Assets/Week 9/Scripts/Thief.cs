using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{

    public GameObject knifePrefab;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public float moveSpeed = 5f;
    public float boostedMoveSpeed = 10f;
    private bool isBoosted = false;



    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
        
        Instantiate(knifePrefab, spawnPoint3.position, spawnPoint3.rotation);


        if (Input.GetMouseButtonDown(1))
        {
            isBoosted = true;

        }

        if (isBoosted)
        {
            moveSpeed = boostedMoveSpeed;
        }
        else
        {
            moveSpeed = 5f;
        }

        Vector2 targetPosition = GetMouseWorldPosition();
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonUp(1))
        {
            isBoosted = false;
        }
       

    }
        private Vector2 GetMouseWorldPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
  
}
