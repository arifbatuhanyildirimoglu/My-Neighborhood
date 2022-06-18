using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected int purchasePrice;
    protected bool isOwned;
    protected float duration;
    protected float amount;

    protected abstract void MakeMoney(float duration, float amount);
}