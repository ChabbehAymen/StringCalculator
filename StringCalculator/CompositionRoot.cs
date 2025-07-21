namespace StringCalculator;

public static class CompositionRoot
{
    public static StringCalculator ComposeProgram()
    {
        var extractor = new RegexExtractor();
        var splitter = new NumbersSplitter(extractor);
        var delimiterExtractor = new DelimiterExtractor(extractor);
        var numbersPreparer = new NumbersPreparer(splitter, delimiterExtractor);
        var calculator = new StringCalculator(numbersPreparer);
        return calculator;
    }
}