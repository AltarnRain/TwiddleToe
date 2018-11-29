// <copyright file="StateCreator.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.StateDefinition
{
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Linq;
    using TwiddleToe.Foundation.StateDefinition;
    using TwiddleToe.Utilities.Helpers;

    /// <summary>
    /// Builds the state.cs file
    /// </summary>
    public class StateCreator
    {
        private const string Namespace = "TwiddleToe.State";

        /// <summary>
        /// The state definition
        /// </summary>
        private readonly StoredState stateDefinition;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCreator"/> class.
        /// </summary>
        /// <param name="stateFile">The state file.</param>
        public StateCreator(string stateFile)
        {
            this.stateDefinition = XmlHelper.Deserialize<StoredState>(stateFile);
        }

        /// <summary>
        /// Builds the state.
        /// </summary>
        /// <param name="stateCsFile">The state cs file.</param>
        public void BuildState(string stateCsFile)
        {
            var unit = new CodeCompileUnit();
            var stateNamespace = new CodeNamespace(Namespace);

            unit.Namespaces.Add(stateNamespace);
            var stateClass = NewClass("State");
            stateClass.Comments.Add(DocumentComment("The state class"));
            stateNamespace.Types.Add(stateClass);

            foreach (var table in this.stateDefinition.Tables)
            {
                var tableClass = NewClass(table.Name);
                tableClass.Comments.Add(DocumentComment($"The {table.Name} class"));
                stateClass.Members.Add(tableClass);

                foreach (var column in table.Columns)
                {
                    var (property, field) = GeneratePropertyCode(column.Name, column.Type);

                    tableClass.Members.Add(field);
                    tableClass.Members.Add(property);
                }
            }

            using (var sourceWriter = new StreamWriter(stateCsFile))
            {
                var options = new CodeGeneratorOptions();

                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sourceWriter, options);
                }
            }
        }

        /// <summary>
        /// Generates a comment in document format
        /// </summary>
        /// <param name="coment">The coment.</param>
        /// <returns>A CodeCommentStatement</returns>
        private static CodeCommentStatement DocumentComment(string coment)
        {
            return new CodeCommentStatement(new CodeComment(coment, true));
        }

        private static (CodeMemberProperty property, CodeMemberField field) GeneratePropertyCode(string name, StateTypes type)
        {
            var field = NewField(name, type);
            var property = NewProperty(name, type);

            property.HasGet = true;
            property.HasSet = true;
            property.Comments.Add(DocumentComment($"Gets or Sets the {property.Name}"));

            property.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name)));

            property.SetStatements.Add(
                new CodeAssignStatement(
                    new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), field.Name),
                        new CodePropertySetValueReferenceExpression()));

            return (property, field);
        }

        /// <summary>
        /// News the field.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="access">The access.</param>
        /// <returns>
        /// A private field
        /// </returns>
        private static CodeMemberField NewField(string name, StateTypes type, MemberAttributes access = MemberAttributes.Private)
        {
            var fieldName = string.Concat(name.Select((c, i) => i == 0 ? char.ToLower(c) : c));
            var fieldType = GetTypeReference(type);
            var field = new CodeMemberField(fieldType, fieldName)
            {
                Attributes = access
            };

            return field;
        }

        /// <summary>
        /// Gets the type reference.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A CodeTypeReference</returns>
        private static CodeTypeReference GetTypeReference(StateTypes type)
        {
            CodeTypeReference returnValue = null;
            switch (type)
            {
                case StateTypes.Number:
                    returnValue = new CodeTypeReference(typeof(int));
                    break;
                case StateTypes.Text:
                    returnValue = new CodeTypeReference(typeof(string));
                    break;
            }

            return returnValue;
        }

        /// <summary>
        /// News the property.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The types.</param>
        /// <param name="access">The access.</param>
        /// <returns>
        /// A new property
        /// </returns>
        private static CodeMemberProperty NewProperty(string name, StateTypes type, MemberAttributes access = MemberAttributes.Public)
        {
            var newProperty = new CodeMemberProperty
            {
                Name = name,
                Attributes = access | MemberAttributes.Final,
                Type = GetTypeReference(type)
            };

            return newProperty;
        }

        /// <summary>
        /// Publics the class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="access">The access.</param>
        /// <returns>
        /// A new public class
        /// </returns>
        private static CodeTypeDeclaration NewClass(
            string name,
            MemberAttributes access = MemberAttributes.Public)
        {
            var newClass = new CodeTypeDeclaration(name)
            {
                Attributes = access,
                IsClass = true,
            };

            return newClass;
        }
    }
}
