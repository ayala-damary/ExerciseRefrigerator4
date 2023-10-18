using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseRefrigerator
{
    public enum Kashrut
    {
        meet,
        parve,
        deary
    }
    public enum Type
    {
        drink,
        eat
    }
    public class Item
    {
        public static int UniqIdItem = 0;
        public int Id { get; }
        public string Name { get; set; }
        public int ShelfId { get; set; }
        public Type Type { get; set; }
        public Kashrut Kashrut { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Size { get; set; }

        public Item(string name, int shelfId, Type type, Kashrut kashrut, DateTime expirationDate, int size)
        {
            Id = UniqIdItem++;
            Name = name;
            ShelfId = shelfId;
            Type = type;
            Kashrut = kashrut;
            ExpirationDate = expirationDate;
            Size = size;
        }





        public override string ToString()
        {
            return $"Item Number: {Id}\nName: {Name}\nShelf: {ShelfId}\nType: {Type}\nKosher: {Kashrut}\nExpiration Date: {ExpirationDate}\nSize: {Size}\n";
        }


    }
}
