using System;
using System.Collections.Generic;

namespace Lab2
{
    class Interactable
    {
        protected void RecordEvent()
        {
            //Запис певної події в ігрове меню
        }
    }
    //-------------------------------------------------------NPC---------------------------------------------------
    class NPC : Interactable
    {
        string playerName;
        public string PlayerName { get { return playerName; } }
        public void SetPlayerName(string PlayerName)
        {
            playerName = PlayerName;
        }
        public void OpenConsole()
        {
            //Відкрити консоль
        }
        public void OpentChat()
        {
            //Відкрити ігровий чат
        }
        public void OpenPauseMenu()
        {
            //Відкрити Pause Menu
        }
    }
    class ServerConnection : NPC
    {
        public string ConnectionString { get; set; }
        public void ConnectToServer()
        {
            //Підєднатися до серверу
        }
        public void Reconect()
        {
            //Перепідєднатися до серверу
        }
    }
    class ConsoleTool : NPC
    {
        //Список доступних команд
        public List<string> CommandList;
        //Список команд які було введено
        public List<string> EnteredCommandList;
        public void EnterCommand()
        {
            //Ввести команду в консолі
        }

    }
    class ChatTool : NPC
    {
        public void SendMessage()
        {
            //Відправити повідомлення в чат
        }
        public void DeleteMessage()
        {
            //Видалити повідомлення з чату

        }
        public void EditMessage(int MessageId)
        {
            //Редагувати повідомлення
        }
    }
    class PuseMenu
    {
        public void Resume()
        {
            //Відновити гру
        }
        public void Quit()
        {
            //Вийти з гри
        }
        public void Options()
        {
            //Відкрити налаштування
        }

        public void MainMenu()
        {
            //Відкрити головне меню
        }
    }
    //-------------------------------------------------------Item---------------------------------------------------

    class Item : Interactable
    {
        int maxAmount;
        int amount;
        public void AddItem()
        {
            //Добавити предмет в інвентар
        }
        public void ShowInventary()
        {
            //Показати інвентар
        }
        public void DropItem()
        {
            //Викинути предмет з інвентаря
        }
    }
    class CreateItem
    {
        //Список речей які можна створити
        List<String> drawing;
        public void сreateItem()
        {
            //Створити предмет
        }
    }
    class Store
    {
        //Список речей які можна купити
        public List<string> Items;
        private int money;
        public int Money { get { return Money; } }
        public void Withdraw(int amount)
        {
            money -= amount;
        }
        public void AddMoney(int amount)
        {
            money += amount;
        }
        public void ShowItem()
        {
            //Показати список доступних для купівлі речей
        }
        public void BuyItem(int itemId)
        {
            //Купити річ
        }
        public void SellItem(int itemId)
        {
            //Продати річ
        }
    }
        //-------------------------------------------------------Enemy---------------------------------------------------
        public class Enemy
        {
            int speed;
            int health;
            public int Health { get { return health; } }
            public int Speed { get { return speed; } }
        public Enemy(int health, int speed)
        {
            this.health = health;
            this.speed = speed;
        }
            public void GetDamage(int amount)
            {
                health -= amount;
                if (health < 0)
                    Die();
            }
            public void Attack()
            {
                //Атака
            }
            public void LookAround()
            {
                //Перевірити чи гравець знаходиться в зоні видимості
            }

            public void Die()
            {

            }
        }
    class LandEnemy : Enemy
    {
        public LandEnemy(int health, int speed) : base(health, speed)
        {

        }
        
        public void LandFollow()
        {
            //Переслідувати гравця по суші
        }
    }
    class FlyEnemy  : LandEnemy
    {
        public FlyEnemy(int health, int speed) : base(health, speed)
        {

        }
        public void FlyFollow()
        {
            //Переслідувати гравця в повітрі
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
