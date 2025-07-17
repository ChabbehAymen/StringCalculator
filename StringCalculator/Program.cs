// kata link: https://static1.squarespace.com/static/5c741968bfba3e13975e33a6/t/5ca6614d971a1877cadc4f8a/1554407757512/String+Calculator+Kata+v1.pdf

using StringCalculator;

var program = CompositionRoot.ComposeProgram();
//program.SplitWith(',').Add("1,2", StringCalculatorOptions.NoDelimiter);
//program
//    .SplitWith('\n')
//    .SplitWith(',')
//    .Add("1\n2,3", StringCalculatorOptions.NoDelimiter);

program.Add("//;\n1002;2", DelimiterSpecificationFactory.SingleDelimiterExpression);
