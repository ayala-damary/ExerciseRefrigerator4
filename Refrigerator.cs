using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRefrigerator
{
    public class Refrigerator
    {
        public static int UniqIdFriger = 0;
        public int Id { get; }
        public string Model { get; set; }
        public string Color { get; set; }

        private int _numShelves;
        public List<Shelf> Shelves { get; set; }
        public Refrigerator() { 
        
        }
        public Refrigerator(string model, string color, int numShelves)
        {
            Id = UniqIdFriger++;
            Model = model;
            Color = color;
            NumShelves = numShelves;
            Shelves = new List<Shelf>();
        }
        public int NumShelves
        {
            get
            { return _numShelves; }

            set
            {
                if (value <= 0) throw new Exception("invalide size");
                _numShelves = value;
            }
        }

        //2
        public int GetFreeSpace()
        {
            int freeSpace = 0;
            for (int i = 0; i < NumShelves; i++)
            {
                freeSpace += Shelves[i].GetFreeSpaceRest();
            }
            return freeSpace;
        }

        ////3
        //public bool AddItem(Item item)
        //{
        //    for (int i = 0; i < Shelves.Count; i++)
        //    {
        //        if (item.Size <= Shelves[i].GetFreeSpaceRest())
        //        {
        //            item.ShelfId = i;
        //            Shelves[i].Items.Add(item);
        //            Shelves[i].FreeSpace -= item.Size;
        //            return true;

        //        }
        //    }
        //    return false;
        //}

        //3
        public bool AddItem(Item item)
        {
            for (int i = 0; i < Shelves.Count; i++)
            {
                if (Shelves[i].ADDItem(item,i))
                {
                    Console.WriteLine("The product add succses  to the fridge");
                    return true;
                }
            }
            Console.WriteLine("Their is not plase in fridge");
            return false;
        }


        ////4
        //public Item RemoveItem(int itemId)
        //{
        //    for (int i = 0; i < Shelves.Count; i++)
        //    {
        //        for (int j = 0; j < Shelves[i].Items.Count; j++)
        //            if (Shelves[i].Items[j].Id == itemId)
        //            {
        //                Item item = null;
        //                item = Shelves[i].Items[j];
        //                Shelves[item.ShelfId].Items.Remove(item);
        //                Shelves[item.ShelfId].FreeSpace += item.Size;
        //                return item;
        //            }
        //    }

        //    return null;
        //}


        //4
        public Item RemoveItem(int itemId)
        {
            for (int i = 0; i < Shelves.Count; i++)
            {
              Shelves[i].REmoveItem(itemId);


            }

            return null;
        }

        //5*
        public void CleanExpired()
        {
            Item item = null;
            DateTime currentTime = DateTime.Now;
            for (int i = 0; i < Shelves.Count; i++)
            {
                for (int j = 0; j < Shelves[i].Items.Count; j++)
                    if (Shelves[i].Items[j].ExpirationDate < currentTime)
                    {
                        Shelves[item.ShelfId].REmoveItem1(Shelves[i].Items[j]);

                    }
            }

        }


        //6
        public List<Item> FindItemsByTypeAndKashrut(Kashrut kashrut ,Type type)
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < Shelves.Count; i++)
            {
                for (int j = 0; j < Shelves[i].Items.Count; j++)
                {
                    if (Shelves[i].Items[j].Type == type && Shelves[i].Items[j].Kashrut == kashrut &&
                        Shelves[i].Items[j].ExpirationDate >= DateTime.Now)
                    {
                        items.Add(Shelves[i].Items[j]);
                    }
                }
            }

            return items;
        }


        //7.1
        public List<Item> SortItemsDescByExpirationDate()
        {
            // צור רשימה של פריטים
            List<Item> items = new List<Item>();
            for (int i = 0; i < Shelves.Count; i++)
            {
                items.AddRange(Shelves[i].Items);
            }

            items.Sort((x, y) => x.ExpirationDate.CompareTo(y.ExpirationDate));

            return items;
        }

       //8.2
        public List<Shelf> SortShelvesByFreeSpace()
        {
            List<Shelf> shelves2 = new List<Shelf>();
            shelves2.AddRange(Shelves);
            shelves2.Sort((x, y) => x.FreeSpace-y.FreeSpace);

            return shelves2;
        }
       
        public List<Refrigerator> SortRefrigeratorsByFreeSpace()
        {
            List<Refrigerator> refrigerators = new List<Refrigerator>();
            refrigerators.Add(this);

            refrigerators.Sort((x, y) => y.GetFreeSpace()-x.GetFreeSpace());

            return refrigerators;
         }

        public void PrepareForShopping2(Kashrut Kashrut, int countDay)
        {
            DateTime currentTime = DateTime.Now;
            DateTime ExpirationDateFinall = currentTime.AddDays(countDay); ;
            List<Item> filteredNumbers = new List<Item>();
         
            for (int i = 0; i < Shelves.Count; i++)
            //filteredNumbers = ((List<Item>)Shelves[i].Items.Where(s => s.Kashrut==Kashrut&& s.ExpirationDate<ExpirationDateFinall));
            {
                for (int j = 0; j < Shelves[i].Items.Count; j++)
                {
                    if (Shelves[i].Items[j].Kashrut == Kashrut && Shelves[i].Items[j].ExpirationDate < ExpirationDateFinall)
                        RemoveItem(Shelves[i].Items[j].Id);
                }
            } 
        }
        public void PrepareForShopping()
        { 
            if (this.GetFreeSpace() < 20)
            {
                CleanExpired();
                if (this.GetFreeSpace() < 20)
                { 
                    PrepareForShopping2(Kashrut.deary,3);
                    Console.WriteLine("Throw away all dairy items that are valid for less than three days.");
                    if (this.GetFreeSpace() < 20)
                    { 
                    PrepareForShopping2(Kashrut.meet,7);
                        Console.WriteLine("Throw away all meeting items that are valid for less than seven days.");
                if (this.GetFreeSpace() < 20)
                        { 
                    PrepareForShopping2(Kashrut.parve, 1);
                            Console.WriteLine("Throw away all meeting items that are valid for less than one days.");
                if (this.GetFreeSpace() < 20)
                  Console.WriteLine("No their is place in the fridgre ,This is not the time to shop.");
}
                    }
                } 


            }

         }



        public override string ToString()
        {
            return $"Warehouse number: {Id}\nModel: {Model}\nColor: {Color}\nNumber of shelves: {NumShelves}\n";
        }



    }
}
