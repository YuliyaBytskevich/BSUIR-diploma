using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Entities;
using Obfuscation.Core.Managers;

namespace Obfuscation.Core.CSharpAnalysis
{
    public class TestVisitor : CSParserBaseVisitor<Root>
    {
        #region for visitor
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;
        #endregion

        public override Root VisitCompilation_unit(Root context)
        {
            IdentifiersGenerator.SetGenerator("a", 0);
            this.root = context;
            return VisitChildren(root);
        }

        //public override string AggregateResult()
        //{
        //    return "fuuuuuuuuuuuuu";
        //}

        #region implemented
        //public override string VisitTerminal(ITerminalNode node)
        //{
        //    result += node.GetText() + " ";
        //    return DefaultResult;
        //}

        public override Root VisitIdentifier(CSParser.IdentifierContext context)
        {
            RenameManager.TryToRenameIdentifier(context, root);

            return VisitChildren(context);
        }

        #endregion

        #region not implemented
        //public override string VisitLiteralAccessExpression(CSParser.LiteralAccessExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitDefaultValueExpression(CSParser.DefaultValueExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitBaseAccessExpression(CSParser.BaseAccessExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSizeofExpression(CSParser.SizeofExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitParenthesisExpressions(CSParser.ParenthesisExpressionsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitThisReferenceExpression(CSParser.ThisReferenceExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitObjectCreationExpression(CSParser.ObjectCreationExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAnonymousMethodExpression(CSParser.AnonymousMethodExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitTypeofExpression(CSParser.TypeofExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUncheckedExpression(CSParser.UncheckedExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSimpleNameExpression(CSParser.SimpleNameExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMemberAccessExpression(CSParser.MemberAccessExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitCheckedExpression(CSParser.CheckedExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLiteralExpression(CSParser.LiteralExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNameofExpression(CSParser.NameofExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitDeclarationStatement(CSParser.DeclarationStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEmbeddedStatement(CSParser.EmbeddedStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLabeledStatement(CSParser.LabeledStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUsingAliasDirective(CSParser.UsingAliasDirectiveContext context)
        //{
        //    //result += context.GetText() + " ";
        //    return VisitChildren(context);
        //}

        //public override string VisitUsingNamespaceDirective(CSParser.UsingNamespaceDirectiveContext context)
        //{
        //    //result += context.GetText() + " ";
        //    return VisitChildren(context);
        //}

        //public override string VisitUsingStaticDirective(CSParser.UsingStaticDirectiveContext context)
        //{
        //    //result += context.GetText() + " ";
        //    return VisitChildren(context);
        //}

        //public override string VisitEmptyStatement(CSParser.EmptyStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitTryStatement(CSParser.TryStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitCheckedStatement(CSParser.CheckedStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitThrowStatement(CSParser.ThrowStatementContext context)
        //{
        //    if (context.ChildCount == 1) { result += context.invokingState + Environment.NewLine + Environment.NewLine; return DefaultResult; } return VisitChildren(context);
        //}

        //public override string VisitForeschStatement(CSParser.ForeschStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUnsafeStatement(CSParser.UnsafeStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitForStatement(CSParser.ForStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitBreakStatement(CSParser.BreakStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitIfStatement(CSParser.IfStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitReturnStatement(CSParser.ReturnStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitGotoStatement(CSParser.GotoStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSwitchStatement(CSParser.SwitchStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFixedStatement(CSParser.FixedStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitWhileStatement(CSParser.WhileStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitDoStatement(CSParser.DoStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUncheckedStatement(CSParser.UncheckedStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExpressionStatement(CSParser.ExpressionStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitContinueStatement(CSParser.ContinueStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUsingStatement(CSParser.UsingStatementContext context)
        //{
        //    //result += context.GetText() + " ";
        //    return VisitChildren(context);
        //}

