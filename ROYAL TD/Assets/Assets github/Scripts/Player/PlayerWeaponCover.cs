using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCover : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    private float timeRemaining;
    private int direction;
    public float nextFireTime;

    private void Awake()
    {
        direction = 3;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void Attack(int typeOfWeapon)
    {
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0f);

        if (typeOfWeapon == 0)
        {
            timeRemaining = 0.95f;
            if (direction == 2)
            {
                SetAnimations(overrideControllers[2]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[1]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[2]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
        }
        else if (typeOfWeapon == 1)
        {
            timeRemaining = 0.55f;
            if (direction == 2)
            {
                SetAnimations(overrideControllers[4]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[3]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[4]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
        }
        else if (typeOfWeapon == 2)
        {
            timeRemaining = 0.55f;
            if (direction == 2)
            {
                SetAnimations(overrideControllers[6]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[5]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[6]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
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

}
