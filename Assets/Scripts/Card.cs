using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    public int Id;
    public CardType Type;
    public bool Enabled = false;
    public bool Selected = false;
    public CardPlayer player;
    private Game game;    
    private Card CurrentCard;
    private Handler Handler;

    public enum CardType{
        Door,
        Treasure,
        Perk
    }

    void OnMouseDown()
    {
        Debug.Log("Click " + this.name);
        if (!Selected)
        {
            game = GameObject.FindObjectOfType<Game>();
            game.CurrentCard = this;
            player = game.CurrentPlayer;
            this.transform.localScale = new Vector3(3, 3, 3);
            if (this.transform.parent.gameObject.name == "Bag")
                this.transform.Rotate(0, 0, 90);
            Debug.Log(this.transform.parent.gameObject.name);
            Selected = true;
        }
        else
        {
            game.CurrentCard = null;
            this.transform.localScale = new Vector3(1, 1, 1);
            Selected = false;
        }
    }
    
    void OnGUI()
    {
        if (Selected)
        {
            //Button Use
            if (GUI.Button(new Rect(400, 400, 125, 50), "Use"))
            {
                Use(this);
            }
            //Stage Finish
            if (game.CurrentStage == "Finish")
            {
                if (GUI.Button(new Rect(275, 400, 125, 50), "Share"))
                {
                    //TODO: Отдать слабому игроку
                }
                if (GUI.Button(new Rect(525, 400, 125, 50), "Drop"))
                {
                    game.tReset(this);
                }
            }
            //Treasure
            if (this.Type == CardType.Treasure)
            {
                if (this.GetComponent<Treasure>().Type == Treasure.TreasureType.Staff)
                {
                    if (
                        this.GetComponent<Staff>().StaffType == "Armor" ||
                        this.GetComponent<Staff>().StaffType == "Helmet" ||
                        this.GetComponent<Staff>().StaffType == "Boot" ||
                        this.GetComponent<Staff>().StaffType == "Weapon" ||
                        this.GetComponent<Staff>().StaffType == "Kastet"
                        )
                    {
                        if (GUI.Button(new Rect(400, 450, 125, 50), "Put On"))
                        {
                            PutOn(this);
                        }
                    }
                    if (GUI.Button(new Rect(525, 450, 125, 50), "To Bag"))
                    {
                        ToBag(this);
                    }
                    if (GUI.Button(new Rect(275, 450, 125, 50), "Sell"))
                    {
                        //TODO: Продать из корзины
                    }
                }
            }        
        }
    }
    //Метод для использования карты всех типов
    void Use(Card card)
    {
        player = game.CurrentPlayer;
        //Тип двери
        if (card.Type == CardType.Door)
        {
            var door = card.GetComponent<Door>();
            //Подтип Класс
            if (card.GetComponent<Door>().Type == Door.DoorType.Class)
            {
                door.GetComponent<Class>().Activate(player);
            }
            //Подтип Напарник
            if (card.GetComponent<Door>().Type == Door.DoorType.Partner)
            {
                door.GetComponent<Partner>().Activate(player);                
            }
            //Подтип Радиация
            if (card.GetComponent<Door>().Type == Door.DoorType.Radiation)
            {
               //TODO: Использование радиации с руки на другого игрока
            }
            //Подтип Ловушка
            if (card.GetComponent<Door>().Type == Door.DoorType.Trap)
            {
               //TODO: Использование ловушки с руки на другого игрока
            }
        }
        //Тип сокровища
        if (card.Type == CardType.Treasure)
        {
            //подтип Лвл
            if (card.GetComponent<Treasure>().Type == Treasure.TreasureType.Lvl)
            {
                card.GetComponent<Treasure>().Use(player);
            }
            //подтип Взрывчатка
            if (card.GetComponent<Staff>().StaffType == "Explosion")
            {
                //TODO: Вызвать метод из словаря
                card.GetComponent<Treasure>().Use(player);
            }
            //подтип Бафф
            if (card.GetComponent<Staff>().StaffType == "Buff")
            {
                //TODO: Вызвать метод из словаря
                card.GetComponent<Treasure>().Use(player);
            }
        }
    }
    //Метод надеть карту
    void PutOn(Card card)
    {
        if (card.GetComponent<Treasure>().Type == Treasure.TreasureType.Staff)
        {
            card.GetComponent<Treasure>().GetComponent<Staff>().PutOn(player);
        }
    }

    void ToBag(Card card)
    {
        player = game.CurrentPlayer;
        if (card.Type == CardType.Treasure)
        {
            if (card.GetComponent<Treasure>().Type == Treasure.TreasureType.Staff)
            {
                var trs = card.GetComponent<Treasure>();
                var staff = trs.GetComponent<Staff>();
                staff.ToBag(player);
            }
        }
    }
}
