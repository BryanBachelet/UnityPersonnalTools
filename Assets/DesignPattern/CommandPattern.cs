using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{


    public abstract class Command
    {
        public abstract void execute();
    }

    public class FireCommand : Command
    {
        public override void execute()
        {
            Debug.Log(" Execute Fire command");
        }
    }

    unsafe public class CardCommand
    {
        public void execute(delegate*<int,int, int> p1, int indexCard, int costCard)
        {
            p1(indexCard, costCard);
        }
    }

}