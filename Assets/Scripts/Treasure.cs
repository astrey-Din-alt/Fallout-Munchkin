using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {
    public string Name;
    public string Discription;
    public string Type;
    public bool AddLvl;

    public void Use(CardPlayer player)
    {
        //TODO: Дописать подробности и описание
        var card = this.GetComponentInParent<Card>();
        switch (this.Type)
        {
            case "Lvl":
                player.Lvl++;
                player.Power++;
                player.Hand.Remove(card);
                GameObject.FindObjectOfType<Game>().tReset(card);
                break;
            case "Other":
                break;
        }            
    }    
}
