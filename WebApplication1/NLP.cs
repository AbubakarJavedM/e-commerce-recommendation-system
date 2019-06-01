using System;
using System.IO;
using VaderSharp;

namespace WebApplication1
{

    public class NLP
    {
       
        public int score;
        ///  public string scoreStr;
        public static void init()
        {

            //var jarRoot = @"..\..\..\..\data\paket-files\nlp.stanford.edu\stanford-corenlp-full-2016-10-31\models";
            var jarRoot = @"C:\Users\Abubakar javaid\Downloads\Compressed\stanford-corenlp-full-2017-06-09\stanford-corenlp-full-2017-06-09\";
            var curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);
           // var props = new MySql.Data.MySqlClient.Properties();
            //   var curDir = Environment.CurrentDirectory;
            //   Directory.SetCurrentDirectory(jarRoot);


            //            Directory.SetCurrentDirectory(curDir);
            //pipeline = new StanfordCoreNLP(props);
        }
        public static double computeSentiment(string text)
        {
            SentimentIntensityAnalyzer s = new SentimentIntensityAnalyzer();
            SentimentAnalysisResults k = new SentimentAnalysisResults();
            k = s.PolarityScores(text);
            double res = k.Compound;
            return res = Math.Abs(res / 0.4) * 5;


        }
    }
}
