using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 3;
    Vector2 rightAttackOffset;
    Collider2D swordCollider;
    private void Start() {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }

    public void AttackRight(){
        Debug.Log("attack right");
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    public void AttackLeft(){
        Debug.Log("attack left");
        swordCollider.enabled = false;
        transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack(){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            // Deal damage to enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null){
                enemy.Health -= damage;
            }
        }
    }
}
