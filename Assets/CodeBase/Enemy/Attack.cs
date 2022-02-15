using System.Linq;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
  [RequireComponent(typeof(EnemyAnimator))]
  public class Attack : MonoBehaviour
  {
    public EnemyAnimator Animator;

    public float AttackCooldown = 3.0f;
    public float Cleavage = 0.5f;
    public float EffectiveDistance = 0.5f;
    public float Damage = 10;
    
    private Transform _heroTransform;
    private float _attackCooldown;
    private bool _isAttacking;
    private Collider[] _hits = new Collider[1];
    private int _layerMAsk;
    private bool _attackIsActive;

    private void Awake()
    {
      _layerMAsk = 1 << LayerMask.NameToLayer("Player");
    }

    private void Update()
    {
      UpdateCooldown();

      if(CanAttack())
        StartAttack();
    }

    public void Construct(Transform heroTransform) => 
      _heroTransform = heroTransform;

    private void OnAttack()
    {
      if (Hit(out Collider hit))
      {
        //PhysicsDebug.DrawDebug(StartPoint(), Cleavage, 1.0f);
        hit.transform.GetComponent<IHealth>().TakeDamage(Damage);
      }
    }

    private void OnAttackEnded()
    {
      _attackCooldown = AttackCooldown;
      _isAttacking = false;
    }

    public void DisableAttack()
    {
      _attackIsActive = false;
    }

    public void EnableAttack()
    {
      _attackIsActive = true;
    }

    private bool CooldownIsUp()
    {
      return _attackCooldown <= 0f;
    }

    private void UpdateCooldown()
    {
      if (!CooldownIsUp())
        _attackCooldown -= Time.deltaTime;
    }

    private bool Hit(out Collider hit)
    {
      var hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), Cleavage, _hits, _layerMAsk);

      hit = _hits.FirstOrDefault();
      
      return hitAmount > 0;
    }

    private Vector3 StartPoint()
    {
      return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
             transform.forward * EffectiveDistance;
    }

    private bool CanAttack()
    {
      return _attackIsActive && !_isAttacking && CooldownIsUp();
    }

    private void StartAttack()
    {
      transform.LookAt(_heroTransform);
      Animator.PlayAttack();
      _isAttacking = true;
    }
  }
}