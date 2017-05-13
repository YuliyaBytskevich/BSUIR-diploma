using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using System.Linq;
using Obfuscation.Core.CSharpAnalysis;

namespace Obfuscation.Core.Helpers
{
    public static class TreeHelper
    {
        public static RuleContext GetAncestorNode(RuleContext current, string requiredNodeState)
        {
            var requiredIndexes = Mappers.CSParserState.NameToIndex(requiredNodeState);
            var ancestor = current.parent;
            while (ancestor != null && !requiredIndexes.Contains(ancestor.invokingState))
            {
                ancestor = ancestor.parent;
            }

            return ancestor;
        }

        public static IEnumerable<RuleContext> GetDescendantNodes(RuleContext current, string requiredNodeState)
        {
            var requiredIndexes = Mappers.CSParserState.NameToIndex(requiredNodeState);
            List<RuleContext> nodes = new List<RuleContext>();

            return CheckChildrenIndexes(nodes, current, requiredIndexes);
        }


        public static IEnumerable<RuleContext> GetDescendantNodesWithText(RuleContext current, string requredText)
        {
            List<RuleContext> nodes = new List<RuleContext>();

            return CheckChildrenText(nodes, current, requredText);
        }

        public static RuleContext GetRoot(RuleContext current)
        {
            RuleContext result = current;
            while (result.parent != null)
            {
                result = result.parent;
            }

            return result;
        }

        public static RuleContext FindDescendantIndentifierNode(RuleContext current, string identifierName)
        {
            RuleContext descendant = null;

            for (int i = 0; i < current.ChildCount; i++)
            {
                if (!(current.GetChild(i) is ITerminalNode))
                {
                    if (current.GetChild(i).ChildCount == 1)
                    {
                        if (current.GetChild(i).GetChild(0).GetText() == identifierName)
                        {
                            return (RuleContext)current.GetChild(i);
                        }
                    }
                    else
                    {
                        return FindDescendantIndentifierNode((RuleContext)current.GetChild(i), identifierName);
                    }
                }
            }

            return descendant;
        }

        public static RuleContext GetDeepCopy(RuleContext sourceNode)
        {
            var copy = GetNodeCopy(sourceNode);
            CopyChildren(sourceNode, copy);

            return copy;
        }

        private static IEnumerable<RuleContext> CheckChildrenIndexes(List<RuleContext> result, RuleContext current, IEnumerable<int> requiredIndexes)
        {
            if (current != null)
            {
                for (int i = 0; i < current.ChildCount; i++)
                {
                    if (!(current.GetChild(i) is ITerminalNode))
                    {
                        var descendant = (RuleContext)current.GetChild(i);
                        if (requiredIndexes.Contains(descendant.invokingState))
                        {
                            result.Add(descendant);
                        }
                        else
                        {
                            CheckChildrenIndexes(result, descendant, requiredIndexes);
                        }
                    }
                }
            }

            return result;
        }

        private static IEnumerable<RuleContext> CheckChildrenText(List<RuleContext> result, RuleContext current, string requiredText)
        {
            if (current != null)
            {
                for (int i = 0; i < current.ChildCount; i++)
                {
                    if (!(current.GetChild(i) is ITerminalNode))
                    {
                        var descendant = (RuleContext)current.GetChild(i);
                        if (descendant.GetText() == requiredText)
                        {
                            result.Add(descendant);
                        }
                        else
                        {
                            CheckChildrenText(result, descendant, requiredText);
                        }
                    }
                }
            }

            return result;
        }
        private static void CopyChildren(RuleContext original, RuleContext result)
        {
            for (int i = 0; i < original.ChildCount; i++)
            {
                var child = original.GetChild(i);
                if (!(child is ITerminalNode))
                {
                    var childContext = child as RuleContext;
                    var childCopy = GetNodeCopy(childContext);
                    ((ParserRuleContext)result).AddChild(childCopy);

                    if (child.ChildCount > 0)
                    {
                        CopyChildren(childContext, (RuleContext)result.GetChild(i));
                    }
                }
                else
                {
                    ((ParserRuleContext)result).AddChild(new TerminalNodeImpl(((ITerminalNode)child).Symbol));
                }
            }
        }

