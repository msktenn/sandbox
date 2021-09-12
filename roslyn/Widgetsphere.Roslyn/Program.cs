using System;
using System.Linq;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace roslyn
{
    class Program
    {
        static readonly string restrikeFolder = "/Users/dad/code/app.restrike.io/src/";

        public static SemanticModel model;

        static void Main(string[] args)
        {


            var code = File.ReadAllText(restrikeFolder + "Restrike.RestAPI/Controllers/AdministrationController.cs");
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = syntaxTree.GetRoot() as CompilationUnitSyntax;
            // Getting the semantic model (for MSCORELIB)
            var compilation = CSharpCompilation.Create("AdminController")
                              .AddReferences(
                                 MetadataReference.CreateFromFile(
                                   typeof(object).Assembly.Location))
                              .AddSyntaxTrees(syntaxTree);
            model = compilation.GetSemanticModel(syntaxTree);

            var walker = new ClassMethodWalker();
            walker.Visit(root);

        }
    }

    public class CustomWalker : CSharpSyntaxWalker
    {
        static int Tabs = 0;
        public override void Visit(SyntaxNode node)
        {
            Tabs++;
            var indents = new String('\t', Tabs);
            Console.WriteLine(indents + node.Kind());
            base.Visit(node);
            Tabs--;
        }
    }

    public class DeeperWalker : CSharpSyntaxWalker
    {
        static int Tabs = 0;
        //NOTE: Make sure you invoke the base constructor with 
        //the correct SyntaxWalkerDepth. Otherwise VisitToken()
        //will never get run.
        public DeeperWalker() : base(SyntaxWalkerDepth.Token)
        {
        }
        public override void Visit(SyntaxNode node)
        {
            Tabs++;
            var indents = new String('\t', Tabs);
            Console.WriteLine(indents + node.Kind());
            base.Visit(node);
            Tabs--;
        }

        public override void VisitToken(SyntaxToken token)
        {
            var indents = new String('\t', Tabs);
            Console.WriteLine(indents + token);
            base.VisitToken(token);
        }
    }

    public class ClassMethodWalker : CSharpSyntaxWalker
    {
        public ClassMethodWalker() : base(SyntaxWalkerDepth.Token)
        {
        }

        string className = String.Empty;
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            className = node.Identifier.ToString();
            var myclassSymbol = Program.model.GetDeclaredSymbol(node);

            base.VisitClassDeclaration(node);
            //var walker = new DeeperWalker();
            //walker.Visit(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            string methodName = node.Identifier.ToString();
            Console.WriteLine(className + '.' + methodName);
            base.VisitMethodDeclaration(node);
        }

        public override void VisitAttribute(AttributeSyntax node)
        {
            try
            {
                Console.WriteLine(node.Name);
                var myTypeInfo = Program.model.GetDeclaredSymbol(node);
                base.VisitAttribute(node);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public override void VisitToken(SyntaxToken token)
        {
            //Console.WriteLine(token);
            base.VisitToken(token);
        }
    }
}

