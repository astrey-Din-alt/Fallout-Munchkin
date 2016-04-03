using UnityEngine;
using System.Collections.Generic;

public class CardPlayer : MonoBehaviour {
    public List<Card> Hand;
    public List<Card> Inventary;
    public List<Card> Bag;
    public List<Card> Perks;
    public List<Card> Class;
    public Card[] Partner = new Card[1];
        
    public int Lvl = 1;
    public int Power;

    public bool isSuper = false;
    public bool isMegaBrain = false;

    public int RunAbility = 2;

    public int RadiationDefense = 1;
    public bool Radiated;
    public Card Radiation;

    public bool Trapped;
    public Card Trap;

    public bool isKilled;

    void Start()
    {
        Power += Lvl;
    }

    public void Killed()
    {
        var game = GameObject.FindObjectOfType<Game>();
        foreach (var t in this.Inventary)
        {
            this.Inventary.Remove(t);
            game.tReset(t);
        }
        foreach (var b in this.Bag)
        {
            this.Bag.Remove(b);
            game.tReset(b);
        }
        foreach (var h in this.Hand)
        {
            this.Hand.Remove(h);
            if (h.Type == "Door")
                game.dReset(h);
            else
                game.tReset(h);
        }
        foreach (var p in this.Perks)
        {
            this.Perks.Remove(p);
            game.pReset(p);
        }
        foreach (var c in this.Class)
        {
            this.Class.Remove(c);
            game.dReset(c);
        }
        isSuper = false;
        isMegaBrain = false;
        Power = Lvl;
        RadiationDefense = 1;
        RunAbility = 2;
        Radiated = false;
        Radiation = null;
        isKilled = true;
    }
}