        //public override string VisitLockStatement(CSParser.LockStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitYieldStatement(CSParser.YieldStatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNamespace_or_type_name(CSParser.Namespace_or_type_nameContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType(CSParser.TypeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitBase_type(CSParser.Base_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSimple_type(CSParser.Simple_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNumeric_type(CSParser.Numeric_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitIntegral_type(CSParser.Integral_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFloating_point_type(CSParser.Floating_point_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitClass_type(CSParser.Class_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType_argument_list(CSParser.Type_argument_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitArgument_list(CSParser.Argument_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitArgument(CSParser.ArgumentContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExpression(CSParser.ExpressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNon_assignment_expression(CSParser.Non_assignment_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAssignment(CSParser.AssignmentContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAssignment_operator(CSParser.Assignment_operatorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConditional_expression(CSParser.Conditional_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNull_coalescing_expression(CSParser.Null_coalescing_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConditional_or_expression(CSParser.Conditional_or_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConditional_and_expression(CSParser.Conditional_and_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInclusive_or_expression(CSParser.Inclusive_or_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExclusive_or_expression(CSParser.Exclusive_or_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAnd_expression(CSParser.And_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEquality_expression(CSParser.Equality_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitRelational_expression(CSParser.Relational_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitShift_expression(CSParser.Shift_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAdditive_expression(CSParser.Additive_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMultiplicative_expression(CSParser.Multiplicative_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUnary_expression(CSParser.Unary_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitPrimary_expression(CSParser.Primary_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitPrimary_expression_start(CSParser.Primary_expression_startContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMember_access(CSParser.Member_accessContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitBracket_expression(CSParser.Bracket_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitIndexer_argument(CSParser.Indexer_argumentContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitPredefined_type(CSParser.Predefined_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExpression_list(CSParser.Expression_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitObject_or_collection_initializer(CSParser.Object_or_collection_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitObject_initializer(CSParser.Object_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMember_initializer_list(CSParser.Member_initializer_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMember_initializer(CSParser.Member_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInitializer_value(CSParser.Initializer_valueContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitCollection_initializer(CSParser.Collection_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitElement_initializer(CSParser.Element_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAnonymous_object_initializer(CSParser.Anonymous_object_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMember_declarator_list(CSParser.Member_declarator_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMember_declarator(CSParser.Member_declaratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUnbound_type_name(CSParser.Unbound_type_nameContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitGeneric_dimension_specifier(CSParser.Generic_dimension_specifierContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitIsType(CSParser.IsTypeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLambda_expression(CSParser.Lambda_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAnonymous_function_signature(CSParser.Anonymous_function_signatureContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExplicit_anonymous_function_parameter_list(CSParser.Explicit_anonymous_function_parameter_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExplicit_anonymous_function_parameter(CSParser.Explicit_anonymous_function_parameterContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitImplicit_anonymous_function_parameter_list(CSParser.Implicit_anonymous_function_parameter_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAnonymous_function_body(CSParser.Anonymous_function_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitQuery_expression(CSParser.Query_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFrom_clause(CSParser.From_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitQuery_body(CSParser.Query_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitQuery_body_clause(CSParser.Query_body_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLet_clause(CSParser.Let_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitWhere_clause(CSParser.Where_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitCombined_join_clause(CSParser.Combined_join_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitOrderby_clause(CSParser.Orderby_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitOrdering(CSParser.OrderingContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSelect_or_group_clause(CSParser.Select_or_group_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitQuery_continuation(CSParser.Query_continuationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitStatement(CSParser.StatementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEmbedded_statement(CSParser.Embedded_statementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSimple_embedded_statement(CSParser.Simple_embedded_statementContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitBlock(CSParser.BlockContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLocal_variable_declaration(CSParser.Local_variable_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLocal_variable_declarator(CSParser.Local_variable_declaratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLocal_variable_initializer(CSParser.Local_variable_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLocal_constant_declaration(CSParser.Local_constant_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitIf_body(CSParser.If_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSwitch_section(CSParser.Switch_sectionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSwitch_label(CSParser.Switch_labelContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitStatement_list(CSParser.Statement_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFor_initializer(CSParser.For_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFor_iterator(CSParser.For_iteratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitCatch_clauses(CSParser.Catch_clausesContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSpecific_catch_clause(CSParser.Specific_catch_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitGeneral_catch_clause(CSParser.General_catch_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitException_filter(CSParser.Exception_filterContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFinally_clause(CSParser.Finally_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitResource_acquisition(CSParser.Resource_acquisitionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNamespace_declaration(CSParser.Namespace_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitQualified_identifier(CSParser.Qualified_identifierContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNamespace_body(CSParser.Namespace_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExtern_alias_directives(CSParser.Extern_alias_directivesContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitExtern_alias_directive(CSParser.Extern_alias_directiveContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitUsing_directives(CSParser.Using_directivesContext context)
        //{
        //    return VisitChildren(context);
        //}

