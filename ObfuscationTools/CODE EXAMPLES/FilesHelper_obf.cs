using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using System.IO;
 
namespace a0.a1 {
 public static class a2 {
 public static string a3 ( string a4 ) {
 try {
 using ( var a5 = new StreamReader ( a4 ) ) {
 return a5.ReadToEnd ( );
 
} 
} catch ( Exception ex ) {
 
} return null;
 
} public static void a6 ( string a7 , string a8 ) {
 try {
 using ( var a9 = new StreamWriter ( a8 ) ) {
 a9.WriteLine ( a7 );
 
} 
} catch ( Exception ex ) {
 
} 
} 
} 
}  
