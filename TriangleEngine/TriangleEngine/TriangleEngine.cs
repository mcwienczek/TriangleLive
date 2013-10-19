﻿using System;
using System.Collections.Generic;

namespace TriangleEngine
{
    public delegate void MonsterEatenEventHandler(object sender, Monster monster);
    public delegate void MonsterBornEventHandler(object sender, Monster monster);
    public class TriangleEngine
    {
        public List<Monster> Monsters;
        public const int BoardSize = 10;
        public event MonsterEatenEventHandler MonsterEaten;
        public event MonsterBornEventHandler MonsterBorn;
        public TriangleEngine()
        {
            Monsters = new List<Monster>();
        }

        public void Turn()
        {
            MoveAll();
            GrowCarrot();
        }

        private void GrowCarrot()
        {
            throw new NotImplementedException();
        }

        private void CheckActions(Monster currentMonster)
        {
            for(int i = 0; i < Monsters.Count; i++)
            {
                Monster monster = Monsters[i];
                if(currentMonster.IsNear(monster))
                {
                    if(currentMonster.Eats(monster))
                        EatMonster(monster);
                    if (currentMonster.GetType() == monster.GetType())
                        Breed(currentMonster, monster);
                }
            }
        }
        
        private void MoveAll()
        {
            for (int i = 0; i < Monsters.Count; i++)
            {
                Monster monster = Monsters[i];
                Direction direction = monster.Move();
                Position newPosition = new Position(direction, monster.Pos);
                if (CanMove(newPosition))
                {
                    monster.Pos = newPosition;
                    CheckActions(monster);
                }
            }
        }

        private void EatMonster(Monster monster)
        {
            Monsters.Remove(monster);
        }

        private void Breed(Monster currentMonster, Monster monster)
        {
            throw new NotImplementedException();
        }

        private bool CanMove(Position position)
        {
            foreach(var m in Monsters)
            {
                if (m.Pos == position)
                    return false;
            }
            return true;
        }

        private Monster LeftMonster(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool PutMonsterOnBoard(Monster monster)
        {
            foreach(Monster m in Monsters)
            {
                if (monster.Pos == m.Pos)
                    return false;
            }
            Monsters.Add(monster);
            return true;
        }

        public void StartGame()
        {

        }

        public void StopGame()
        {

        }
    }    
}

