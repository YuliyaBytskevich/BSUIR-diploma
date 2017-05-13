using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 
namespace FruitExampleConsole {
 public class Apple : Fruit {
 public string description;
 public Apple ( string name ) : base ( name ) {
 
} public Apple ( string name , string color ) : base ( name , color ) {
 
} public override string ToString ( ) {
 description = "Apple: " + Name + "(" + Color + ", " + Taste + ")";
 return description;
 
} 
} 
} 
namespace FruitExampleConsole {
 public class Fruit : IWeightable {
 public string Name {
 get;
 private set;
 
} public string Color {
 get;
 set;
 
} public string Taste {
 get;
 set;
 
} private int weight;
 public Fruit ( string name ) {
 Name = name;
 
} public Fruit ( string name , string color ) {
 Name = name;
 Color = color;
 
} public void SetWeightInGrams ( int weight ) {
 this.weight = weight;
 
} public int GetWeightInGrams ( ) {
 return weight;
 
} 
} 
} 
namespace FruitExampleConsole {
 public interface IWeightable {
 void SetWeightInGrams ( int weight );
 int GetWeightInGrams ( );
 
} 
} 
namespace FruitExampleConsole {
 class Program {
 static void Main ( string [ ] args ) {
 var second = new Apple ( "Granny Smith" );
 second.weight = weight;
 var x = second.GetWeightInGrams ( );
 
} 
} 
}  
