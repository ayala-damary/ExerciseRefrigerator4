using System;
using System.Collections.Generic;
using System.Text;


namespace ExerciseRefrigerator
{
    public class Shelf
    {
        public static int UniqIdShelf = 0;
        public int Id { get; }
        public int Floor { get; set; }
        public int FreeSpace { get; set; }
        public List<Item> Items { get; set; }
        public Shelf(int floor, int freeSpace)
        {
            Id = UniqIdShelf++;
            Floor = floor;
            FreeSpace = freeSpace;
            Items = new List<Item>();
        }

        public int GetFreeSpaceRest()
        {
            int TakeupPspace = 0;

            for (int i = 0; i < Items.Count; i++)
            {
                TakeupPspace += Items[i].Size;
            }
            return FreeSpace - TakeupPspace;

        }

        public bool ADDItem(Item item, int numShelf)
        {
            if (item.Size <= this.GetFreeSpaceRest())
            {
                item.ShelfId = numShelf;
                this.Items.Add(item);
                this.FreeSpace -= item.Size;
                return true;

            }  
            return false;
        }



        //4
        public Item REmoveItem(int itemId)
        {
            for (int j = 0; j < this.Items.Count; j++)
            { 
                    if (this.Items[j].Id == itemId)
                    {
                        Item item = null;
                        item = this.Items[j];
                        this.Items.Remove(item);
                        this.FreeSpace += item.Size;
                        return item;
                    }
            }

            return null;
        }

        //4
        public Item REmoveItem1(Item item)
        {
           this.Items.Remove(item);
            this.FreeSpace += item.Size;
            return item;
        }




        public override string ToString()
        {
            return $"Shelf number: {Id}\nFloor: {Floor}\nFree space: {FreeSpace}\n";
        }

    }
}
