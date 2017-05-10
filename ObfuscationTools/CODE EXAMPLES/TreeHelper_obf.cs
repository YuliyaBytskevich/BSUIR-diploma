using Antlr4.Runtime;
 using Antlr4.Runtime.Tree;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 
namespace a0.a1 {
 public static class a2 {
 public static RuleContext a3 ( RuleContext a4 , string a5 ) {
 var a6 = Mappers.CSParserState.NameToIndex ( a5 );
 var a7 = a4.parent;
 while ( a7 != null && ! a6.Contains ( a7.invokingState ) ) {
 a7 = a7.parent;
 
} return a7;
 
} public static IEnumerable < RuleContext > a8 ( RuleContext a4 , string a5 ) {
 var a6 = Mappers.CSParserState.NameToIndex ( a5 );
 List < RuleContext > a9 = new List < RuleContext > ( );
 return a16 ( a9 , a4 , a6 );
 
} public static RuleContext a10 ( RuleContext a4 ) {
 RuleContext a11 = a4;
 while ( a11.parent != null ) {
 a11 = a11.parent;
 
} return a11;
 
} public static RuleContext a12 ( RuleContext a4 , string a13 ) {
 RuleContext a14 = null;
 for ( int a15 = 0;
 a15 < a4.ChildCount;
 a15 ++ ) {
 if ( ! ( a4.GetChild ( a15 ) is ITerminalNode ) ) {
 if ( a4.GetChild ( a15 ).ChildCount == 1 ) {
 if ( a4.GetChild ( a15 ).GetChild ( 0 ).GetText ( ) == a13 ) {
 return ( RuleContext ) a4.GetChild ( a15 );
 
} 
} else {
 return a12 ( ( RuleContext ) a4.GetChild ( a15 ) , a13 );
 
} 
} 
} return a14;
 
} private static IEnumerable < RuleContext > a16 ( List < RuleContext > a11 , RuleContext a4 , IEnumerable < int > a6 ) {
 for ( int a15 = 0;
 a15 < a4.ChildCount;
 a15 ++ ) {
 if ( ! ( a4.GetChild ( a15 ) is ITerminalNode ) ) {
 var a14 = ( RuleContext ) a4.GetChild ( a15 );
 if ( a6.Contains ( a14.invokingState ) ) {
 a11.Add ( a14 );
 
} else {
 a16 ( a11 , a14 , a6 );
 
} 
} 
} return a11;
 
} 
} 
}  
