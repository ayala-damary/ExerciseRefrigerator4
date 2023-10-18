using System;

namespace ExerciseRefrigerator
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Refrigerator refrigerator = new Refrigerator("LG", "לבן", 5);


            Shelf shelf1 = new Shelf(1, 100);
            Shelf shelf2 = new Shelf(2, 200);
            Shelf shelf3 = new Shelf(3, 300);
            Shelf shelf4 = new Shelf(4, 400);
            Shelf shelf5 = new Shelf(5, 500);


            refrigerator.Shelves.Add(shelf1);
            refrigerator.Shelves.Add(shelf2);
            refrigerator.Shelves.Add(shelf3);
            refrigerator.Shelves.Add(shelf4);
            refrigerator.Shelves.Add(shelf5);


            Item item1 = new Item("חלב", 0, Type.drink, Kashrut.deary, DateTime.Now.AddDays(7), 100);
            Item item2 = new Item("ביצים", 0, Type.eat, Kashrut.parve, DateTime.Now.AddDays(3), 200);
            Item item3 = new Item("לחם", 0, Type.eat, Kashrut.meet, DateTime.Now.AddDays(1), 300);
            Item item4 = new Item("בשר", 0, Type.eat, Kashrut.meet, DateTime.Now.AddDays(6), 400);
            Item item5 = new Item("ירקות", 0, Type.eat, Kashrut.parve, DateTime.Now.AddDays(2), 500);

            // הוספת פריטים למדפים
            shelf1.Items.Add(item1);
            shelf2.Items.Add(item2);
            shelf3.Items.Add(item3);
            shelf4.Items.Add(item4);
            shelf5.Items.Add(item5);

            // ממשק משתמש
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Display all items");
                Console.WriteLine("2. Show how much space is left in the warehouse");
                Console.WriteLine("3. Add item to warehouse");
                Console.WriteLine("4. Remove item from warehouse");
                Console.WriteLine("5. Clear the warehouse");
                Console.WriteLine("6. What do I want to eat?");
                Console.WriteLine("7. Sort by expiration date");
                Console.WriteLine("8. Sort by available space");
                Console.WriteLine("9. Sort by available space in the warehouse");
                Console.WriteLine("10. Preparing for shopping");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // הצג את כל הפריטים
                        Console.WriteLine(refrigerator.ToString());
                        break;
                    case 2:
                        // הצג כמה מקום נשאר במחסן
                        refrigerator.GetFreeSpace();
                        break;
                    case 3:
                        // הוסף פריט למחסן
                        refrigerator.AddItem(item1);
                        break;
                    case 4:
                        // הוצא פריט מהמחסן
                        refrigerator.RemoveItem(1);
                        break;
                    case 5:
                        // נקה את המחסן
                        refrigerator.CleanExpired();
                        break;
                    case 6:
                        // מה בא לי לאכול?
                        refrigerator.FindItemsByTypeAndKashrut(Kashrut.deary, Type.drink);
                        break;
                    case 7:
                        // מיון לפי תאריך תפוגה
                        refrigerator.SortItemsDescByExpirationDate();
                        break;
                    case 8:
                        // מה בא לי לאכול?
                        refrigerator.SortShelvesByFreeSpace();
                        break;
                    case 9:
                        // מה בא לי לאכול?
                        refrigerator.SortShelvesByFreeSpace();
                        break;
                    case 10:
                        // מה בא לי לאכול?
                        refrigerator.PrepareForShopping();
                        break;
                    case 100:
                        // מה בא לי לאכול?
                        running = false;
                        break;
                }
            }
        }
    }
}
