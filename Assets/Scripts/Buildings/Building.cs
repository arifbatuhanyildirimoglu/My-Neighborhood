using System.Collections;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected string name;
    protected int purchasePrice;
    protected bool isOwned;
    protected bool isMakingMoney;
    protected float duration;
    protected float amount;

    protected IEnumerator MakeMoney(float duration, float amount)
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            Player.Instance.Budget += amount;
            //TODO: para çıkarıp ekranın sağ üstüne ekleme animasyonunu oynat
        }
    }

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