using UnityEngine;
using System.Collections;

public class Partner : MonoBehaviour {
    public int Bonus;

    public void Activate(CardPlayer player)
    {
        var card = this.GetComponentInParent<Card>();
        player.Power += this.Bonus;
        player.Partner[0] = card;
        player.Hand.Remove(card);
        var inv = player.transform.FindChild("Inventory");
        card.transform.parent = inv.transform;
        card.transform.position = new Vector3(28, 15, 0);
        card.transform.localScale = new Vector3(1, 1, 1);
        card.Selected = false;
        GameObject.FindObjectOfType<Game>().CurrentCard = null;
    }
}