        private static RuleContext GetNodeCopy(RuleContext current)
        {
            var parent = (ParserRuleContext)current.parent;
            var invokingState = current.invokingState;

            #region return same type instance
            switch (current.GetType().Name)
            {
                case "Compilation_unitContext": { return new CSParser.Compilation_unitContext(parent, current.invokingState); }
                case "Extern_alias_directivesContext": { return new CSParser.Extern_alias_directivesContext(parent, invokingState); }
                case "Using_directivesContext": { return new CSParser.Using_directivesContext(parent, invokingState); }
                case "Global_attribute_sectionContext": { return new CSParser.Global_attribute_sectionContext(parent, invokingState); }
                case "Namespace_member_declarationsContext": { return new CSParser.Namespace_member_declarationsContext(parent, invokingState); }
                case "Namespace_or_type_nameContext": { return new CSParser.Namespace_or_type_nameContext(parent, invokingState); }
                case "IdentifierContext": { return new CSParser.IdentifierContext(parent, invokingState); }
                case "Qualified_alias_memberContext": { return new CSParser.Qualified_alias_memberContext(parent, invokingState); }
                case "Type_argument_listContext": { return new CSParser.Type_argument_listContext(parent, invokingState); }
                case "TypeContext": { return new CSParser.TypeContext(parent, invokingState); }
                case "Base_typeContext": { return new CSParser.Base_typeContext(parent, invokingState); }
                case "Rank_specifierContext": { return new CSParser.Rank_specifierContext(parent, invokingState); }
                case "Simple_typeContext": { return new CSParser.Simple_typeContext(parent, invokingState); }
                case "Class_typeContext": { return new CSParser.Class_typeContext(parent, invokingState); }
                case "Numeric_typeContext": { return new CSParser.Numeric_typeContext(parent, invokingState); }
                case "Integral_typeContext": { return new CSParser.Integral_typeContext(parent, invokingState); }
                case "Floating_point_typeContext": { return new CSParser.Floating_point_typeContext(parent, invokingState); }
                case "Argument_listContext": { return new CSParser.Argument_listContext(parent, invokingState); }
                case "ArgumentContext": { return new CSParser.ArgumentContext(parent, invokingState); }
                case "ExpressionContext": { return new CSParser.ExpressionContext(parent, invokingState); }
                case "AssignmentContext": { return new CSParser.AssignmentContext(parent, invokingState); }
                case "Non_assignment_expressionContext": { return new CSParser.Non_assignment_expressionContext(parent, invokingState); }
                case "Lambda_expressionContext": { return new CSParser.Lambda_expressionContext(parent, invokingState); }
                case "Query_expressionContext": { return new CSParser.Query_expressionContext(parent, invokingState); }
                case "Conditional_expressionContext": { return new CSParser.Conditional_expressionContext(parent, invokingState); }
                case "Unary_expressionContext": { return new CSParser.Unary_expressionContext(parent, invokingState); }
                case "Assignment_operatorContext": { return new CSParser.Assignment_operatorContext(parent, invokingState); }
                case "Right_shift_assignmentContext": { return new CSParser.Right_shift_assignmentContext(parent, invokingState); }
                case "Null_coalescing_expressionContext": { return new CSParser.Null_coalescing_expressionContext(parent, invokingState); }
                case "Conditional_or_expressionContext": { return new CSParser.Conditional_or_expressionContext(parent, invokingState); }
                case "Conditional_and_expressionContext": { return new CSParser.Conditional_and_expressionContext(parent, invokingState); }
                case "Inclusive_or_expressionContext": { return new CSParser.Inclusive_or_expressionContext(parent, invokingState); }
                case "Exclusive_or_expressionContext": { return new CSParser.Exclusive_or_expressionContext(parent, invokingState); }
                case "And_expressionContext": { return new CSParser.And_expressionContext(parent, invokingState); }
                case "Equality_expressionContext": { return new CSParser.Equality_expressionContext(parent, invokingState); }
                case "Relational_expressionContext": { return new CSParser.Relational_expressionContext(parent, invokingState); }
                case "Shift_expressionContext": { return new CSParser.Shift_expressionContext(parent, invokingState); }
                case "IsTypeContext": { return new CSParser.IsTypeContext(parent, invokingState); }
                case "Additive_expressionContext": { return new CSParser.Additive_expressionContext(parent, invokingState); }
                case "Right_shiftContext": { return new CSParser.Right_shiftContext(parent, invokingState); }
                case "Multiplicative_expressionContext": { return new CSParser.Multiplicative_expressionContext(parent, invokingState); }
                case "Primary_expressionContext": { return new CSParser.Primary_expressionContext(parent, invokingState); }
                case "Primary_expression_startContext": { return new CSParser.Primary_expression_startContext(parent, invokingState); }
                case "Bracket_expressionContext": { return new CSParser.Bracket_expressionContext(parent, invokingState); }
                case "Member_accessContext": { return new CSParser.Member_accessContext(parent, invokingState); }
                case "Method_invocationContext": { return new CSParser.Method_invocationContext(parent, invokingState); }
                case "LiteralAccessExpressionContext": { return new CSParser.LiteralAccessExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "DefaultValueExpressionContext": { return new CSParser.DefaultValueExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "BaseAccessExpressionContext": { return new CSParser.BaseAccessExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "Expression_listContext": { return new CSParser.Expression_listContext(parent, invokingState); }
                case "SizeofExpressionContext": { return new CSParser.SizeofExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "ParenthesisExpressionsContext": { return new CSParser.ParenthesisExpressionsContext((CSParser.Primary_expression_startContext)current); }
                case "ThisReferenceExpressionContext": { return new CSParser.ThisReferenceExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "ObjectCreationExpressionContext": { return new CSParser.ObjectCreationExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "Anonymous_object_initializerContext": { return new CSParser.Anonymous_object_initializerContext(parent, invokingState); }
                case "Array_initializerContext": { return new CSParser.Array_initializerContext(parent, invokingState); }
                case "Object_creation_expressionContext": { return new CSParser.Object_creation_expressionContext(parent, invokingState); }
                case "Object_or_collection_initializerContext": { return new CSParser.Object_or_collection_initializerContext(parent, invokingState); }
                case "AnonymousMethodExpressionContext": { return new CSParser.AnonymousMethodExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "BlockContext": { return new CSParser.BlockContext(parent, invokingState); }
                case "Explicit_anonymous_function_parameter_listContext": { return new CSParser.Explicit_anonymous_function_parameter_listContext(parent, invokingState); }
                case "TypeofExpressionContext": { return new CSParser.TypeofExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "Unbound_type_nameContext": { return new CSParser.Unbound_type_nameContext(parent, invokingState); }
                case "UncheckedExpressionContext": { return new CSParser.UncheckedExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "SimpleNameExpressionContext": { return new CSParser.SimpleNameExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "MemberAccessExpressionContext": { return new CSParser.MemberAccessExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "Predefined_typeContext": { return new CSParser.Predefined_typeContext(parent, invokingState); }
                case "CheckedExpressionContext": { return new CSParser.CheckedExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "LiteralExpressionContext": { return new CSParser.LiteralExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "LiteralContext": { return new CSParser.LiteralContext(parent, invokingState); }
                case "NameofExpressionContext": { return new CSParser.NameofExpressionContext((CSParser.Primary_expression_startContext)current); }
                case "Indexer_argumentContext": { return new CSParser.Indexer_argumentContext(parent, invokingState); }
                case "Object_initializerContext": { return new CSParser.Object_initializerContext(parent, invokingState); }
                case "Collection_initializerContext": { return new CSParser.Collection_initializerContext(parent, invokingState); }
                case "Member_initializer_listContext": { return new CSParser.Member_initializer_listContext(parent, invokingState); }
                case "Member_initializerContext": { return new CSParser.Member_initializerContext(parent, invokingState); }
                case "Initializer_valueContext": { return new CSParser.Initializer_valueContext(parent, invokingState); }
                case "Element_initializerContext": { return new CSParser.Element_initializerContext(parent, invokingState); }
                case "Member_declarator_listContext": { return new CSParser.Member_declarator_listContext(parent, invokingState); }
                case "Member_declaratorContext": { return new CSParser.Member_declaratorContext(parent, invokingState); }
                case "Generic_dimension_specifierContext": { return new CSParser.Generic_dimension_specifierContext(parent, invokingState); }
                case "Anonymous_function_signatureContext": { return new CSParser.Anonymous_function_signatureContext(parent, invokingState); }
                case "Right_arrowContext": { return new CSParser.Right_arrowContext(parent, invokingState); }
                case "Anonymous_function_bodyContext": { return new CSParser.Anonymous_function_bodyContext(parent, invokingState); }
                case "Implicit_anonymous_function_parameter_listContext": { return new CSParser.Implicit_anonymous_function_parameter_listContext(parent, invokingState); }
                case "Explicit_anonymous_function_parameterContext": { return new CSParser.Explicit_anonymous_function_parameterContext(parent, invokingState); }
                case "From_clauseContext": { return new CSParser.From_clauseContext(parent, invokingState); }
                case "Query_bodyContext": { return new CSParser.Query_bodyContext(parent, invokingState); }
                case "Select_or_group_clauseContext": { return new CSParser.Select_or_group_clauseContext(parent, invokingState); }
                case "Query_body_clauseContext": { return new CSParser.Query_body_clauseContext(parent, invokingState); }
                case "Query_continuationContext": { return new CSParser.Query_continuationContext(parent, invokingState); }
                case "Let_clauseContext": { return new CSParser.Let_clauseContext(parent, invokingState); }
                case "Where_clauseContext": { return new CSParser.Where_clauseContext(parent, invokingState); }
                case "Combined_join_clauseContext": { return new CSParser.Combined_join_clauseContext(parent, invokingState); }
                case "Orderby_clauseContext": { return new CSParser.Orderby_clauseContext(parent, invokingState); }
                case "OrderingContext": { return new CSParser.OrderingContext(parent, invokingState); }
                case "StatementContext": { return new CSParser.StatementContext(parent, invokingState); }
                case "DeclarationStatementContext": { return new CSParser.DeclarationStatementContext((CSParser.StatementContext)current); }
                case "Local_variable_declarationContext": { return new CSParser.Local_variable_declarationContext(parent, invokingState); }
                case "Local_constant_declarationContext": { return new CSParser.Local_constant_declarationContext(parent, invokingState); }
                case "EmbeddedStatementContext": { return new CSParser.EmbeddedStatementContext((CSParser.StatementContext)current); }
                case "Embedded_statementContext": { return new CSParser.Embedded_statementContext(parent, invokingState); }
                case "LabeledStatementContext": { return new CSParser.LabeledStatementContext((CSParser.StatementContext)current); }
                case "Simple_embedded_statementContext": { return new CSParser.Simple_embedded_statementContext(parent, invokingState); }
                case "EmptyStatementContext": { return new CSParser.EmptyStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "TryStatementContext": { return new CSParser.TryStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "Catch_clausesContext": { return new CSParser.Catch_clausesContext(parent, invokingState); }
                case "Finally_clauseContext": { return new CSParser.Finally_clauseContext(parent, invokingState); }
                case "CheckedStatementContext": { return new CSParser.CheckedStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "ThrowStatementContext": { return new CSParser.ThrowStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "ForeschStatementContext": { return new CSParser.ForeschStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "UnsafeStatementContext": { return new CSParser.UnsafeStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "ForStatementContext": { return new CSParser.ForStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "For_initializerContext": { return new CSParser.For_initializerContext(parent, invokingState); }
                case "For_iteratorContext": { return new CSParser.For_iteratorContext(parent, invokingState); }
                case "BreakStatementContext": { return new CSParser.BreakStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "IfStatementContext": { return new CSParser.IfStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "If_bodyContext": { return new CSParser.If_bodyContext(parent, invokingState); }
                case "ReturnStatementContext": { return new CSParser.ReturnStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "GotoStatementContext": { return new CSParser.GotoStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "SwitchStatementContext": { return new CSParser.SwitchStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "Switch_sectionContext": { return new CSParser.Switch_sectionContext(parent, invokingState); }
                case "FixedStatementContext": { return new CSParser.FixedStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "Pointer_typeContext": { return new CSParser.Pointer_typeContext(parent, invokingState); }
                case "Fixed_pointer_declaratorsContext": { return new CSParser.Fixed_pointer_declaratorsContext(parent, invokingState); }
                case "WhileStatementContext": { return new CSParser.WhileStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "DoStatementContext": { return new CSParser.DoStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "UncheckedStatementContext": { return new CSParser.UncheckedStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "ExpressionStatementContext": { return new CSParser.ExpressionStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "ContinueStatementContext": { return new CSParser.ContinueStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "UsingStatementContext": { return new CSParser.UsingStatementContext((CSParser.Simple_embedded_statementContext)current); }
                case "Resource_acquisitionContext": { return new CSParser.Resource_acquisitionContext(parent, invokingState); }
                case "LockStatementContext": { return new CSParser.LockStatementContext((CSParser.Simple_embedded_statementContext)parent); }
                case "YieldStatementContext": { return new CSParser.YieldStatementContext((CSParser.Simple_embedded_statementContext)parent); }
                case "Statement_listContext": { return new CSParser.Statement_listContext(parent, invokingState); }
                case "Local_variable_declaratorContext": { return new CSParser.Local_variable_declaratorContext(parent, invokingState); }
                case "Local_variable_initializerContext": { return new CSParser.Local_variable_initializerContext(parent, invokingState); }
                case "Local_variable_initializer_unsafeContext": { return new CSParser.Local_variable_initializer_unsafeContext(parent, invokingState); }
                case "Constant_declaratorsContext": { return new CSParser.Constant_declaratorsContext(parent, invokingState); }
                case "Switch_labelContext": { return new CSParser.Switch_labelContext(parent, invokingState); }
                case "Specific_catch_clauseContext": { return new CSParser.Specific_catch_clauseContext(parent, invokingState); }
                case "General_catch_clauseContext": { return new CSParser.General_catch_clauseContext(parent, invokingState); }
                case "Exception_filterContext": { return new CSParser.Exception_filterContext(parent, invokingState); }
                case "Namespace_declarationContext": { return new CSParser.Namespace_declarationContext(parent, invokingState); }
                case "Qualified_identifierContext": { return new CSParser.Qualified_identifierContext(parent, invokingState); }
                case "Namespace_bodyContext": { return new CSParser.Namespace_bodyContext(parent, invokingState); }
                case "Extern_alias_directiveContext": { return new CSParser.Extern_alias_directiveContext(parent, invokingState); }
                case "Using_directiveContext": { return new CSParser.Using_directiveContext(parent, invokingState); }
                case "UsingAliasDirectiveContext": { return new CSParser.UsingAliasDirectiveContext((CSParser.Using_directiveContext)current); }
                case "UsingNamespaceDirectiveContext": { return new CSParser.UsingNamespaceDirectiveContext((CSParser.Using_directiveContext)current); }
                case "UsingStaticDirectiveContext": { return new CSParser.UsingStaticDirectiveContext((CSParser.Using_directiveContext)current); }
                case "Namespace_member_declarationContext": { return new CSParser.Namespace_member_declarationContext(parent, invokingState); }
                case "Type_declarationContext": { return new CSParser.Type_declarationContext(parent, invokingState); }
                case "Class_definitionContext": { return new CSParser.Class_definitionContext(parent, invokingState); }
                case "Struct_definitionContext": { return new CSParser.Struct_definitionContext(parent, invokingState); }
                case "Interface_definitionContext": { return new CSParser.Interface_definitionContext(parent, invokingState); }
                case "Enum_definitionContext": { return new CSParser.Enum_definitionContext(parent, invokingState); }
                case "Delegate_definitionContext": { return new CSParser.Delegate_definitionContext(parent, invokingState); }
                case "AttributesContext": { return new CSParser.AttributesContext(parent, invokingState); }
                case "All_member_modifiersContext": { return new CSParser.All_member_modifiersContext(parent, invokingState); }
                case "Type_parameter_listContext": { return new CSParser.Type_parameter_listContext(parent, invokingState); }
                case "Type_parameterContext": { return new CSParser.Type_parameterContext(parent, invokingState); }
                case "Class_baseContext": { return new CSParser.Class_baseContext(parent, invokingState); }
                case "Interface_type_listContext": { return new CSParser.Interface_type_listContext(parent, invokingState); }
                case "Type_parameter_constraints_clausesContext": { return new CSParser.Type_parameter_constraints_clausesContext(parent, invokingState); }
                case "Type_parameter_constraints_clauseContext": { return new CSParser.Type_parameter_constraints_clauseContext(parent, invokingState); }
                case "Type_parameter_constraintsContext": { return new CSParser.Type_parameter_constraintsContext(parent, invokingState); }
                case "Constructor_constraintContext": { return new CSParser.Constructor_constraintContext(parent, invokingState); }
                case "Primary_constraintContext": { return new CSParser.Primary_constraintContext(parent, invokingState); }
                case "Secondary_constraintsContext": { return new CSParser.Secondary_constraintsContext(parent, invokingState); }
                case "Class_bodyContext": { return new CSParser.Class_bodyContext(parent, invokingState); }
                case "Class_member_declarationsContext": { return new CSParser.Class_member_declarationsContext(parent, invokingState); }
                case "Class_member_declarationContext": { return new CSParser.Class_member_declarationContext(parent, invokingState); }
                case "Common_member_declarationContext": { return new CSParser.Common_member_declarationContext(parent, invokingState); }
                case "Destructor_definitionContext": { return new CSParser.Destructor_definitionContext(parent, invokingState); }
                case "All_member_modifierContext": { return new CSParser.All_member_modifierContext(parent, invokingState); }
                case "Constant_declarationContext": { return new CSParser.Constant_declarationContext(parent, invokingState); }
                case "Typed_member_declarationContext": { return new CSParser.Typed_member_declarationContext(parent, invokingState); }
                case "Event_declarationContext": { return new CSParser.Event_declarationContext(parent, invokingState); }
                case "Conversion_operator_declaratorContext": { return new CSParser.Conversion_operator_declaratorContext(parent, invokingState); }
                case "BodyContext": { return new CSParser.BodyContext(parent, invokingState); }
                case "Constructor_declarationContext": { return new CSParser.Constructor_declarationContext(parent, invokingState); }
                case "Method_declarationContext": { return new CSParser.Method_declarationContext(parent, invokingState); }
                case "Indexer_declarationContext": { return new CSParser.Indexer_declarationContext(parent, invokingState); }
                case "Property_declarationContext": { return new CSParser.Property_declarationContext(parent, invokingState); }
                case "Operator_declarationContext": { return new CSParser.Operator_declarationContext(parent, invokingState); }
                case "Field_declarationContext": { return new CSParser.Field_declarationContext(parent, invokingState); }
                case "Constant_declaratorContext": { return new CSParser.Constant_declaratorContext(parent, invokingState); }
                case "Variable_declaratorsContext": { return new CSParser.Variable_declaratorsContext(parent, invokingState); }
                case "Variable_declaratorContext": { return new CSParser.Variable_declaratorContext(parent, invokingState); }
                case "Variable_initializerContext": { return new CSParser.Variable_initializerContext(parent, invokingState); }
                case "Return_typeContext": { return new CSParser.Return_typeContext(parent, invokingState); }
                case "Member_nameContext": { return new CSParser.Member_nameContext(parent, invokingState); }
                case "Method_bodyContext": { return new CSParser.Method_bodyContext(parent, invokingState); }
                case "Formal_parameter_listContext": { return new CSParser.Formal_parameter_listContext(parent, invokingState); }
                case "Parameter_arrayContext": { return new CSParser.Parameter_arrayContext(parent, invokingState); }
                case "Fixed_parametersContext": { return new CSParser.Fixed_parametersContext(parent, invokingState); }
                case "Fixed_parameterContext": { return new CSParser.Fixed_parameterContext(parent, invokingState); }
                case "Arg_declarationContext": { return new CSParser.Arg_declarationContext(parent, invokingState); }
                case "Parameter_modifierContext": { return new CSParser.Parameter_modifierContext(parent, invokingState); }
                case "Array_typeContext": { return new CSParser.Array_typeContext(parent, invokingState); }
                case "Accessor_declarationsContext": { return new CSParser.Accessor_declarationsContext(parent, invokingState); }
                case "Accessor_modifierContext": { return new CSParser.Accessor_modifierContext(parent, invokingState); }
                case "Accessor_bodyContext": { return new CSParser.Accessor_bodyContext(parent, invokingState); }
                case "Set_accessor_declarationContext": { return new CSParser.Set_accessor_declarationContext(parent, invokingState); }
                case "Get_accessor_declarationContext": { return new CSParser.Get_accessor_declarationContext(parent, invokingState); }
                case "Event_accessor_declarationsContext": { return new CSParser.Event_accessor_declarationsContext(parent, invokingState); }
                case "Remove_accessor_declarationContext": { return new CSParser.Remove_accessor_declarationContext(parent, invokingState); }
                case "Add_accessor_declarationContext": { return new CSParser.Add_accessor_declarationContext(parent, invokingState); }
                case "Overloadable_operatorContext": { return new CSParser.Overloadable_operatorContext(parent, invokingState); }
                case "Constructor_initializerContext": { return new CSParser.Constructor_initializerContext(parent, invokingState); }
                case "Struct_interfacesContext": { return new CSParser.Struct_interfacesContext(parent, invokingState); }
                case "Struct_bodyContext": { return new CSParser.Struct_bodyContext(parent, invokingState); }
                case "Struct_member_declarationContext": { return new CSParser.Struct_member_declarationContext(parent, invokingState); }
                case "Fixed_size_buffer_declaratorContext": { return new CSParser.Fixed_size_buffer_declaratorContext(parent, invokingState); }
                case "Variant_type_parameter_listContext": { return new CSParser.Variant_type_parameter_listContext(parent, invokingState); }
                case "Variant_type_parameterContext": { return new CSParser.Variant_type_parameterContext(parent, invokingState); }
                case "Variance_annotationContext": { return new CSParser.Variance_annotationContext(parent, invokingState); }
                case "Interface_baseContext": { return new CSParser.Interface_baseContext(parent, invokingState); }
                case "Interface_bodyContext": { return new CSParser.Interface_bodyContext(parent, invokingState); }
                case "Interface_member_declarationContext": { return new CSParser.Interface_member_declarationContext(parent, invokingState); }
                case "Interface_accessorsContext": { return new CSParser.Interface_accessorsContext(parent, invokingState); }
                case "Enum_baseContext": { return new CSParser.Enum_baseContext(parent, invokingState); }
                case "Enum_bodyContext": { return new CSParser.Enum_bodyContext(parent, invokingState); }
                case "Enum_member_declarationContext": { return new CSParser.Enum_member_declarationContext(parent, invokingState); }
                case "Global_attribute_targetContext": { return new CSParser.Global_attribute_targetContext(parent, invokingState); }
                case "Attribute_listContext": { return new CSParser.Attribute_listContext(parent, invokingState); }
                case "KeywordContext": { return new CSParser.KeywordContext(parent, invokingState); }
                case "Attribute_sectionContext": { return new CSParser.Attribute_sectionContext(parent, invokingState); }
                case "Attribute_targetContext": { return new CSParser.Attribute_targetContext(parent, invokingState); }
                case "AttributeContext": { return new CSParser.AttributeContext(parent, invokingState); }
                case "Attribute_argumentContext": { return new CSParser.Attribute_argumentContext(parent, invokingState); }
                case "Fixed_pointer_declaratorContext": { return new CSParser.Fixed_pointer_declaratorContext(parent, invokingState); }
                case "Fixed_pointer_initializerContext": { return new CSParser.Fixed_pointer_initializerContext(parent, invokingState); }
                case "Boolean_literalContext": { return new CSParser.Boolean_literalContext(parent, invokingState); }
                case "String_literalContext": { return new CSParser.String_literalContext(parent, invokingState); }
                case "Interpolated_regular_stringContext": { return new CSParser.Interpolated_regular_stringContext(parent, invokingState); }
                case "Interpolated_verbatium_stringContext": { return new CSParser.Interpolated_verbatium_stringContext(parent, invokingState); }
                case "Interpolated_regular_string_partContext": { return new CSParser.Interpolated_regular_string_partContext(parent, invokingState); }
                case "Interpolated_verbatium_string_partContext": { return new CSParser.Interpolated_verbatium_string_partContext(parent, invokingState); }
                case "Interpolated_string_expressionContext": { return new CSParser.Interpolated_string_expressionContext(parent, invokingState); }
                case "Method_member_nameContext": { return new CSParser.Method_member_nameContext(parent, invokingState); }
                default: return null;
            }
            #endregion
        }
    }
}
