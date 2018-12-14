using UnityEngine;

public class Unit : MonoBehaviour
{
    public event System.Action<Unit> OnUnitDestroyed;

    public GamePlayManager GamePlay { set; private get; }

    private Animator animator;

    private Movement movement;

    private bool isDead;

    private float deathSpeed = 30f;
    
    protected float defaultSpeed = 1.2f;

    public float Speed => defaultSpeed + GamePlay.GetSpeedModifier();

    protected Transform selfTransform;
	
	void Start ()
    {
        movement = GetComponent<Movement>();
        movement.Unit = this;

        animator = GetComponent<Animator>();
        animator.speed = defaultSpeed;
	}
		
	void FixedUpdate ()
    {
        if (isDead)
            return;

        movement.Move();
	}

    public virtual void Kill()
    {
        isDead = true;

        animator.speed = deathSpeed;

        animator.SetTrigger("death");

        Destroy(GetComponent<SphereCollider>());
    }

    private void OnDestroy()
    {
        OnUnitDestroyed?.Invoke(this);
    }
}
