using AxGrid.Base;
using CodeBase.Constants;
using UnityEngine;
public class PlayerCollector : MonoBehaviourExt
{
    [Header("SphereCast Settings")]
    public float radius = 1f;
    public float sradius = 1f;
    public LayerMask layerMask = ~0;
    public bool showGiszmos;
    
    [Space]
    public Transform currentTarget;
    public PlayerMover playerMover;

    [OnUpdate]
    private void FoundCoin()
    {
        var coins = Physics.OverlapSphere(transform.position, radius, layerMask, QueryTriggerInteraction.Collide);
        if (coins.Length > 0 && Model.GetBool(ModelConstants.PLAYER_LOOTING_STATE))
        {
            currentTarget = coins[0].transform;
            playerMover.SetTarget(currentTarget.position);
            playerMover.CantMove(false);
            playerMover.Move();
            VacuumCoinsAround();
        }
        else
        {
            playerMover.CantMove(true);
        }
    }

    private void VacuumCoinsAround()
    {
        var coins = Physics.OverlapSphere(transform.position, sradius, layerMask, QueryTriggerInteraction.Collide);
        foreach (var c in coins)
        {
            c.GetComponent<Coin>().TakeCoin();
        }
    }

    private void OnDrawGizmos()
    {
        if (showGiszmos)
        {
            Gizmos.color = new Color(1f, 1f, 0f, 0.2f);
            Gizmos.DrawSphere(transform.position, radius);
        }
    }

}