        //public override string VisitUsing_directive(CSParser.Using_directiveContext context)
        //{
        //    foreach(var child in context.children)
        //    {
        //        if (child.ChildCount == 0)
        //        {
        //            result += child.GetText() + " ";
        //        }
        //    }
        //    return VisitChildren(context);
        //}

        //public override string VisitNamespace_member_declarations(CSParser.Namespace_member_declarationsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitNamespace_member_declaration(CSParser.Namespace_member_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType_declaration(CSParser.Type_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitQualified_alias_member(CSParser.Qualified_alias_memberContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType_parameter_list(CSParser.Type_parameter_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType_parameter(CSParser.Type_parameterContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitClass_base(CSParser.Class_baseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterface_type_list(CSParser.Interface_type_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType_parameter_constraints_clauses(CSParser.Type_parameter_constraints_clausesContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType_parameter_constraints_clause(CSParser.Type_parameter_constraints_clauseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitType_parameter_constraints(CSParser.Type_parameter_constraintsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitPrimary_constraint(CSParser.Primary_constraintContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSecondary_constraints(CSParser.Secondary_constraintsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConstructor_constraint(CSParser.Constructor_constraintContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitClass_body(CSParser.Class_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitClass_member_declarations(CSParser.Class_member_declarationsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitClass_member_declaration(CSParser.Class_member_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAll_member_modifiers(CSParser.All_member_modifiersContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAll_member_modifier(CSParser.All_member_modifierContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitCommon_member_declaration(CSParser.Common_member_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitTyped_member_declaration(CSParser.Typed_member_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConstant_declarators(CSParser.Constant_declaratorsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConstant_declarator(CSParser.Constant_declaratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitVariable_declarators(CSParser.Variable_declaratorsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitVariable_declarator(CSParser.Variable_declaratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitVariable_initializer(CSParser.Variable_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitReturn_type(CSParser.Return_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMember_name(CSParser.Member_nameContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMethod_body(CSParser.Method_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFormal_parameter_list(CSParser.Formal_parameter_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFixed_parameters(CSParser.Fixed_parametersContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFixed_parameter(CSParser.Fixed_parameterContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitParameter_modifier(CSParser.Parameter_modifierContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitParameter_array(CSParser.Parameter_arrayContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAccessor_declarations(CSParser.Accessor_declarationsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitGet_accessor_declaration(CSParser.Get_accessor_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitSet_accessor_declaration(CSParser.Set_accessor_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAccessor_modifier(CSParser.Accessor_modifierContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAccessor_body(CSParser.Accessor_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEvent_accessor_declarations(CSParser.Event_accessor_declarationsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAdd_accessor_declaration(CSParser.Add_accessor_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitRemove_accessor_declaration(CSParser.Remove_accessor_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitOverloadable_operator(CSParser.Overloadable_operatorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConversion_operator_declarator(CSParser.Conversion_operator_declaratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConstructor_initializer(CSParser.Constructor_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitBody(CSParser.BodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitStruct_interfaces(CSParser.Struct_interfacesContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitStruct_body(CSParser.Struct_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitStruct_member_declaration(CSParser.Struct_member_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitArray_type(CSParser.Array_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitRank_specifier(CSParser.Rank_specifierContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitArray_initializer(CSParser.Array_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitVariant_type_parameter_list(CSParser.Variant_type_parameter_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitVariant_type_parameter(CSParser.Variant_type_parameterContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitVariance_annotation(CSParser.Variance_annotationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterface_base(CSParser.Interface_baseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterface_body(CSParser.Interface_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterface_member_declaration(CSParser.Interface_member_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterface_accessors(CSParser.Interface_accessorsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEnum_base(CSParser.Enum_baseContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEnum_body(CSParser.Enum_bodyContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEnum_member_declaration(CSParser.Enum_member_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitGlobal_attribute_section(CSParser.Global_attribute_sectionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitGlobal_attribute_target(CSParser.Global_attribute_targetContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAttributes(CSParser.AttributesContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAttribute_section(CSParser.Attribute_sectionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAttribute_target(CSParser.Attribute_targetContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAttribute_list(CSParser.Attribute_listContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAttribute(CSParser.AttributeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitAttribute_argument(CSParser.Attribute_argumentContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitPointer_type(CSParser.Pointer_typeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFixed_pointer_declarators(CSParser.Fixed_pointer_declaratorsContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFixed_pointer_declarator(CSParser.Fixed_pointer_declaratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFixed_pointer_initializer(CSParser.Fixed_pointer_initializerContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitFixed_size_buffer_declarator(CSParser.Fixed_size_buffer_declaratorContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitLocal_variable_initializer_unsafe(CSParser.Local_variable_initializer_unsafeContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitRight_arrow(CSParser.Right_arrowContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitRight_shift(CSParser.Right_shiftContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitRight_shift_assignment(CSParser.Right_shift_assignmentContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitBoolean_literal(CSParser.Boolean_literalContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitString_literal(CSParser.String_literalContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterpolated_regular_string(CSParser.Interpolated_regular_stringContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterpolated_verbatium_string(CSParser.Interpolated_verbatium_stringContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterpolated_regular_string_part(CSParser.Interpolated_regular_string_partContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterpolated_verbatium_string_part(CSParser.Interpolated_verbatium_string_partContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterpolated_string_expression(CSParser.Interpolated_string_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitKeyword(CSParser.KeywordContext context)
        //{
        //    result += context.GetText() + " ";
        //    return DefaultResult;
        //}

