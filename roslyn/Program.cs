using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;

namespace roslyn
{
    class Program
    {
        static void Main(string[] args)
        {
           var syntaxTree = CSharpSyntaxTree.ParseText(
            @"using System;
            using System.Collections;
            using System.Linq;
            using System.Text;

            namespace HelloWorldApplication
            {
            class Program
            {
            static void Main(string[] args)
            {
            Console.WriteLine(""Hello World"");
            }
            }
            }");

            var root = syntaxTree.GetRoot() as CompilationUnitSyntax;

            var namespaceSyntax = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>().First();
                    
            var programClassSyntax = namespaceSyntax.Members.OfType<ClassDeclarationSyntax>().First();

            var mainMethodSyntax = programClassSyntax.Members.OfType<MethodDeclarationSyntax>().First();

            Console.WriteLine(mainMethodSyntax.ToString());

            Console.ReadKey();
        }
    }
}

