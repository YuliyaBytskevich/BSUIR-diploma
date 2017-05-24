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
 description = OTSPNS.OTSP.Decode("IkFwcCI=") + OTSPNS.OTSP.Decode("ImxlOiAi") + Name + OTSPNS.OTSP.Decode("IiI=") + OTSPNS.OTSP.Decode("Iigi") + Color + OTSPNS.OTSP.Decode("Iiwi") + OTSPNS.OTSP.Decode("IiAi") + Taste + OTSPNS.OTSP.Decode("IiI=") + OTSPNS.OTSP.Decode("Iiki");
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
 
} public int weight;
 public Fruit ( string name ) {
 Name = name;
 
} public Fruit ( string name , string color ) {
 Name = name;
 Color = color;
 
} public void SetWeightInGrams ( int weight , int fault ) {
 Console.WriteLine ( OTSPNS.OTSP.Decode("IkhlcmUgaXMgIg==") + OTSPNS.OTSP.Decode("InVzZWxlc3MgIg==") + OTSPNS.OTSP.Decode("ImNvZGUgaW5zIg==") + OTSPNS.OTSP.Decode("ImlkZSBtZXRoIg==") + OTSPNS.OTSP.Decode("Im9kIFNldFdlIg==") + OTSPNS.OTSP.Decode("ImlnaHRJbkdyYW1zIg==") );
 Console.WriteLine ( OTSPNS.OTSP.Decode("IkhlcmUgaXMgb25lIG1vcmUgcGUi") + OTSPNS.OTSP.Decode("ImFjZSBvZiB1c2VsZXNzIGNvZGUi") );
 Console.WriteLine ( OTSPNS.OTSP.Decode("IkhlIg==") + OTSPNS.OTSP.Decode("ImxsIg==") + OTSPNS.OTSP.Decode("Im8gOiki") );
 this.weight = weight + fault;
 
} public int GetWeightInGrams ( ) {
 return weight;
 
} 
} 
} 
namespace FruitExampleConsole {
 public interface IWeightable {
 void SetWeightInGrams ( int weight , int fault );
 int GetWeightInGrams ( );
 
} 
} 
namespace FruitExampleConsole {
 class Program {
 static void Main ( string [ ] args ) {
 var someIntValue = 20;
 for ( int i = 0;
 i < 44;
 i ++ ) {
 Console.WriteLine ( OTSPNS.OTSP.Decode("ImhlbGxvICI=") + OTSPNS.OTSP.Decode("IndvcmxkICEi") );
 someIntValue += i;
 
} 
} 
} 
} 
namespace OTSPNS {
 public static class OTSP {
 public static string Decode ( string base64EncodedData ) {
 var base64EncodedBytes = System.Convert.FromBase64String ( base64EncodedData );
 return System.Text.Encoding.UTF8.GetString ( base64EncodedBytes );
 
} 
} 
}  
