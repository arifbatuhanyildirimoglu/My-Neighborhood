using System.Collections;
using DG.Tweening;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected string name;
    protected int purchasePrice;
    protected bool isOwned;
    protected bool isMakingMoney;
    protected float duration;
    protected float amount;
    [SerializeField] private GameObject money;

    protected IEnumerator MakeMoney(float duration, float amount)
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            Player.Instance.Budget += amount;
            GameObject instantiatedMoney = Instantiate(money, transform.position,
                Quaternion.LookRotation(Camera.main.transform.position));
            instantiatedMoney.transform.DOMove(Player.Instance.transform.position, 0.3f)
                .OnComplete(() => Destroy(instantiatedMoney));
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