        //public override string VisitClass_definition(CSParser.Class_definitionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitStruct_definition(CSParser.Struct_definitionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitInterface_definition(CSParser.Interface_definitionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEnum_definition(CSParser.Enum_definitionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitDelegate_definition(CSParser.Delegate_definitionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitEvent_declaration(CSParser.Event_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitField_declaration(CSParser.Field_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitProperty_declaration(CSParser.Property_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConstant_declaration(CSParser.Constant_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitIndexer_declaration(CSParser.Indexer_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitDestructor_definition(CSParser.Destructor_definitionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitConstructor_declaration(CSParser.Constructor_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMethod_declaration(CSParser.Method_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMethod_member_name(CSParser.Method_member_nameContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitOperator_declaration(CSParser.Operator_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitArg_declaration(CSParser.Arg_declarationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitMethod_invocation(CSParser.Method_invocationContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}

        //public override string VisitObject_creation_expression(CSParser.Object_creation_expressionContext context)
        //{
        //   if (context.ChildCount == 1){result += string.Format("[{0}] {1} {2}", Mappers.CSParserState.IndexToName(context.invokingState), context.GetChild(0).GetText(), Environment.NewLine);return DefaultResult;} else {result += string.Format("[{0}] {1}", Mappers.CSParserState.IndexToName(context.invokingState), Environment.NewLine); return VisitChildren(context);}
        //}
        #endregion
    }
}
