using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMarket : MonoBehaviour
{
    public BuySlotTemplate prefab;
    public int count;

    public Item teeth;
    public Item bones;
    public Item eyeball;
    public Item heart;
    public Item brain;
    public Item _scarecrow;
    public Item _ashes;
    public Item _fire;
    public Item _zombie;

    private void Start()
    {
        //teeth seeds
        BuySlotTemplate teethSeeds = Instantiate(prefab, transform);
        teethSeeds.name.text = "Teeth Seeds";
        teethSeeds.cost.text = "5";
        teethSeeds.item.sprite = teeth.itemSprite;
        teethSeeds.buy.onClick.AddListener(delegate
            {
                if( (Currency.singleton.myMoney - 5) >= 0)
                {
                    Inventory.singleton.AddItem(teethSeeds.item);
                    Currency.singleton.TakeMoney(5);
                }
            }
        );

        //bone seeds
        BuySlotTemplate boneSeeds = Instantiate(prefab, transform);
        boneSeeds.name.text = "Bone Seeds";
        boneSeeds.cost.text = "5";
        boneSeeds.item.sprite = bones.itemSprite;
        boneSeeds.buy.onClick.AddListener(delegate
            {
                if( (Currency.singleton.myMoney - 5) >= 0)
                {
                    Inventory.singleton.AddItem(boneSeeds.item);
                    Currency.singleton.TakeMoney(5);
                }
            }
        );

        //eyeball seeds
        BuySlotTemplate eyeballSeeds = Instantiate(prefab, transform);
        eyeballSeeds.name.text = "Eye Seeds";
        eyeballSeeds.cost.text = "10";
        eyeballSeeds.item.sprite = eyeball.itemSprite;
        eyeballSeeds.buy.onClick.AddListener(delegate
            {
                if( (Currency.singleton.myMoney - 10) >= 0)
                {
                    Inventory.singleton.AddItem(eyeballSeeds.item);
                    Currency.singleton.TakeMoney(10);
                }
            }
        );


        //Heart seeds
        BuySlotTemplate heartSeeds = Instantiate(prefab, transform);
        heartSeeds.name.text = "Heart Seeds";
        heartSeeds.cost.text = "25";
        heartSeeds.item.sprite = heart.itemSprite;
        heartSeeds.buy.onClick.AddListener(delegate
            {
                if( (Currency.singleton.myMoney - 25) >= 0)
                {
                    Inventory.singleton.AddItem(heartSeeds.item);
                    Currency.singleton.TakeMoney(25);
                }
            }
        );

        //Brain Seeds
        BuySlotTemplate brainSeeds = Instantiate(prefab, transform);
        brainSeeds.name.text = "Brain Seeds";
        brainSeeds.cost.text = "50";
        brainSeeds.item.sprite = brain.itemSprite;
        brainSeeds.buy.onClick.AddListener(delegate
            {
                if( (Currency.singleton.myMoney - 50) >= 0)
                {
                    Inventory.singleton.AddItem(brainSeeds.item);
                    Currency.singleton.TakeMoney(50);
                }
            }
        );

        //Scarecrow
        BuySlotTemplate scarecrow = Instantiate(prefab, transform);
        scarecrow.name.text = "Scarecrow";
        scarecrow.cost.text = "75";

        //Ashes
        BuySlotTemplate ashes = Instantiate(prefab, transform);
        ashes.name.text = "Human Ashes";
        ashes.cost.text = "30";

        //Blue flame
        BuySlotTemplate fire = Instantiate(prefab, transform);
        fire.name.text = "Blue Flame";
        fire.cost.text = "100";

        //Zambie
        BuySlotTemplate zombie = Instantiate(prefab, transform);
        zombie.name.text = "Zombie";
        zombie.cost.text = "250";
    }
}
