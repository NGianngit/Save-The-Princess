using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackForPlayer : MonoBehaviour
{
    Animator animator;
    private Input input;
    public GameObject handSword;
    public GameObject handBow;
    // Start is called before the first frame update
    void Start()
    {
        //call animator//
        animator = GetComponent<Animator>();
        //on press of leftclick swing sword
        input.Player.Attack.started += ctx => attack();
        //on let go of left click stop swinging sword
        input.Player.Attack.canceled += ctx => stopAttack();
    }


    private void stopAttack()
    {
        animator.SetBool("IsAttacking", false);
    }
    private void attack()
    {
        handSword.SetActive(true);
        handBow.SetActive(false);
        animator.SetBool("IsAttacking", true);
        
    }
    private void Awake()
    {
        input = new Input();
    }
    private void OnEnable()
    {
        input.Enable();

    }
    private void OnDisable()
    {
        input.Disable();

    }

    
}

