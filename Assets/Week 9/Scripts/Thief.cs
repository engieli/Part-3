using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

  
    public float dashSpeed = 7;
    Coroutine dashing;

    protected override void Attack()
    {
        //dash towards mouse
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       if(dashing != null )
        {
            StopCoroutine(dashing);
        }

       dashing = StartCoroutine(Dash() );
       
    }

    IEnumerator Dash()
    {
        speed += dashSpeed;
        while(speed > 3)
        {
            yield return null;
        }
        base.Attack();
        { 
        yield return new WaitForSeconds(0.1f);
            Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
            yield return new WaitForSeconds(0.1f)
        }
    }
    protected override void Update()
    {
        if(Dashing == true)
        {
            Dash();
        }
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
