using UnityEngine;
using System.Collections;

public class Staff : MonoBehaviour {
    public string StaffType;
    public bool Junk;
    public int Price;
    public int Power;
    public bool OneTime;
    public bool ForEveryone;
    public bool isCondition;

    public void PutOn(CardPlayer player)
    {
        if (!isCondition)
        {
            var card = this.GetComponentInParent<Card>();
            player.Power += this.Power;
            //Add to Inventary list
            player.Inventary.Add(card);
            //Remove from Hand List
            player.Hand.Remove(card);
            //transform
            var inv = player.transform.FindChild("Inventory");
            card.transform.parent = inv.transform;
            card.transform.position = setPosition(card);
            card.transform.localScale = new Vector3(1, 1, 1);
            card.Selected = false;
            GameObject.FindObjectOfType<Game>().CurrentCard = null;
        }
    }

    public void ToBag(CardPlayer player) {
        var card = this.GetComponentInParent<Card>();
        player.Bag.Add(card);
        player.Hand.Remove(card);        
        int X = 13 + player.Bag.Count * 5;
        int Y = 35 - player.Bag.Count * 5;
        var bag = player.transform.FindChild("Bag");
        card.transform.parent = bag.transform;
        card.transform.position = new Vector3(50, Y, 0);
        card.transform.Rotate(0, 0, 270);
        card.transform.localScale = new Vector3(1, 1, 1);
        card.Selected = false;
        GameObject.FindObjectOfType<Game>().CurrentCard = null;
    }

    private Vector3 setPosition(Card card) {
        Vector3 position = new Vector3 (0, 0 ,0);
            switch (card.GetComponent<Staff>().StaffType)
        {
            //TODO Проверка на двуручное + наличие
            case "Weapon":
                if (card.GetComponent<Weapon>().InTwoArms)
                    position = new Vector3(17, 29, 0);
                else
                    position = new Vector3(14, 29, 0);
                break;         
            case "Armor":
                position = new Vector3(35, 29, 0);
                break;
            case "Helmet":
                position = new Vector3(28, 29, 0);
                break;
            case "Boot":
                position = new Vector3(41, 29, 0);
                break;
        }
        return position;
    }
}
