using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using System.IO;
 using Antlr4.Runtime;
 using Antlr4.Runtime.Tree;
 using System.Diagnostics;
 
namespace a0 {
 class a1 {
 static CSharpParser.Compilation_unitContext a2 = null;
 static CSharpParser a3 = null;
 static void Main ( string [ ] a4 ) {
 var a5 = File.ReadAllText ( Path.GetFullPath ( @"..\..\" ) + "Hello.cs" );
 var a6 = new CSharpLexer ( new AntlrInputStream ( a5 ) );
 CommonTokenStream a7 = new CommonTokenStream ( a6 );
 a3 = new CSharpParser ( a7 );
 a2 = a3.compilation_unit ( );
 a8 ( a2 , "" , true );
 Console.ReadLine ( );
 
} static void a8 ( IParseTree a9 , string a10 , bool a11 ) {
 Console.Write ( a10 );
 if ( a11 ) {
 Console.Write ( "\\-" );
 a10 += "  ";
 
} else {
 Console.Write ( "|-" );
 a10 += "| ";
 
} var a12 = a9.ToString ( );
 if ( a12.Contains ( "[" ) ) {
 a12 = a12.Replace ( "[" , "" );
 a12 = a12.Replace ( "]" , "" );
 if ( a12 != string.Empty ) {
 var a13 = int.Parse ( a12.Split ( ' ' ).First ( ) );
 var a14 = a3.GetStateName ( a13 );
 if ( a14 != null ) {
 a12 = "[" + a14 + "]";
 
} else {
 Debug.WriteLine ( ">>> STATE NAME IS MISSING. CODE: " + a13 );
 
} 
} else {
 a12 = "";
 
} 
} else {
 a12 = "\"" + a12 + "\"";
 
} Console.WriteLine ( a12 );
 for ( int a15 = 0;
 a15 < a9.ChildCount;
 a15 ++ ) {
 a8 ( a9.GetChild ( a15 ) , a10 , a15 == a9.ChildCount - 1 );
 
} 
} 
} 
}  
