using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 
namespace a0 {
 public class a1 : a6 {
 public string a2;
 public a1 ( string a3 ) : base ( a3 ) {
 
} public a1 ( string a3 , string a4 ) : base ( a3 , a4 ) {
 
} public override string a5 ( ) {
 a2 = "Apple: " + a7 + "(" + a8 + ", " + a9 + ")";
 return a2;
 
} 
} 
} 
namespace a0 {
 public class a6 : a13 {
 public string a7 {
 get;
 private set;
 
} public string a8 {
 get;
 set;
 
} public string a9 {
 get;
 set;
 
} private int a10;
 public a6 ( string a3 ) {
 a7 = a3;
 
} public a6 ( string a3 , string a4 ) {
 a7 = a3;
 a8 = a4;
 
} public void a11 ( int a10 ) {
 this.a10 = a10;
 
} public int a12 ( ) {
 return a10;
 
} 
} 
} 
namespace a0 {
 public interface a13 {
 void a11 ( int a10 );
 int a12 ( );
 
} 
} 
namespace a0 {
 class a14 {
 static void a15 ( string [ ] a16 ) {
 var a17 = new a1 ( "Golden" , "yellow" );
 a17.a9 = "sweet";
 var a18 = new a1 ( "Granny Smith" );
 a18.a8 = "green";
 a18.a9 = "sweet/sour";
 a18.a11 ( 210 );
 var a19 = a18.a12 ( );
 a13 a20 = new a1 ( "Red prince" );
 
} 
} 
}  
