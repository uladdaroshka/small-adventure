using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
  public class AgentMoveToPlayer : Follow
  {
    private const float MinimalDistance = 1;
    
    public NavMeshAgent Agent;
    
    private Transform _heroTransform;
    private IGameFactory _gameFactory;

    private void Update() => 
      SetDestinationForAgent();

    public void Construct(Transform heroTransform) => 
      _heroTransform = heroTransform;

    private void SetDestinationForAgent()
    {
      if (IsHeroNotReached())
        Agent.destination = _heroTransform.position;
    }

    private bool IsHeroNotReached() => 
      Agent.transform.position.SqrMagnitudeTo(_heroTransform.position) >= MinimalDistance;
  }
}