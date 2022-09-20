using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    private float timeRemaining;
    private int direction;
    private Collider2D loot;
    private Collider2D enemy;
    private int weaponDamage;
    private int typeOfWeapon;
    [SerializeField] private AudioSource sound1;
    [SerializeField] private AudioSource sound2;
    [SerializeField] private AudioSource sound3;
    public int damageOfHammer;
    public int damageOfSword;
    public int damageOfSycthe;

    private void Awake()
    {
        weaponDamage = 50;
        direction = 3;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        typeOfWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().typeOfWeapon;
        animator = GetComponent<Animator>();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SetAnimations(overrideControllers[0]);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            SetAnimations(overrideControllers[0]);
        }

        if(typeOfWeapon == 0)
        {
            weaponDamage = damageOfHammer;
        }
        else if (typeOfWeapon == 1)
        {
            weaponDamage = damageOfSword;
        }
        else if (typeOfWeapon == 2)
        {
            weaponDamage = damageOfSycthe;
        }
    }

    public void Attack(int typeOfWeapon)
    {
        
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0f);

        if (typeOfWeapon == 0)
        {
            timeRemaining = 0.95f;
            if (direction == 1)
            {
                SetAnimations(overrideControllers[3]);
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (direction == 2)
            {
                SetAnimations(overrideControllers[2]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[1]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[2]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }

            if (!sound1.isPlaying)
            {
                sound1.Play();
            }
        }
        else if (typeOfWeapon == 1)
        {
            timeRemaining = 0.55f;
            if (direction == 1)
            {
                SetAnimations(overrideControllers[6]);
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (direction == 2)
            {
                SetAnimations(overrideControllers[5]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[4]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[5]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }

            if (!sound2.isPlaying)
            {
                sound2.Play();
            }
        }
        else if (typeOfWeapon == 2)
        {
            timeRemaining = 0.55f;
            if (direction == 1)
            {
                SetAnimations(overrideControllers[9]);
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (direction == 2)
            {
                SetAnimations(overrideControllers[8]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[7]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[8]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }

            if (!sound3.isPlaying)
            {
                sound3.Play();
            }
        }

        if (loot != null)
        {
            loot.GetComponent<Loot>().receiveDamage(weaponDamage);
        }

        if (enemy != null)
        {
            enemy.GetComponent<EnemyHp>().DecreaseEntityHp(weaponDamage);
        }
    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }

    public void setDirection(int direction)
    {
        this.direction = direction;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (typeOfWeapon == 0 || typeOfWeapon == 2)
        {
            if (other.gameObject.CompareTag("Stone"))
            {
                loot = other;
            }

            if (other.gameObject.CompareTag("Tree"))
            {
                loot = other;
            }
        }

        if (typeOfWeapon == 1 || typeOfWeapon == 2)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                enemy = other;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        loot = null;
    }
}
