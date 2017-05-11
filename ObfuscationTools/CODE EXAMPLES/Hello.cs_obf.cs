using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using Antlr_Test_1.Greetings;
 
namespace Antlr_Test_1.Greetings {
 public class Hello {
 public string SomeProperty {
 get;
 private set;
 
} public string userName;
 private const int x = 1;
 public Hello ( ) {
 Console.WriteLine ( "constructor" );
 
} public void SayHello ( ) {
 int x = 1;
 const int y = 20;
 for ( int i = 0;
 i < y;
 i ++ ) {
 Console.WriteLine ( "Hello! =)" );
 
} 
} public void SayHello ( string userName ) {
 Console.WriteLine ( "Hello, " + userName + "! =)" );
 
} 
} public static class Static {
 public static void DoNothing ( ) {
 
} 
} 
} 
namespace Antlr_Test_1.Test {
 public class Test {
 private Hello greetings = new Hello ( );
 public Test ( Hello h ) {
 greetings.SayHello ( );
 Static.DoNothing ( );
 var something = greetings.SomeProperty;
 greetings.userName = "Ololosh";
 
} 
} 
}  
