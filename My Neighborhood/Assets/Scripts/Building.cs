using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected string name;
    protected int purchasePrice;
    protected bool isOwned;
    protected float duration;
    protected float amount;

    protected abstract void MakeMoney(float duration, float amount);

    public string Name => name;
    
    public int PurchasePrice
    {
        get => purchasePrice;
    }
    
    public bool IsOwned
    {
        get => isOwned;
        set => isOwned = value;
    }

    public float Duration => duration;

    public float Amount => amount;
}