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
 description = OTSPNS.OTSP.Decode(IkFwcGxlOiAi) + Name + OTSPNS.OTSP.Decode(Iigi) + Color + OTSPNS.OTSP.Decode(IiwgIg==) + Taste + OTSPNS.OTSP.Decode(Iiki);
 return description;
 
} 
} 
} 
namespace FruitExampleConsole {
 public class Fruit {
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
 
} public void SetWeightInGrams ( int w , int something ) {
 Console.WriteLine ( OTSPNS.OTSP.Decode(IkhlcmUgaXMgdXNlbGVzcyBjb2RlIGluc2lkZSBtZXRob2QgU2V0V2VpZ2h0SW5HcmFtcyI=) );
 Console.WriteLine ( OTSPNS.OTSP.Decode(IkhlcmUgaXMgb25lIG1vcmUgcGVhY2Ugb2YgdXNlbGVzcyBjb2RlIg==) );
 Console.WriteLine ( OTSPNS.OTSP.Decode(IkhlbGxvIDopIg==) );
 this.weight = w + something;
 
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
 var second = new Apple ( OTSPNS.OTSP.Decode(IkdyYW5ueSBTbWl0aCI=) );
 var smth = 210;
 Console.WriteLine ( OTSPNS.OTSP.Decode(IkhlcmUgaXMgdXNlbGVzcyBjb2RlIGluc2lkZSBtZXRob2QgU2V0V2VpZ2h0SW5HcmFtcyI=) );
 Console.WriteLine ( OTSPNS.OTSP.Decode(IkhlcmUgaXMgb25lIG1vcmUgcGVhY2Ugb2YgdXNlbGVzcyBjb2RlIg==) );
 Console.WriteLine ( OTSPNS.OTSP.Decode(IkhlbGxvIDopIg==) );
 second.weight = 666 + smth;
 var x = second.GetWeightInGrams ( );
 
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
