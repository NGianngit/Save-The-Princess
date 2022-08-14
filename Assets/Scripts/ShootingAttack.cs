using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : MonoBehaviour
{
    Animator animator;
    private Input input;
    public GameObject Sword;
    public GameObject Bow;
    public GameObject projectile;
    bool hasShot;
    public float recoil;
    public float Delay;


    // Start is called before the first frame update
    void Start()
    {
        //call animator//
        animator = GetComponent<Animator>();
        //on press of right click shoot arrow
        input.Player.Shooting.started += ctx => shoot();
        //on let go of right click stop shooting arrow
        input.Player.Shooting.canceled += ctx => stopShoot();
    }


    private void stopShoot()
    {
        animator.SetBool("IsShooting", false);
    }
    private void shoot()
    {
        //Disable Sword and activate bow
        Sword.SetActive(false);
        Bow.SetActive(true);
        
        if (animator.GetBool("IsRunning"))
        {
            animator.SetBool("IsShooting", false);
        }
        else
        {
            if (!hasShot)
            {                
                animator.SetBool("IsShooting", true);
                StartCoroutine(pause());
                
                hasShot = true;
                Invoke(nameof(ResetAttack), recoil);
            }
        }       
    }

    private void ResetAttack()
    {
        animator.SetBool("IsShooting", false);
        hasShot = false;
    }

    IEnumerator pause()
    {       
        yield return new WaitForSeconds(Delay);

        //Attack code here
        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        //End of attack code
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

